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
using System.IO;
using SoftLogik.Miscellaneous;

namespace SoftLogik.IO
{
  public static class StreamUtils
  {
    private const int BufferSize = 4096;

    public static void WriteStream(Stream sourceStream, Stream destinationStream)
    {
      WriteStream(sourceStream, destinationStream, BufferSize);
    }

    public static void WriteStream(Stream sourceStream, Stream destinationStream, int bufferSize)
    {
      if (sourceStream == null)
        throw new ArgumentNullException("sourceStream");

      if (destinationStream == null)
        throw new ArgumentNullException("destinationStream");

      byte[] buffer = new byte[bufferSize];

      int bytesRead;

      // while read on the stream continues to return data,
      // write the data into the memorystream
      while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
      {
        destinationStream.Write(buffer, 0, bytesRead);
      }
    }

    public static byte[] ReadAllBytes(Stream stream)
    {
      byte[] data = new byte[stream.Length - stream.Position];

      stream.Read(data, (int)stream.Position, data.Length);

      return data;
    }

    public static string ToString(Stream stream)
    {
      ValidationUtils.ArgumentNotNull(stream, "stream");

      string value;
      using (StreamReader sr = new StreamReader(stream))
      {
        value = sr.ReadToEnd();
      }

      return value;
    }
  }
}