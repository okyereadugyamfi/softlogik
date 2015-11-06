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
using System.Web.UI.WebControls;

namespace SoftLogik.Web.UI
{
  public static class TableUtils
  {
    /// <summary>
    /// Fixes a table so that the last cell in a row has a span that matches the longest row.
    /// </summary>
    /// <param name="table">The table to fix.</param>
    public static void FixColumnSpans(Table table)
    {
      if (table == null)
        throw new ArgumentNullException("table");

      int maxRowWidth = 0;

      // loop through the table's row and get the width of the longest row
      foreach (TableRow row in table.Rows)
      {
        int currentRowWidth = CalculateRowColumnSpan(row);

        if (currentRowWidth > maxRowWidth)
          maxRowWidth = currentRowWidth;
      }

      // loop through the rows and set the final cell to have a colspan that means
      // it's length matches the longest row
      foreach (TableRow row in table.Rows)
      {
        int currentRowWidth = CalculateRowColumnSpan(row);

        if (currentRowWidth < maxRowWidth)
          row.Cells[row.Cells.Count - 1].ColumnSpan = maxRowWidth - currentRowWidth + 1;
      }
    }

    /// <summary>
    /// Calculates the row's column span.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <returns>The row's column span.</returns>
    public static int CalculateRowColumnSpan(TableRow row)
    {
      if (row == null)
        throw new ArgumentNullException("row");

      int spanWidth = 0;

      foreach (TableCell cell in row.Cells)
      {
        spanWidth += (cell.ColumnSpan != 0) ? cell.ColumnSpan : 1;
      }

      return spanWidth;
    }
  }
}