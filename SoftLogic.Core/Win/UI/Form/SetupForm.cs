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
using SoftLogik.Win.UI.Support;

namespace SoftLogik.Win.UI
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
                    _RecordState.BindingData = true; 
					CreateSetupView(_DataSource, _BindingSettings);
                    _RecordState.BindingData = false;
					ToolbarSupport.ToolbarToggleDefault(tbrMain, tvwName);
					if (_DataSource == null)
					{
						OnNewRecord();
					}
					else if (((IList)_DataSource).Count == 0)
					{
						OnNewRecord();
					}
				}
			}

            protected override void OnNewRecord()
            {
                base.OnNewRecord();
                if (DetailBinding.Current != null)
                {
                    ToolbarSupport.ToolbarToggleSave(tbrMain, tvwName);
                }
            }
			protected override void OnSaveRecord()
			{
				base.OnSaveRecord();
				if (DetailBinding.Current != null)
				{
					RefreshMaster();
					ToolbarSupport.ToolbarToggleDefault(tbrMain, tvwName);
				}
			}
			protected override void OnRefreshRecord()
			{
				try
				{
					this._RecordState.CurrentState = FormRecordModes.EditMode;
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
					this._RecordState.CurrentState = FormRecordModes.EditMode;
					this._RecordState.ShowingData = true;
					DetailBinding.Sort =  _BindingSettings.DisplayMember + _lastSortOrder;
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
				ToolbarSupport.ToolbarToggleDefault(tbrMain, tvwName);
			}
			protected override void OnNavigate(RecordNavigateDirections direction)
			{
				base.OnNavigate(direction);
				_RecordState.ShowingData = true;
				SyncNameList();
				_RecordState.ShowingData = false;
			}
			
			protected virtual void SyncNameList()
			{
				foreach (DataTreeNode node in tvwName.Nodes)
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
			protected virtual bool SyncNameList(DataTreeNode InnerNode)
			{
				foreach (DataTreeNode node in InnerNode.Nodes)
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
			protected virtual void CreateSetupView(object DataSource, RecordBindingSettings bindingSettings)
			{
				if (DataSource != null)
				{
					
					tvwName.DataSource = DataSource;
					tvwName.DisplayMember = bindingSettings.DisplayMember;
					tvwName.ValueMember = bindingSettings.ValueMember;
					DetailBinding.DataSource = DataSource;
					tvwName.SetLeafData(bindingSettings.DisplayMember, bindingSettings.DisplayMember, bindingSettings.ValueMember, 0, - 1);
					foreach (DataTreeNodeGroup itm in bindingSettings.NodeGroups)
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