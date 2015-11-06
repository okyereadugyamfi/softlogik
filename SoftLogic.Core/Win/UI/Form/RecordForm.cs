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
using System.IO;
using System.Drawing.Imaging;
using SoftLogik.Win.UI;
using SoftLogik.Win.UI.Support;


namespace SoftLogik.Win.UI
	{
		public partial class RecordForm
		{
			public RecordForm()
			{
				InitializeComponent();
            }

            #region Event Dispatch
			public delegate void RecordBindingEventHandler(System.Object sender, FormRecordBindingEventArgs e);
			private RecordBindingEventHandler RecordBindingEvent;
			
			public event RecordBindingEventHandler RecordBinding
			{
				add
				{
					RecordBindingEvent = (RecordBindingEventHandler) System.Delegate.Combine(RecordBindingEvent, value);
				}
				remove
				{
					RecordBindingEvent = (RecordBindingEventHandler) System.Delegate.Remove(RecordBindingEvent, value);
				}
			}

            public delegate void RecordNavigateEventHandler(System.Object sender, RecordNavigateEventArgs e);
            private RecordNavigateEventHandler RecordNavigateEvent;

            public event RecordNavigateEventHandler RecordNavigate
            {
                add
                {
                    RecordNavigateEvent = (RecordNavigateEventHandler)System.Delegate.Combine(RecordNavigateEvent, value);
                }
                remove
                {
                    RecordNavigateEvent = (RecordNavigateEventHandler)System.Delegate.Remove(RecordNavigateEvent, value);
                }
            }
			
			public delegate void DataboundEventHandler(System.Object sender, System.EventArgs e);
			private DataboundEventHandler DataboundEvent;
			
			public event DataboundEventHandler Databound
			{
				add
				{
					DataboundEvent = (DataboundEventHandler) System.Delegate.Combine(DataboundEvent, value);
				}
				remove
				{
					DataboundEvent = (DataboundEventHandler) System.Delegate.Remove(DataboundEvent, value);
				}
			}
			
			public delegate void RecordChangedEventHandler(System.Object sender, FormRecordUpdateEventArgs e);
			private RecordChangedEventHandler RecordChangedEvent;
			
			public event RecordChangedEventHandler RecordChanged
			{
				add
				{
					RecordChangedEvent = (RecordChangedEventHandler) System.Delegate.Combine(RecordChangedEvent, value);
				}
				remove
				{
					RecordChangedEvent = (RecordChangedEventHandler) System.Delegate.Remove(RecordChangedEvent, value);
				}
			}
			
			public delegate void RecordValidatingEventHandler(System.Object sender, FormValidatingEventArgs e);
			private RecordValidatingEventHandler RecordValidatingEvent;
			
			public event RecordValidatingEventHandler RecordValidating
			{
				add
				{
					RecordValidatingEvent = (RecordValidatingEventHandler) System.Delegate.Combine(RecordValidatingEvent, value);
				}
				remove
				{
					RecordValidatingEvent = (RecordValidatingEventHandler) System.Delegate.Remove(RecordValidatingEvent, value);
				}
            }
            #endregion

            #region Properties

            protected object _DataSource = null;
			protected RecordBindingSettings _BindingSettings;
			protected FormRecordStateManager _RecordState = new FormRecordStateManager();
			protected LookupForm _LookupForm;
			protected Control _FirstField = null;
			protected NewRecordCallback _NewRecordProc;
			
			public LookupForm LookupForm
			{
				set
				{
					_LookupForm = value;
				}
			}
			
			#endregion

			#region Form Overrides
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				//WindowState = FormWindowState.Maximized
				
				if (! DesignMode)
				{
					FormRecordBindingEventArgs dataBindSettings = new FormRecordBindingEventArgs();
					OnRecordBinding(dataBindSettings);
					this._RecordState.CurrentState = FormRecordModes.EditMode; //By Default Form is in Edit Mode
					this._RecordState.BindingData = true;
					_DataSource = dataBindSettings.DataSource;
					_BindingSettings = dataBindSettings.BindingSettings;
					_NewRecordProc = _BindingSettings.NewRecordProc;
					
					SPFormSupport.BindControls(this.Controls, ref DetailBinding, new System.EventHandler(OnFieldChanged));
					
					MyTabOrderManager = new UI.VisualTabOrderManager(this);
					MyTabOrderManager.SetTabOrder(UI.VisualTabOrderManager.TabScheme.DownFirst); // set tab order

				}
				
			}
			
			protected override void OnActivated(System.EventArgs e)
			{
				base.OnActivated(e);
				
			}

            private bool m_boolAlreadyExiting = false;
            public bool AlreadyExiting
            {
                set { m_boolAlreadyExiting = value; }
            }
			protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
			{
                if (!m_boolAlreadyExiting)
                {
				    if (_RecordState.CurrentState == FormRecordModes.DirtyMode || _RecordState.CurrentState == FormRecordModes.InsertMode)
				    {
					    DialogResult msgResult = MessageBox.Show("Save Changes made to " + this.Text + "?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
    					
					    switch (msgResult)
					    {
						    case System.Windows.Forms.DialogResult.Yes:
							    OnSaveRecord(); //Save Changes
							    break;
						    case System.Windows.Forms.DialogResult.No:
							    break;
						    case System.Windows.Forms.DialogResult.Cancel:
							    e.Cancel = true;
							    break;
					    }
				    } 
                }

				base.OnFormClosing(e);
			}
			protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
			{
				base.OnKeyDown(e);
				
				if (e.Control)
				{
					switch (e.KeyCode)
					{
						case Keys.N:
							NewRecord.PerformClick();
							break;
						case Keys.S:
							SaveRecord.PerformClick();
							break;
						case Keys.Delete:
							DeleteRecord.PerformClick();
							break;
					}
				}
				
				if (e.KeyCode == Keys.Escape)
				{
					if (_RecordState.CurrentState == FormRecordModes.DirtyMode)
					{
						UndoRecord.PerformClick();
					}
					else
					{
						CloseWindow.PerformClick();
					}
				}
				
				
			}
			#endregion
			
			#region Protected Overrides
			protected virtual void OnRecordBinding(FormRecordBindingEventArgs e)
			{
				if (RecordBindingEvent != null) //let client respond
					RecordBindingEvent(this, e);
			}
            protected virtual void OnRecordNavigate(RecordNavigateEventArgs e)
            {

                if (RecordNavigateEvent != null)
                    RecordNavigateEvent(tbrMain, e);
            }
			protected virtual void OnRecordChanged(FormRecordUpdateEventArgs e)
			{
				if (RecordChangedEvent != null)
					RecordChangedEvent(this, e);
			}
			#endregion

			#region Private Methods
			protected virtual void OnFieldChanged(System.Object sender, System.EventArgs e)
			{
				if (_RecordState.ShowingData == false)
				{
					if (_RecordState.CurrentState == FormRecordModes.EditMode && _RecordState.CurrentState != FormRecordModes.DirtyMode && (! _RecordState.BindingData))
					{
						_RecordState.CurrentState = FormRecordModes.DirtyMode;
						UpdateFormCaption(false);
						ToolbarSupport.ToolbarToggleSave(tbrMain, null);
					}
				}
				_RecordState.BindingData = false;
			}
			protected virtual void OnNewRecord()
			{
				try
				{
					DetailBinding.AddNew();
					//DetailBinding.MoveFirst();
					this._RecordState.CurrentState = FormRecordModes.InsertMode;
					ToolbarSupport.ToolbarToggleSave(tbrMain, null);
					FirstFieldFocus();
				}
				catch (Exception)
				{
				}
			}
			protected virtual void OnRefreshRecord()
			{
				try
				{
					this._RecordState.CurrentState = FormRecordModes.EditMode;
					FirstFieldFocus();
				}
				catch (Exception)
				{
				}
			}
			protected virtual void OnSortRecord()
			{
				try
				{
					this._RecordState.CurrentState = FormRecordModes.EditMode;
					FirstFieldFocus();
				}
				catch (Exception)
				{
				}
			}
			protected virtual void OnSaveRecord()
			{
				this.Validate();
				try
				{
					_RecordState.ShowingData = true;
					DetailBinding.EndEdit();
					_RecordState.ShowingData = false;
				}
				catch (Exception)
				{
					return;
				}
				
				if (DetailBinding.Current != null)
				{
					if (this._RecordState.CurrentState == FormRecordModes.InsertMode)
					{
						OnRecordChanged(new FormRecordUpdateEventArgs(_RecordState.NewRecordData, FormDataStates.New));
						_RecordState.NewRecordData = null;
					}
					else
					{
						OnRecordChanged(new FormRecordUpdateEventArgs(DetailBinding.Current, FormDataStates.Edited));
					}
					
					
					_RecordState.CurrentState = FormRecordModes.EditMode;
					UpdateFormCaption(true);
				}
			}
			protected virtual void OnUndoRecord()
			{
				if (DetailBinding.Current != null)
				{
					DetailBinding.CancelEdit();
                    DetailBinding.ResetBindings(false);
					
				}
				_RecordState.CurrentState = FormRecordModes.EditMode;
				UpdateFormCaption(true);
			}
			protected virtual void OnDeleteRecord()
			{
				try
				{
					if (MessageBox.Show("Are you sure you want to Delete \'" + ((DataRowView) DetailBinding.Current).Row[_BindingSettings.DisplayMember].ToString() + "\' ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						OnRecordChanged(new FormRecordUpdateEventArgs(((DataRowView) DetailBinding.Current).Row, FormDataStates.Deleted));
						_RecordState.ShowingData = true;
						DetailBinding.RemoveCurrent();
						_RecordState.ShowingData = false;
					}
				}
				catch (Exception)
				{
				}
			}
			protected virtual void OnSearchRecord()
			{
				if (_LookupForm != null)
				{
					_LookupForm.ShowDialog(this);
					//.SearchResults()
				}
			}
			protected virtual void OnCopyRecord()
			{
				if (DetailBinding.Current != null)
				{
					//_RecordState.ShowingData = True
					DataRowView clonedDataRow = (DataRowView) DetailBinding.Current;
					DataRowView newDataRow = (DataRowView) (DetailBinding.AddNew());
					DuplicateRecord(clonedDataRow, ref newDataRow);
					DetailBinding.ResetBindings(false);
					_RecordState.CurrentState = FormRecordModes.InsertMode;
					//_RecordState.ShowingData = False
				}
			}
            protected virtual void OnNavigate(RecordNavigateDirections direction)
			{
				object lastRecord;
				object currentRecord;
 				_RecordState.ShowingData = true;
				lastRecord = DetailBinding.Current;
				switch (direction)
				{
					case RecordNavigateDirections.First:
						SelectNameInList(0);
						break;
					case RecordNavigateDirections.Last:
						SelectNameInList(DetailBinding.Count - 1);
						break;
					case RecordNavigateDirections.Next:
						SelectNameInList(DetailBinding.Position + 1);
						break;
					case RecordNavigateDirections.Previous:
						SelectNameInList(DetailBinding.Position - 1);
						break;
				}
				
				_RecordState.ShowingData = false;
				currentRecord = DetailBinding.Current;
                OnRecordNavigate(new RecordNavigateEventArgs(direction, ref lastRecord, ref currentRecord)); 
			}

			protected virtual void OnCloseWindow()
			{
				this.Close();
			}
			
			#endregion
			#region Support Methods
			protected virtual void UpdateFormCaption(bool Clear)
			{
				string strText = this.Text;
				
				if (! Clear)
				{
					strText += ((strText.EndsWith("*")) ? string.Empty : "*").ToString();
					this.Text = strText;
				}
				else
				{
					this.Text = strText.Replace("*", string.Empty);
				}
			}
			protected virtual void FirstFieldFocus()
			{
				int lastTabIndex;
				try
				{
					Control firstControl = this.GetNextControl(this, true);
					if (firstControl != null)
					{
						lastTabIndex = firstControl.TabIndex;
						FindFirstField(firstControl, ref lastTabIndex);
					}
				}
				catch (Exception)
				{
					return;
				}
				
			}
			private void FindFirstField(Control OuterControl, ref int lastTabIndex)
			{
				Control ctl = OuterControl;
				while (ctl != null)
				{
					if ((! ctl.HasChildren) && (ctl.CanFocus && ctl.CanSelect))
					{
						ctl.Focus();
						return;
					}
					else
					{
						ctl = ctl.GetNextControl(ctl, true);
						FindFirstField(ctl, ref lastTabIndex);
					}
				}
			}
			private void DuplicateRecord(DataRowView SourceRow, ref DataRowView TargetRow)
			{
				_RecordState.DuplicatingData = true;
				TargetRow.Row.ItemArray = SourceRow.Row.ItemArray;
				
				foreach (DataColumn itm in TargetRow.Row.Table.Columns)
				{
					if (itm.ReadOnly)
					{
						if (itm.AutoIncrement)
						{
							TargetRow[itm.ColumnName] = 0;
						}
					}
				}
				_RecordState.DuplicatingData = false;
			}
			#endregion
			#region List and Toolbar Events
			protected virtual void ToolbarOperation(System.Object sender, System.EventArgs e)
			{
				
				if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarNew)
				{
					OnNewRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarSave)
				{
					OnSaveRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarDelete)
				{
					OnDeleteRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarUndo)
				{
					OnUndoRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarSearch)
				{
					OnSearchRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarCopy)
				{
					OnCopyRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarRefresh)
				{
					OnRefreshRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarSort)
				{
					OnSortRecord();
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarFirst)
				{
					OnNavigate(RecordNavigateDirections.First);
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarPrevious)
				{
					OnNavigate(RecordNavigateDirections.Previous);
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarNext)
				{
					OnNavigate(RecordNavigateDirections.Next);
				}
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarLast)
				{
					OnNavigate(RecordNavigateDirections.Last);
				} //Close Window
				else if (((ToolStripItem) sender).Name == ToolbarSupport.MasterToolbarButtonNames.ToolbarClose)
				{
					OnCloseWindow();
				}
			}
			public void tbrMain_ItemClicked(System.Object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
			{
				ToolbarOperation(e.ClickedItem, e);
			}
			protected virtual void SelectNameInList(int Index)
			{
				int selectedRow = Index;
				object lastRecord = null;
				object currentRecord = null;
				
				if (selectedRow != - 1)
				{
					_RecordState.ShowingData = true;
					if (DetailBinding.Current != null)
					{
						lastRecord = DetailBinding.Current;
					}
					DetailBinding.Position = selectedRow;
					_RecordState.ShowingData = false;
					if (DetailBinding.Current != null)
					{
						currentRecord =  DetailBinding.Current;
					}
                    OnNavigate(RecordNavigateDirections.None);
				}
			}
			#endregion
			
			public void DetailBinding_BindingComplete(object sender, System.Windows.Forms.BindingCompleteEventArgs e)
			{
				this._RecordState.BindingData = false;
			}
			
			public void DetailBinding_DataSourceChanged(object sender, System.EventArgs e)
			{
				this._RecordState.BindingData = true;
			}
			
			public void DetailBinding_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
			{
				if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
				{
					if ((_NewRecordProc != null)&& _RecordState.DuplicatingData == false && _RecordState.ShowingData == false)
					{
						DetailBinding[e.NewIndex] = _NewRecordProc.Invoke();
                        _RecordState.NewRecordData = DetailBinding[e.NewIndex];
					}
				}
			}
			
		}
	}
	
	
	
	

