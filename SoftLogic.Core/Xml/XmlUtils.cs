#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using SoftLogik.Miscellaneous;

namespace SoftLogik.Xml
{
  public static class XmlUtils
  {
    public static XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
    {
      ValidationUtils.ArgumentNotNull(doc, "doc");
      ValidationUtils.ArgumentNotNullOrEmpty(name, "name");

      XmlAttribute attribute = doc.CreateAttribute(name);
      attribute.Value = value;

      return attribute;
    }

    /// <summary>
    /// Converts the specified collection to an XmlDocument.
    /// </summary>
    /// <param name="collection">The collection.</param>
    /// <param name="rootName">Name of the root element.</param>
    /// <param name="itemName">Name of the item elements.</param>
    /// <param name="propertyConverters">The property converters.</param>
    /// <returns></returns>
    public static XmlDocument ConvertToXml<T>(IEnumerable<T> collection, string rootName, string itemName, Dictionary<string, Converter<T, string>> propertyConverters)
    {
      ValidationUtils.ArgumentNotNull(collection, "collection");
      ValidationUtils.ArgumentNotNull(propertyConverters, "propertyConverters");

      ValidationUtils.ArgumentNotNullOrEmpty(rootName, "rootName");
      ValidationUtils.ArgumentNotNullOrEmpty(itemName, "itemName");

      XmlDocument doc = new XmlDocument();
      XmlElement rootElement = doc.CreateElement(rootName);
      doc.AppendChild(rootElement);

      foreach (T item in collection)
      {
        XmlElement itemElement = doc.CreateElement(itemName);

        foreach (KeyValuePair<string, Converter<T, string>> property in propertyConverters)
        {
          string attributeName = property.Key;
          Converter<T, string> converter = property.Value;

          string value = converter(item);

          itemElement.SetAttribute(attributeName, value);
        }

        rootElement.AppendChild(itemElement);
      }

      return doc;
    }

    public static string ToString(XmlReader reader)
    {
      return IndentXml(reader, "  ");
    }

    public static string IndentXml(string xml, string indentChars)
    {
      ValidationUtils.ArgumentNotNullOrEmpty(xml, "xml");

      using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml)))
      {
        return IndentXml(xmlReader, indentChars);
      }
    }

    public static string IndentXml(XmlNode node, string indentChars)
    {
      ValidationUtils.ArgumentNotNull(node, "node");

      using (XmlNodeReader xmlReader = new XmlNodeReader(node))
      {
        return IndentXml(xmlReader, indentChars);
      }
    }

    public static string IndentXml(XmlReader xmlReader, string indentChars)
    {
      ValidationUtils.ArgumentNotNull(xmlReader, "xmlReader");
      ValidationUtils.ArgumentNotNullOrEmpty(indentChars, "indentChars");

      StringBuilder sb = new StringBuilder();
      StringWriter sw = new StringWriter(sb);

      if (xmlReader.Read())
      {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = indentChars;
        settings.OmitXmlDeclaration = (xmlReader.NodeType != XmlNodeType.XmlDeclaration);

        using (XmlWriter xmlWriter = XmlWriter.Create(sw, settings))
        {
          do
          {
            xmlWriter.WriteNode(xmlReader, false);
          } while (xmlReader.Read());
        }
      }

      return sb.ToString();
    }

    public static bool TryIndentXml(string xml, out string indentedXml)
    {
      return TryIndentXml(xml, "  ", out indentedXml);
    }

    public static bool TryIndentXml(string xml, string indentChars, out string indentedXml)
    {
      return MiscellaneousUtils.TryAction<string>(delegate { return IndentXml(xml, indentChars); }, out indentedXml);
    }

    public static XmlDocument ToXmlDocument(object value)
    {
      ValidationUtils.ArgumentNotNull(value, "value");

      return CreateXmlDocument(delegate(XmlWriter writer)
                               {
                                 XmlSerializer serializer = new XmlSerializer(value.GetType());
                                 serializer.Serialize(writer, value);
                               });
    }

    public static XmlDocument CreateXmlDocument(Action<XmlWriter> action)
    {
      ValidationUtils.ArgumentNotNull(action, "action");

      XmlDocument doc = new XmlDocument();
      using (XmlWriter writer = doc.CreateNavigator().AppendChild())
      {
        action(writer);
      }

      return doc;
    }
  }
}