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
using System.Globalization;
using System.Resources;
using System.Reflection;
using SoftLogik.Miscellaneous;

namespace SoftLogik.Resources
{
  public class ResourceLoader : IResourceGetter
  {
    private readonly ResourceManager _resourceManager;

    public ResourceLoader(Assembly resourceAssembly)
    {
      ValidationUtils.ArgumentNotNull(resourceAssembly, "resourceAssembly");

      // assembly that resources are loader from is determined by the assembly of the assembly marker type
      string assemblyName = resourceAssembly.GetName().Name;

      List<string> assemblyResourceNames = new List<string>(resourceAssembly.GetManifestResourceNames());

      List<string> possibleResourceNames = new List<string>();
      // location in Microsoft assemblies
      possibleResourceNames.Add(assemblyName);
      // location of generated file in 2005 projects
      possibleResourceNames.Add(assemblyName + ".Properties.Resources");

      // look at a couple of locations for the resources file, loading the first one found
      foreach (string possibleResourceName in possibleResourceNames)
      {
        if (assemblyResourceNames.Contains(possibleResourceName + ".resources"))
        {
          _resourceManager = new ResourceManager(possibleResourceName, resourceAssembly);
          break;
        }
      }

      if (_resourceManager == null)
        throw new Exception(string.Format("Could not find embedded resource file for assembly {0}.", assemblyName));
    }

    public ResourceManager ResourceManager
    {
      get { return _resourceManager; }
    }

    public string GetString(string name)
    {
      string resourceValue = _resourceManager.GetString(name);

      if (resourceValue == null)
        throw new Exception(string.Format("Resource '{0}' not found in {1}.", name, _resourceManager.BaseName));

      return resourceValue;
    }

    public string GetString(string name, params object[] values)
    {
      string resourceValue = GetString(name);

      return string.Format(CultureInfo.CurrentCulture, resourceValue, values);
    }

    public object GetObject(string name)
    {
      object resourceValue = _resourceManager.GetObject(name);

      if (resourceValue == null)
        throw new Exception(string.Format("Resource '{0}' not found in {1}.", name, _resourceManager.BaseName));

      return resourceValue;
    }

    public T GetObject<T>(string name)
    {
      object value = GetObject(name);

      if (!(value is T))
        throw new Exception(string.Format("Resource '{0}' is of type {1}, not {2}.", name, value.GetType(), typeof(T)));

      return (T)value;
    }
  }
}