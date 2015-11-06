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
	public partial class DSFilters
	{
		
		public partial class SPFilterTableDataTable
		{
			
			
			private void SPFilterTableDataTable_ColumnChanging(System.Object sender, System.Data.DataColumnChangeEventArgs e)
			{
				if (e.Column.ColumnName == this.FilterIDColumn.ColumnName)
				{
					//Add user code here
				}
				
			}
			
		}
		
	}
	
}
