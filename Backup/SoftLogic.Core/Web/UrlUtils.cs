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
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Web;

namespace SoftLogik.Web
{
  public static class UrlUtils
  {
    public static string GetSchemeHostPort(Uri uri)
    {
      if (uri == null)
        throw new ArgumentNullException("uri");

      return uri.Scheme + "://" + uri.Host + ":" + uri.Port + "/";
    }

    /// <summary>
    /// Converts the speicified NameValueCollection to query string text.
    /// </summary>
    /// <param name="nameValues">The NameValueCollection to convert.</param>
    /// <returns></returns>
    public static string ToQueryString(NameValueCollection nameValues)
    {
      return ToQueryString(nameValues, false);
    }

    /// <summary>
    /// Converts the speicified NameValueCollection to query string text.
    /// </summary>
    /// <param name="nameValues">The NameValueCollection to convert.</param>
    /// <param name="encodeValues">if set to <c>true</c> the values are encoded.</param>
    /// <returns></returns>
    public static string ToQueryString(NameValueCollection nameValues, bool encodeValues)
    {
      if (nameValues == null)
        throw new ArgumentNullException("nameValues");

      StringBuilder sb = new StringBuilder();

      foreach (string variableKey in nameValues.AllKeys)
      {
        string value = nameValues[variableKey];

        if (value != null)
        {
          sb.Append(variableKey);
          sb.Append("=");
          sb.Append((encodeValues) ? HttpUtility.UrlEncode(value) : value);
          sb.Append("&");
        }
      }

      // remove trailing &
      if (sb.Length > 0)
        sb.Length = sb.Length - 1;

      return sb.ToString();
    }

    /// <summary>
    /// Converts the speicified querystring to a NameValueCollection.
    /// </summary>
    /// <param name="queryString">The querystring to convert to a NameValueCollection.</param>
    /// <returns></returns>
    public static NameValueCollection FromQueryString(string queryString)
    {
      return FromQueryString(queryString, false);
    }

    /// <summary>
    /// Converts the speicified querystring to a NameValueCollection.
    /// </summary>
    /// <param name="queryString">The querystring to convert to a NameValueCollection.</param>
    /// <param name="decodeValues">if set to <c>true</c> the values are decoded.</param>
    /// <returns></returns>
    public static NameValueCollection FromQueryString(string queryString, bool decodeValues)
    {
      NameValueCollection nameValues = new NameValueCollection();

      if (queryString == null)
        throw new ArgumentNullException("querystring");

      // split querystring up into fragments
      string[] array = queryString.Split(new char[] { '&', '=' });

      // add to namevaluecollection
      for (int i = 0; i < array.Length - 1; i += 2)
      {
        string name = array[i];
        string value = array[i + 1];

        nameValues.Add(name, (decodeValues) ? HttpUtility.UrlDecode(value) : value);
      }

      return nameValues;
    }

    public static string UrlEncodeBase64(string base64Data)
    {
      return new string(UrlEncodeBase64(base64Data.ToCharArray()));
    }

    public static char[] UrlEncodeBase64(char[] base64Data)
    {
      for (int i = 0; i < base64Data.Length; i++)
      {
        switch (base64Data[i])
        {
          case '+':
            base64Data[i] = '@';
            break;
          case '/':
            base64Data[i] = '$';
            break;
        }
      }
      return base64Data;
    }

    public static string UrlDecodeBase64(string base64Data)
    {
      return new string(UrlDecodeBase64(base64Data.ToCharArray()));
    }

    public static char[] UrlDecodeBase64(char[] base64Data)
    {
      for (int i = 0; i < base64Data.Length; i++)
      {
        switch (base64Data[i])
        {
          case '@':
            base64Data[i] = '+';
            break;
          case '$':
            base64Data[i] = '/';
            break;
        }
      }
      return base64Data;
    }

    public static bool IsRelativeUrl(string virtualPath)
    {
      if (virtualPath.IndexOf(":") != -1)
        return false;

      return !IsRooted(virtualPath);
    }

    public static bool IsRooted(string basepath)
    {
      if (!string.IsNullOrEmpty(basepath) && (basepath[0] != '/'))
        return (basepath[0] == '\\');

      return true;
    }
  }
}
