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
using SoftLogik.Win.Data;

namespace SoftLogik.Win.UI
	{
		public partial class LookupForm
		{
			public LookupForm()
			{
				InitializeComponent();
			}
			
			public delegate void ItemSelectedEventHandler(SPLookupFormItemSelectedEventArgs e);
			private ItemSelectedEventHandler ItemSelectedEvent;
			
			public event ItemSelectedEventHandler ItemSelected
			{
				add
				{
					ItemSelectedEvent = (ItemSelectedEventHandler) System.Delegate.Combine(ItemSelectedEvent, value);
				}
				remove
				{
					ItemSelectedEvent = (ItemSelectedEventHandler) System.Delegate.Remove(ItemSelectedEvent, value);
				}
			}
			
			
			
			#region Data Members
            private SimpleSearchCollection _DataSource;
			#endregion
			
			#region Properties
			private string _SearchType = string.Empty;
			public string SearchType
			{
				get
				{
					return _SearchType;
				}
				set
				{
					_SearchType = value;
				}
			}
			
			private string _SubType = string.Empty;
			public string SubType
			{
				get
				{
					return _SubType;
				}
				set
				{
					_SubType = value;
				}
			}
			
			private DataGridViewSelectedRowCollection _SearchResults = null;
			private DataGridViewRow _FirstResult = null;
			
			public DataGridViewRow FirstResult
			{
				get
				{
					return _FirstResult;
				}
			}
			public DataGridViewSelectedRowCollection SearchResults
			{
				get
				{
					return _SearchResults;
				}
			}
			#endregion
			
			private void BindResultList()
			{
				bsSimpleSearch.DataSource = SPSearchHelper.GetSearchResults(SearchType, SubType, SearchFor.Text, SearchText.Text);
				SimpleResults.DataSource = bsSimpleSearch;
				
				SimpleResults.Columns["ID"].Visible = false;
				SimpleResults.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			public void SimpleResults_DoubleClick(object sender, System.EventArgs e)
			{
				if ((SimpleResults.SelectedRows != null)&& SimpleResults.SelectedRows.Count > 0)
				{
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
					if (ItemSelectedEvent != null)
						ItemSelectedEvent(new SPLookupFormItemSelectedEventArgs(SimpleResults.SelectedRows[0], SimpleResults.SelectedRows));
					
					_FirstResult = SimpleResults.SelectedRows[0];
					_SearchResults = SimpleResults.SelectedRows;
				}
			}
			public void SearchFor_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				if (SearchText.CanFocus)
				{
					SearchText.Focus();
				}
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
				this.DockState = WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide;
				SearchFor.SelectedIndex = 0;
				BindResultList();
				
				base.OnLoad(e);
			}
			protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
			{
				//Me.DialogResult = CType(IIf(e.CloseReason <> CloseReason.UserClosing, System.Windows.Forms.DialogResult.OK, System.Windows.Forms.DialogResult.Cancel), System.Windows.Forms.DialogResult)
				base.OnFormClosing(e);
			}
			
			public void SearchText_TextChanged(System.Object sender, System.EventArgs e)
			{
				BindResultList();
			}
		}
		
		public class SPLookupFormItemSelectedEventArgs : EventArgs
		{
			
			
			private DataGridViewSelectedRowCollection _SelectedItems = null;
			private DataGridViewRow _FirstItem = null;
			
			public DataGridViewRow FirstItem
			{
				get
				{
					return _FirstItem;
				}
			}
			public DataGridViewSelectedRowCollection SelectedItems
			{
				get
				{
					return _SelectedItems;
				}
			}
			
			public SPLookupFormItemSelectedEventArgs(DataGridViewRow FirstItem, DataGridViewSelectedRowCollection SelectedItems)
			{
				this._FirstItem = FirstItem;
				this._SelectedItems = SelectedItems;
			}
		}
		
		
	}