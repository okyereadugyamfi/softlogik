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
using System.Globalization;
using System.Text;
using System.Data.SqlTypes;

namespace SoftLogik.Miscellaneous
{
  public static class DateTimeUtils
  {
    public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

    public static DateTime ToSqlServerPrecision(DateTime value)
    {
      SqlDateTime sqlValue = new SqlDateTime(value);

      return sqlValue.Value;
    }

    public static DateTime ConvertUnixSeconds(long unixSeconds, long residualNanoseconds)
    {
      DateTime actualDateTime = ConvertUnixSeconds(unixSeconds);

      long ticks = residualNanoseconds / 100;

      return actualDateTime.AddTicks(ticks);
    }

    public static DateTime ConvertUnixSeconds(long unixSeconds)
    {
      return UnixEpoch.AddSeconds(unixSeconds);
    }

    public static string ToFileSortableDateTime(DateTime value)
    {
      return value.ToString("yyyyMMdd'T'HHmmss", CultureInfo.CurrentCulture);
    }

    public static DateTime FromFileSortableDateTime(string value)
    {
      return DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss", CultureInfo.CurrentCulture);
    }
  }
}
