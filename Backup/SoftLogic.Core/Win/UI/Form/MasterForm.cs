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
using SoftLogik.Win.Data;


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
                return new DataTable().DefaultView[0];  //SPMaster.GetEmptyMaster(TypeID).DefaultView[0];
			}
			
			protected override void OnRecordChanged(FormRecordUpdateEventArgs e)
			{
				base.OnRecordChanged(e);
                Master recordRow = new Master();
				switch (e.DataState)
				{
					case FormDataStates.New:
                        recordRow.Save();
						break;
					case FormDataStates.Edited:
                        Master oldRecord = Master.FetchByID(recordRow.MasterID);
                        oldRecord.Name = recordRow.Name;
                        oldRecord.GroupID = recordRow.GroupID;
                        oldRecord.Note = recordRow.Note;
                        oldRecord.GroupID = recordRow.GroupID;
						break;
					case FormDataStates.Deleted:
						Master.Delete(recordRow.MasterID);
						break;
				}

			}
			
			protected override void OnRecordBinding(FormRecordBindingEventArgs e)
			{
				base.OnRecordBinding(e);
				if (string.IsNullOrEmpty(TypeID) == false)
				{
					e.BindingSettings.DisplayMember = "Name";
					e.BindingSettings.ValueMember = "MasterID";
					try
					{
						e.DataSource = new MasterCollection().Where("GroupID", TypeID).Load().ToDataTable();
                        e.BindingSettings.NewRecordProc += new NewRecordCallback(NewMaster);
					}
					catch (Exception)
					{
					}
				}
				
				
			}
			
			
		}
	}