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
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SoftLogik.Email
{
  public static class EmailUtils
  {
    /// <summary>
    /// Ensures the line feeds. See http://cr.yp.to/docs/smtplf.html and 822bis section 2.3.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static string EnsureLineFeeds(string value)
    {
      return Regex.Replace(value, "(?<!\r)\n", "\r\n", RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Parses the comma delimited email addresses.
    /// </summary>
    /// <param name="emailAddresses">The email addresses.</param>
    /// <returns></returns>
    public static MailAddressCollection ParseEmailAddresses(string emailAddresses)
    {
      try
      {
        MailAddressCollection mailAddressCollection = new MailAddressCollection();

        if (!string.IsNullOrEmpty(emailAddresses))
          mailAddressCollection.Add(emailAddresses);

        return mailAddressCollection;
      }
      catch (FormatException e)
      {
        throw new FormatException("Error parsing email addresses: " + emailAddresses, e);
      }
    }
  }
}