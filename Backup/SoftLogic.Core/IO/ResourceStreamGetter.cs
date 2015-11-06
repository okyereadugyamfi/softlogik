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
using System.IO;
using System.Reflection;

namespace SoftLogik.IO
{
  public class ResourceStreamGetter : IStreamGetter
  {
    private Assembly _resourceAssembly;
    private string _resourceName;

    public Assembly ResourceAssembly
    {
      get { return _resourceAssembly; }
      set { _resourceAssembly = value; }
    }

    public string ResourceName
    {
      get { return _resourceName; }
      set { _resourceName = value; }
    }

    public Stream GetStream()
    {
      if (string.IsNullOrEmpty(_resourceName))
        throw new InvalidOperationException("ResourceName must be set.");

      // if resource assembly has not been set, default to the currently executing assembly
      Assembly assembly = _resourceAssembly ?? Assembly.GetExecutingAssembly();
      Stream resourceStream = assembly.GetManifestResourceStream(_resourceName);

      if (resourceStream == null)
        throw new Exception(string.Format("Could not find resource '{0}' in assmebly '{1}'.", _resourceName, assembly.FullName));

      return resourceStream;
    }
  }
}