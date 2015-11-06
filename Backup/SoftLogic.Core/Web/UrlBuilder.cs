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
using System.Web;
using System.Collections.Specialized;
using System.Text;

namespace SoftLogik.Web
{
  public class UrlBuilder
  {
    private string _path;
    private string _target;
    private HttpValueCollection _queryString;

    public HttpValueCollection QueryString
    {
      get
      {
        if (_queryString == null)
          _queryString = new HttpValueCollection();

        return _queryString;
      }
    }

    public string Target
    {
      get { return _target; }
      set { _target = value; }
    }

    public string Path
    {
      get { return _path; }
      set { _path = value; }
    }

    public UrlBuilder()
    {
    }

    //public UrlBuilder(string url)
    //{
    //}

    public UrlBuilder(string url)
    {
      if (url == null)
        throw new ArgumentNullException("url");

      int targetStartPosition = url.IndexOf('#');

      // question mark found
      if (targetStartPosition != -1)
      {
        string target = url.Substring(targetStartPosition + 1, url.Length - targetStartPosition - 1);

        _target = HttpUtility.UrlDecode(target);
      }

      int queryStartPosition = url.IndexOf('?');

      // question mark found
      if (queryStartPosition != -1)
      {
        // get querystring and url without querystring
        string queryString = url.Substring(queryStartPosition + 1, url.Length - queryStartPosition - 1);
        url = url.Substring(0, queryStartPosition);

        _queryString = new HttpValueCollection(queryString, true, Encoding.UTF8);
      }

      _path = HttpUtility.UrlDecode(url);
    }

    public override string ToString()
    {
      return ToString(true);
    }

    public string ToString(bool urlEncode)
    {
      StringBuilder sb = new StringBuilder();

      if (urlEncode)
        sb.Append(HttpUtility.UrlEncode(_path));
      else
        sb.Append(_path);

      string queryString = _queryString.ToString(urlEncode);

      if (queryString.Length > 0)
        sb.Append("?");

      sb.Append(queryString);

      if (_target != null)
      {
        sb.Append("#");

        if (urlEncode)
          sb.Append(HttpUtility.UrlEncode(_target));
        else
          sb.Append(_target);
      }

      return sb.ToString();
    }

    public static string ModifyQueryString(string url, string name, string value, bool addIfNotFound)
    {
      UrlBuilder urlHelper = new UrlBuilder(url);

      if (urlHelper.QueryString[name] != null || addIfNotFound)
        urlHelper.QueryString[name] = value;

      return urlHelper.ToString();
    }
  }
}