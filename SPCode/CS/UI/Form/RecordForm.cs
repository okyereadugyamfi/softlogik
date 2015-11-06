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


namespace SoftLogik.Win
{
	namespace UI
	{
		public partial class RecordForm
		{
			public RecordForm()
			{
				InitializeComponent();
			}
			
			//Navigation Events
			public delegate void NavigationChangedEventHandler(System.Object sender, SPFormNavigateEventArgs e);
			private NavigationChangedEventHandler NavigationChangedEvent;
			
			public event NavigationChangedEventHandler NavigationChanged
			{
				add
				{
					NavigationChangedEvent = (NavigationChangedEventHandler) System.Delegate.Combine(NavigationChangedEvent, value);
				}
				remove
				{
					NavigationChangedEvent = (NavigationChangedEventHandler) System.Delegate.Remove(NavigationChangedEvent, value);
				}
			}
			
			public delegate void RecordBindingEventHandler(System.Object sender, SPFormRecordBindingEventArgs e);
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
			
			public delegate void RecordChangedEventHandler(System.Object sender, SPFormRecordUpdateEventArgs e);
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
			
			public delegate void RecordValidatingEventHandler(System.Object sender, SPFormValidatingEventArgs e);
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
			
			
			#region Properties
			
			protected DataTable _DataSource = null;
			protected SPRecordBindingSettings _BindingSettings;
			protected SPFormRecordStateManager _RecordState = new SPFormRecordStateManager();
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
					SPFormRecordBindingEventArgs dataBindSettings = new SPFormRecordBindingEventArgs();
					OnRecordBinding(dataBindSettings);
					this._RecordState.CurrentState = SPFormRecordModes.EditMode; //By Default Form is in Edit Mode
					this._RecordState.BindingData = true;
					_DataSource = dataBindSettings.DataSource;
					_BindingSettings = dataBindSettings.BindingSettings;
					_NewRecordProc = _BindingSettings.NewRecordProc;
					
					SPFormSupport.BindControls(this.Controls, ref DetailBinding, ref _RecordState, new SoftLogik.Win.UI.EventHandler(OnFieldChanged));
					
					MyTabOrderManager = new UI.SPTabOrderManager(this);
					MyTabOrderManager.SetTabOrder(UI.SPTabOrderManager.TabScheme.DownFirst); // set tab order
				}
				
			}
			
			protected override void OnActivated(System.EventArgs e)
			{
				base.OnActivated(e);
				
			}
			protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
			{
				if (_RecordState.CurrentState == SPFormRecordModes.DirtyMode || _RecordState.CurrentState == SPFormRecordModes.InsertMode)
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
					if (_RecordState.CurrentState == SPFormRecordModes.DirtyMode)
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
			protected virtual void OnRecordBinding(SPFormRecordBindingEventArgs e)
			{
				if (RecordBindingEvent != null) //let client respond
					RecordBindingEvent(this, e);
			}
			
			
			protected virtual void OnRecordChanged(SPFormRecordUpdateEventArgs e)
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
					if (_RecordState.CurrentState == SPFormRecordModes.EditMode && _RecordState.CurrentState != SPFormRecordModes.DirtyMode && (! _RecordState.BindingData))
					{
						_RecordState.CurrentState = SPFormRecordModes.DirtyMode;
						UpdateFormCaption(false);
						TStripSupport.ToolbarToggleSave(tbrMain, null);
					}
				}
				_RecordState.BindingData = false;
			}
			protected virtual void OnNewRecord()
			{
				try
				{
					DetailBinding.AddNew();
					DetailBinding.MoveFirst();
					this._RecordState.CurrentState = SPFormRecordModes.InsertMode;
					TStripSupport.ToolbarToggleSave(tbrMain, null);
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
					this._RecordState.CurrentState = SPFormRecordModes.EditMode;
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
					this._RecordState.CurrentState = SPFormRecordModes.EditMode;
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
					if (this._RecordState.CurrentState == SPFormRecordModes.InsertMode)
					{
						OnRecordChanged(new SPFormRecordUpdateEventArgs(_RecordState.NewRecordData, @SPFormDataStates.New));
						_RecordState.NewRecordData = null;
					}
					else
					{
						OnRecordChanged(new SPFormRecordUpdateEventArgs(((DataRowView) DetailBinding.Current).Row, SPFormDataStates.Edited));
					}
					
					
					_RecordState.CurrentState = SPFormRecordModes.EditMode;
					UpdateFormCaption(true);
				}
			}
			protected virtual void OnUndoRecord()
			{
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				if (DetailBinding.Current != null)
				{
					if (((DataRowView) DetailBinding.Current).IsNew)
					{
						DetailBinding.RemoveCurrent();
					}
					else
					{
						DetailBinding.CancelEdit();
					}
					
					
				}
				_RecordState.CurrentState = SPFormRecordModes.EditMode;
				UpdateFormCaption(true);
			}
			protected virtual void OnDeleteRecord()
			{
				try
				{
					if (MessageBox.Show("Are you sure you want to Delete \'" + ((DataRowView) DetailBinding.Current).Row(_BindingSettings.DisplayMember).ToString() + "\' ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						OnRecordChanged(new SPFormRecordUpdateEventArgs(((DataRowView) DetailBinding.Current).Row, SPFormDataStates.Deleted));
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
					_RecordState.CurrentState = SPFormRecordModes.InsertMode;
					//_RecordState.ShowingData = False
				}
			}
			protected virtual void OnNavigate(SPRecordNavigateDirections direction)
			{
				DataRow lastRecord;
				DataRow currentRecord;
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				_RecordState.ShowingData = true;
				lastRecord = ((DataRowView) DetailBinding.Current).Row;
				switch (direction)
				{
					case SPRecordNavigateDirections.First:
						SelectNameInList(0);
						break;
					case SPRecordNavigateDirections.Last:
						SelectNameInList(DetailBinding.Count - 1);
						break;
					case SPRecordNavigateDirections.Next:
						SelectNameInList(DetailBinding.Position + 1);
						break;
					case SPRecordNavigateDirections.Previous:
						SelectNameInList(DetailBinding.Position - 1);
						break;
				}
				
				_RecordState.ShowingData = false;
				currentRecord = ((DataRowView) DetailBinding.Current).Row;
				if (NavigationChangedEvent != null)
					NavigationChangedEvent(tbrMain, new SPFormNavigateEventArgs(direction, lastRecord, currentRecord));
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
					strText += ((strText.EndsWith("*")) ? Constants.vbNullString : "*").ToString();
					this.Text = strText;
				}
				else
				{
					this.Text = strText.Replace("*", Constants.vbNullString);
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
				
				if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarNew)
				{
					OnNewRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarSave)
				{
					OnSaveRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarDelete)
				{
					OnDeleteRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarUndo)
				{
					OnUndoRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarSearch)
				{
					OnSearchRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarCopy)
				{
					OnCopyRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarRefresh)
				{
					OnRefreshRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarSort)
				{
					OnSortRecord();
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarFirst)
				{
					OnNavigate(SPRecordNavigateDirections.First);
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarPrevious)
				{
					OnNavigate(SPRecordNavigateDirections.Previous);
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarNext)
				{
					OnNavigate(SPRecordNavigateDirections.Next);
				}
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarLast)
				{
					OnNavigate(SPRecordNavigateDirections.Last);
				} //Close Window
				else if (((ToolStripItem) sender).Name == TStripSupport.MasterToolbarButtonNames.ToolbarClose)
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
				DataRow lastRecord = null;
				DataRow currentRecord = null;
				
				if (selectedRow != - 1)
				{
					_RecordState.ShowingData = true;
					if (DetailBinding.Current != null)
					{
						lastRecord = ((DataRowView) DetailBinding.Current).Row;
					}
					DetailBinding.Position = selectedRow;
					_RecordState.ShowingData = false;
					if (DetailBinding.Current != null)
					{
						currentRecord = ((DataRowView) DetailBinding.Current).Row;
					}
					if (NavigationChangedEvent != null)
						NavigationChangedEvent(tbrMain, new SPFormNavigateEventArgs(SPRecordNavigateDirections.None, lastRecord, currentRecord));
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
						((DataRowView) (DetailBinding[e.NewIndex])).Row.ItemArray = _NewRecordProc.Invoke.Row.ItemArray;
						_RecordState.NewRecordData = ((DataRowView) (DetailBinding[e.NewIndex])).Row;
					}
				}
			}
			
		}
	}
	
	
	
	
}
