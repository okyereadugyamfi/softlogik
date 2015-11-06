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
using SoftLogik.Miscellaneous;
using System.Xml.XPath;

namespace SoftLogik.Xml
{
  public static class XPathUtils
  {
    private static readonly XPathDocument _emptyXPathDocument;

    static XPathUtils()
    {
      XmlDocument doc = new XmlDocument();
      doc.AppendChild(doc.CreateElement("DocumentRoot"));

      _emptyXPathDocument = new XPathDocument(new XmlNodeReader(doc));
    }

    public static XPathDocument EmptyXPathDocument
    {
      get { return _emptyXPathDocument; }
    }

    /// <summary>
    /// Gets the text from a selected node.
    /// </summary>
    /// <param name="navigable">The XPath navigable value to select from.</param>
    /// <param name="xpath">The XPath expression to select a text node.</param>
    /// <param name="selectedText">The selected text.</param>
    /// <returns>The text from the selected node.</returns>
    public static bool TrySelectNodeText(IXPathNavigable navigable, string xpath, out string selectedText)
    {
      return MiscellaneousUtils.TryAction<string>(delegate { return SelectNodeText(navigable, xpath); }, out selectedText);
    }

    public static string SelectNodeText(IXPathNavigable navigable, string xpath)
    {
      if (navigable == null)
        throw new ArgumentNullException("navigable");
      if (xpath == null)
        throw new ArgumentNullException("xpath");

      XPathNavigator startNavigator = navigable.CreateNavigator();
      XPathNavigator selectedNodeNavigator = startNavigator.SelectSingleNode(xpath);

      if (selectedNodeNavigator != null)
      {
        if (selectedNodeNavigator.NodeType == XPathNodeType.Text)
          return selectedNodeNavigator.Value;
        else
          throw new XmlException(string.Format("XPath expression '{0}' returned a non-text node.", xpath));
      }
      else
      {
        throw new XmlException(string.Format("XPath expression '{0}' did not return a node.", xpath));
      }
    }

    public static bool TrySelectNodeXml(IXPathNavigable navigable, string xpath, out string selectedXml)
    {
      return MiscellaneousUtils.TryAction<string>(delegate { return SelectNodeXml(navigable, xpath); }, out selectedXml);
    }

    public static string SelectNodeXml(IXPathNavigable navigable, string xpath)
    {
      if (navigable == null)
        throw new ArgumentNullException("navigable");
      if (xpath == null)
        throw new ArgumentNullException("xpath");

      XPathNavigator startNavigator = navigable.CreateNavigator();
      XPathNavigator selectedNavigator = startNavigator.SelectSingleNode(xpath);

      if (selectedNavigator != null)
        return selectedNavigator.InnerXml;
      else
        throw new XmlException(string.Format("XPath expression '{0}' did not return a node.", xpath));
    }
  }
}