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


namespace SoftLogik.Win.UI.Controls
{
	[Description("Data Aware MenuStrip Component")]
    [ToolboxBitmap(typeof(MenuStrip), "DataMenuStrip")]
    public partial class DataMenuStrip
	{
		
		
		protected override void OnPaint(PaintEventArgs pe)
		{
			// Calling the base class OnPaint
			base.OnPaint(pe);
		}
		
		private bool m_autoBuild = true;
		
		public bool AutoBuildTree
		{
			get
			{
				return this.m_autoBuild;
			}
			set
			{
				this.m_autoBuild = value;
			}
		}
		
		#region Data Binding
		private CurrencyManager m_currencyManager = null;
		private string m_ValueMember;
		private string m_DisplayMember;
		private object m_oDataSource;
		
		[Category("Data")]public object DataSource
		{
			get
			{
				return m_oDataSource;
			}
			set
			{
				if (value == null)
				{
					this.m_currencyManager = null;
					this.Items.Clear();
				}
				else
				{
					if (!(value is IList|| m_oDataSource is IListSource))
					{
						throw (new System.Exception("Invalid DataSource"));
					}
					else
					{
						if (value is IListSource)
						{
							IListSource myListSource = (IListSource) value;
							if (myListSource.ContainsListCollection == true)
							{
								throw (new System.Exception("Invalid DataSource"));
							}
						}
						this.m_oDataSource = value;
						this.m_currencyManager = (CurrencyManager) (this.BindingContext[value]);
						if (this.AutoBuildTree)
						{
							BuildTree();
						}
					}
				}
			}
		} // end of DataSource property
		
		[Category("Data")]public string ValueMember
		{
			get
			{
				return this.m_ValueMember;
			}
			set
			{
				this.m_ValueMember = value;
			}
		}
		
		[Category("Data")]public string DisplayMember
		{
			get
			{
				return this.m_DisplayMember;
			}
			set
			{
				this.m_DisplayMember = value;
			}
		}
		
		public object GetValue(int index)
		{
			IList innerList = this.m_currencyManager.List;
			if (innerList != null)
			{
				if ((this.ValueMember != "") && (index >= 0 && 0 < innerList.Count))
				{
					PropertyDescriptor pdValueMember;
					pdValueMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
					return pdValueMember.GetValue(innerList[index]);
				}
			}
			return null;
		}
		
		public object GetDisplay(int index)
		{
			IList innerList = this.m_currencyManager.List;
			if (innerList != null)
			{
				if ((this.DisplayMember != "") && (index >= 0 && 0 < innerList.Count))
				{
					PropertyDescriptor pdDisplayMember;
					pdDisplayMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
					return pdDisplayMember.GetValue(innerList[index]);
				}
			}
			return null;
		}
		
		#endregion
		
		#region Building the Tree
		
		private ArrayList treeGroups = new ArrayList();
		
		public void BuildTree()
		{
			this.Items.Clear();
			if ((this.m_currencyManager != null) && (this.m_currencyManager.List != null))
			{
				IList innerList = this.m_currencyManager.List;
				ToolStripItemCollection currNode = this.Items;
				int currGroupIndex = 0;
				int currListIndex = 0;
				
				
				if (this.treeGroups.Count > currGroupIndex)
				{
					DataTreeNodeGroup currGroup = (DataTreeNodeGroup) (treeGroups[currGroupIndex]);
					MenuStripItem myFirstNode = null;
					PropertyDescriptor pdGroupBy;
					PropertyDescriptor pdValue;
					PropertyDescriptor pdDisplay;
					
					pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
					pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
					pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
					
					string currGroupBy = null;
					if (innerList.Count > currListIndex)
					{
						object currObject;
						while (currListIndex < innerList.Count)
						{
							currObject = innerList[currListIndex];
							if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy)
							{
								currGroupBy = pdGroupBy.GetValue(currObject).ToString();
								
								myFirstNode = new MenuStripItem(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList[currListIndex]), currGroup.ImageIndex, currListIndex);
								
								currNode.Add((ToolStripItem) myFirstNode);
							}
							else
							{
								AddMenuItems(currGroupIndex, ref currListIndex, this.Items, currGroup.GroupBy);
							}
						} // end while
					} // end if
				}
				else
				{
					while (currListIndex < innerList.Count)
					{
						AddMenuItems(currGroupIndex, ref currListIndex, this.Items, "");
					}
				} // end else
				
				
				
			} // end if
		}
		
		private void AddMenuItems(int currGroupIndex, ref int currentListIndex, ToolStripItemCollection currNodes, string prevGroupByField)
		{
			IList innerList = this.m_currencyManager.List;
			System.ComponentModel.PropertyDescriptor pdPrevGroupBy = null;
			string prevGroupByValue = null;
			
			DataTreeNodeGroup currGroup;
			
			if (prevGroupByField != "")
			{
				pdPrevGroupBy = this.m_currencyManager.GetItemProperties()[prevGroupByField];
			}
			
			currGroupIndex++;
			
			if (treeGroups.Count > currGroupIndex)
			{
				currGroup = (DataTreeNodeGroup) (treeGroups[currGroupIndex]);
				PropertyDescriptor pdGroupBy = null;
				PropertyDescriptor pdValue = null;
				PropertyDescriptor pdDisplay = null;
				
				pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
				pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
				pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
				
				string currGroupBy = null;
				
				if (innerList.Count > currentListIndex)
				{
					if (pdPrevGroupBy != null)
					{
						prevGroupByValue = pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString();
					}
					
					MenuStripItem myFirstNode = null;
					object currObject = null;
					
					while ((currentListIndex < innerList.Count) && (pdPrevGroupBy != null) && (pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString() == prevGroupByValue))
					{
						currObject = innerList[currentListIndex];
						if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy)
						{
							currGroupBy = pdGroupBy.GetValue(currObject).ToString();
							
							myFirstNode = new MenuStripItem(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList[currentListIndex]), currGroup.ImageIndex, currentListIndex);
							
							currNodes.Add(myFirstNode);
						}
						else
						{
							AddMenuItems(currGroupIndex, ref currentListIndex, this.Items, currGroup.GroupBy);
						}
					}
				}
			}
			else
			{
				MenuStripItem myNewLeafNode;
				object currObject = this.m_currencyManager.List[currentListIndex];
				
				if ((this.DisplayMember != null) && (this.ValueMember != null) && (this.DisplayMember != "") && (this.ValueMember != ""))
				{
					PropertyDescriptor pdDisplayloc = this.m_currencyManager.GetItemProperties()[this.DisplayMember];
					PropertyDescriptor pdValueloc = this.m_currencyManager.GetItemProperties()[this.ValueMember];
					
					if (this.Tag == null)
					{
						myNewLeafNode = new MenuStripItem("", pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex);
					}
					else
					{
						myNewLeafNode = new MenuStripItem(this.Tag.ToString(), pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex);
					}
				}
				else
				{
					myNewLeafNode = new MenuStripItem("", currentListIndex.ToString(), currObject, currObject, currentListIndex, currentListIndex);
				}
				
				currNodes.Add(myNewLeafNode);
				currentListIndex++;
			}
		}
		#endregion
		
	}
	
	
	[Description("Specify Grouping for a collection of Menu Items in MenuStrip")]public class MenuStripItemGroup
	{
		
		private string groupName;
		private string groupByMember;
		private string groupByDisplayMember;
		private string groupByValueMember;
		
		private int groupImageIndex;
		
		public MenuStripItemGroup(string name, string groupBy, string displayMember, string valueMember, int imageIndex)
		{
			this.ImageIndex = imageIndex;
			this.Name = name;
			this.GroupBy = groupBy;
			this.DisplayMember = displayMember;
			this.ValueMember = valueMember;
		}
		
		public MenuStripItemGroup(string name, string groupBy) : this(name, groupBy, groupBy, groupBy, - 1)
		{
		}
		
		public int ImageIndex
		{
			get
			{
				return groupImageIndex;
			}
			set
			{
				groupImageIndex = value;
			}
		}
		
		public string Name
		{
			get
			{
				return groupName;
			}
			set
			{
				groupName = value;
			}
		}
		
		public string GroupBy
		{
			get
			{
				return groupByMember;
			}
			set
			{
				groupByMember = value;
			}
		}
		
		public string DisplayMember
		{
			get
			{
				return groupByDisplayMember;
			}
			set
			{
				groupByDisplayMember = value;
			}
		}
		public string ValueMember
		{
			get
			{
				return groupByValueMember;
			}
			set
			{
				groupByValueMember = value;
			}
		}
	}
	[Description("A menu item in the MenuStrip")]public class MenuStripItem : ToolStripMenuItem
	{
		
		private string m_groupName;
		private object m_value;
		private object m_item;
		private int m_position;
		
		public MenuStripItem()
		{
			
		}
		
		public MenuStripItem(string GroupName, string text, object item, object value, int imageIndex, int position)
		{
			this.GroupName = GroupName;
			this.Text = text;
			this.Item = item;
			this.Value = value;
			this.ImageIndex = imageIndex;
			this.m_position = position;
		}
		
		public MenuStripItem(string groupName, string text, object item, object value, int position)
		{
			this.GroupName = groupName;
			this.Text = text;
			this.Item = item;
			this.Value = value;
			this.m_position = position;
		}
		
		public string GroupName
		{
			get
			{
				return m_groupName;
			}
			set
			{
				this.m_groupName = value;
			}
		}
		
		public object Item
		{
			get
			{
				return m_item;
			}
			set
			{
				m_item = value;
			}
		}
		
		public object Value
		{
			get
			{
				return m_value;
			}
			set
			{
				m_value = value;
			}
		}
		
		public int Position
		{
			get
			{
				return m_position;
			}
		}
	}
}
