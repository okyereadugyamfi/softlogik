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
using System.Configuration;

namespace SoftLogik.Miscellaneous
{
  public static class ConfigUtils
  {
    /// <summary>
    /// Gets the value from the applications appSettings. This will error if the appSetting is not defined.
    /// </summary>
    /// <param name="appSettingName">Name of the appSettings key.</param>
    /// <returns></returns>
    public static T GetAppSetting<T>(string appSettingName) where T : IConvertible
    {
      return GetAppSettingInternal<T>(appSettingName, false, default(T));
    }

    /// <summary>
    /// Gets the value from the applications appSettings.
    /// </summary>
    /// <param name="appSettingName">Name of the appSettings key.</param>
    /// <param name="defaultValue">The default value returned if the appSetting has not been defined.</param>
    /// <returns></returns>
    public static T GetAppSetting<T>(string appSettingName, T defaultValue) where T : IConvertible
    {
      return GetAppSettingInternal<T>(appSettingName, true, defaultValue);
    }

    private static T GetAppSettingInternal<T>(string appSettingName, bool useDefaultOnUndefined, T defaultValue) where T : IConvertible
    {
      string value = ConfigurationManager.AppSettings[appSettingName];

      // require that all appSettings are either defined or have explicitly been given a default value
      if (value == null)
      {
        if (useDefaultOnUndefined)
          return defaultValue;
        else
          throw new Exception(string.Format("{0} not defined in appSettings.", appSettingName));
      }

      return (T)Convert.ChangeType(value, typeof(T));
    }

    public static void AddConfigurationProperties(ConfigurationPropertyCollection collection, IEnumerable<ConfigurationProperty> properties)
    {
      if (collection == null)
        throw new ArgumentNullException("collection");
      if (properties == null)
        throw new ArgumentNullException("properties");

      foreach (ConfigurationProperty property in properties)
      {
        collection.Add(property);
      }
    }

    public static string GetConnectionString(string connectionStringName)
    {
      if (connectionStringName == null)
        throw new ArgumentNullException("connectionStringName");

      ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];

      if (settings == null)
        throw new Exception(string.Format("No connection string settings with the name '{0}'.", connectionStringName));

      return settings.ConnectionString;
    }
  }
}
