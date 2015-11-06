using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogik
{
    public static class Time
    {
            public enum TimeFragments : int
            {
                Hours,
                Minutes,
                Seconds
            }

            private const double TIME_SECONDSINDAY = 24 * 3600;

            public static double GetTimeUnit(double DurationInSeconds, TimeFragments TimeFragment)
            {
                double currtimeUnit = 0D;

                switch (TimeFragment)
                {
                    case TimeFragments.Hours:
                        if (DurationInSeconds > TIME_SECONDSINDAY)
                        {
                            currtimeUnit = 0D;// Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Hour, System.DateTime.MinValue, System.DateTime.MinValue.AddSeconds(DurationInSeconds), Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);
                        }
                        else
                        {
                            currtimeUnit = System.DateTime.MinValue.AddSeconds(DurationInSeconds).Hour;
                        }

                        break;
                    case TimeFragments.Minutes:
                        currtimeUnit = System.DateTime.MinValue.AddSeconds(DurationInSeconds).Minute;
                        break;
                    case TimeFragments.Seconds:
                        currtimeUnit = System.DateTime.MinValue.AddSeconds(DurationInSeconds).Second;
                        break;
                }

                return currtimeUnit;
            }

            public static string GetTimeSummary(double DurationInSeconds)
            {
                double dHours = GetTimeUnit(DurationInSeconds, TimeFragments.Hours);
                double dMinutes = GetTimeUnit(DurationInSeconds, TimeFragments.Minutes);
                double dSeconds = GetTimeUnit(DurationInSeconds, TimeFragments.Seconds);

                double resultSummary = dHours + (dMinutes / 100) + (dSeconds / 3600);
                return resultSummary.ToString("00.00");
            }
        
    }
}
