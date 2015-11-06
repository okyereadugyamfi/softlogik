using System.Diagnostics;
using System;
using System.Management;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.Design;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ACSGhana.Web.Framework
{
	public sealed class DateSupport
	{
		static public string GetTimeDifference(DateTime startdate, DateTime enddate)
		{
			
			const int secondsInADay = 24 * 3600;
			const int secondsInAnHour = 3600;
			const int secondsInAMinute = 60;
			
			int timeDiff = DateAndTime.DateDiff(DateInterval.Second, startdate, enddate, 1, 1);
			int dayDiff = timeDiff / secondsInADay;
			int hourDiff = (timeDiff - (dayDiff * secondsInADay)) / secondsInAnHour;
			int minDiff = (timeDiff - (dayDiff * secondsInADay) - (hourDiff * secondsInAnHour)) / secondsInAMinute;
			int secDiff = timeDiff - (dayDiff * secondsInADay) - (hourDiff * secondsInAnHour) - (minDiff * secondsInAMinute);
			
			StringBuilder strFriendlyTime = new StringBuilder();
			if (dayDiff == 1)
			{
				strFriendlyTime.Append(dayDiff + " day ");
			}
			if (dayDiff > 1)
			{
				strFriendlyTime.Append(dayDiff + " days ");
			}
			if (hourDiff == 1)
			{
				strFriendlyTime.Append(hourDiff + " hr ");
			}
			if (hourDiff > 1)
			{
				strFriendlyTime.Append(hourDiff + " hrs ");
			}
			if (minDiff > 0)
			{
				strFriendlyTime.Append(minDiff + " min ");
			}
			if (secDiff > 0)
			{
				strFriendlyTime.Append(secDiff + " sec ");
			}
			
			return strFriendlyTime.ToString();
		}
		static public string GetFriendlyDate(DateTime src, bool ReturnFullName)
		{
			DateTime currdate = DateTime.Now;
			string strTimeOfDay = Constants.vbNullString;
			int datediff = (src - currdate).Days;
			if (datediff == -1)
			{
				
				return "Yesterday";
			}
			else if (datediff >= -7 && datediff <= - 2)
			{
				
				return "Last " + src.DayOfWeek.ToString();
			}
			else if (datediff == 0)
			{
				if (ReturnFullName)
				{
					//If src.TimeOfDay >= TimeValue("00:00:00").TimeOfDay And _
					//src.TimeOfDay <= TimeValue("12:00:00").TimeOfDay Then
					//    strTimeOfDay = "Morning"
					//ElseIf src.TimeOfDay > TimeValue("12:00:00").TimeOfDay And _
					//src.TimeOfDay <= TimeValue("16:00:00").TimeOfDay Then
					//    strTimeOfDay = "Afternoon"
					//Else
					//    strTimeOfDay = "Evening"
					//End If
					
					return src.DayOfWeek.ToString() + ", " + src.ToLongDateString().Replace(src.DayOfWeek.ToString() + ", ", "");
				}
				else
				{
					return "Today";
					
				}
			}
			else if (datediff >= 1 && datediff <= 7)
			{
				
				return "This " + src.DayOfWeek.ToString();
			}
			else
			{
				
				return src.ToString();
			}
		}
		
		static public string GetGreeting()
		{
			DateTime currdate = DateTime.Now;
			string strTimeOfDay = Constants.vbNullString;
			DateTime src = DateTime.Now;
			
			if (src.TimeOfDay >= DateAndTime.TimeValue("00:00:00").TimeOfDay && src.TimeOfDay <= DateAndTime.TimeValue("12:00:00").TimeOfDay)
			{
				strTimeOfDay = "Morning";
			}
			else if (src.TimeOfDay > DateAndTime.TimeValue("12:00:00").TimeOfDay && src.TimeOfDay <= DateAndTime.TimeValue("16:00:00").TimeOfDay)
			{
				strTimeOfDay = "Afternoon";
			}
			else
			{
				strTimeOfDay = "Evening";
			}
			
			return "Good " + strTimeOfDay;
			
		}
	}
	
}
