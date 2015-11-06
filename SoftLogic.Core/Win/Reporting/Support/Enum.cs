using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;
using System.Reflection;
using System.ComponentModel;


namespace SoftLogik.Win
{
	namespace Reporting
	{
		
		public enum SPReportFilterFieldTypes
		{
			@General,
			@SimpleDate,
			@RangeDate,
			@Memo,
			@Custom
		}
		
		public enum SPComparisons
		{
			[SPComparisonDescription(" Equals ", "(#1 = #2)")]Equals,
			[SPComparisonDescription(" Not Equals ", "(#1 <> #2)")]NotEquals,
			[SPComparisonDescription(" Less Than or Equals ", "(#1 =< #2)")]LessThanEquals,
			[SPComparisonDescription(" Greater Or Equals ", "(#1 >= #2)")]GreaterThanEquals,
			[SPComparisonDescription("Between ", "(BETWEEN #1 AND #2)")]Between,
			[SPComparisonDescription(" Not Between ", "(NOT(BETWEEN #1 AND #2))")]NotBetween,
			[SPComparisonDescription(" In ", "(IN #1)")]@In,
			[SPComparisonDescription(" Not In ", "(NOT(IN #1))")]@NotIn,
			[SPComparisonDescription(" Like ", "(LIKE #1)")]@Like
		}
		
		#region SPComparison Description Attribute Class
		[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]public class SPComparisonDescriptionAttribute : System.Attribute
		{
			
			
			private string mOperation;
			private string mDescription;
			
			public string Operation
			{
				get
				{
					return mOperation;
				}
				set
				{
					mOperation = value;
				}
			}
			public string Description
			{
				get
				{
					return mDescription;
				}
				set
				{
					mDescription = value;
				}
			}
			public SPComparisonDescriptionAttribute(string Description, string Operation)
			{
				mOperation = Operation;
				mDescription = Description;
			}
		}
		
		
		[Description("Helper Class to Retrieve Extended Enumarator Properties")]public class SPComparisonsHelper
		{
			
			public static string GetDescription(object obj)
			{
				Type t = obj.GetType();
				FieldInfo fInfo = t.GetField(System.Enum.GetName(t, obj));
				
				SPComparisonDescriptionAttribute attr = (SPComparisonDescriptionAttribute) (fInfo.GetCustomAttributes(typeof(SPComparisonDescriptionAttribute), false)[0]);
				
				return attr.Description;
			}
			public static string GetOperation(object obj, string Operand1, string Operand2)
			{
				Type t = obj.GetType();
				FieldInfo fInfo = t.GetField(System.Enum.GetName(t, obj));
				
				SPComparisonDescriptionAttribute attr = (SPComparisonDescriptionAttribute) (fInfo.GetCustomAttributes(typeof(SPComparisonDescriptionAttribute), false)[0]);
				
				return attr.Operation.Replace("#1", Operand1).Replace("#2", Operand2);
			}
			
			public static ArrayList GetComparisonDataList(Type EnumType)
			{
				Array items = System.Enum.GetValues(EnumType);
				
				ArrayList retItems = new ArrayList();
				
				foreach (object itm in items)
				{
					FieldInfo fInfo = EnumType.GetField(System.Enum.GetName(EnumType, itm));
					
					SPComparisonDescriptionAttribute attr = (SPComparisonDescriptionAttribute) (fInfo.GetCustomAttributes(typeof(SPComparisonDescriptionAttribute), false)[0]);
					SPReportFilterOperator newItm = new SPReportFilterOperator(attr.Description, ((SPComparisons) itm));
					retItems.Add(newItm);
				}
				
				return retItems;
			}
		}
		#endregion
		
	}
}
