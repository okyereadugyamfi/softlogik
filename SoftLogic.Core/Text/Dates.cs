using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogik.Text
{
    public static class Dates
    {

        #region Date Math

        /// <summary>
        /// Dayses the ago.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public static DateTime DaysAgo(int days)
        {
            TimeSpan t = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Subtract(t);
        }

        /// <summary>
        /// Dayses from now.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public static DateTime DaysFromNow(int days)
        {
            TimeSpan t = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Add(t);
        }

        /// <summary>
        /// Hourses the ago.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns></returns>
        public static DateTime HoursAgo(int hours)
        {
            TimeSpan t = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Subtract(t);
        }

        /// <summary>
        /// Hourses from now.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns></returns>
        public static DateTime HoursFromNow(int hours)
        {
            TimeSpan t = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Add(t);
        }

        /// <summary>
        /// Minuteses the ago.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <returns></returns>
        public static DateTime MinutesAgo(int minutes)
        {
            TimeSpan t = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Subtract(t);
        }

        /// <summary>
        /// Minuteses from now.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <returns></returns>
        public static DateTime MinutesFromNow(int minutes)
        {
            TimeSpan t = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Add(t);
        }

        /// <summary>
        /// Secondses the ago.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        public static DateTime SecondsAgo(int seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Subtract(t);
        }

        /// <summary>
        /// Seconds from now.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        public static DateTime SecondsFromNow(int seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Add(t);
        }

        #endregion

        #region Diffs

        /// <summary>
        /// Diffs the specified date one.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static TimeSpan Diff(DateTime dateOne, DateTime dateTwo)
        {
            TimeSpan t = dateOne.Subtract(dateTwo);
            return t;
        }

        /// <summary>
        /// Diffs the days.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffDays(string dateOne, string dateTwo)
        {
            DateTime dtOne;
            DateTime dtTwo;
            if (DateTime.TryParse(dateOne, out dtOne) && DateTime.TryParse(dateTwo, out dtTwo))
            {
                return Diff(dtOne, dtTwo).TotalDays;
            }
            return 0;
        }

        /// <summary>
        /// Diffs the days.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffDays(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalDays;
        }

        /// <summary>
        /// Diffs the hours.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffHours(string dateOne, string dateTwo)
        {
            DateTime dtOne;
            DateTime dtTwo;
            if (DateTime.TryParse(dateOne, out dtOne) && DateTime.TryParse(dateTwo, out dtTwo))
            {
                return Diff(dtOne, dtTwo).TotalHours;
            }
            return 0;
        }

        /// <summary>
        /// Diffs the hours.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffHours(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalHours;
        }

        /// <summary>
        /// Diffs the minutes.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffMinutes(string dateOne, string dateTwo)
        {
            DateTime dtOne;
            DateTime dtTwo;
            if (DateTime.TryParse(dateOne, out dtOne) && DateTime.TryParse(dateTwo, out dtTwo))
            {
                return Diff(dtOne, dtTwo).TotalMinutes;
            }
            return 0;
        }

        /// <summary>
        /// Diffs the minutes.
        /// </summary>
        /// <param name="dateOne">The date one.</param>
        /// <param name="dateTwo">The date two.</param>
        /// <returns></returns>
        public static double DiffMinutes(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalHours;
        }



        /// <summary>
        /// Displays the difference in time between the two dates. Return example is "12 years 4 months 24 days 8 hours 33 minutes 5 seconds"
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string ReadableDiff(DateTime startTime, DateTime endTime)
        {
            string result = "";

            int seconds = endTime.Second - startTime.Second;
            int minutes = endTime.Minute - startTime.Minute;
            int hours = endTime.Hour - startTime.Hour;
            int days = endTime.Day - startTime.Day;
            int months = endTime.Month - startTime.Month;
            int years = endTime.Year - startTime.Year;


            if (seconds < 0)
            {
                minutes--;
                seconds += 60;
            }
            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }
            if (hours < 0)
            {
                days--;
                hours += 24;
            }

            if (days < 0)
            {
                months--;
                int previousMonth = (endTime.Month == 1) ? 12 : endTime.Month - 1;
                int year = (previousMonth == 12) ? endTime.Year - 1 : endTime.Year;
                days += DateTime.DaysInMonth(year, previousMonth);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }


            //put this in a readable format
            if (years > 0)
            {
                result = years.ToString() + " years, " + months.ToString() + " months ago";
            }
            else if (months > 0)
            {
                result = months.ToString() + " months, " + days.ToString() + " days ago";

            }
            else if (days > 0)
            {
                result = days.ToString() + " days, " + hours.ToString() + " hours ago";

            }
            else if (hours > 0)
            {
                result = hours.ToString() + " hours, " + minutes.ToString() + " minutes ago";

            }
            else if (minutes > 0)
            {
                result = minutes.ToString() + " minutes ago";

            }
            return result;

        }



        #endregion


        //many thanks to A Alliance for the code below
        //http://authors.aspalliance.com/olson/methods/
        /// <summary>
        /// Counts the number of weekdays between two dates.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int CountWeekdays(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            Console.WriteLine(ts.Days);
            int cnt = 0;
            for (int i = 0; i < ts.Days; i++)
            {
                DateTime dt = startTime.AddDays(i);
                if (IsWeekDay(dt))
                {
                    cnt++;
                }
            }

            return cnt;
        }

        /// <summary>
        /// Counts the number of weekends between two dates.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int CountWeekends(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            Console.WriteLine(ts.Days);
            int cnt = 0;
            for (int i = 0; i < ts.Days; i++)
            {
                DateTime dt = startTime.AddDays(i);
                if (IsWeekEnd(dt))
                {
                    cnt++;
                }
            }

            return cnt;
        }
        /// <summary>
        /// Verifies if the object is a date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsDate(object dt)
        {
            DateTime newDate;
            return DateTime.TryParse(dt.ToString(), out newDate);
        }

        /// <summary>
        /// Checks to see if the date is a week day (Mon - Fri)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekDay(DateTime dt)
        {
            return Convert.ToInt16(dt.DayOfWeek) < 6;
        }

        /// <summary>
        ///  Checks to see if the date is Sat or Sunday
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekEnd(DateTime dt)
        {
            return Convert.ToInt16(dt.DayOfWeek) > 5;
        }

        /// <summary>
        /// Displays the difference in time between the two dates. Return example is "12 years 4 months 24 days 8 hours 33 minutes 5 seconds"
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string TimeDiff(DateTime startTime, DateTime endTime)
        {
            int seconds = endTime.Second - startTime.Second;
            int minutes = endTime.Minute - startTime.Minute;
            int hours = endTime.Hour - startTime.Hour;
            int days = endTime.Day - startTime.Day;
            int months = endTime.Month - startTime.Month;
            int years = endTime.Year - startTime.Year;
            if (seconds < 0)
            {
                minutes--;
                seconds += 60;
            }
            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }
            if (hours < 0)
            {
                days--;
                hours += 24;
            }
            if (days < 0)
            {
                months--;
                int previousMonth = (endTime.Month == 1) ? 12 : endTime.Month - 1;
                int year = (previousMonth == 12) ? endTime.Year - 1 : endTime.Year;
                days += DateTime.DaysInMonth(year, previousMonth);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }

            string sYears = FormatString("year", string.Empty, years);
            string sMonths = FormatString("month", sYears, months);
            string sDays = FormatString("day", sMonths, days);
            string sHours = FormatString("hour", sDays, hours);
            string sMinutes = FormatString("minute", sHours, minutes);
            string sSeconds = FormatString("second", sMinutes, seconds);

            return sYears + sMonths + sDays + sHours + sMinutes + sSeconds;
        }

        /// <summary>
        /// Given a datetime object, returns the formatted month and day, i.e. "April 15th" 
        /// </summary>
        /// <param name="date">The date to extract the string from</param>
        /// <returns></returns>
        public static string GetFormattedMonthAndDay(DateTime date)
        {
            return String.Format("{0:MMMM}", date) + " " + GetDateDayWithSuffix(date);
        }

        /// <summary>
        /// Given a datetime object, returns the formatted day, "15th" 
        /// </summary>
        /// <param name="date">The date to extract the string from</param>
        /// <returns></returns>
        public static string GetDateDayWithSuffix(DateTime date)
        {
            int dayNumber = date.Day;
            if (dayNumber == 1 || dayNumber == 21 || dayNumber == 31)
            {
                return dayNumber + "st";
            }
            else if (dayNumber == 2 || dayNumber == 22)
            {
                return dayNumber + "nd";
            }
            else if (dayNumber == 3 || dayNumber == 23)
            {
                return dayNumber + "rd";
            }
            return dayNumber + "th";
        }

        //remove leading strings with zeros and adjust for singular/plural
        private static string FormatString(string str, string previousStr, int t)
        {
            if ((t == 0) && (previousStr.Length == 0)) return string.Empty;
            if (t == 1)
            {
                str = t + " " + str;
            }
            else
            {
                str = t + " " + str + "s";
            }
            return str + " ";
        }


    }

}
