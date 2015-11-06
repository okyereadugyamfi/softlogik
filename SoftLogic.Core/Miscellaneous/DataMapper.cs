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
using System.Globalization;
using SoftLogik.Reflection;

namespace SoftLogik.Miscellaneous
{
  /// <summary>
  /// Map data from a source into a target object
  /// by copying public property values.
  /// </summary>
  /// <remarks></remarks>
  public static class DataMapper
  {
    #region Map from IDictionary

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">A name/value dictionary containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <remarks>
    /// The key names in the dictionary must match the property names on the target
    /// object. Target properties may not be readonly or indexed.
    /// </remarks>
    public static void Map(System.Collections.IDictionary source, object target)
    {
      Map(source, target, false);
    }

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">A name/value dictionary containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <param name="ignoreList">A list of property names to ignore. 
    /// These properties will not be set on the target object.</param>
    /// <remarks>
    /// The key names in the dictionary must match the property names on the target
    /// object. Target properties may not be readonly or indexed.
    /// </remarks>
    public static void Map(System.Collections.IDictionary source, object target, params string[] ignoreList)
    {
      Map(source, target, false, ignoreList);
    }

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">A name/value dictionary containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <param name="ignoreList">A list of property names to ignore. 
    /// These properties will not be set on the target object.</param>
    /// <param name="suppressExceptions">If <see langword="true" />, any exceptions will be supressed.</param>
    /// <remarks>
    /// The key names in the dictionary must match the property names on the target
    /// object. Target properties may not be readonly or indexed.
    /// </remarks>
    public static void Map(
      System.Collections.IDictionary source,
      object target, bool suppressExceptions,
      params string[] ignoreList)
    {
      List<string> ignore = new List<string>(ignoreList);
      foreach (string propertyName in source.Keys)
      {
        if (!ignore.Contains(propertyName))
        {
          try
          {
            SetPropertyValue(target, propertyName, source[propertyName]);
          }
          catch (Exception ex)
          {
            if (!suppressExceptions)
              throw new ArgumentException(
                String.Format("{0} ({1})",
                "Property copy failed", propertyName), ex);
          }
        }
      }
    }

    #endregion

    #region Map from Object

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">An object containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <remarks>
    /// The property names and types of the source object must match the property names and types
    /// on the target object. Source properties may not be indexed. 
    /// Target properties may not be readonly or indexed.
    /// </remarks>
    public static void Map(object source, object target)
    {
      Map(source, target, false, MemberTypes.Property, BindingFlags.Public | BindingFlags.Instance);
    }

    public static void Map(object source, object target, MemberTypes memberTypes)
    {
      Map(source, target, false, memberTypes, BindingFlags.Public | BindingFlags.Instance);
    }

    public static void Map(object source, object target, MemberTypes memberTypes, BindingFlags bindingAttr)
    {
      Map(source, target, false, memberTypes, bindingAttr);
    }

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">An object containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <param name="ignoreList">A list of property names to ignore. 
    /// These properties will not be set on the target object.</param>
    /// <remarks>
    /// The property names and types of the source object must match the property names and types
    /// on the target object. Source properties may not be indexed. 
    /// Target properties may not be readonly or indexed.
    /// </remarks>
    public static void Map(object source, object target, params string[] ignoreList)
    {
      Map(source, target, false, MemberTypes.Property, BindingFlags.Public | BindingFlags.Instance, ignoreList);
    }

    /// <summary>
    /// Copies values from the source into the
    /// properties of the target.
    /// </summary>
    /// <param name="source">An object containing the source values.</param>
    /// <param name="target">An object with properties to be set from the dictionary.</param>
    /// <param name="ignoreList">A list of property names to ignore. 
    /// These properties will not be set on the target object.</param>
    /// <param name="memberTypes">The types of members you want to map.</param>
    /// <param name="bindAttr">Specifies which members you want to map.</param>
    /// <param name="suppressExceptions">If <see langword="true" />, any exceptions will be supressed.</param>
    /// <remarks>
    /// <para>
    /// The property names and types of the source object must match the property names and types
    /// on the target object. Source properties may not be indexed. 
    /// Target properties may not be readonly or indexed.
    /// </para><para>
    /// Properties to copy are determined based on the source object. Any properties
    /// on the source object marked with the <see cref="BrowsableAttribute"/> equal
    /// to false are ignored.
    /// </para>
    /// </remarks>
    public static void Map(
      object source, object target,
      bool suppressExceptions,
      MemberTypes memberTypes, BindingFlags bindAttr,
      params string[] ignoreList)
    {
      List<string> ignore = new List<string>(ignoreList);
      Type sourceType = source.GetType();
      List<MemberInfo> memberInfos = new List<MemberInfo>(sourceType.FindMembers(memberTypes, bindAttr, null, null));

      if ((memberTypes & MemberTypes.Field) != 0)
      {
        while ((sourceType = sourceType.BaseType) != null)
        {
          memberInfos.AddRange(sourceType.FindMembers(MemberTypes.Field, bindAttr, null, null));
        }
      }

      foreach (MemberInfo memberInfo in memberInfos)
      {
        string propertyName = memberInfo.Name;

        if (!ignore.Contains(propertyName))
        {
          try
          {
            SetPropertyValue(target, propertyName, ReflectionUtils.GetMemberValue(memberInfo, source));
          }
          catch (Exception ex)
          {
            if (!suppressExceptions)
              throw new ArgumentException(string.Format("{0} ({1})", "Property copy failed", propertyName), ex);
          }
        }
      }
    }

    #endregion

    /// <summary>
    /// Sets an object's property with the specified value,
    /// coercing that value to the appropriate type if possible.
    /// </summary>
    /// <param name="target">Object containing the property to set.</param>
    /// <param name="memberName">Name of the member to set.</param>
    /// <param name="value">Value to set into the member.</param>
    public static void SetPropertyValue(object target, string memberName, object value)
    {
      MemberInfo memberInfo = ReflectionUtils.GetMember(target.GetType(),
        memberName,
        MemberTypes.All,
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

      if (memberInfo == null)
        throw new Exception(string.Format("Could not find MemberInfo '{0}' on '{1}'", memberName, target.GetType()));

      if (value == null)
      {
        ReflectionUtils.SetMemberValue(memberInfo, target, value);
      }
      else
      {
        Type memberType = ReflectionUtils.GetMemberUnderlyingType(memberInfo);
        Type valueType = value.GetType();

        if (memberType.Equals(valueType))
        {
          // types match, just copy value
          ReflectionUtils.SetMemberValue(memberInfo, target, value);
        }
        else
        {
          object convertedValue = ConvertUtils.ConvertOrCast(value, CultureInfo.CurrentCulture, memberType);

          ReflectionUtils.SetMemberValue(memberInfo, target, convertedValue);
        }
      }
    }
  }
}