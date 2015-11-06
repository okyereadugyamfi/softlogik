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
using System.Web.Security;
using System.Web.UI;

namespace SoftLogik.Web.Modules
{
  public class AccessDeniedRedirectModule : IHttpModule
  {
    public void Dispose()
    {
    }

    public void Init(HttpApplication context)
    {
      context.EndRequest += EndRequest;
    }

    void EndRequest(object sender, EventArgs e)
    {
      HttpApplication application = (HttpApplication)sender;
      HttpContext context = application.Context;
      HttpRequest request = context.Request;
      HttpResponse response = context.Response;

      bool redirectAccessDenied = false;

      switch (context.Response.StatusCode)
      {
        case 401:
          if (context.Handler is Page && request.IsAuthenticated)
            redirectAccessDenied = true;
          break;
        case 302:
          if (request.IsAuthenticated)
          {
            bool hasAccess = UrlAuthorizationModule.CheckUrlAccessForPrincipal(request.Url.LocalPath, context.User, request.RequestType);

            if (!hasAccess)
            {
              string redirectUrl = response.RedirectLocation.ToUpperInvariant();
              string loginUrl = FormsAuthentication.LoginUrl.ToUpperInvariant();

              redirectAccessDenied = redirectUrl.StartsWith(loginUrl);
            }
          }
          break;
      }

      if (redirectAccessDenied)
        response.Redirect("~/AccessDenied.aspx", true);
    }
  }
}