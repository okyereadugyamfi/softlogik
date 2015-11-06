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

using System.Reflection;
using System.Resources;

namespace SoftLogik.Resources
{
  public class ResourceLoader<TAssemblyMarker> : ResourceLoader
  {
    private readonly static object _sync;
    private static IResourceGetter _instance;

    static ResourceLoader()
    {
      _sync = new object();
    }

    protected ResourceLoader(Assembly resourceAssembly)
      : base(resourceAssembly)
    {
    }

    public static IResourceGetter ResourceGetterInstance
    {
      get
      {
        if (_instance == null)
        {
          lock (_sync)
          {
            if (_instance == null)
              _instance = new ResourceLoader<TAssemblyMarker>(typeof(TAssemblyMarker).Assembly);
          }
        }

        return _instance;
      }
    }

    public new static ResourceManager ResourceManager
    {
      get { return ResourceGetterInstance.ResourceManager; }
    }

    public new static string GetString(string name)
    {
      return ResourceGetterInstance.GetString(name);
    }

    public new static string GetString(string name, params object[] values)
    {
      return ResourceGetterInstance.GetString(name, values);
    }

    public new static object GetObject(string name)
    {
      return ResourceGetterInstance.GetObject(name);
    }

    public new static T GetObject<T>(string name)
    {
      return ResourceGetterInstance.GetObject<T>(name);
    }
  }
}