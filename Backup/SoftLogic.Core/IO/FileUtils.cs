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
using System.Text;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace SoftLogik.IO
{
  public class FileUtils
  {
    public static FileSystemInfo GetFileSystemInfo(string path)
    {
      if (File.Exists(path))
      {
        return new FileInfo(path);
      }
      else if (Directory.Exists(path))
      {
        return new DirectoryInfo(path);
      }

      return null;
    }

    /// <summary>
    /// Removes invalid file name characters from the specified string.
    /// </summary>
    /// <param name="s">The filename string.</param>
    /// <returns></returns>
    public static string ToValidFileName(string s)
    {
      return ToValidFileName(s, string.Empty, null);
    }

    public static string ToValidFileName(string s, string invalidReplacement)
    {
      return ToValidFileName(s, invalidReplacement, null);
    }

    public static string ToValidFileName(string s, string invalidReplacement, string spaceReplacement)
    {
      StringBuilder sb = new StringBuilder(s);

      foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
      {
        if (invalidReplacement != null)
          sb.Replace(invalidFileNameChar.ToString(), invalidReplacement);
      }

      if (spaceReplacement != null)
        sb.Replace(" ", spaceReplacement);

      return sb.ToString();
    }

    public static string MapPath(string path)
    {
      if (Path.IsPathRooted(path))
      {
        return path;
      }
      else if (HostingEnvironment.IsHosted)
      {
        return HostingEnvironment.MapPath(path);
      }
      else if (VirtualPathUtility.IsAppRelative(path))
      {
        string physicalPath = VirtualPathUtility.ToAbsolute(path, "/");
        physicalPath = physicalPath.Replace('/', '\\');
        physicalPath = physicalPath.Substring(1);
        physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, physicalPath);

        return physicalPath;
      }
      else
      {
        throw new Exception("Could not resolve non-rooted path.");
      }
    }
  }
}