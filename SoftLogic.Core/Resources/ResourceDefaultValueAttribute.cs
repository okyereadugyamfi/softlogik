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
using System.ComponentModel;

namespace SoftLogik.Resources
{
  [AttributeUsage(AttributeTargets.All)]
  public abstract class ResourceDefaultValueAttribute : DefaultValueAttribute
  {
    private bool _localized;
    private readonly Type _type;
    private IResourceGetter _resourceLoader;

    protected IResourceGetter ResourceLoader
    {
      get
      {
        if (_resourceLoader == null)
          _resourceLoader = Create();

        return _resourceLoader;
      }
    }

    public override object TypeId
    {
      get { return typeof(DefaultValueAttribute); }
    }

    public override object Value
    {
      get
      {
        if (!_localized)
        {
          _localized = true;
          string resourceKey = (string)base.Value;

          if (!string.IsNullOrEmpty(resourceKey))
          {
            object defaultValue = ResourceLoader.GetString("Default_" + resourceKey);

            if (_type != null)
            {
              try
              {
                defaultValue = TypeDescriptor.GetConverter(_type).ConvertFromInvariantString((string)defaultValue);
              }
              catch (NotSupportedException)
              {
                defaultValue = null;
              }
            }

            base.SetValue(defaultValue);
          }
        }
        return base.Value;
      }
    }

    public ResourceDefaultValueAttribute(string value)
      : base(value)
    {
    }

    public ResourceDefaultValueAttribute(Type type, string value)
      : base(value)
    {
      _type = type;
    }

    protected abstract IResourceGetter Create();
  }
}