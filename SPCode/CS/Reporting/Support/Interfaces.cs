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

namespace SoftLogik.Win
{
	namespace Reporting
	{
		public class SPReportFilterValue
		{
			
			
			private string _Name;
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
			
		}
		
		public class SPReportFilterValueCollection : List<SPReportFilterValue>
		{
			
			
		}
		
		public delegate SPReportFilterValue  SPAdvancedSearchDelegate(string Options);
		public delegate SPReportFilterValueCollection  SPFilterSetupDelegate(string Options);
		
	}
	
}
