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
	namespace UI
	{
		public partial class SetupForm
		{
			public SetupForm()
			{
				InitializeComponent();
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				if (! DesignMode)
				{
					CreateSetupView(_DataSource, _BindingSettings);
					TStripSupport.ToolbarToggleDefault(tbrMain, tvwName);
					if (_DataSource == null)
					{
						OnNewRecord();
					}
					else if (_DataSource.Rows.Count == 0)
					{
						OnNewRecord();
					}
				}
			}
			
			protected override void OnFieldChanged(System.Object sender, System.EventArgs e)
			{
				if (_RecordState.ShowingData == false)
				{
					if (_RecordState.CurrentState == SPFormRecordModes.EditMode && _RecordState.CurrentState != SPFormRecordModes.DirtyMode && (! _RecordState.BindingData))
					{
						_RecordState.CurrentState = SPFormRecordModes.DirtyMode;
						UpdateFormCaption(false);
						TStripSupport.ToolbarToggleSave(tbrMain, tvwName);
					}
				}
				_RecordState.BindingData = false;
			}
			protected override void OnNewRecord()
			{
				try
				{
					DetailBinding.AddNew();
					this._RecordState.CurrentState = SPFormRecordModes.InsertMode;
					TStripSupport.ToolbarToggleSave(tbrMain, tvwName);
					FirstFieldFocus();
				}
				catch (Exception)
				{
				}
			}
			protected override void OnSaveRecord()
			{
				base.OnSaveRecord();
				if (DetailBinding.Current != null)
				{
					RefreshMaster();
					TStripSupport.ToolbarToggleDefault(tbrMain, tvwName);
				}
			}
			protected override void OnRefreshRecord()
			{
				try
				{
					this._RecordState.CurrentState = SPFormRecordModes.EditMode;
					this._RecordState.ShowingData = true;
					OnLoad(new EventArgs());
					FirstFieldFocus();
					this._RecordState.ShowingData = false;
				}
				catch (Exception)
				{
				}
			}
			
			private string _lastSortOrder = " DESC ";
			protected override void OnSortRecord()
			{
				try
				{
					this._RecordState.CurrentState = SPFormRecordModes.EditMode;
					this._RecordState.ShowingData = true;
					_DataSource.DefaultView.Sort = _BindingSettings.DisplayMember + _lastSortOrder;
					if (_lastSortOrder == " ASC ")
					{
						_lastSortOrder = " DESC ";
					}
					else
					{
						_lastSortOrder = " ASC ";
					}
					
					RefreshMaster();
					this._RecordState.ShowingData = false;
					FirstFieldFocus();
				}
				catch (Exception)
				{
				}
			}
			protected override void OnDeleteRecord()
			{
				base.OnDeleteRecord();
				_RecordState.ShowingData = true;
				RefreshMaster();
				_RecordState.ShowingData = false;
			}
			protected override void OnUndoRecord()
			{
				base.OnUndoRecord();
				TStripSupport.ToolbarToggleDefault(tbrMain, tvwName);
			}
			protected override void OnNavigate(SPRecordNavigateDirections direction)
			{
				base.OnNavigate(direction);
				_RecordState.ShowingData = true;
				SyncNameList();
				_RecordState.ShowingData = false;
			}
			
			protected virtual void SyncNameList()
			{
				foreach (SPTreeNode node in tvwName.Nodes)
				{
					if (node.Index == DetailBinding.Position)
					{
						tvwName.SelectedNode = node;
						return;
					}
					else
					{
						if (node.Nodes.Count > 0)
						{
							if (SyncNameList(node))
							{
								return;
							}
						}
					}
				}
			}
			protected virtual bool SyncNameList(SPTreeNode InnerNode)
			{
				foreach (SPTreeNode node in InnerNode.Nodes)
				{
					if (node.Index == DetailBinding.Position)
					{
						tvwName.SelectedNode = node;
						return true;
					}
					else
					{
						SyncNameList(node);
					}
				}
				return false;
			}
			protected virtual void CreateSetupView(DataTable DataSource, SPRecordBindingSettings bindingSettings)
			{
				if (DataSource != null)
				{
					
					tvwName.DataSource = DataSource.DefaultView;
					tvwName.DisplayMember = bindingSettings.DisplayMember;
					tvwName.ValueMember = bindingSettings.ValueMember;
					DetailBinding.DataSource = DataSource;
					tvwName.SetLeafData(bindingSettings.DisplayMember, bindingSettings.DisplayMember, bindingSettings.ValueMember, 0, - 1);
					foreach (SPTreeNodeGroup itm in bindingSettings.NodeGroups)
					{
						tvwName.AddGroup(itm.Name, itm.GroupBy, itm.DisplayMember, itm.ValueMember, itm.ImageIndex, itm.SelectedImageIndex);
					}
					tvwName.BuildTree();
					
				}
			}
			public void tvwName_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
			{
				SelectNameInList(e.Node.Index);
			}
			private void RefreshMaster()
			{
				if (_DataSource != null)
				{
					tvwName.BuildTree();
				}
				DetailBinding.ResetBindings(false);
			}
			
		}
	}
	
}
