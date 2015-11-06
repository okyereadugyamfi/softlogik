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

namespace ACSGhana.Web.Framework
{
	public sealed class SafeConverters
	{
		
		public const DateTime DEFAULT_DATE = DateTime.Parse("1/1/1753");
		
		public static System.Nullable<DateTime> SafeDate(string Expression)
		{
			if (Expression == DBNull.Value)
			{
				return null;
			}
			else
			{
				if (Expression != Constants.vbNullString)
				{
					return DateTime.Parse(Expression);
				}
				else
				{
					return null;
				}
			}
		}
		public static DateTime SafeDateEx(string Expression)
		{
			if (Expression == DBNull.Value || Expression == string.Empty)
			{
				return System.Data.SqlTypes.SqlDateTime.Null.Value;
			}
			else
			{
				DateTime oldDate = DateTime.Parse(Expression);
				System.Data.SqlTypes.SqlDateTime newDate;
				if (oldDate < System.Data.SqlTypes.SqlDateTime.MinValue.Value)
				{
					newDate = System.Data.SqlTypes.SqlDateTime.MinValue.Value.AddTicks(oldDate.Ticks);
				}
				else
				{
					newDate = oldDate;
				}
				
				return newDate;
			}
		}
		public static System.Nullable<DateTime> SafeDate2(string Expression)
		{
			if (Expression == DBNull.Value)
			{
				return null;
			}
			else
			{
				if (Expression != Constants.vbNullString)
				{
					return DateTime.Parse(Expression);
				}
				else
				{
					return new DateTime(0);
				}
			}
		}
		public static System.Nullable<short> SafeShort(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == DBNull.Value)
				{
					return - 1;
				}
				if (Expression.GetType() == typeof(string))
				{
					if (! string.IsNullOrEmpty(Expression))
					{
						if (Expression is string&& Expression == "Nothing")
						{
							return 0;
						}
						return System.Convert.ToInt16(Expression);
					}
					else
					{
						return 0;
					}
				}
				else
				{
					return System.Convert.ToInt16(Expression);
				}
			}
			else
			{
				return 0;
			}
		}
		public static System.Nullable<int> SafeInteger(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == DBNull.Value)
				{
					return 0;
				}
				if (Expression.GetType() == typeof(string))
				{
					if (! string.IsNullOrEmpty(Expression))
					{
						if (Expression is string&& Expression == "Nothing")
						{
							return 0;
						}
						return System.Convert.ToInt32(Expression);
					}
					else
					{
						return 0;
					}
				}
				else
				{
					return System.Convert.ToInt32(Expression);
				}
			}
			else
			{
				return 0;
			}
		}
		public static System.Nullable<long> SafeLong(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == DBNull.Value)
				{
					return 0;
				}
				if (Expression.GetType() == typeof(string))
				{
					if (! string.IsNullOrEmpty(Expression))
					{
						if (Expression is string&& Expression == "Nothing")
						{
							return 0;
						}
						
						return System.Convert.ToInt32(Expression);
					}
					else
					{
						return 0;
					}
				}
				else
				{
					return System.Convert.ToInt32(Expression);
				}
			}
			else
			{
				return 0;
			}
		}
		public static System.Nullable<decimal> SafeDecimal(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == DBNull.Value)
				{
					return 0M;
				}
				if (Expression.GetType() == typeof(string))
				{
					if (! string.IsNullOrEmpty(Expression))
					{
						if (Expression is string&& Expression == "Nothing")
						{
							return 0M;
						}
						return System.Convert.ToDecimal(Expression);
					}
					else
					{
						return 0M;
					}
				}
				else
				{
					return System.Convert.ToDecimal(Expression);
				}
			}
			else
			{
				return 0M;
			}
		}
		public static System.Nullable<double> SafeDouble(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == DBNull.Value)
				{
					return 0.0F;
				}
				if (Expression.GetType() == typeof(string))
				{
					if (! string.IsNullOrEmpty(Expression))
					{
						if (Expression is string&& Expression == "Nothing")
						{
							return 0.0F;
						}
						return System.Convert.ToDouble(Expression);
					}
					else
					{
						return 0.0F;
					}
				}
				else
				{
					return System.Convert.ToDouble(Expression);
				}
			}
			else
			{
				return 0.0F;
			}
		}
		public static System.Nullable<DateTime> SafeTime(string Expression)
		{
			if (Expression != Constants.vbNullString)
			{
				DateTime NewTime = DateAndTime.TimeValue(Expression);
				return DEFAULT_DATE.AddTicks(NewTime.Ticks);
			}
			else
			{
				return null;
			}
		}
		public static double SafeHours(string Expression)
		{
			//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
			if (Expression != Constants.vbNullString)
			{
				if (Expression.Contains(":"))
				{
					double timeTotal = 0M;
					string[] timeSections = Expression.Split(":");
					double hours;
					double minutes;
					double seconds;
					if (timeSections.Length > 2)
					{
						hours = timeSections[0];
						minutes = timeSections[1];
						seconds = timeSections[2];
					}
					else
					{
						hours = timeSections[0];
						minutes = timeSections[1];
					}
					
					timeTotal = hours + (minutes / 60) + (seconds / 3600);
					return timeTotal;
				}
				else
				{
					return double.Parse(Expression);
				}
			}
			else
			{
				return null;
			}
		}
		public static double SafeDuration(object Expression)
		{
			if (Expression != null)
			{
				double DurHrs = Conversion.Fix(Expression);
				double DurMins = (Expression - Conversion.Fix(Expression)) * 100;
				if (DurMins > 60)
				{
					DurHrs += 1 + ((DurMins - 60) / 100);
					return DurHrs;
				}
				return System.Convert.ToDouble(Expression);
			}
			else
			{
				return 0M;
			}
		}
		
		public Function CDBValue<t struct })<t> where t ;: Structure
		{
			if (Expression.GetType() == typeof(t))
			{
				return Expression;
			}
			else
			{
				return ((t) null);
			}
		}
		
		public string SafeString(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == System.DBNull.Value)
				{
					return Constants.vbNullString;
				}
				else
				{
					if (Expression is string&& Expression == "Nothing")
					{
						return null;
					}
					return Expression.ToString();
				}
			}
			else
			{
				return Constants.vbNullString;
			}
		}
		public System.Nullable<bool> SafeBoolean(object Expression)
		{
			if (Expression != null)
			{
				if (Expression == System.DBNull.Value)
				{
					return false;
				}
				else
				{
					if (Expression is string&& string.IsNullOrEmpty(Expression))
					{
						return false;
					}
					if (Expression is string&& Expression == "Nothing")
					{
						return false;
					}
					return System.Convert.ToBoolean(Expression);
				}
			}
			else
			{
				return false;
			}
		}
		
	}
	
}
