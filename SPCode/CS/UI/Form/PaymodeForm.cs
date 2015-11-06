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
//using SoftLogik.Win.SPDataProxy;
using System.ComponentModel;


namespace SoftLogik.Win
{
	namespace UI
	{
		public partial class PaymodeForm
		{
			public PaymodeForm()
			{
				InitializeComponent();
			}
			
			protected virtual DataRowView NewPayMode()
			{
				return SPPayMode.GetEmptyPayMode().DefaultView[0];
			}
			
			protected override void OnRecordChanged(SPFormRecordUpdateEventArgs e)
			{
				base.OnRecordChanged(e);
				SPPayModeRow recordRow = (SPPayModeRow) e.DataRow;
				if (recordRow != null)
				{
					switch (e.DataState)
					{
						case @SPFormDataStates.New:
							SPPayMode.InsertPayMode(recordRow.Name, recordRow.Category, recordRow.BankID, recordRow.Note);
							break;
						case SPFormDataStates.Edited:
							SPPayMode.UpdatePayMode(recordRow.PayModeID, recordRow.Name, recordRow.Category, recordRow.BankID, recordRow.Note);
							break;
						case SPFormDataStates.Deleted:
							SPPayMode.DeletePayMode(recordRow.PayModeID);
							break;
					}
					
				}
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				
				try
				{
					ddlCategory.DataSource = SPPayModeCategories.DefaulList;
					ddlCategory.DisplayMember = "Name";
					ddlCategory.ValueMember = "Category";
				}
				catch (Exception)
				{
				}
				
				base.OnLoad(e);
			}
			protected override void OnRecordBinding(SPFormRecordBindingEventArgs e)
			{
				base.OnRecordBinding(e);
				
				e.BindingSettings.DisplayMember = "Name";
				e.BindingSettings.ValueMember = "PayModeID";
				try
				{
					e.DataSource = SPPayMode.GetPayModes();
					e.BindingSettings.NewRecordProc = new System.EventHandler(NewPayMode);
				}
				catch (Exception)
				{
				}
				
			}
			
		}
	}
	
}
