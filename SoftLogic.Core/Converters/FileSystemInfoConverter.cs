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
using System.ComponentModel;
using System.Globalization;
using System.Net.Mail;
using System.IO;
using System.Web.Hosting;
using SoftLogik.IO;
using SoftLogik.Miscellaneous;

namespace SoftLogik.Converters
{
  public class FileSystemInfoConverter : TypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;

      return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof(string))
        return true;

      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value != null)
        value.ToString();

      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object data)
    {
      if (data != null && data.GetType() == typeof(string))
      {
        string path = data.ToString();
        string resolvedPath;

        if (Path.IsPathRooted(path))
          resolvedPath = path;
        else
          resolvedPath = HostingEnvironment.MapPath(path);

        FileSystemInfo fileSystemInfo = FileUtils.GetFileSystemInfo(resolvedPath);

        if (fileSystemInfo != null)
          return fileSystemInfo;
        else
          throw new Exception(string.Format(null, "Could not resolve path '{0}' to a file or directory.", resolvedPath));
      }

      return base.ConvertFrom(context, culture, data);
    }
  }
}
