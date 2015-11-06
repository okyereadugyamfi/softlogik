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
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace SoftLogik.Collections
{
  [Serializable]
  public sealed class SerializableNameValueCollection : NameValueCollection, IXmlSerializable
  {
    XmlSchema IXmlSerializable.GetSchema()
    {
      return null;
    }

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
      // name start
      reader.Read();

      while (reader.Name == "NameValue")
      {
        string name;
        string value;

        // Name
        reader.Read();
        reader.Read();
        name = reader.Value;
        reader.Read();

        // Value
        reader.Read();
        reader.Read();
        value = reader.Value;
        reader.Read();

        reader.Read();
        reader.Read();

        Add(name, value);
      }

      // name end
      reader.Read();
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
      foreach (string key in Keys)
      {
        writer.WriteStartElement("NameValue");
        writer.WriteElementString("Name", key);
        writer.WriteElementString("Value", this[key]);
        writer.WriteEndElement();
      }
    }
  }
}