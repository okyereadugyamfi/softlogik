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
using System.Configuration;
using SoftLogik.Miscellaneous;

namespace SoftLogik.Configuration
{
  public abstract class ConfigurationElementCollectionBase<T> :
    ConfigurationElementCollection where T : ConfigurationElement, IIdentifiable
  {
    public override ConfigurationElementCollectionType CollectionType
    {
      get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
    }

    public T this[int index]
    {
      get { return (T)BaseGet(index); }
      set
      {
        if (BaseGet(index) != null)
          BaseRemoveAt(index);

        BaseAdd(index, value);
      }
    }

    new public T this[string key]
    {
      get { return (T)BaseGet(key); }
    }

    public void Add(T element)
    {
      BaseAdd(element);
    }

    public void Clear()
    {
      BaseClear();
    }

    public bool Contains(string key)
    {
      return (BaseGet(key) != null);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return Activator.CreateInstance<T>();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((T)element).Id;
    }

    public void Remove(T element)
    {
      Remove(element.Id);
    }

    public void Remove(string key)
    {
      BaseRemove(key);
    }

    public void RemoveAt(int index)
    {
      BaseRemoveAt(index);
    }
  }
}