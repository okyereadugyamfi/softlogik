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
	#region Report Parameter Classes
	public sealed class ReportParameter
	{
		
		
		#region ctors
		public ReportParameter()
		{
			
		}
		public ReportParameter(string Name, object value)
		{
			this._Name = Name;
			this._Value = value;
		}
		#endregion
		
		private string _Name;
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
		
		private object _Value;
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
		
	}
	
	public sealed class ReportParameterCollection : List<ReportParameter>
	{
		
		
	}
	
	#endregion
	
}
