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
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

using System.IO;
using System.Globalization;
using System.ComponentModel;
using SoftLogik.Miscellaneous;
using SoftLogik.Reflection;
using SoftLogik.Text;

namespace SoftLogik.Web
{
  public static class ControlUtils
  {
    public static bool EnableLegacyRendering
    {
      get
      {
        System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        XhtmlConformanceSection xhtmlSection = (XhtmlConformanceSection)configuration.GetSection("system.web/xhtmlConformance");

        return xhtmlSection.Mode == XhtmlConformanceMode.Legacy;
      }
    }

    public static bool IsDesignMode(Control control)
    {
      if (control == null)
        throw new ArgumentNullException("control");

      ISite site = control.Site;

      return (site == null || site.DesignMode);
    }

    public static void AddAttributesWithoutID<T>(T control, Action<T> action) where T : Control
    {
      string tempID = control.ID;
      control.ID = null;

      action(control);

      control.ID = tempID;
    }

    public static void AddAttributesWithoutID(Control control, Action<HtmlTextWriter> addAttributes, HtmlTextWriter writer)
    {
      string tempID = control.ID;
      control.ID = null;

      addAttributes(writer);

      control.ID = tempID;
    }

    public static bool IsControlEmpty(Control control)
    {
      if (control == null)
        throw new ArgumentNullException("control");

      ControlCollection controls = control.Controls;

      // placeholder has no controls
      if (controls.Count == 0)
      {
        return true;
      }
      else if (controls.Count == 1)
      {
        LiteralControl staticContent = controls[0] as LiteralControl;

        // control only has a literal control which is either empty,
        // or contains nothing but whitespace
        if (staticContent != null)
        {
          if (string.IsNullOrEmpty(staticContent.Text))
            return true;
          else if (StringUtils.IsWhiteSpace(staticContent.Text))
            return true;
        }
      }

      return false;
    }

    public static string RenderTemplate(Control parentControl, ITemplate template)
    {
      if (template == null)
        throw new ArgumentNullException("template");

      Control temporaryContainer = new Control();
      parentControl.Controls.Add(temporaryContainer);

      template.InstantiateIn(temporaryContainer);

      string html = RenderControls(temporaryContainer.Controls, 0, string.Empty);

      parentControl.Controls.Remove(temporaryContainer);

      return html;
    }

    public static string RenderChildren(Control control)
    {
      if (control == null)
        throw new ArgumentNullException("control");

      return RenderControls(control.Controls);
    }

    public static void RenderChildren(Control control, HtmlTextWriter writer)
    {
      if (control == null)
        throw new ArgumentNullException("control");

      RenderControls(control.Controls, writer);
    }

    public static string RenderControl(Control control)
    {
      if (control == null)
        throw new ArgumentNullException("control");

      return DoRender(delegate(HtmlTextWriter writer)
      {
        control.RenderControl(writer);
      });
    }

    public static string RenderControls(ControlCollection controls)
    {
      return DoRender(delegate(HtmlTextWriter writer)
      {
        RenderControls(controls, writer);
      });
    }

    public static string RenderControls(ControlCollection controls, int indent, string newLine)
    {
      return DoRender(delegate(HtmlTextWriter writer)
      {
        writer.Indent = indent;
        writer.NewLine = newLine;

        RenderControls(controls, writer);
      });
    }

    private static string DoRender(Action<HtmlTextWriter> render)
    {
      StringBuilder sb = new StringBuilder();
      using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
      {
        using (HtmlTextWriter htmlWriter = new HtmlTextWriter(sw))
        {
          render(htmlWriter);
        }
      }

      return sb.ToString();
    }

    public static void RenderControls(ControlCollection controls, HtmlTextWriter writer)
    {
      if (controls == null)
        throw new ArgumentNullException("controls");

      if (writer == null)
        throw new ArgumentNullException("writer");

      for (int i = 0; i < controls.Count; i++)
      {
        controls[i].RenderControl(writer);
      }
    }

    private static T FindControl<T>(Control parent, string id, bool required, string errorMessage) where T : Control
    {
      if (parent == null)
        throw new ArgumentNullException("parent");

      ValidationUtils.ArgumentNotNullOrEmpty(id, "id");

      Control control = FindControl(parent, id, required, errorMessage);
      T typedControl = null;

      if (control != null)
      {
        typedControl = control as T;

        if (typedControl == null)
        {
          if (!string.IsNullOrEmpty(errorMessage))
            throw new Exception(errorMessage);
          else
            throw new Exception(string.Format("Could not cast control '{0}' of type '{1}' to '{2}", id, control.GetType().Name, typeof(T).Name));
        }
      }

      return typedControl;
    }

    private static Control FindControl(Control parent, string id, bool required, string errorMessage)
    {
      if (parent == null)
        throw new ArgumentNullException("parent");

      ValidationUtils.ArgumentNotNullOrEmpty(id, "id");

      Control control = parent.FindControl(id);

      if (control == null)
      {
        if (required)
        {
          if (!string.IsNullOrEmpty(errorMessage))
            throw new Exception(errorMessage);
          else
            throw new Exception(string.Format("Could not find control '{0}'", id));
        }
      }

      return control;
    }

    public static T FindOptionalControl<T>(Control parent, string id) where T : Control
    {
      return FindControl<T>(parent, id, false, null);
    }

    public static T FindOptionalControl<T>(Control parent, string id, string errorMessage) where T : Control
    {
      return FindControl<T>(parent, id, false, errorMessage);
    }

    public static T FindRequiredControl<T>(Control parent, string id) where T : Control
    {
      return FindControl<T>(parent, id, true, null);
    }

    public static T FindRequiredControl<T>(Control parent, string id, string errorMessage) where T : Control
    {
      return FindControl<T>(parent, id, true, errorMessage);
    }

    public static object GetControlValue(Control c)
    {
      ValidationUtils.ArgumentNotNull(c, "c");

      ControlValuePropertyAttribute attribute = ReflectionUtils.GetAttribute<ControlValuePropertyAttribute>(c.GetType(), true);

      if (attribute == null)
        throw new Exception(string.Format("Could not find attribute '{0}' on type '{1}'.", typeof(ControlValuePropertyAttribute).Name, c.GetType().Name));

      object value = DataBinder.Eval(c, attribute.Name);

      if (value == null)
        value = attribute.DefaultValue;

      return value;
    }

    public static object FindControlValue(Control parent, string id)
    {
      return FindControlValue(parent, id, null);
    }

    public static object FindControlValue(Control parent, string id, string errorMessage)
    {
      if (parent == null)
        throw new ArgumentNullException("c");

      ValidationUtils.ArgumentNotNullOrEmpty(id, "id");

      Control foundControl = FindControl(parent, id, true, errorMessage);

      return GetControlValue(foundControl);
    }
  }
}