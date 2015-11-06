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


namespace SoftLogik.Win.UI
	{
		public partial class MasterForm
		{
			public MasterForm()
			{
				InitializeComponent();
			}
			
			private string _TypeID = string.Empty;
			private DataRowView _NewRecordEmptyItem = null;
			
			public string TypeID
			{
				get
				{
					return _TypeID;
				}
				set
				{
					_TypeID = value;
				}
			}
			
			protected virtual DataRowView NewMaster()
			{
				return SPMaster.GetEmptyMaster(TypeID).DefaultView[0];
			}
			
			protected override void OnRecordChanged(SPFormRecordUpdateEventArgs e)
			{
				base.OnRecordChanged(e);
				SPMasterRow recordRow = (SPMasterRow) e.DataRow;
				if (recordRow != null)
				{
					switch (e.DataState)
					{
						case @SPFormDataStates.New:
							SPMaster.InsertMaster(recordRow.Name, recordRow.Note, TypeID);
							break;
						case SPFormDataStates.Edited:
							SPMaster.UpdateMaster(recordRow.MasterID, recordRow.Name, recordRow.Note);
							break;
						case SPFormDataStates.Deleted:
							SPMaster.DeleteMaster(recordRow.MasterID);
							break;
					}
					
				}
			}
			
			protected override void OnRecordBinding(SPFormRecordBindingEventArgs e)
			{
				base.OnRecordBinding(e);
				if (string.IsNullOrEmpty(TypeID) == false)
				{
					e.BindingSettings.DisplayMember = "Name";
					e.BindingSettings.ValueMember = "MasterID";
					try
					{
						e.DataSource = SPMaster.GetMaster(TypeID);
						e.BindingSettings.NewRecordProc = new System.EventHandler(NewMaster);
					}
					catch (Exception)
					{
					}
				}
				
				
			}
			
			
		}
	}