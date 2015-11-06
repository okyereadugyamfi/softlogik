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
using System.IO;
using System.Net;

namespace SoftLogik.IO
{
  public class WebRequestStreamGetter : IStreamGetter
  {
    private string _proxyUserName;
    private string _proxyPassword;
    private string _proxyDomain;
    private Uri _requestUri;
    private string _userAgent;

    public string ProxyUserName
    {
      get { return _proxyUserName; }
      set { _proxyUserName = value; }
    }

    public string ProxyPassword
    {
      get { return _proxyPassword; }
      set { _proxyPassword = value; }
    }

    public string ProxyDomain
    {
      get { return _proxyDomain; }
      set { _proxyDomain = value; }
    }

    public Uri RequestUri
    {
      get { return _requestUri; }
      set { _requestUri = value; }
    }

    public string UserAgent
    {
      get { return _userAgent; }
      set { _userAgent = value; }
    }

    public Stream GetStream()
    {
      if (_requestUri == null)
        throw new InvalidOperationException("RequestUri must be set.");

      WebRequest webRequest = WebRequest.Create(_requestUri);
      webRequest.Method = "GET";
      webRequest.Timeout = 60000;
      if (!string.IsNullOrEmpty(_proxyUserName))
      {
        if (webRequest.Proxy == null)
          throw new InvalidOperationException("No proxy on WebRequest. Could not set proxy credentials.");

        webRequest.Proxy.Credentials = new NetworkCredential(_proxyUserName, _proxyPassword, _proxyDomain);
      }

      if (webRequest is HttpWebRequest)
        ((HttpWebRequest)webRequest).UserAgent = _userAgent;

      WebResponse webResponse = webRequest.GetResponse();

      return webResponse.GetResponseStream();
    }
  }
}