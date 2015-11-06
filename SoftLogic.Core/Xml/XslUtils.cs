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

using System.Collections.Generic;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.XPath;

namespace SoftLogik.Xml
{
  public static class XslUtils
  {
    public static XmlTextReader GetTemplateFromCache(string xslTemplatePath, string templateName)
    {
      string filePath = xslTemplatePath + templateName;
      StringReader sr = new StringReader(File.ReadAllText(filePath));

      return new XmlTextReader(sr);
    }

    public static void TransformNode(XmlNode element, XmlReader xslTemplate)
    {
      XmlReader reader = new XmlNodeReader(element);

      XmlReader transformResultReader = TransformXml(reader, xslTemplate, null);
      element.CreateNavigator().ReplaceSelf(transformResultReader);
    }

    //public static void TransformNavigable(IXPathNavigable navigable, XmlReader xslTemplate)
    //{
    //  XPathNavigator navigator = navigable.CreateNavigator();

    //  XmlReader transformResultReader = TransformXml(navigator, xslTemplate, null);
    //  navigator.ReplaceSelf(transformResultReader);
    //}

    public static XmlReader TransformXml(XmlReader xml, XmlReader xsl)
    {
      XPathNavigator navigator = new XPathDocument(xml).CreateNavigator();
      return TransformXml(navigator, xsl, null);
    }

    public static XmlReader TransformXml(XmlReader xml, XmlReader xsl, XsltArgumentList args, XmlResolver resolver)
    {
      XPathNavigator navigator = new XPathDocument(xml).CreateNavigator();
      return TransformXml(navigator, xsl, args, resolver);
    }

    public static XmlReader TransformXml(XmlReader xml, XmlReader xsl, XsltArgumentList args)
    {
      XPathNavigator navigator = new XPathDocument(xml).CreateNavigator();
      return TransformXml(navigator, xsl, args);
    }

    public static XmlReader TransformXml(XPathNavigator xmlXPathDocument, XmlReader xsl, XsltArgumentList args)
    {
      return TransformXml(xmlXPathDocument, xsl, args, new XmlUrlResolver());
    }

    public static XmlReader TransformXml(XPathNavigator xmlXPathDocument, XmlReader xsl, XsltArgumentList args, XmlResolver resolver)
    {
      XslCompiledTransform transform = new XslCompiledTransform();
      transform.Load(xsl, XsltSettings.Default, resolver);
      MemoryStream ms = new MemoryStream();
      string xml = xmlXPathDocument.OuterXml;
      XmlReader reader = XmlReader.Create(new StringReader(xml));
      transform.Transform(reader, args, ms);
      ms.Seek(0, SeekOrigin.Begin);

      return XmlReader.Create(ms);
    }

    public static XmlReader TransformXml(XmlReader xslTemplate, IDictionary<string, object> parameters)
    {
      return TransformXml(xslTemplate, ToXsltArgumentList(parameters));
    }

    public static XmlReader TransformXml(XmlReader xslTemplate, XsltArgumentList args)
    {
      return TransformXml(XPathUtils.EmptyXPathDocument.CreateNavigator(), xslTemplate, args);
    }

    public static XmlReader TransformXml(string xslTemplatePath, XsltArgumentList args)
    {
      using (XmlReader xmlReader = XmlReader.Create(xslTemplatePath))
      {
        return TransformXml(xmlReader, args);
      }
    }

    public static XsltArgumentList ToXsltArgumentList(IDictionary<string, object> parameters)
    {
      XsltArgumentList args = new XsltArgumentList();
      if (parameters != null)
      {
        foreach (KeyValuePair<string, object> nameValue in parameters)
        {
          args.AddParam(nameValue.Key, string.Empty, nameValue.Value);
        }
      }

      return args;
    }
  }
}