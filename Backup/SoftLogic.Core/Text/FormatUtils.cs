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
using System.Globalization;

namespace SoftLogik.Text
{
  public class FormatUtils
  {
    private static readonly string[] fuzzyHours = new string[] { 
        "midnight", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "noon", "one", "two", "three", 
        "four", "five", "six", "seven", "eight", "nine", "ten", "eleven"
     };
    private static readonly string[] fuzzyMinutes = new string[] { "five", "ten", "a quarter", "twenty", "twenty five", "half" };

    private static readonly string[] _suffixes = new string[] { "th", "st", "nd", "rd" };

    /// <summary>
    /// Converts a number value into a string that represents the number
    /// expressed in whole kilobytes. This is a format similar to the
    /// Windows Explorer "Size" column.
    /// </summary>
    public static string FileSizeToStringKB(long fileSize)
    {
      return string.Format("{0:n0} KB", Math.Ceiling((double)fileSize / 1024));
    }


    /// <summary>
    /// Converts a numeric value into a string that represents the number
    /// expressed as a size value in bytes, kilobytes, megabytes, gigabytes,
    /// or terabytes depending on the size. Output is identical to
    /// StrFormatByteSize() in shlwapi.dll. This is a format similar to
    /// the Windows Explorer file Properties page. For example:
    ///      532 ->  532 bytes
    ///     1240 -> 1.21 KB
    ///   235606 ->  230 KB
    ///  5400016 -> 5.14 MB
    /// </summary>
    /// <remarks>
    /// It was surprisingly difficult to emulate the StrFormatByteSize() function
    /// due to a few quirks. First, the function only displays three digits:
    ///  - displays 2 decimal places for values under 10            (e.g. 2.12 KB)
    ///  - displays 1 decimal place for values under 100            (e.g. 88.2 KB)
    ///  - displays 0 decimal places for values under 1000         (e.g. 532 KB)
    ///  - jumps to the next unit of measure for values over 1000    (e.g. 0.97 MB)
    /// The second quirk: insiginificant digits are truncated rather than
    /// rounded. The original function likely uses integer math.
    /// This implementation was tested to 100 TB.
    /// </remarks>
    public static string FileSizeToString(long fileSize)
    {
      if (fileSize < 1024)
      {
        return string.Format("{0} bytes", fileSize);
      }
      else
      {
        double value = fileSize;
        value = value / 1024;
        string unit = "KB";
        if (value >= 1000)
        {
          value = Math.Floor(value);
          value = value / 1024;
          unit = "MB";
        }
        if (value >= 1000)
        {
          value = Math.Floor(value);
          value = value / 1024;
          unit = "GB";
        }
        if (value >= 1000)
        {
          value = Math.Floor(value);
          value = value / 1024;
          unit = "TB";
        }

        if (value < 10)
        {
          value = Math.Floor(value * 100) / 100;
          return string.Format("{0:n2} {1}", value, unit);
        }
        else if (value < 100)
        {
          value = Math.Floor(value * 10) / 10;
          return string.Format("{0:n1} {1}", value, unit);
        }
        else
        {
          value = Math.Floor(value * 1) / 1;
          return string.Format("{0:n0} {1}", value, unit);
        }
      }
    }

    public static string DateTimeToWords(DateTime date)
    {
      return DateTimeToWords(date, DateTime.Now);
    }

    public static string DateTimeToWords(DateTime dateTime, DateTime currentDate)
    {
      string result;
      TimeSpan t1 = new TimeSpan(currentDate.Ticks);
      TimeSpan t2 = new TimeSpan(dateTime.Ticks);
      int daysElapsed = t1.Days - t2.Days;
      if (daysElapsed < -7 || daysElapsed >= 14)
        result = DateToWords(dateTime, currentDate);
      else if (daysElapsed == 0)
        result = "this " + GetPeriod(dateTime.Hour);
      else
        result = DateToWords(dateTime, currentDate) + " " + GetPeriod(dateTime.Hour);

      return (result + " at " + TimeToWords(dateTime));
    }

    public static string DateToWords(DateTime date)
    {
      return DateToWords(date, DateTime.Now);
    }

    public static string DateToWords(DateTime date, DateTime currentDate)
    {
      TimeSpan t1 = new TimeSpan(currentDate.Ticks);
      TimeSpan t2 = new TimeSpan(date.Ticks);
      int daysElapsed = t1.Days - t2.Days;

      if (daysElapsed < -1 && daysElapsed >= -7)
        return ("next " + date.ToString("dddd"));

      if (daysElapsed == -1)
        return "tomorrow";

      if (daysElapsed == 0)
        return "today";

      if (daysElapsed == 1)
        return "yesterday";

      if (daysElapsed > 1 && daysElapsed < 7)
        return date.ToString("dddd");

      if (daysElapsed >= 7 && daysElapsed < 14)
        return "last " + date.ToString("dddd");

      return
        (date.ToString("MMMM") + " " + GetOrdinal(date.Day) +
         ((date.Year != currentDate.Year) ? (" " + date.ToString("yyyy")) : string.Empty));
    }

    public static string GetOrdinal(int value)
    {
      int tenth = value%10;

      if (tenth >= _suffixes.Length)
      {
        return _suffixes[0];
      }
      else
      {
        // special case for 11, 12, 13
        int hundredth = value % 100;
        if (hundredth >= 11 && hundredth <= 13)
          return _suffixes[0];

        return _suffixes[tenth];
      }
    }

    private static string GetPeriod(int hour)
    {
      if (hour > 18)
        return "evening";

      if (hour > 12)
        return "afternoon";

      if (hour > 3)
        return "morning";

      return "night";
    }

    public static string TimeToWords(DateTime time)
    {
      string result;
      int minutes = time.Minute;
      int hours = time.Hour;
      bool toHour = false;
      int remainder = time.Minute % 5;

      if (remainder < 3)
        minutes -= remainder;
      else
        minutes += 5 - remainder;

      if (minutes > 30)
      {
        hours = (hours + 1) % 24;
        minutes = 60 - minutes;
        toHour = true;
      }

      if (minutes != 0)
        result = fuzzyMinutes[minutes / 6] + " " + (toHour ? "to" : "past") + " " + fuzzyHours[hours];
      else
        result = fuzzyHours[hours] + ((hours != 0 && hours != 12) ? " o'clock" : string.Empty);

      if (hours > 0 && hours < 12)
        return result + " am";

      if (hours > 12)
        result = result + " pm";

      return result;
    }
  }
}