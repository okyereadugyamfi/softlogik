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
using System.Collections;
using SoftLogik.Miscellaneous;
using SoftLogik.Reflection;

namespace SoftLogik.Collections
{
  public static class EnumerableUtils
  {
    /// <summary>
    /// Performs an action for each item in an enumerable, divided by a seperator action.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable">The enumerable.</param>
    /// <param name="action">The action.</param>
    /// <param name="seperatorAction">The seperator action.</param>
    public static void ForEach<T>(IEnumerable<T> enumerable, Action<T> action, Action<T> seperatorAction)
    {
      ValidationUtils.ArgumentNotNull(enumerable, "enumerable");
      ValidationUtils.ArgumentNotNull(action, "action");

      bool first = true;

      foreach (T item in enumerable)
      {
        if (first)
        {
          first = false;
        }
        else
        {
          if (seperatorAction != null)
            seperatorAction(item);
        }

        action(item);
      }
    }

    /// <summary>
    /// Creates an enumerable from a creator with the specified count.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemCreator">The item creator.</param>
    /// <param name="count">The count.</param>
    /// <returns></returns>
    public static IEnumerable<T> Create<T>(Creator<T> itemCreator, int count)
    {
      ValidationUtils.ArgumentNotNull(itemCreator, "itemCreator");
      ValidationUtils.ArgumentNotNegative<int>(count, "count");

      for (int i = 0; i < count; i++)
      {
        yield return itemCreator();
      }
    }

    public static IEnumerable<int> Times(int times)
    {
      for (int i = 1; i <= times; i++)
      {
        yield return i;
      }
    }

    public static IEnumerable<T> Convert<T>(IEnumerable enumerable)
    {
      return Convert<T>(enumerable, false);
    }

    public static IEnumerable<T> Convert<T>(IEnumerable enumerable, bool defaultOnBadType)
    {
      ValidationUtils.ArgumentNotNull(enumerable, "enumerable");

      return new EnumerableWrapper<T>(enumerable, defaultOnBadType, true);
    }

    public static string ToString(IEnumerable enumerable)
    {
      return ToString(enumerable, delegate(object value)
      {
        return MiscellaneousUtils.ToString(value);
      }, ", ");
    }

    public static string ToString(IEnumerable enumerable, Converter<object, string> converter)
    {
      return ToString(enumerable, converter, ", ");
    }

    public static string ToString(IEnumerable enumerable, Converter<object, string> converter, string separator)
    {
      ValidationUtils.ArgumentNotNull(enumerable, "enumerable");

      return ToString<object>(Convert<object>(enumerable), converter, separator);
    }

    public static string ToString<T>(IEnumerable<T> collection, Converter<T, string> converter)
    {
      return ToString<T>(Convert<T>(collection), converter, ", ");
    }

    public static string ToString<T>(IEnumerable<T> enumerable, Converter<T, string> converter, string separator)
    {
      ValidationUtils.ArgumentNotNull(enumerable, "enumerable");
      ValidationUtils.ArgumentNotNull(converter, "converter");
      ValidationUtils.ArgumentNotNull(separator, "separator");

      List<T> list = new List<T>(enumerable);

      List<string> texts = list.ConvertAll<string>(converter);

      return string.Join(separator, texts.ToArray());
    }
  }
}