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
using SoftLogik.Miscellaneous;

namespace SoftLogik.Text
{
  /// <summary>
  /// Builds a string. Unlike StringBuilder this class lets you reuse it's internal buffer.
  /// </summary>
  internal class StringBuffer
  {
    private char[] _buffer;
    private int _position;

    private static readonly char[] _emptyBuffer = new char[0];

    public int Position
    {
      get { return _position; }
      set
      {
        ValidationUtils.ArgumentNotNegative<int>(value, "value");
        _position = value;
      }
    }

    public StringBuffer()
    {
      _buffer = _emptyBuffer;
    }

    public StringBuffer(int initialSize)
    {
      ValidationUtils.ArgumentNotNegative<int>(initialSize, "initialSize");

      _buffer = new char[initialSize];
    }

    public StringBuffer(char[] internalBuffer)
    {
      ValidationUtils.ArgumentNotNull(internalBuffer, "internalBuffer");

      _buffer = internalBuffer;
      _position = internalBuffer.Length;
    }

    public void Append(char value)
    {
      // ensure buffer array is large enough to contain value
      if (_position + 1 > _buffer.Length)
        EnsureSize(1);

      // set value and increment poisition
      _buffer[_position++] = value;
    }

    public void Append(char[] value)
    {
      if (value == null)
        return;

      // ensure buffer array is large enough to contain value
      if (_position + value.Length > _buffer.Length)
        EnsureSize(value.Length);

      for (int i = 0; i < value.Length; i++)
      {
        _buffer[_position++] = value[i];
      }
    }

    public void Clear()
    {
      // release buffer memory
      _buffer = _emptyBuffer;
      _position = 0;
    }

    private void EnsureSize(int appendLength)
    {
      // double buffer size
      char[] newBuffer = new char[(_position + appendLength) * 2];
      int copyLength = (_buffer.Length < _position) ? _buffer.Length : _position;

      Array.Copy(_buffer, newBuffer, copyLength);

      _buffer = newBuffer;
    }

    public override string ToString()
    {
      return new string(_buffer, 0, _position);
    }
  }
}