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
using System.Web;

namespace SoftLogik.Web
{
  /// <summary>
  /// A <see cref="WebParameterAttribute"/> that's specifically bound to the
  /// a parameter in the query string (Request.QueryString collection)
  /// </summary>
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public sealed class QueryParameterAttribute : WebParameterAttribute
  {
    private bool _decode;

    public bool Decode
    {
      get { return _decode; }
      set { _decode = value; }
    }

    #region Constructors
    /// <summary>
    /// Creates a new QueryParameterAttribute to load a field from an identically-named
    /// parameter in the QueryString collection, if it exists.
    /// The parameter has no default value, and is not required
    /// </summary>
    public QueryParameterAttribute()
    {
    }

    /// <summary>
    /// Creates a new QueryParameterAttribute to load a field from the given parameter
    /// in the QueryString collection, if it exists.
    /// The parameter has no default value, and is not required
    /// </summary>
    /// <param name="paramName">The key of a parameter in the QueryString collections</param>
    public QueryParameterAttribute(string paramName)
      : base(paramName)
    {
    }
    #endregion

    /// <summary>
    /// Retrieves an item from the QueryString by key
    /// </summary>
    protected override string GetValue(string paramName, HttpRequest request)
    {
      string value = request.QueryString[paramName];

      if (_decode)
        value = HttpUtility.UrlDecode(value);

      return value;
    }
  }
}