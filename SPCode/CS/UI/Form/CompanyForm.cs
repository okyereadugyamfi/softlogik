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
using SoftLogik.Win.SPDataProxyTableAdapters;


namespace SoftLogik.Win
{
	namespace UI
	{
		public partial class CompanyForm
		{
			public CompanyForm()
			{
				InitializeComponent();
			}
			
			private DataRowView _NewRecordEmptyItem = null;
			
			protected virtual DataRowView NewCompany()
			{
				return SPCompanyData.GetEmptyRecord().DefaultView[0];
			}
			
			private void CompanyForm_RecordBinding(object sender, SPFormRecordBindingEventArgs e)
			{
				
				e.BindingSettings.DisplayMember = "Name";
				e.BindingSettings.ValueMember = "CompanyID";
				
				try
				{
					e.DataSource = SPCompanyData.GetCompanies();
					e.BindingSettings.NewRecordProc = new System.EventHandler(NewCompany);
				}
				catch (Exception)
				{
				}
			}
			
			private void CompanyForm_RecordUpdated(object sender, SPFormRecordUpdateEventArgs e)
			{
				SPCompanyRow recordRow = (SPCompanyRow) e.DataRow;
				if (recordRow != null)
				{
					switch (e.DataState)
					{
						case @SPFormDataStates.New:
							SPCompanyData.InsertCompany(recordRow.Name, recordRow.PhoneList, recordRow.EmailAddress, recordRow.Address1, recordRow.Address2, recordRow.Logo, recordRow.Motto, recordRow.CustomNote);
							break;
						case SPFormDataStates.Edited:
							SPCompanyData.UpdateCompany(recordRow.CompanyID, recordRow.Name, recordRow.PhoneList, recordRow.EmailAddress, recordRow.Address1, recordRow.Address2, recordRow.Logo, recordRow.Motto, recordRow.CustomNote);
							break;
						case SPFormDataStates.Deleted:
							SPCompanyData.DeleteCompany(recordRow.CompanyID);
							break;
					}
					
				}
			}
			
			public void btnChangePhoto_Click(System.Object sender, System.EventArgs e)
			{
				
				try
				{
					Logo.Image = Image.FromFile(SPFileDialog.ShowDialog(SPFileDialog.FileDialogTypes.Picture));
					txtName.Text += " ";
					
					txtName.Text = txtName.Text.TrimEnd();
				}
				catch (Exception)
				{
				}
			}
			
			public void btnClearPhoto_Click(System.Object sender, System.EventArgs e)
			{
				Logo.Image = null;
				txtName.Text += " ";
				
				txtName.Text = txtName.Text.TrimEnd();
			}
			
			public void Logo_BackgroundImageChanged(object sender, System.EventArgs e)
			{
				
			}
			
			public void Logo_Invalidated(object sender, System.Windows.Forms.InvalidateEventArgs e)
			{
				
			}
			
			
		}
	}
	
	
	
}
