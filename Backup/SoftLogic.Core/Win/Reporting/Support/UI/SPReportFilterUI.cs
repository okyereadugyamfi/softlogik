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
		public partial class SPReportFilterUI
		{
			
			
			private SPReportFilterCollection _Filters;
			private ArrayList _Operators;
			
			public SPReportFilterCollection Filters
			{
				set
				{
					_Filters = value;
				}
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				if (! DesignMode)
				{
					FilterList.DataSource = SPReportUIFactory.GetDefaultFilterList();
				}
				BuildFieldList();
				BuildOperatorList();
				base.OnLoad(e);
			}
			
			private void BuildFieldList()
			{
				if (_Filters != null)
				{
					bsFields.DataSource = _Filters;
					
					DataGridViewComboBoxColumn fieldColumn = (DataGridViewComboBoxColumn) (FilterList.Columns["FieldDataGridViewTextBoxColumn"]);
					
					if (fieldColumn != null)
					{
						fieldColumn.DataSource = bsFields;
						fieldColumn.DisplayMember = "DisplayMember";
						fieldColumn.ValueMember = "ValueMember";
					}
				}
			}
			private void BuildOperatorList()
			{
				_Operators = SPComparisonsHelper.GetComparisonDataList(typeof(SPComparisons));
				if (_Operators != null)
				{
					bsOperators.DataSource = _Operators;
					
					DataGridViewComboBoxColumn operatorColumn = (DataGridViewComboBoxColumn) (FilterList.Columns["OperationDataGridViewTextBoxColumn"]);
					
					if (operatorColumn != null)
					{
						operatorColumn.DataSource = bsOperators;
						operatorColumn.DisplayMember = "Name";
						operatorColumn.ValueMember = "Value";
					}
				}
			}
			
			private void btnAddFilter_Click(System.Object sender, System.EventArgs e)
			{
				bsFilterTable.AddNew();
			}
			
			public void NewFilter_Click(System.Object sender, System.EventArgs e)
			{
				bsFilterTable.AddNew();
			}
			
			public void DeleteFilter_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					bsFilterTable.RemoveCurrent();
				}
				catch (Exception)
				{
				}
				
			}
		}
	}
	
	
}
