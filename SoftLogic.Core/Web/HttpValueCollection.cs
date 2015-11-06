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
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace SoftLogik.Web
{
  [Serializable]
  public class HttpValueCollection : NameValueCollection
  {
    public HttpValueCollection()
      : base(StringComparer.OrdinalIgnoreCase)
    {
    }

    public HttpValueCollection(int capacity)
      : base(capacity, StringComparer.OrdinalIgnoreCase)
    {
    }

    public HttpValueCollection(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public HttpValueCollection(string str)
      : this(str, false, false, Encoding.UTF8)
    {
    }

    public HttpValueCollection(string str, bool urlencoded, Encoding encoding)
      : this(str, false, urlencoded, encoding)
    {
    }

    public HttpValueCollection(string str, bool readOnly, bool urlencoded, Encoding encoding)
      : base(StringComparer.OrdinalIgnoreCase)
    {
      if (!string.IsNullOrEmpty(str))
        FillFromString(str, urlencoded, encoding);

      IsReadOnly = readOnly;
    }

    internal void Add(HttpCookieCollection c)
    {
      int num1 = c.Count;
      for (int num2 = 0; num2 < num1; num2++)
      {
        HttpCookie cookie1 = c.Get(num2);
        base.Add(cookie1.Name, cookie1.Value);
      }
    }

    internal void FillFromEncodedBytes(byte[] bytes, Encoding encoding)
    {
      int num1 = (bytes != null) ? bytes.Length : 0;
      for (int num2 = 0; num2 < num1; num2++)
      {
        string text1;
        string text2;
        int num3 = num2;
        int num4 = -1;
        while (num2 < num1)
        {
          switch (bytes[num2])
          {
            case 0x3d:
              if (num4 < 0)
              {
                num4 = num2;
              }
              break;
          }
          num2++;
        }
        if (num4 >= 0)
        {
          text1 = HttpUtility.UrlDecode(bytes, num3, num4 - num3, encoding);
          text2 = HttpUtility.UrlDecode(bytes, num4 + 1, (num2 - num4) - 1, encoding);
        }
        else
        {
          text1 = null;
          text2 = HttpUtility.UrlDecode(bytes, num3, num2 - num3, encoding);
        }
        base.Add(text1, text2);
        if ((num2 == (num1 - 1)) && (bytes[num2] == 0x26))
        {
          base.Add(null, string.Empty);
        }
      }
    }

    public void FillFromString(string s)
    {
      FillFromString(s, false, null);
    }

    public void FillFromString(string s, bool urlEncoded, Encoding encoding)
    {
      if (string.IsNullOrEmpty(s))
        return;

      for (int i = 0; i < s.Length; i++)
      {
        int ampIndex = i;
        int equalsIndex = -1;
        while (i < s.Length)
        {
          if (s[i] == '=')
          {
            if (equalsIndex < 0)
              equalsIndex = i;
          }
          else if (s[i] == '&')
          {
            break;
          }
          i++;
        }
        string name = null;
        string value = null;
        if (equalsIndex >= 0)
        {
          name = s.Substring(ampIndex, equalsIndex - ampIndex);
          value = s.Substring(equalsIndex + 1, (i - equalsIndex) - 1);
        }
        else
        {
          value = s.Substring(ampIndex, i - ampIndex);
        }

        if (urlEncoded)
          base.Add(HttpUtility.UrlDecode(name, encoding), HttpUtility.UrlDecode(value, encoding));
        else
          base.Add(name, value);

        if (i == (s.Length - 1) && s[i] == '&')
        {
          base.Add(null, string.Empty);
        }
      }
    }

    internal void MakeReadOnly()
    {
      base.IsReadOnly = true;
    }

    internal void MakeReadWrite()
    {
      base.IsReadOnly = false;
    }

    internal void Reset()
    {
      base.Clear();
    }

    public override string ToString()
    {
      return ToString(true);
    }

    public virtual string ToString(bool urlencoded)
    {
      return ToString(urlencoded, null);
    }

    public virtual string ToString(bool urlEncoded, IDictionary excludeKeys)
    {
      if (Count == 0)
        return string.Empty;

      StringBuilder sb = new StringBuilder();
      bool excludeContainsViewState = (excludeKeys != null) && (excludeKeys["__VIEWSTATE"] != null);
      for (int i = 0; i < Count; i++)
      {
        string key = GetKey(i);
        if ((!excludeContainsViewState || key == null || !key.StartsWith("__VIEWSTATE", StringComparison.Ordinal)) && (excludeKeys == null || key == null || excludeKeys[key] == null))
        {
          if (urlEncoded)
            key = HttpUtility.UrlEncodeUnicode(key);

          key = !string.IsNullOrEmpty(key) ? (key + "=") : string.Empty;

          ArrayList keyValues = (ArrayList)base.BaseGet(i);

          if (sb.Length > 0)
            sb.Append('&');

          int valuesCount = (keyValues != null) ? keyValues.Count : 0;

          if (valuesCount == 1)
          {
            sb.Append(key);
            string value = (string)keyValues[0];

            if (urlEncoded)
              value = HttpUtility.UrlEncodeUnicode(value);

            sb.Append(value);
          }
          else if (valuesCount == 0)
          {
            sb.Append(key);
          }
          else
          {
            for (int j = 0; j < valuesCount; j++)
            {
              if (j > 0)
                sb.Append('&');

              sb.Append(key);
              string value = (string)keyValues[j];

              if (urlEncoded)
                value = HttpUtility.UrlEncodeUnicode(value);

              sb.Append(value);
            }
          }
        }
      }
      return sb.ToString();
    }
  }
}