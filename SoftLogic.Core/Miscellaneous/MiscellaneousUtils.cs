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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using SoftLogik.Reflection;

namespace SoftLogik.Miscellaneous
{
  public delegate void Action();
  public delegate T Creator<T>();
  public delegate T Func<A0, T>(A0 arg0);
  public delegate T Func<A0, A1, T>(A0 arg0, A1 arg1);
  public delegate T Func<A0, A1, A2, T>(A0 arg0, A1 arg1, A2 arg2);

  public static class MiscellaneousUtils
  {
    public static bool TryAction<T>(Creator<T> creator, out T output)
    {
      ValidationUtils.ArgumentNotNull(creator, "creator");

      try
      {
        output = creator();
        return true;
      }
      catch
      {
        output = default(T);
        return false;
      }
    }

    public static bool TryGetDescription(object value, out string description)
    {
      return TryAction<string>(delegate { return GetDescription(value); }, out description);
    }

    public static string GetDescription(object o)
    {
      ValidationUtils.ArgumentNotNull(o, "o");

      ICustomAttributeProvider attributeProvider = o as ICustomAttributeProvider;

      // object passed in isn't an attribute provider
      // if value is an enum value, get value field member, otherwise get values type
      if (attributeProvider == null)
      {
        Type valueType = o.GetType();

        if (valueType.IsEnum)
          attributeProvider = valueType.GetField(o.ToString());
        else
          attributeProvider = valueType;
      }

      DescriptionAttribute descriptionAttribute = ReflectionUtils.GetAttribute<DescriptionAttribute>(attributeProvider);

      if (descriptionAttribute != null)
        return descriptionAttribute.Description;
      else
        throw new Exception(string.Format("No DescriptionAttribute on '{0}'.", o.GetType()));
    }

    public static IList<string> GetDescriptions(IList values)
    {
      ValidationUtils.ArgumentNotNull(values, "values");

      string[] descriptions = new string[values.Count];

      for (int i = 0; i < values.Count; i++)
      {
        descriptions[i] = GetDescription(values[i]);
      }

      return descriptions;
    }

    public static string ToString(object value)
    {
      return (value != null) ? value.ToString() : "{null}";
    }
  }
}
