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
using System.Web;
using System.IO;

namespace SoftLogik.Web
{
  public static class ResponseUtils
  {
    /// <summary>
    /// Return the response with a file.
    /// </summary>
    /// <param name="fileData">The file data.</param>
    /// <param name="fileName">Name of the file.</param>
    public static void FileResponse(byte[] fileData, string fileName)
    {
      FileResponse(fileData, fileName, "application/octet-stream");
    }

    /// <summary>
    /// Return the response with a file.
    /// </summary>
    /// <param name="fileData">The file data.</param>
    /// <param name="fileName">Name of the file.</param>
    public static void FileResponse(Stream fileData, string fileName)
    {
      FileResponse(fileData, fileName, "application/octet-stream", 16384);
    }

    /// <summary>
    /// Return the response with a file.
    /// </summary>
    /// <param name="fileData">The file data.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="contentType">The HTTP MIME type of the content.</param>
    public static void FileResponse(byte[] fileData, string fileName, string contentType)
    {
      if (fileData == null)
        throw new ArgumentNullException("fileData", "Data cannot be null");

      FileResponse(new MemoryStream(fileData), fileName, contentType, fileData.Length);
    }

    /// <summary>
    /// Return the response with a file.
    /// </summary>
    /// <param name="fileData">The file data.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="contentType">The HTTP MIME type of the content.</param>
    public static void FileResponse(Stream fileData, string fileName, string contentType)
    {
      FileResponse(fileData, fileName, contentType, 16384);
    }

    /// <summary>
    /// Return the response with a file.
    /// </summary>
    /// <param name="fileData">The file data.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="contentType">The HTTP MIME type of the content.</param>
    /// <param name="bufferSize">Size of the buffer.</param>
    public static void FileResponse(Stream fileData, string fileName, string contentType, int bufferSize)
    {
      HttpContext context = HttpContext.Current;

      if (context == null)
        throw new InvalidOperationException("Unable to aquire HttpContext");

      if (fileData == null)
        throw new ArgumentNullException("fileData", "File data cannot be null");

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentException("Filename cannot be null or empty", "filename");

      if (string.IsNullOrEmpty(contentType))
        throw new ArgumentException("ContentType cannot be null or empty", "contentType");

      HttpResponse response = context.Response;
      response.Clear();
      response.ClearHeaders();
      response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
      response.ContentType = contentType;

      byte[] buffer = new byte[bufferSize];
      while ((bufferSize = fileData.Read(buffer, 0, buffer.Length)) > 0)
      {
        response.OutputStream.Write(buffer, 0, bufferSize);
      }

      response.End();
    }

    /// <summary>
    /// Gives a permanent redirect to the browser.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="url">The URL to permanently redirect to.</param>
    public static void PermanentRedirect(HttpResponse response, string url)
    {
      response.ClearContent();
      response.ClearHeaders();

      response.StatusCode = 301;
      response.Status = "301 Moved Permanently";
      response.RedirectLocation = url;
      response.End();
    }
  }
}
