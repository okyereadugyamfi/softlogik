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
using SoftLogik.Reflection;

namespace SoftLogik.Miscellaneous
{
  public struct Range<T> : IEquatable<Range<T>> where T : struct, IComparable<T>
  {
    private readonly T _start;
    private readonly T _end;

    public Range(T start, T end)
    {
      //long startLong = start.ToInt64(CultureInfo.InvariantCulture);
      //long endLong = end.ToInt64(CultureInfo.InvariantCulture);

      //try
      //{
      //  long length = checked(endLong - startLong);
      //}
      //catch (OverflowException e)
      //{
      //  throw new Exception(string.Format("Range between {0} and {1} exceeds maximum length.", start, end), e);
      //}

      _start = start;
      _end = end;
    }

    public T Start
    {
      get { return _start; }
    }

    public T End
    {
      get { return _end; }
    }

    public bool InRange(T value)
    {
      bool greaterOrEqualToStart = (_start.CompareTo(value) != 1);
      bool lessThanEnd = (_end.CompareTo(value) == 1);

      return (greaterOrEqualToStart && lessThanEnd);
    }

    public override string ToString()
    {
      return string.Format("Start: {0}, End: {1}", _start, _end);
    }

    public bool Equals(Range<T> other)
    {
      return (_start.Equals(other._start) && _end.Equals(other._end));
    }

    public override bool Equals(object obj)
    {
      if (obj is Range<T>)
      {
        Range<T> other = (Range<T>)obj;
        return Equals(other);
      }

      return false;
    }

    public override int GetHashCode()
    {
      return _start.GetHashCode() ^ _end.GetHashCode();
    }
  }

  public static class MathUtils
  {
    public static bool InRange<T>(T value, T start, T end) where T : struct, IComparable<T>
    {
      Range<T> range = new Range<T>(start, end);
      return range.InRange(value);
    }

    public static List<Range<T>> DivideRange<T>(Range<T> range, int count) where T : struct, IComparable<T>
    {
      Func<T, T, T> add = GenericOperatorFactory<T, T, T, Range<T>>.Add;
      Func<T, T, T> subtract = GenericOperatorFactory<T, T, T, Range<T>>.Subtract;
      Func<T, T, T> divide = GenericOperatorFactory<T, T, T, Range<T>>.Divide;
      Func<T, T, T> multiply = GenericOperatorFactory<T, T, T, Range<T>>.Multiply;

      T length = subtract(range.End, range.Start);
      T dividedRangeLength = divide(length, ConvertUtils.ConvertOrCast<T>(count));
      //double remainderPerDivide = (length % (double)count) / (double)count;

      List<Range<T>> ranges = new List<Range<T>>(count);

      for (int i = 0; i < count; i++)
      {
        //decimal extra = (remainderPerDivide * (i + 1));

        T newStart = add(multiply(dividedRangeLength, ConvertUtils.ConvertOrCast<T>(i)), range.Start);
        T newEnd = add(multiply(dividedRangeLength, ConvertUtils.ConvertOrCast<T>(i + 1)), range.Start);

        Range<T> newRange = new Range<T>(newStart, newEnd);
        ranges.Add(newRange);
      }

      return ranges;
    }

    public static char IntToHex(int n)
    {
      if (n <= 9)
      {
        return (char)(n + 48);
      }
      return (char)((n - 10) + 97);
    }

    public static int HexToInt(char h)
    {
      if ((h >= '0') && (h <= '9'))
      {
        return (h - '0');
      }
      if ((h >= 'a') && (h <= 'f'))
      {
        return ((h - 'a') + 10);
      }
      if ((h >= 'A') && (h <= 'F'))
      {
        return ((h - 'A') + 10);
      }
      return -1;
    }
  }
}