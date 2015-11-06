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
using System.Reflection;
using System.Web;
using System.Collections.Generic;
using SoftLogik.Collections;
using SoftLogik.Reflection;

namespace SoftLogik.Web
{
  /// <summary>
  /// Marks a field or property as being bound to a specific parameter present in the
  /// <see cref="System.Web.HttpRequest"/>. This attribute is normally only
  /// applied to subclasses of <see cref="System.Web.UI.Page"/>
  /// </summary>
  /// <example>
  /// Here a simple page class marks field with the attribute, and then
  /// calls the static WebParameterAttribute.SetValues() method to
  /// automatically load the fields with value from Request.Form or Request.QueryString
  /// (depending on what was used to submit the form). Note that since
  /// parameter binding in this example is done both on first-request
  /// and on postback, this page must always be either linked to supplying
  /// data in the querystring, or cross-posted to with the data in the Form.
  /// <code><![CDATA[
  /// public class BoundParameterDemo : System.Web.UI.Page{
  ///		[WebParameter()]
  ///		protected string FirstName;
  ///
  ///		[WebParameter("Last_Name")]
  ///		protected string LastName;
  ///
  ///		[WebParameter(IsRequired=true)]
  ///		protected int CustomerID;
  ///
  ///		private void Page_Load(object sender, System.EventArgs e) {
  ///			WebParameterAttribute.SetValues(this, Request);
  ///		}
  ///	}
  /// ]]>
  /// </code>
  /// </example>
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public abstract class WebParameterAttribute : Attribute
  {
    #region Declarations
    object _defaultValue;
    string _parameterName;
    bool _isRequired = false;
    bool _isDefaultForInvalid = false;
    bool _overwriteNonDefaultValue = true;
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new WebParameterAttribute to load a field from an identically-named
    /// parameter in the Form/QueryString collection, if it exists.
    /// The parameter has no default value, and is not required
    /// </summary>
    protected WebParameterAttribute()
    {
    }

    /// <summary>
    /// Creates a new WebParameterAttribute to load a field from the given parameter name
    /// The parameter has no default value, and is not required
    /// </summary>
    /// <param name="paramName">The key of a parameter in the Form or QueryString collections</param>
    protected WebParameterAttribute(string paramName)
    {
      _parameterName = paramName;
    }
    #endregion

    /// <summary>
    /// The name (key) of the parameter being bound against in the Request
    /// </summary>
    public string ParameterName
    {
      get { return _parameterName; }
      set { _parameterName = value; }
    }
    /// <summary>
    /// An optional default value to use if the parameter doesn't exist
    /// in the current Request, or null to clear
    /// </summary>
    /// <remarks>Whilst this is a bit unneccesary for a field, its
    /// handy for properties - can save all that <code>if(ViewState["x"]==null)</code>
    /// stuff...</remarks>
    public object DefaultValue
    {
      get { return _defaultValue; }
      set { _defaultValue = value; }
    }

    /// <summary>
    /// Whether the absence of the parameter, along with the absence
    /// of a default, causes an error, rather than the default
    /// behaviour which is that the field will just be skipped.
    /// The default is false.
    /// </summary>
    public bool IsRequired
    {
      get { return _isRequired; }
      set { _isRequired = value; }
    }
    /// <summary>
    /// Whether the default value can be used if the value passed to
    /// the page is invalid in some way (rejected by the type converter,
    /// or causes an error on the field/property set).
    /// The default is false.
    /// </summary>
    public bool IsDefaultUsedForInvalid
    {
      get { return _isDefaultForInvalid; }
      set { _isDefaultForInvalid = value; }
    }

    /// <summary>
    /// Whether the value is retrieved from the parameter
    /// on post back.
    /// </summary>
    public bool OverwriteNonDefaultValue
    {
      get { return _overwriteNonDefaultValue; }
      set { _overwriteNonDefaultValue = value; }
    }

    /// <summary>
    /// Retrieves an item either from the Query or POST collections, depending on the
    /// mode of the request, or performs custom retrieval in derived classes
    /// </summary>
    protected abstract string GetValue(string paramName, HttpRequest request);

    /// <summary>
    /// Sets public properties and fields on <c>target</c> that are marked with
    /// <see cref="WebParameterAttribute"/> to the corresponding values retrieved from
    /// <c>request</c>, or a default value as set on the attribute
    /// </summary>
    /// <param name="target">The object (typically a <see cref="System.Web.UI.Page"/>) being bound</param>
    /// <param name="request">The <see cref="System.Web.HttpRequest"/> to load the data from.
    /// The attribute determines whether data is loaded from request.Form, request.QueryString
    /// or other parts of request</param>
    public static void SetValues(object target, HttpRequest request, bool isPostBack)
    {
      // Get the page type
      Type pageType = target.GetType().BaseType;

      List<MemberInfo> targetMembers = ReflectionUtils.GetFieldsAndProperties(pageType, BindingFlags.Instance | BindingFlags.Public);

      // Loop over the fields and properties
      for (int i = 0; i < targetMembers.Count; i++)
        SetValue(targetMembers[i], target, request, isPostBack);
    }

    public static T GetAttribute<T>(MemberInfo member) where T : Attribute
    {
      T[] attributes = (T[])member.GetCustomAttributes(typeof(T), true);

      if (!CollectionUtils.IsNullOrEmpty<T>(attributes))
        return attributes[0];
      else
        return null;
    }

    /// <summary>
    /// Examines a single <c>member</c> (a property or field) for <see cref="WebParameterAttribute"/>.
    /// If so marked then the member is set on <c>target</c> with the relevant value
    /// retrieved from <c>request</c>, or the default value provided in the attribute
    /// </summary>
    /// <param name="target">The object (typically a <see cref="System.Web.UI.Page"/>) being bound</param>
    /// <param name="request">The <see cref="System.Web.HttpRequest"/> to load the data from.
    /// The attribute determines whether data is loaded from request.Form, request.QueryString
    /// or other parts of request</param>
    private static void SetValue(MemberInfo member, object target, HttpRequest request, bool isPostBack)
    {
      WebParameterAttribute attrib;
      TypeConverter converter;
      object paramValue;
      string paramName;

      attrib = ReflectionUtils.GetAttribute<WebParameterAttribute>(member, true);

      if (attrib != null)
      {
        // Use the attribute name if supplied, otherwise use the member's name
        if (attrib.ParameterName != null)
          paramName = attrib.ParameterName;
        else
          paramName = member.Name;

        // Make sure we're not going after an indexed property
        if (member.MemberType == MemberTypes.Property)
        {
          ParameterInfo[] ps = ((PropertyInfo)member).GetIndexParameters();

          if (!CollectionUtils.IsNullOrEmpty<ParameterInfo>(ps))
            throw new NotSupportedException(string.Format("Parameter '{0}' applied to an indexed Property. Cannot apply WebParameterAttribute to indexed property", paramName));
        }

        Type underlyingType = ReflectionUtils.GetMemberUnderlyingType(member);

        // If a default is supplied, insure it is of the underlying type
        if (attrib.DefaultValue != null)
        {
          if (!underlyingType.IsAssignableFrom(attrib.DefaultValue.GetType()))
          {
            throw new ApplicationException(string.Format("The default value for the parameter '{0}' has different type then the one of the property itself.", paramName));
          }
        }

        if (!attrib.OverwriteNonDefaultValue)
        {
          // return if member value is non default or empty string
          object currentMemberValue = ReflectionUtils.GetMemberValue(member, target);

          bool isDefaultValue;

          if (underlyingType == typeof(string))
            isDefaultValue = string.IsNullOrEmpty((string)currentMemberValue);
          else
            isDefaultValue = ReflectionUtils.IsUnitializedValue(currentMemberValue);

          // value is not default. don't set value
          if (!isDefaultValue)
            return;
        }

        // Use parameter name to get the value from the request object
        paramValue = attrib.GetValue(paramName, request);

        if (paramValue != null)
        {
          // Now assign the loaded value onto the member, using the relevant type converter
          // Have to perform the assignment slightly differently for fields and properties
          converter = TypeDescriptor.GetConverter(underlyingType);

          if (converter == null || !converter.CanConvertFrom(paramValue.GetType()))
            throw new ApplicationException(string.Format("Could not convert from {0} to {1}", paramValue.GetType(), underlyingType));

          if (ReflectionUtils.CanSetMemberValue(member))
          {
            try
            {
              ReflectionUtils.SetMemberValue(member, target, converter.ConvertFrom(paramValue));
            }
            catch
            {
              // We catch errors both from the type converter
              // and from any problems in setting the field/property
              // (eg property-set rules, security, readonly properties)

              // If there is a default and it is used for invalid data
              // then set member to default

              if (attrib.IsDefaultUsedForInvalid && attrib.DefaultValue != null)
              {
                ReflectionUtils.SetMemberValue(member, target, attrib.DefaultValue);
              }
              else
              {
                throw;
              }
            }
          }
          else
          {
            throw new Exception(string.Format("Member '{0}' on type '{1}' could not be set.", member.Name, member.DeclaringType.FullName));
          }
        }
        else if (attrib.DefaultValue != null)
        {
          ReflectionUtils.SetMemberValue(member, target, attrib.DefaultValue);
        }
        else
        {
          if (attrib.IsRequired)
            throw new ApplicationException(string.Format("Required parameter '{0}' evaluated to null", paramName));

          // Throw an error if cannot assign null to member's underlying type
          if (!ReflectionUtils.IsNullable(underlyingType))
            throw new ApplicationException(string.Format("Parameter '{0}' mapped to a non-nullable ValueType evaluated to null", paramName));

          ReflectionUtils.SetMemberValue(member, target, null);
        }
      }
    }
  }
}