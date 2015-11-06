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
using System.Data.SqlTypes;

namespace SoftLogik.Database
{
  public static class SqlUtils
  {
    public static object ToValue(INullable nullableValue)
    {
      if (nullableValue == null)
        return null;
      else if (nullableValue is SqlInt32)
        return ToValue((SqlInt32)nullableValue);
      else if (nullableValue is SqlInt64)
        return ToValue((SqlInt64)nullableValue);
      else if (nullableValue is SqlBoolean)
        return ToValue((SqlBoolean)nullableValue);
      else if (nullableValue is SqlString)
        return ToValue((SqlString)nullableValue);
      else if (nullableValue is SqlDateTime)
        return ToValue((SqlDateTime)nullableValue);

      throw new Exception(string.Format("Unsupported INullable type: {0}", nullableValue.GetType()));
    }

    /// <summary>
    /// Converts SqlType to .NET value.
    /// </summary>
    /// <param name="sqlValue">The SQL value.</param>
    /// <returns></returns>
    public static int? ToValue(SqlInt32 sqlValue)
    {
      if (DatabaseUtils.IsNull(sqlValue))
        return null;
      else
        return sqlValue.Value;
    }

    /// <summary>
    /// Converts SqlType to .NET value.
    /// </summary>
    /// <param name="sqlValue">The SQL value.</param>
    /// <returns></returns>
    public static long? ToValue(SqlInt64 sqlValue)
    {
      if (DatabaseUtils.IsNull(sqlValue))
        return null;
      else
        return sqlValue.Value;
    }

    /// <summary>
    /// Converts SqlType to .NET value.
    /// </summary>
    /// <param name="sqlValue">The SQL value.</param>
    /// <returns></returns>
    public static string ToValue(SqlString sqlValue)
    {
      if (DatabaseUtils.IsNull(sqlValue))
        return null;
      else
        return sqlValue.Value;
    }

    /// <summary>
    /// Converts SqlType to .NET value.
    /// </summary>
    /// <param name="sqlValue">The SQL value.</param>
    /// <returns></returns>
    public static DateTime? ToValue(SqlDateTime sqlValue)
    {
      if (DatabaseUtils.IsNull(sqlValue))
        return null;
      else
        return sqlValue.Value;
    }

    /// <summary>
    /// Converts SqlType to .NET value.
    /// </summary>
    /// <param name="sqlValue">The SQL value.</param>
    /// <returns></returns>
    public static bool? ToValue(SqlBoolean sqlValue)
    {
      if (DatabaseUtils.IsNull(sqlValue))
        return null;
      else
        return sqlValue.Value;
    }

    public static T? ToValue<T>(object value) where T : struct
    {
      if (DatabaseUtils.IsNull(value))
        return null;
      else
        return new T?((T)value);
    }

    public static SqlInt32 FromValue(int? nullableValue)
    {
      return (nullableValue != null) ? new SqlInt32(nullableValue.Value) : new SqlInt32();
    }

    public static SqlDateTime FromValue(DateTime? nullableValue)
    {
      return (nullableValue != null) ? new SqlDateTime(nullableValue.Value) : new SqlDateTime();
    }

    public static SqlBoolean FromValue(bool? nullableValue)
    {
      return (nullableValue != null) ? new SqlBoolean(nullableValue.Value) : new SqlBoolean();
    }
  }
}