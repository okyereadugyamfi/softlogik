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
using SoftLogik.Miscellaneous;
using SoftLogik.Reflection;

namespace SoftLogik.Collections
{
  public class EnumeratorWrapper<T> : IEnumerator<T>
  {
    private readonly IEnumerator _enumerator;
    private readonly bool _defaultOnBadType;
    private readonly bool _convertNonCompatibleType;

    public bool DefaultOnBadType
    {
      get { return _defaultOnBadType; }
    }

    public bool ConvertNonCompatibleType
    {
      get { return _convertNonCompatibleType; }
    }

    public EnumeratorWrapper(IEnumerator e) : this(e, false, false)
    {
    }

    public EnumeratorWrapper(IEnumerator e, bool defaultOnBadType, bool convertNonCompatibleType)
    {
      ValidationUtils.ArgumentNotNull(e, "e");

      _defaultOnBadType = defaultOnBadType;
      _convertNonCompatibleType = convertNonCompatibleType;
      _enumerator = e;
    }

    private bool IsCompatibleObject(object value)
    {
      return (value is T || (value == null && ReflectionUtils.IsNullable(typeof(T))));
    }

    public T Current
    {
      get
      {
        object current = _enumerator.Current;

        if (IsCompatibleObject(current))
        {
          return (T)_enumerator.Current;
        }
        else
        {
          if (_convertNonCompatibleType)
          {
            T convertedValue;
            if (ConvertUtils.TryConvert(current, out convertedValue))
              return convertedValue;
          }

          if (_defaultOnBadType)
            return default(T);
          else
            throw new Exception(string.Format("Error converting '{0}' to {1}.", MiscellaneousUtils.ToString(current), typeof(T)));
        }
      }
    }

    public void Dispose()
    {
      IDisposable disposable = _enumerator as IDisposable;

      if (disposable != null)
        disposable.Dispose();
    }

    object IEnumerator.Current
    {
      get { return _enumerator.Current; }
    }

    public bool MoveNext()
    {
      return _enumerator.MoveNext();
    }

    public void Reset()
    {
      _enumerator.Reset();
    }
  }
}