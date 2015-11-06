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
using SoftLogik.Text;
using System.Globalization;

namespace SoftLogik.Miscellaneous
{
  public static class RandomUtils
  {
    private static readonly Random _random = new Random();

    public static long GetInt32(Random r)
    {
      ValidationUtils.ArgumentNotNull(r, "r");

      return r.Next(int.MinValue, int.MaxValue);
    }

    public static long GetInt32()
    {
      return GetInt32(_random);
    }

    public static long GetInt64(Random r)
    {
      ValidationUtils.ArgumentNotNull(r, "r");

      long high = GetInt32(r);
      high = high << 32;
      long low = GetInt32(r);

      return high | low;
    }

    public static long GetInt64()
    {
      return GetInt64(_random);
    }

    public static ulong GetUInt64(Random r)
    {
      return (ulong)GetInt64(r);
    }

    public static ulong GetUInt64()
    {
      return GetUInt64(_random);
    }

    public static bool GetBoolean()
    {
      return GetBoolean(_random);
    }

    public static bool GetBoolean(Random r)
    {
      // get random 1 or 0 and convert to bool
      return Convert.ToBoolean(r.Next(2));
    }

    public static uint GetUInt32()
    {
      return GetUInt32(_random);
    }

    public static uint GetUInt32(Random r)
    {
      return (uint)GetInt32(r);
    }

    public static double GetDouble()
    {
      return GetDouble(_random);
    }

    public static double GetDouble(Random r)
    {
      ValidationUtils.ArgumentNotNull(r, "r");

      double randomResult = _random.NextDouble();
      randomResult = randomResult - 0.5;

      return randomResult * double.MaxValue * 2;
    }

    public static string GetAsciiString(int length)
    {
      char minBmpCodePointValue = ' ';
      char maxBmpCodePointValue = '~';

      return GetString(length, minBmpCodePointValue, maxBmpCodePointValue);
    }

    public static string GetUnicodeString(int length)
    {
      char minBmpCodePointValue = ' ';
      char maxBmpCodePointValue = (char)65535;

      return GetString(length, minBmpCodePointValue, maxBmpCodePointValue);
    }

    public static string GetLatinString(int length)
    {
      char minBmpCodePointValue = ' ';
      char maxBmpCodePointValue = (char)255;

      return GetString(length, minBmpCodePointValue, maxBmpCodePointValue);
    }

    private static string GetString(int length, int minBmpCodePointValue, int maxBmpCodePointValue)
    {
      StringBuilder builder = new StringBuilder();

      while (builder.Length < length)
      {
        int i = 0;
        char c = Convert.ToChar(_random.Next(minBmpCodePointValue, maxBmpCodePointValue + 1));

        UnicodeCategory category = char.GetUnicodeCategory(c);

        switch (category)
        {
          case UnicodeCategory.PrivateUse:
          case UnicodeCategory.OtherNotAssigned:
          case UnicodeCategory.Surrogate:
            // don't use
            break;
          default:
            builder.Append(c);
            break;
        }
      }

      return builder.ToString();
    }
  }
}