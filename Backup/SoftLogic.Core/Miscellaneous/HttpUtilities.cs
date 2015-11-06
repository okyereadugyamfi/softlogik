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
using System.Web;
using System.Globalization;
using SoftLogik.Web;

namespace SoftLogik.Miscellaneous
{
  public static class HttpUtilities
  {
    public static string GetCompleteUrlPath(HttpContext context, string pageUrl)
    {
      if (string.IsNullOrEmpty(pageUrl))
        return string.Empty;


      if (UrlUtils.IsRelativeUrl(pageUrl))
        pageUrl = VirtualPathUtility.Combine(context.Request.ApplicationPath, pageUrl);

      return pageUrl;
    }

    public static bool AccessingPage(HttpContext context, string pageUrl)
    {
      if (!string.IsNullOrEmpty(pageUrl))
      {
        pageUrl = GetCompleteUrlPath(context, pageUrl);

        if (string.IsNullOrEmpty(pageUrl))
          return false;

        int queryStartIndex = pageUrl.IndexOf('?');
        if (queryStartIndex >= 0)
          pageUrl = pageUrl.Substring(0, queryStartIndex);

        string requestPath = context.Request.Path;

        if (string.Compare(requestPath, pageUrl, true, CultureInfo.InvariantCulture) == 0)
          return true;

        if (pageUrl.IndexOf('%') >= 0)
        {
          string decodedUnlockUrl = HttpUtility.UrlDecode(pageUrl);
          if (string.Compare(requestPath, decodedUnlockUrl, true, CultureInfo.InvariantCulture) == 0)
            return true;

          decodedUnlockUrl = HttpUtility.UrlDecode(pageUrl, context.Request.ContentEncoding);
          if (string.Compare(requestPath, decodedUnlockUrl, true, CultureInfo.InvariantCulture) == 0)
            return true;
        }
      }
      return false;
    }
  }
}