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
using SoftLogik.Miscellaneous;
using SoftLogik.Reflection;
using SoftLogik.Collections;
using System.Collections;

namespace SoftLogik.Testing
{
  public class RandomValueCreator : IValueCreator
  {
    private static readonly Random _staticRandom = new Random();
    private static readonly RandomValueCreator _default = new RandomValueCreator();

    private readonly Random _random;

    public RandomValueCreator(Random r)
    {
      ValidationUtils.ArgumentNotNull(r, "r");

      _random = r;
    }

    public RandomValueCreator() : this(_staticRandom)
    {
    }

    public static RandomValueCreator Default
    {
      get { return _default; }
    }

    public object CreateValue(Type valueType)
    {
      ValidationUtils.ArgumentNotNull(valueType, "valueType");

      // First, is the type a nullable type? if so return a value based on the
      // generic argument.
      if (ReflectionUtils.IsNullableType(valueType))
      {
        // randomly return null some of the time
        if (RandomUtils.GetBoolean(_random))
          return null;

        Type underlyingType = Nullable.GetUnderlyingType(valueType);
        return CreateValue(underlyingType);
      }
      else if (valueType.IsEnum)
      {
        Array values = Enum.GetValues(valueType);
        return values.GetValue(_random.Next(values.Length));
      }
      else if (valueType == typeof(Guid))
      {
        return Guid.NewGuid();
      }
      else if (valueType == typeof(TimeSpan))
      {
        return new TimeSpan(_random.Next(byte.MinValue, byte.MaxValue));
      }

      Type implementingType;
      if (ReflectionUtils.IsSubClass(valueType, typeof(IList<>), out implementingType))
      {
        Type listContentsType = implementingType.GetGenericArguments()[0];


        return CollectionUtils.CreateAndPopulateList(valueType, delegate(IList populateList)
                                                                {
                                                                  int count = _random.Next(0, 100);
                                                                  for (int i = 0; i < count; i++)
                                                                  {
                                                                    populateList.Add(CreateValue(listContentsType));
                                                                  }
                                                                });
      }

      TypeCode typeCode = Type.GetTypeCode(valueType);

      switch (typeCode)
      {
        case TypeCode.Boolean:
          return RandomUtils.GetBoolean(_random);
        case TypeCode.Byte:
          return Convert.ToByte(_random.Next(byte.MinValue, byte.MaxValue));
        case TypeCode.Char:
          return Convert.ToChar(_random.Next(char.MinValue, char.MaxValue));
        case TypeCode.DateTime:
          return new DateTime(_random.Next(int.MaxValue));
        case TypeCode.Decimal:
          return Convert.ToDecimal(_random.Next(int.MaxValue));
        case TypeCode.Double:
          return _random.NextDouble();
        case TypeCode.Int16:
          return Convert.ToInt16(_random.Next(Int16.MinValue, Int16.MaxValue));
        case TypeCode.Int32:
          return _random.Next(Int32.MinValue, Int32.MaxValue);
        case TypeCode.Int64:
          return RandomUtils.GetInt64(_random);
        case TypeCode.SByte:
          return Convert.ToSByte(_random.Next(SByte.MinValue, SByte.MaxValue));
        case TypeCode.Single:
          return Convert.ToSingle(_random.Next(SByte.MinValue, SByte.MaxValue));
        case TypeCode.String:
          return Guid.NewGuid().ToString();
        case TypeCode.UInt16:
          return Convert.ToUInt16(_random.Next(0, UInt16.MaxValue));
        case TypeCode.UInt32:
          return RandomUtils.GetUInt32(_random);
        case TypeCode.UInt64:
          return RandomUtils.GetUInt64(_random);
        default:
          if (ReflectionUtils.IsInstantiatableType(valueType))
            return Activator.CreateInstance(valueType);
          else
            throw new Exception(string.Format("Cannot create random value for type {0}.", valueType));
      }
    }

    public bool CanCreateValue(Type valueType)
    {
      // hack
      try
      {
        CreateValue(valueType);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}