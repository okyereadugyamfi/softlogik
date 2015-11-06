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
using System.Reflection;
using System.ComponentModel;
using SoftLogik.Miscellaneous;
using SoftLogik.Reflection;

namespace SoftLogik.Testing
{
  /// <summary>
  /// For use in unit tests, the ClassTester offers a number of benefits
  ///     - increased coverage testing all those property setters and getters that normally get ignored
  ///     - tests that simple properties are wired up correctly
  ///     - tests the implementation of INotifyPropertyChanged for classes that implement it
  ///     - testing of constructors including mapping of parameters to properties with the same name
  /// For more information, see the help on the TestProperties method and the static TestConstructors method.
  /// It is designed to test simple POCO classes only - any complicated properties or constructors
  /// should be tested with a manual unit test as normal. It is important to use this tool in 
  /// conjunction with code coverage to ensure you are getting the coverage you think you are.
  /// </summary>
  public class ClassTester
  {
    private readonly bool _checkNotifyPropertyChanged;
    private readonly object _subject;
    private readonly Type _subjectType;
    private readonly List<String> _ignoredProperties = new List<string>();
    private readonly IValueCreator _valueCreator;
    private string _lastPropertyChanged;
    private int _maxLoopsPerProperty = 1000;

    public ClassTester(object subject, IValueCreator valueCreator)
    {
      ValidationUtils.ArgumentNotNull(valueCreator, "valueCreator");
      ValidationUtils.ArgumentNotNull(subject, "subject");

      _valueCreator = valueCreator;
      _subject = subject;
      _subjectType = _subject.GetType();

      if (subject is INotifyPropertyChanged)
      {
        _checkNotifyPropertyChanged = true;
        INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged)subject;
        notifyPropertyChanged.PropertyChanged += PropertyChanged;
      }
    }

    public ClassTester(object subject) : this(subject, RandomValueCreator.Default)
    {
    }

    /// <summary>
    /// When trying to create random values, how many attempts should the algorithm
    /// have at creating different values before erroring.
    /// </summary>
    public int MaxLoopsPerProperty
    {
      get { return _maxLoopsPerProperty; }
      set { _maxLoopsPerProperty = value; }
    }

    public IList<String> IgnoredProperties
    {
      get { return _ignoredProperties; }
    }

    /// <summary>
    /// Tests the constructors of the specified type be generating, where possible, random
    /// values and newing up the object. If testMappedProperties is specified as true, the 
    /// tester will also check to make sure that the value passed to any constructor parameters
    /// is also the value of any properties with the same name (case-insensitive) on the object.
    /// If the class has any constructors that require types that have no default value (such as
    /// an interface) this method will fail with a TesterException.
    /// </summary>
    /// <param name="type">The type to test</param>
    /// <param name="testMappedProperties">Whether to test properties with the same name as the constructor parameters</param>
    public static void TestConstructors(Type type, bool testMappedProperties)
    {
      TestConstructors(type, testMappedProperties, RandomValueCreator.Default);
    }

    internal static void TestConstructors(Type type, bool testMappedProperties, IValueCreator valueCreator)
    {
      ValidationUtils.ArgumentNotNull(valueCreator, "valueCreator");

      ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

      foreach (ConstructorInfo constructor in constructors)
      {
        ParameterInfo[] parameters = constructor.GetParameters();
        object[] paramValues = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
          paramValues[i] = valueCreator.CreateValue(parameters[i].ParameterType);
        }
        object result = constructor.Invoke(paramValues);

        if (testMappedProperties)
        {
          for (int i = 0; i < parameters.Length; i++)
          {
            PropertyInfo mappedProperty = type.GetProperty(
                parameters[i].Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (mappedProperty != null && mappedProperty.CanRead)
            {
              object valueOut = mappedProperty.GetValue(result, null);

              if (!(Equals(paramValues[i], valueOut)))
              {
                throw new ClassTesterException(string.Format(
                    "The value of the '{0}' property did not equal the value set with the '{1}' constructor parameter (in: '{2}', out: '{3}')",
                    mappedProperty.Name,
                    parameters[i].Name,
                    valueOut,
                    paramValues[i]));
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Tests set (where the property is settable) and get (where the property is gettable) for
    /// all properties on the instance of the object used to construct this ClassTester instance.
    /// If the instance implements INotifyPropertyChanged, the tester will also check to ensure that
    /// when the property is changed, it fires the appropriate event. Properties are changed by 
    /// generating two random values and setting twice.
    /// 
    /// Properties with non default types (such as interfaces) will be skipped. It is important to 
    /// utilise this test in conjunction with a code coverage tool to ensure the bits you think are
    /// being tested actually are.
    /// 
    /// The tester will try MaxLoopsPerProperty attempts at generating two different random values.
    /// If the class can't generate two random values (because it doesn't understand the type) then
    /// consider ignoring that problem property and testing it manually.
    /// </summary>
    public void TestProperties()
    {
      PropertyInfo[] properties = _subjectType.GetProperties();

      foreach (PropertyInfo property in properties)
      {
        // we can only SET if the property is writable and we can new up the type
        bool testSet = (property.CanWrite && _valueCreator.CanCreateValue(property.PropertyType));
        bool testGet = property.CanRead;

        if (IgnoreProperty(property) || ReflectionUtils.IsPropertyIndexed(property))
        {
          // skip this property - we can't test indexers or properties
          // we've been asked to ignore
          continue;
        }
        object valueIn2 = null;

        // we can only set properties 
        if (testSet)
        {
          // We need two 'in' values to ensure the property actually changes.
          // because the values are random - we need to loop to make sure we
          // get different ones (i.e. bool);
          object valueIn1 = _valueCreator.CreateValue(property.PropertyType);
          valueIn2 = valueIn1;
          // safety net 
          int counter = 0;
          while (Equals(valueIn1, valueIn2))
          {
            if (counter++ > _maxLoopsPerProperty)
            {
              throw new InvalidOperationException(string.Format(
                "Could not generate two different values for the type '{0}'. Consider ignoring the '{1}' property or increasing the MaxLoopsPerProperty value above {2}.",
                property.PropertyType,
                property.Name,
                _maxLoopsPerProperty));
            }
            valueIn2 = _valueCreator.CreateValue(property.PropertyType);
          }

          ReflectionUtils.SetMemberValue(property, _subject, valueIn1);
          ReflectionUtils.SetMemberValue(property, _subject, valueIn2);

          // TODO - do we need to consider threads here?
          if (_checkNotifyPropertyChanged)
          {
            if (_lastPropertyChanged != property.Name)
            {
              throw new ClassTesterException(string.Format(
                  "The property '{0}' did not throw a PropertyChangedEvent",
                  property.Name));
            }
            _lastPropertyChanged = null;
          }
        }

        if (testGet)
        {
          object valueOut = ReflectionUtils.GetMemberValue(property, _subject);

          // if we can also write - we should test the value
          // we written to the variable.
          if (testSet)
          {
            if (!Equals(valueIn2, valueOut))
            {
              throw new ClassTesterException(string.Format(
                  "The get value of the '{0}' property did not equal the set value (in: '{1}', out: '{2}')",
                  property.Name,
                  valueOut,
                  valueIn2));
            }
          }
        }
      }
    }

    private bool IgnoreProperty(PropertyInfo property)
    {
      return _ignoredProperties.Contains(property.Name);
    }

    private void PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      _lastPropertyChanged = e.PropertyName;
    }
  }
}