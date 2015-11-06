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
using System.Threading;

namespace SoftLogik.Miscellaneous
{
  public class SingletonProvider<T> where T : class
  {
    private readonly object _lockObject = new object();
    private T _instance;
    private Creator<T> _creator;

    public SingletonProvider(Creator<T> creator)
    {
      ValidationUtils.ArgumentNotNull(creator, "creator");

      _creator = creator;
    }

    public T Value
    {
      get
      {
        if (_instance == null)
        {
          lock (_lockObject)
          {
            if (_instance == null)
            {
              T instance = _creator();

              if (instance == null)
                throw new Exception("Creator delegate cannot return null.");

              Thread.MemoryBarrier();
              _instance = instance;
              _creator = null;
            }
          }
        }

        return _instance;
      }
    }
  }
}