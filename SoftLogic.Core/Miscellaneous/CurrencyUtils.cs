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

namespace SoftLogik.Miscellaneous
{
  public static class CurrencyUtils
  {
    public const string ValidateDollarString = @"(^\$?(?!0,?\d)\d{1,3}(,?\d{3})*(\.\d\d)?)$";

    /// <summary>
    /// Converts to decimal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static decimal ConvertToDecimal(object value)
    {
      if (value == null)
        throw new ArgumentNullException("value");

      if (value is decimal)
        return (decimal)value;
      else
        return ConvertToDecimal(value.ToString());
    }

    /// <summary>
    /// Converts to decimal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static decimal ConvertToDecimal(string value)
    {
      ValidationUtils.ArgumentNotNullOrEmpty(value, "value");

      // remove whitespace
      string trimmedValue = value.Trim();
      // remove leading $
      trimmedValue = trimmedValue.TrimStart('$');

      return Convert.ToDecimal(trimmedValue);
    }
  }
}
