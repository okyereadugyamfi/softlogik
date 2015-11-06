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
  public class TestDataGetter : IDataGetter
  {
    private readonly IEnumerable<byte[]> _datas;
    private IEnumerator<byte[]> _dataEnumerator;
    private bool _disposed;

    public TestDataGetter(IEnumerable<byte[]> datas)
    {
      ValidationUtils.ArgumentNotNull(datas, "datas");

      _datas = datas;
    }

    public byte[] GetData()
    {

      if (_dataEnumerator == null)
        _dataEnumerator = _datas.GetEnumerator();

      if (!_disposed && _dataEnumerator.MoveNext())
        return _dataEnumerator.Current;
      else
        return null;
    }

    public void Dispose()
    {
      _disposed = true;
    }
  }
}