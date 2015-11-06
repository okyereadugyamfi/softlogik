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
using System.IO;
using System.Collections;
using System.Reflection;

namespace SoftLogik.Miscellaneous
{
  public class ObjectDumper
  {
    const ConsoleColor cIdent = ConsoleColor.White;
    const ConsoleColor cValue = ConsoleColor.Gray;

    public static void Write(object o, TextWriter writer)
    {
      Write(o, 0, writer);
    }

    public static void Write(object o, int depth, TextWriter writer)
    {
      ObjectDumper dumper = new ObjectDumper(depth, writer);
      dumper.WriteObject(null, o);
    }

    TextWriter _writer;
    int _pos;
    int _level;
    int _depth;

    private ObjectDumper(int depth, TextWriter writer)
    {
      _writer = writer;
      _depth = depth;
    }

    private void Write(string s)
    {
      if (s != null)
      {
        _writer.Write(s);
        _pos += s.Length;
      }
    }

    private void Write(string s, ConsoleColor c)
    {
      ConsoleColor temp = Console.ForegroundColor;
      Console.ForegroundColor = c;
      Write(s);
      Console.ForegroundColor = temp;
    }

    private void WriteIndent()
    {
      for (int i = 0; i < _level; i++) _writer.Write("  ");
    }

    private void WriteLine()
    {
      _writer.WriteLine();
      _pos = 0;
    }

    private void WriteTab()
    {
      Write("  ");
      while (_pos % 8 != 0) Write(" ");
    }

    private void WriteObject(string prefix, object o)
    {
      if (o == null || o is ValueType || o is string)
      {
        WriteIndent();
        Write(prefix);
        WriteValue(o);
        WriteLine();
      }
      else if (o is IEnumerable)
      {
        foreach (object element in (IEnumerable)o)
        {
          if (element is IEnumerable && !(element is string))
          {
            WriteIndent();
            Write(prefix);
            Write("...");
            WriteLine();
            if (_level < _depth)
            {
              _level++;
              WriteObject(prefix, element);
              _level--;
            }
          }
          else
          {
            WriteObject(prefix, element);
          }
        }
      }
      else
      {
        MemberInfo[] members = o.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
        WriteIndent();
        Write(prefix);
        bool propWritten = false;
        foreach (MemberInfo m in members)
        {
          FieldInfo f = m as FieldInfo;
          PropertyInfo p = m as PropertyInfo;
          if (f != null || p != null)
          {
            if (propWritten)
            {
              WriteTab();
            }
            else
            {
              propWritten = true;
            }
            Write(m.Name, cIdent);
            Write("=");
            Type t = f != null ? f.FieldType : p.PropertyType;
            if (t.IsValueType || t == typeof(string))
            {
              WriteValue(f != null ? f.GetValue(o) : p.GetValue(o, null));
            }
            else
            {
              if (typeof(IEnumerable).IsAssignableFrom(t))
              {
                Write("...");
              }
              else
              {
                Write("{ }");
              }
            }
          }
        }
        if (propWritten) WriteLine();
        if (_level < _depth)
        {
          foreach (MemberInfo m in members)
          {
            FieldInfo f = m as FieldInfo;
            PropertyInfo p = m as PropertyInfo;
            if (f != null || p != null)
            {
              Type t = f != null ? f.FieldType : p.PropertyType;
              if (!(t.IsValueType || t == typeof(string)))
              {
                object value = f != null ? f.GetValue(o) : p.GetValue(o, null);
                if (value != null)
                {
                  _level++;
                  WriteObject(m.Name + ": ", value);
                  _level--;
                }
              }
            }
          }
        }
      }
    }

    private void WriteValue(object o)
    {
      if (o == null)
      {
        Write("null");
      }
      else if (o is DateTime)
      {
        Write(((DateTime)o).ToShortDateString(), cValue);
      }
      else if (o is ValueType || o is string)
      {
        Write(o.ToString(), cValue);
      }
      else if (o is IEnumerable)
      {
        Write("...");
      }
      else
      {
        Write("{ }");
      }
    }
  }
}
