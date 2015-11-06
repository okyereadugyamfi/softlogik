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
using System.Web.UI;
using System.IO;

namespace SoftLogik.Web.Modules
{
  public class DefaultResolveModule : IHttpModule
  {
    private bool _resolveEventAttached = false;
    private object _lockObject = new object();
    private const string DefaultPage = "default.aspx";

    public void Dispose()
    {
    }

    public void Init(HttpApplication context)
    {
      context.BeginRequest += new EventHandler(context_BeginRequest);
    }

    private void context_BeginRequest(object sender, EventArgs e)
    {
      if (!_resolveEventAttached)
      {
        lock (_lockObject)
        {
          if (!_resolveEventAttached)
          {
            SiteMapProvider provider = SiteMap.Provider;

            if (provider != null)
              provider.SiteMapResolve += new SiteMapResolveEventHandler(SiteMapResolve);

            _resolveEventAttached = true;
          }
        }
      }
    }

    private SiteMapNode SiteMapResolve(object sender, SiteMapResolveEventArgs e)
    {
      HttpContext context = e.Context;
      SiteMapProvider provider = e.Provider;

      if (context == null)
        return null;

      HttpRequest request = context.Request;
      string pageName = VirtualPathUtility.GetFileName(request.Path);

      if (string.Compare(pageName, DefaultPage, StringComparison.OrdinalIgnoreCase) == 0)
      {
        List<SiteMapResolveEventHandler> resolveMethods = new List<SiteMapResolveEventHandler>();

        resolveMethods.Add(delegate
        {
          return provider.FindSiteMapNode(RemoveDefault(context.Request.RawUrl));
        });

        resolveMethods.Add(delegate
        {
          int queryStartIndex = context.Request.RawUrl.IndexOf("?", StringComparison.Ordinal);
          if (queryStartIndex != -1)
            return provider.FindSiteMapNode(RemoveDefault(context.Request.RawUrl.Substring(0, queryStartIndex)));
          else
            return null;
        });

        resolveMethods.Add(delegate
        {
          Page page = context.CurrentHandler as Page;
          if (page != null)
          {
            string queryString = page.ClientQueryString;

            if (queryString.Length > 0)
              return provider.FindSiteMapNode(RemoveDefault(context.Request.Path + "?" + queryString));
          }
          return null;
        });

        resolveMethods.Add(delegate
        {
          return provider.FindSiteMapNode(RemoveDefault(context.Request.Path));
        });

        foreach (SiteMapResolveEventHandler method in resolveMethods)
        {
          SiteMapNode node = method(sender, e);

          if (node != null)
            return node;
        }
      }

      return null;
    }

    public static string RemoveDefault(string url)
    {
      int startIndex = url.IndexOf(DefaultPage, StringComparison.OrdinalIgnoreCase);

      return (startIndex != -1) ? url.Remove(startIndex, DefaultPage.Length) : url;
    }
  }
}