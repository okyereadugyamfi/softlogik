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
using System.ComponentModel;


namespace SoftLogik.Win
{
	namespace Reporting
	{
		#region Report Filter Classes
		public class SPReportFilter
		{
			
			
			private SPReportFilterFieldTypes _Type = SPReportFilterFieldTypes.General;
			private string _DisplayMember = string.Empty;
			private string _ValueMember = string.Empty;
			private string _Operation = string.Empty;
			private string _OperationText = string.Empty;
			private object _Value = null;
			
			#region Properties
			protected internal SPReportFilterFieldTypes @Type
			{
				get
				{
					return _Type;
				}
			}
			protected internal string Operation
			{
				get
				{
					return _Operation;
				}
				set
				{
					_Operation = value;
				}
			}
			public string OperationText
			{
				get
				{
					return _OperationText;
				}
				set
				{
					_OperationText = value;
				}
			}
			public string DisplayMember
			{
				get
				{
					return _DisplayMember;
				}
				set
				{
					_DisplayMember = value;
				}
			}
			public string ValueMember
			{
				get
				{
					return _ValueMember;
				}
				set
				{
					_ValueMember = value;
				}
			}
			protected internal object Value
			{
				get
				{
					return _Value;
				}
				set
				{
					_Value = value;
				}
			}
			#endregion
			
			public SPReportFilter(string DisplayMember, string ValueMember, SPReportFilterFieldTypes @Type)
			{
				this._DisplayMember = DisplayMember;
				this._ValueMember = ValueMember;
				this._Type = @Type;
			}
			
			public override string ToString()
			{
				return this._Operation.Replace("#ValueMember#", this._ValueMember);
			}
			
			public string ToFormattedString()
			{
				return this._OperationText.Replace("#DisplayMember#", this._DisplayMember);
			}
		}
		
		[DataObject()]public class SPReportFilterCollection : List<SPReportFilter>
		{
			
			
			
			public SPReportFilter Add(string DisplayMember, string ValueMember, SPReportFilterFieldTypes @Type)
			{
				SPReportFilter newItem = new SPReportFilter(DisplayMember, ValueMember, @Type);
				try
				{
					this.Add(newItem);
				}
				catch (Exception)
				{
				}
				return newItem;
			}
			public SPReportFilter this[string DisplayMember]
			{
				get
				{
					foreach (SPReportFilter itm in this)
					{
						if (itm.DisplayMember == DisplayMember)
						{
							return itm;
						}
					}
					
					return null;
				}
			}
			public void Remove(string DisplayMember)
			{
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				this.Remove(this[DisplayMember]);
			}
			
			public override string ToString()
			{
				string strFilterQuery = Constants.vbNullString;
				
				foreach (SPReportFilter qry in this)
				{
					strFilterQuery += qry.ToString();
					strFilterQuery += " AND ";
				}
				
				if (strFilterQuery.Trim().EndsWith("AND"))
				{
					strFilterQuery = Strings.Mid(Strings.Trim(strFilterQuery), 1, Strings.Trim(strFilterQuery).Length - 3);
				}
				
				return strFilterQuery;
			}
			
		}
		
		#endregion
		
		#region Report Group Classes
		[Description("Specify a Grouping used in a Report.")]public class SPReportGrouping
		{
			
			
			private string _DisplayMember = string.Empty;
			private string _ValueMember = string.Empty;
			
			public string DisplayMember
			{
				get
				{
					return _DisplayMember;
				}
				set
				{
					_DisplayMember = value;
				}
			}
			
			
			public SPReportGrouping(string DisplayMember, string ValueMember)
			{
				this._DisplayMember = DisplayMember;
				this._ValueMember = ValueMember;
			}
			
		}
		[Description("Specify a List of Groupings used in a Report.")]public class SPReportGroupingCollection : List<SPReportGrouping>
		{
			
			
			public SPReportGrouping Add(string DisplayMember, string ValueMember)
			{
				SPReportGrouping newItem = new SPReportGrouping(DisplayMember, ValueMember);
				try
				{
					this.Add(newItem);
				}
				catch (Exception)
				{
				}
				return newItem;
			}
			public SPReportGrouping this[string DisplayMember]
			{
				get
				{
					foreach (SPReportGrouping itm in this)
					{
						if (itm.DisplayMember == DisplayMember)
						{
							return itm;
						}
					}
					
					return null;
				}
			}
			
			public void Remove(string DisplayMember)
			{
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				this.Remove(this[DisplayMember]);
			}
			
		}
		#endregion
		
		#region Report Parameter Classes
		public class SPReportParameter
		{
			
			
			private string _Name = string.Empty;
			private object _Value = null;
			
			public string Name
			{
				get
				{
					return _Name;
				}
				set
				{
					_Name = value;
				}
			}
			public object Value
			{
				get
				{
					return _Value;
				}
				set
				{
					_Value = value;
				}
			}
			
			public SPReportParameter(string Name, object Value)
			{
				this._Name = Name;
				this._Value = Value;
			}
			
		}
		public class SPReportParameterCollection : List<SPReportParameter>
		{
			
			
			public SPReportParameter Add(string Name, object Value)
			{
				SPReportParameter newItem = new SPReportParameter(Name, Value);
				try
				{
					this.Add(newItem);
				}
				catch (Exception)
				{
				}
				return newItem;
			}
			
			public SPReportParameter this[string Name]
			{
				get
				{
					foreach (SPReportParameter itm in this)
					{
						if (itm.Name == Name)
						{
							return itm;
						}
					}
					
					return null;
				}
			}
			public void Remove(string Name)
			{
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				this.Remove(this[Name]);
			}
		}
		#endregion
		
		
		#region Report Filter Operator Classes
		public class SPReportFilterOperator
		{
			
			
			private string _Name = string.Empty;
			public string Name
			{
				get
				{
					return _Name;
				}
				set
				{
					_Name = value;
				}
			}
			
			private SPComparisons _Value = SPComparisons.Equals;
			
			public SPComparisons Value
			{
				get
				{
					return _Value;
				}
				set
				{
					_Value = value;
				}
			}
			
			public SPReportFilterOperator()
			{
				
			}
			
			public SPReportFilterOperator(string Name, SPComparisons Value)
			{
				this._Name = Name;
				this._Value = Value;
			}
		}
		#endregion
	}
	
	
	
}
