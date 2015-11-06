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
using System.IO;

namespace SoftLogik.Miscellaneous
{
  public enum GridLines
  {
    None,
    Horizontal,
    Vertical,
    Both
  }

  public class TableTextWriter : TextWriter
  {
    #region Private inner types
    private struct Cell
    {
      string _text;

      public Cell(string text)
      {
        _text = text;
      }

      public string Text
      {
        get { return _text ?? string.Empty; }
      }
    }

    private class Column
    {
      private int _maximumWidth;

      public int MaximumWidth
      {
        get { return _maximumWidth; }
      }

      public Column(int maximumWidth)
      {
        _maximumWidth = maximumWidth;
      }
    }

    private struct Row
    {
      private List<Cell> _cells;

      public Row(List<Cell> cells)
      {
        _cells = cells;
      }

      public List<Cell> Cells
      {
        get { return _cells; }
      }
    }
    #endregion

    private TextWriter _writer;
    private List<Row> _rows;
    private Row? _currentRow;
    private int _columnSpacing;
    private bool _border;
    private GridLines _gridLines;

    public GridLines GridLines
    {
      get { return _gridLines; }
      set { _gridLines = value; }
    }

    public bool Border
    {
      get { return _border; }
      set { _border = value; }
    }

    public int ColumnSpacing
    {
      get { return _columnSpacing; }
      set { _columnSpacing = value; }
    }

    public TableTextWriter(TextWriter writer)
    {
      _writer = writer;
      _columnSpacing = 1;
    }

    private void EnsureCurrentLine()
    {
      if (_rows == null)
        _rows = new List<Row>();

      if (_currentRow == null)
      {
        _currentRow = new Row(new List<Cell>());
        _rows.Add(_currentRow.Value);
      }
    }

    private void WriteSpacing()
    {
      _writer.Write(new string(' ', _columnSpacing));
    }

    private int CalculateColumnSpacing()
    {
      if (_gridLines == GridLines.Vertical || _gridLines == GridLines.Both)
        return (_columnSpacing * 2) + 1;
      else
        return _columnSpacing;
    }

    public override void Flush()
    {
      if (_rows == null)
        return;

      List<Column> columns = CalculateCellColumns();

      int columnsTotalWidth = CalculateTotalColumnCellWidth(columns);
      int columnsTotalSpacing = CalculateTotalColumnSpacingWidth(columns);
      int totalInnerWidth = columnsTotalWidth + columnsTotalSpacing + (_columnSpacing * 2);

      if (_border)
      {
        _writer.Write(@"/");
        _writer.Write(new string('-', totalInnerWidth));
        _writer.Write(@"\");
        _writer.WriteLine();
      }

      for (int rowIndex = 0; rowIndex < _rows.Count; rowIndex++)
      {
        Row row = _rows[rowIndex];

        if (_border)
        {
          _writer.Write("|");
          WriteSpacing();
        }

        for (int i = 0; i < columns.Count; i++)
        {
          Column column = columns[i];
          Cell? cell = (i < row.Cells.Count) ? new Cell?(row.Cells[i]) : null;

          InternalWrite(cell, columns[i]);
          WriteSpacing();

          if (i + 1 < columns.Count && (_gridLines == GridLines.Vertical || _gridLines == GridLines.Both))
          {
            _writer.Write("|");
            WriteSpacing();
          }
        }

        if (_border)
          _writer.Write("|");

        _writer.WriteLine();

        if (rowIndex + 1 < _rows.Count)
        {
          if (_gridLines == GridLines.Horizontal || _gridLines == GridLines.Both)
          {
            if (_border)
              _writer.Write("|");

            _writer.Write(new string('-', totalInnerWidth));

            if (_border)
              _writer.Write("|");

            _writer.WriteLine();
          }
        }
      }

      if (_border)
      {
        _writer.Write(@"\");
        _writer.Write(new string('-', totalInnerWidth));
        _writer.Write(@"/");
        _writer.WriteLine();
      }

      _rows = null;
      _writer.Flush();
    }

    private int CalculateTotalColumnCellWidth(List<Column> columns)
    {
      int totalWidth = 0;

      foreach (Column column in columns)
      {
        totalWidth += column.MaximumWidth;
      }

      return totalWidth;
    }

    private List<Column> CalculateCellColumns()
    {
      SortedDictionary<int, int> cellIndexMaximumWidths = new SortedDictionary<int, int>(Comparer<int>.Default);

      for (int rowIndex = 0; rowIndex < _rows.Count; rowIndex++)
      {
        Row row = _rows[rowIndex];

        for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
        {
          Cell cell = row.Cells[cellIndex];

          int maximumWidth;
          cellIndexMaximumWidths.TryGetValue(cellIndex, out maximumWidth);

          cellIndexMaximumWidths[cellIndex] = Math.Max(cell.Text.Length, maximumWidth);
        }
      }

      List<Column> columns = new List<Column>();

      foreach (int columnIndex in cellIndexMaximumWidths.Keys)
      {
        columns.Add(new Column(cellIndexMaximumWidths[columnIndex]));
      }

      return columns;
    }

    private int CalculateTotalColumnSpacingWidth(List<Column> columns)
    {
      return (columns.Count - 1) * CalculateColumnSpacing();
    }

    private void InternalWrite(Cell? cell, Column column)
    {
      string text = (cell != null) ? cell.Value.Text : string.Empty;

      _writer.Write(text);

      for (int i = text.Length; i < column.MaximumWidth; i++)
      {
        _writer.Write(' ');
      }
    }

    private void AddCell(string text)
    {
      EnsureCurrentLine();

      _currentRow.Value.Cells.Add(new Cell(text));
    }

    #region TextWriter overriden members
    protected override void Dispose(bool disposing)
    {
      if (disposing)
        Flush();

      base.Dispose(disposing);
    }

    public override Encoding Encoding
    {
      get { return _writer.Encoding; }
    }

    public override void Write(object value)
    {
      if (value == null)
        Write(string.Empty);

      base.Write(value);
    }

    public override void Write(string value)
    {
      AddCell(value);
    }

    public override void Write(char[] buffer, int index, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException("buffer", "Buffer cannot be null.");

      if (index < 0)
        throw new ArgumentOutOfRangeException("index", "Non-negative number required.");

      if (count < 0)
        throw new ArgumentOutOfRangeException("index", "Non-negative number required.");

      if (buffer.Length - index < count)
        throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");

      Write(new string(buffer, index, count));
    }

    public override void Write(char value)
    {
      Write(value.ToString());
    }

    public override void WriteLine()
    {
      if (_currentRow == null)
        EnsureCurrentLine();

      _currentRow = null;
    }
    #endregion
  }
}