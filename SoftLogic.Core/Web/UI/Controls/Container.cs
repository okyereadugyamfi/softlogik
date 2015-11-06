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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.Design;

namespace SoftLogik.Web.UI.Controls
{
  public class Container<TOwner> : WebControl where TOwner : WebControl
  {
    private TOwner _owner;
    private Dictionary<string, Control> _cachedFindControls;
    private bool _renderDesignerRegion;

    private Dictionary<string, Control> CachedFindControls
    {
      get
      {
        if (_cachedFindControls == null)
          _cachedFindControls = new Dictionary<string, Control>();

        return _cachedFindControls;
      }
    }

    public bool RenderDesignerRegion
    {
      get { return _renderDesignerRegion; }
      set { _renderDesignerRegion = value; }
    }

    public Container(TOwner owner)
    {
      _owner = owner;
    }

    private T FindControl<T>(string id, bool required, string errorMessage) where T : Control
    {
      Control control;
      T foundControl;

      if (!CachedFindControls.TryGetValue(id, out control))
      {
        // control wasn't cached. try to find it
        foundControl = FindControl(id) as T;

        // add to cache if found
        // otherwise throw an exception if required
        if (foundControl != null)
          CachedFindControls.Add(id, foundControl);
        else if (required)
          throw new Exception(errorMessage);
      }
      else
      {
        foundControl = (T)control;
      }

      return foundControl;
    }

    protected T FindOptionalControl<T>(string id) where T : Control
    {
      return FindControl<T>(id, false, null);
    }

    protected T FindRequiredControl<T>(string id, string errorMessage) where T : Control
    {
      return FindControl<T>(id, true, errorMessage);
    }

    protected override void Render(HtmlTextWriter writer)
    {
      if (_renderDesignerRegion)
      {
        Table table = new Table();
        TableCell cell = new TableCell();

        table.Rows.Add(new TableRow());
        table.Rows[0].Cells.Add(cell);
        table.BorderWidth = new Unit(0, UnitType.Pixel);
        table.CellPadding = 0;
        table.CellSpacing = 0;

        cell.Attributes[DesignerRegion.DesignerRegionAttributeName] = "0";

        table.RenderControl(writer);
      }
      else
      {
        RenderContents(writer);
      }
    }
  }
}