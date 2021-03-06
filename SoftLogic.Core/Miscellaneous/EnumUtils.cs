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
using SoftLogik.Collections;
using System.Globalization;

namespace SoftLogik.Miscellaneous
{
  public static class EnumUtils
  {
    /// <summary>
    /// Parses the specified enum member name, returning it's value.
    /// </summary>
    /// <param name="enumMemberName">Name of the enum member.</param>
    /// <returns></returns>
    public static T Parse<T>(string enumMemberName) where T : struct
    {
      return Parse<T>(enumMemberName, false);
    }

    /// <summary>
    /// Parses the specified enum member name, returning it's value.
    /// </summary>
    /// <param name="enumMemberName">Name of the enum member.</param>
    /// <param name="ignoreCase">If set to <c>true</c> ignore case.</param>
    /// <returns></returns>
    public static T Parse<T>(string enumMemberName, bool ignoreCase) where T : struct
    {
      ValidationUtils.ArgumentTypeIsEnum(typeof(T), "T");

      return (T)Enum.Parse(typeof(T), enumMemberName, ignoreCase);
    }

    public static bool TryParse<T>(string enumMemberName, bool ignoreCase, out T value) where T : struct
    {
      ValidationUtils.ArgumentTypeIsEnum(typeof(T), "T");

      return MiscellaneousUtils.TryAction<T>(delegate { return Parse<T>(enumMemberName, ignoreCase); }, out value);
    }

    /// <summary>
    /// Gets a dictionary of the names and values of an Enum type.
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, ulong> GetNamesAndValues<T>() where T : struct
    {
      return GetNamesAndValues<ulong>(typeof(T));
    }

    /// <summary>
    /// Gets a dictionary of the names and values of an Enum type.
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, TUnderlyingType> GetNamesAndValues<TEnum, TUnderlyingType>()
      where TEnum : struct
      where TUnderlyingType : struct
    {
      return GetNamesAndValues<TUnderlyingType>(typeof(TEnum));
    }

    /// <summary>
    /// Gets a dictionary of the names and values of an Enum type.
    /// </summary>
    /// <param name="enumType">The enum type to get names and values for.</param>
    /// <returns></returns>
    public static IDictionary<string, TUnderlyingType> GetNamesAndValues<TUnderlyingType>(Type enumType)
    {
      if (enumType == null)
        throw new ArgumentNullException("enumType");

      ValidationUtils.ArgumentTypeIsEnum(enumType, "enumType");

      Array enumValues = Enum.GetValues(enumType);
      string[] enumNames = Enum.GetNames(enumType);

      KeyedList<string, TUnderlyingType> nameValues = new KeyedList<string, TUnderlyingType>();

      for (int i = 0; i < enumValues.Length; i++)
      {
        try
        {
          nameValues.Add(enumNames[i], (TUnderlyingType)Convert.ChangeType(enumValues.GetValue(i), typeof(TUnderlyingType)));
        }
        catch (OverflowException e)
        {
          throw new Exception(
            string.Format("Value from enum with the underlying type of {0} cannot be added to dictionary with a value type of {1}. Value was too large: {2}",
              Enum.GetUnderlyingType(enumType), typeof(TUnderlyingType), Convert.ToUInt64(enumValues.GetValue(i))), e);
        }
      }

      return nameValues;
    }

    /// <summary>
    /// Gets the maximum valid value of an Enum type. Flags enums are ORed.
    /// </summary>
    /// <typeparam name="TEnumType">The type of the returned value. Must be assignable from the enum's underlying value type.</typeparam>
    /// <param name="enumType">The enum type to get the maximum value for.</param>
    /// <returns></returns>
    public static TEnumType GetMaximumValue<TEnumType>(Type enumType) where TEnumType : IConvertible, IComparable<TEnumType>
    {
      if (enumType == null)
        throw new ArgumentNullException("enumType");

      Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);

      if (!typeof(TEnumType).IsAssignableFrom(enumUnderlyingType))
        throw new ArgumentException(string.Format("TEnumType is not assignable from the enum's underlying type of {0}.", enumUnderlyingType.Name));

      ulong maximumValue = 0;
      Array enumValues = Enum.GetValues(enumType);

      if (enumType.IsDefined(typeof(FlagsAttribute), false))
      {
        foreach (TEnumType value in enumValues)
        {
          maximumValue = maximumValue | value.ToUInt64(CultureInfo.InvariantCulture);
        }
      }
      else
      {
        foreach (TEnumType value in enumValues)
        {
          ulong tempValue = value.ToUInt64(CultureInfo.InvariantCulture);

          // maximumValue is smaller than the enum value
          if (maximumValue.CompareTo(tempValue) == -1)
            maximumValue = tempValue;
        }
      }

      return (TEnumType)Convert.ChangeType(maximumValue, typeof(TEnumType), CultureInfo.InvariantCulture);
    }
  }
}