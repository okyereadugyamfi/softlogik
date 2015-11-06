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
using System.Configuration;
using System.Data.SqlTypes;

namespace SoftLogik.Database
{
  public static class DatabaseUtils
  {
    /// <summary>
    /// Converts specified value to nullable value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static T? ConvertToNullableValue<T>(object value) where T : struct
    {
      if (value == null)
      {
        return null;
      }
      else if (value == DBNull.Value)
      {
        return null;
      }
      else if (value is string && string.IsNullOrEmpty((string)value))
      {
        return null;
      }
      else
      {
        if (!(value is T))
        {
          try
          {
            value = Convert.ChangeType(value, typeof(T));
          }
          catch (Exception e)
          {
            throw new ArgumentException("Value is not a valid type.", "value", e);
          }
        }

        return new T?((T)value);
      }
    }

    /// <summary>
    /// Determines whether the specified value is null.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// 	<c>true</c> if the specified value is null; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNull(object value)
    {
      if (value == null)
        return true;

      if (value is INullable && ((INullable)value).IsNull)
        return true;

      if (value == DBNull.Value)
        return true;

      return false;
    }
  }
}
