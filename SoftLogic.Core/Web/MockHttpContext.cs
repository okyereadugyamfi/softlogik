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
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.SessionState;

namespace SoftLogik.Web
{
  public sealed class MockHttpContext
  {
    // NOTE: This code is based on the following article:
    // http://righteousindignation.gotdns.org/blog/archive/2004/04/13/149.aspx
    private const string ContextKeyAspSession = "AspSession";
    private const string ThreadDataKeyAppPath = ".appPath";
    private const string ThreadDataKeyAppPathValue = "c:\\inetpub\\wwwroot\\webapp\\";
    private const string ThreadDataKeyAppVPath = ".appVPath";
    private const string ThreadDataKeyAppVPathValue = "/webapp";
    private const string WorkerRequestPage = "default.aspx";

    private readonly HttpContext _context;

    private MockHttpContext()
      : base()
    {
    }

    public MockHttpContext(bool isSecure)
      : this()
    {
      Thread.GetDomain().SetData(ThreadDataKeyAppPath, ThreadDataKeyAppPathValue);
      Thread.GetDomain().SetData(ThreadDataKeyAppVPath, ThreadDataKeyAppVPathValue);
      SimpleWorkerRequest request = new WorkerRequest(WorkerRequestPage, string.Empty, new StringWriter(), isSecure);
      _context = new HttpContext(request);

      HttpSessionStateContainer container = new HttpSessionStateContainer(
              Guid.NewGuid().ToString("N"), new SessionStateItemCollection(), new HttpStaticObjectsCollection(),
              5, true, HttpCookieMode.AutoDetect, SessionStateMode.InProc, false);

      HttpSessionState state = Activator.CreateInstance(
               typeof(HttpSessionState),
               BindingFlags.Public | BindingFlags.NonPublic |
               BindingFlags.Instance | BindingFlags.CreateInstance,
               null,
               new object[] { container }, CultureInfo.CurrentCulture) as HttpSessionState;
      _context.Items[ContextKeyAspSession] = state;
    }

    public HttpContext Context
    {
      get
      {
        return _context;
      }
    }

    private class WorkerRequest : SimpleWorkerRequest
    {
      private readonly bool _isSecure;

      public WorkerRequest(string page, string query, TextWriter output, bool isSecure)
        : base(page, query, output)
      {
        _isSecure = isSecure;
      }

      public override bool IsSecure()
      {
        return _isSecure;
      }
    }
  }
}
