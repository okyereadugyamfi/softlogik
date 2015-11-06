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
using SoftLogik.Miscellaneous;

namespace SoftLogik.Testing
{
  public class AssertTest<T>
  {
    private readonly Predicate<T> _test;
    private readonly string _message;
    private bool _passed;

    public AssertTest(Predicate<T> test, string message)
    {
      ValidationUtils.ArgumentNotNull(test, "test");
      ValidationUtils.ArgumentNotNullOrEmpty(message, "message");

      _test = test;
      _message = message;
    }

    public string Message
    {
      get { return _message; }
    }

    public Predicate<T> Test
    {
      get { return _test; }
    }

    public bool Passed
    {
      get { return _passed; }
      set { _passed = value; }
    }
  }

  public static class TestingUtils
  {
    public static void TestCollection<T>(IList<T> list, IList<AssertTest<T>> tests)
    {
      ValidationUtils.ArgumentNotNull(list, "list");
      ValidationUtils.ArgumentNotNull(tests, "tests");

      List<AssertTest<T>> nonPassedTests = new List<AssertTest<T>>(tests);

      foreach (T t in list)
      {
        for (int i = nonPassedTests.Count - 1; i >= 0; i--)
        {
          AssertTest<T> test = nonPassedTests[i];
          bool testResult = test.Test(t);

          if (testResult)
          {
            test.Passed = true;
            nonPassedTests.RemoveAt(i);
          }
        }

        if (nonPassedTests.Count == 0)
          break;
      }

      foreach (AssertTest<T> nonPassedTest in nonPassedTests)
      {
        throw new Exception(nonPassedTest.Message);
      }
    }
  }
}