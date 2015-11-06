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
using System.Web.Caching;
using System.Security.Principal;

namespace SoftLogik.Web.Handlers
{
  public abstract class HandlerBase
  {
    private HttpContext _context;

    protected HttpContext Context
    {
      get
      {
        if (_context == null)
          _context = HttpContext.Current;

        return _context;
      }
      set { _context = value; }
    }

    protected HttpApplicationState Application
    {
      get
      {
        if (Context != null)
          return Context.Application;

        return null;
      }
    }

    protected HttpApplication ApplicationInstance
    {
      get
      {
        if (Context != null)
          return Context.ApplicationInstance;

        return null;
      }
    }

    protected Cache Cache
    {
      get
      {
        if (Context != null)
          return Context.Cache;

        return null;
      }
    }

    protected HttpRequest Request
    {
      get
      {
        if (Context != null)
          return Context.Request;

        return null;
      }
    }

    protected HttpResponse Response
    {
      get
      {
        if (Context != null)
          return Context.Response;

        return null;
      }
    }

    protected HttpServerUtility Server
    {
      get
      {
        if (Context != null)
          return Context.Server;

        return null;
      }
    }

    protected TraceContext Trace
    {
      get
      {
        if (Context != null)
          return Context.Trace;

        return null;
      }
    }

    public IPrincipal User
    {
      get
      {
        if (Context != null)
          return Context.User;

        return null;
      }
    }
  }
}