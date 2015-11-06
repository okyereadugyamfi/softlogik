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
using System.Security.Cryptography;
using System.IO;

namespace SoftLogik.Miscellaneous
{
  public static class EncryptionUtils
  {
    public static byte[] GenerateKey()
    {
      RijndaelManaged provider = new RijndaelManaged();
      provider.GenerateKey();

      return provider.Key;
    }

    public static byte[] GenerateIV()
    {
      RijndaelManaged provider = new RijndaelManaged();
      provider.GenerateIV();

      return provider.IV;
    }

    public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
    {
      RijndaelManaged provider = new RijndaelManaged();

      MemoryStream ms = new MemoryStream();

      using (CryptoStream cryptoStream = new CryptoStream(ms, provider.CreateDecryptor(key, iv), CryptoStreamMode.Write))
      {
        cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
      }

      return Encoding.UTF8.GetString(ms.ToArray());
    }

    public static byte[] Encrypt(string value, byte[] key, byte[] iv)
    {
      RijndaelManaged provider = new RijndaelManaged();
      byte[] valueBytes = Encoding.UTF8.GetBytes(value);

      MemoryStream ms = new MemoryStream();

      using (CryptoStream cryptoStream = new CryptoStream(ms, provider.CreateEncryptor(key, iv), CryptoStreamMode.Write))
      {
        cryptoStream.Write(valueBytes, 0, valueBytes.Length);
      }

      return ms.ToArray();
    }
  }
}