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

using System.Collections;
using System.Collections.Generic;
using SoftLogik.Miscellaneous;

namespace SoftLogik.Collections
{
  public class EnumerableWrapper<T> : IEnumerable<T>
  {
    private readonly IEnumerable _enumerable;
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

    public EnumerableWrapper(IEnumerable e)
      : this(e, false, false)
    {
    }

    public EnumerableWrapper(IEnumerable e, bool defaultOnBadType, bool convertNonCompatibleType)
    {
      ValidationUtils.ArgumentNotNull(e, "e");

      _defaultOnBadType = defaultOnBadType;
      _convertNonCompatibleType = convertNonCompatibleType;
      _enumerable = e;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new EnumeratorWrapper<T>(_enumerable.GetEnumerator(), _defaultOnBadType, _convertNonCompatibleType);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}