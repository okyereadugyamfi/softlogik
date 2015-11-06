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
using System.Reflection;
using System.Text;
using System.Web.UI;

namespace SoftLogik.Web
{
  public static class ScriptManagerHelper
  {
    private static readonly object _initLock = new object();
    private static bool _initialized;
    private static MethodInfo _registerClientScriptBlockMethod;
    private static MethodInfo _registerStartupScriptMethod;
    private static MethodInfo _registerClientScriptResourceMethod;
    private static bool _ajaxAvailable;

    private static void Initialize()
    {
      if (!_initialized)
      {
        lock (_initLock)
        {
          if (!_initialized)
          {
            Type scriptManagerType = Type.GetType("System.Web.UI.ScriptManager, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", false);

            if (scriptManagerType != null)
            {
              Type[] parms;

              parms = new Type[] { typeof(Control), typeof(Type), typeof(string) };
              _registerClientScriptResourceMethod = scriptManagerType.GetMethod("RegisterClientScriptResource", parms);

              parms = new Type[] { typeof(Control), typeof(Type), typeof(string), typeof(string), typeof(bool) };
              _registerClientScriptBlockMethod = scriptManagerType.GetMethod("RegisterClientScriptBlock", parms);
              _registerStartupScriptMethod = scriptManagerType.GetMethod("RegisterStartupScript", parms);

              _ajaxAvailable = true;
            }

            _initialized = true;
          }
        }
      }
    }

    public static bool AjaxAvailable
    {
      get
      {
        Initialize();

        return _ajaxAvailable;
      }
    }

    public static void RegisterClientScriptResource(Control control, Type type, string resourceName)
    {
      Initialize();

      if (_registerClientScriptResourceMethod != null)
        _registerClientScriptResourceMethod.Invoke(null, new object[] { control, type, resourceName });
      else
        control.Page.ClientScript.RegisterClientScriptResource(type, resourceName);
    }

    public static void RegisterClientScriptBlock(Control control, Type type, string key, string script, bool addScriptTags)
    {
      Initialize();

      if (_registerClientScriptBlockMethod != null)
        _registerClientScriptBlockMethod.Invoke(null, new object[] { control, type, key, script, addScriptTags });
      else
        control.Page.ClientScript.RegisterClientScriptBlock(type, key, script, addScriptTags);
    }

    public static void RegisterStartupScript(Control control, Type type, string key, string script, bool addScriptTags)
    {
      Initialize();

      if (_registerStartupScriptMethod != null)
        _registerStartupScriptMethod.Invoke(null, new object[] { control, type, key, script, addScriptTags });
      else
        control.Page.ClientScript.RegisterStartupScript(type, key, script, addScriptTags);
    }
  }
}
