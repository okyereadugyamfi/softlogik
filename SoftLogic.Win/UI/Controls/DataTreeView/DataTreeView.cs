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
	/// <summary>
	/// Treeview Control that utilizes a Custom Data Source Manager .
	/// </summary>
    [ToolboxBitmap(typeof(TreeView), "DataTreeView")]
	public partial class DataTreeView
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
					this.Nodes.Clear();
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
			this.Nodes.Clear();
			if ((this.m_currencyManager != null) && (this.m_currencyManager.List != null))
			{
				IList innerList = this.m_currencyManager.List;
				TreeNodeCollection currNode = this.Nodes;
				int currGroupIndex = 0;
				int currListIndex = 0;
				
				
				if (this.treeGroups.Count > currGroupIndex)
				{
					SPTreeNodeGroup currGroup = (SPTreeNodeGroup) (treeGroups[currGroupIndex]);
					SPTreeNode myFirstNode = null;
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
								
								myFirstNode = new SPTreeNode(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList[currListIndex]), currGroup.ImageIndex, currGroup.SelectedImageIndex, currListIndex);
								
								currNode.Add((TreeNode) myFirstNode);
							}
							else
							{
								AddNodes(currGroupIndex, ref currListIndex, myFirstNode.Nodes, currGroup.GroupBy);
							}
						} // end while
					} // end if
				}
				else
				{
					while (currListIndex < innerList.Count)
					{
						AddNodes(currGroupIndex, ref currListIndex, this.Nodes, "");
					}
				} // end else
				
				if (this.Nodes.Count > 0)
				{
					this.SelectedNode = this.Nodes[0];
				}
				
			} // end if
		}
		
		private void AddNodes(int currGroupIndex, ref int currentListIndex, TreeNodeCollection currNodes, string prevGroupByField)
		{
			IList innerList = this.m_currencyManager.List;
			System.ComponentModel.PropertyDescriptor pdPrevGroupBy = null;
			string prevGroupByValue = null;
			
			SPTreeNodeGroup currGroup;
			
			if (prevGroupByField != "")
			{
				pdPrevGroupBy = this.m_currencyManager.GetItemProperties()[prevGroupByField];
			}
			
			currGroupIndex++;
			
			if (treeGroups.Count > currGroupIndex)
			{
				currGroup = (SPTreeNodeGroup) (treeGroups[currGroupIndex]);
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
					
					SPTreeNode myFirstNode = null;
					object currObject = null;
					
					while ((currentListIndex < innerList.Count) && (pdPrevGroupBy != null) && (pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString() == prevGroupByValue))
					{
						currObject = innerList[currentListIndex];
						if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy)
						{
							currGroupBy = pdGroupBy.GetValue(currObject).ToString();
							
							myFirstNode = new SPTreeNode(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList[currentListIndex]), currGroup.ImageIndex, currGroup.SelectedImageIndex, currentListIndex);
							
							currNodes.Add((TreeNode) myFirstNode);
						}
						else
						{
							AddNodes(currGroupIndex, ref currentListIndex, myFirstNode.Nodes, currGroup.GroupBy);
						}
					}
				}
			}
			else
			{
				SPTreeNode myNewLeafNode;
				object currObject = this.m_currencyManager.List[currentListIndex];
				
				if ((this.DisplayMember != null) && (this.ValueMember != null) && (this.DisplayMember != "") && (this.ValueMember != ""))
				{
					PropertyDescriptorCollection pdDisplayColl = this.m_currencyManager.GetItemProperties();
					PropertyDescriptor pdDisplayloc = pdDisplayColl[this.DisplayMember.ToLowerInvariant()];
					PropertyDescriptor pdValueloc = pdDisplayColl[this.ValueMember.ToLowerInvariant()];
					
					if (this.Tag == null)
					{
						myNewLeafNode = new SPTreeNode("", pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex);
					}
					else
					{
						myNewLeafNode = new SPTreeNode(this.Tag.ToString(), pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex);
					}
				}
				else
				{
					myNewLeafNode = new SPTreeNode("", currentListIndex.ToString(), currObject, currObject, this.ImageIndex, this.SelectedImageIndex, currentListIndex);
				}
				
				currNodes.Add((TreeNode) myNewLeafNode);
				currentListIndex++;
			}
		}
		#endregion
		#region Groups
		
		public void RemoveGroup(SPTreeNodeGroup group)
		{
			if (treeGroups.Contains(group))
			{
				treeGroups.Remove(group);
				if (this.AutoBuildTree)
				{
					BuildTree();
				}
			}
		}
		
		public void RemoveGroup(string groupName)
		{
			foreach (SPTreeNodeGroup group in this.treeGroups)
			{
				if (group.Name == groupName)
				{
					RemoveGroup(group);
					return;
				}
			}
		}
		
		public void RemoveAllGroups()
		{
			this.treeGroups.Clear();
			if (this.AutoBuildTree)
			{
				this.BuildTree();
			}
		}
		
		public void AddGroup(SPTreeNodeGroup group)
		{
			try
			{
				treeGroups.Add(group);
				if (this.AutoBuildTree)
				{
					this.BuildTree();
				}
			}
			catch (NotSupportedException e)
			{
				MessageBox.Show(e.Message);
			}
			catch (System.Exception e)
			{
				throw (e);
			}
		}
		
		public void AddGroup(string name, string groupBy, string displayMember, string valueMember, int imageIndex, int selectedImageIndex)
		{
			SPTreeNodeGroup myNewGroup = new SPTreeNodeGroup(name, groupBy, displayMember, valueMember, imageIndex, selectedImageIndex);
			this.AddGroup(myNewGroup);
		}
		
		public SPTreeNodeGroup[] GetGroups()
		{
			return ((SPTreeNodeGroup[]) (treeGroups.ToArray(Type.GetType("SPTreeNodeGroup"))));
		}
		
		#endregion
		
		public void SetLeafData(string name, string displayMember, string valueMember, int imageIndex, int selectedImageIndex)
		{
			this.Tag = name;
			this.DisplayMember = displayMember;
			this.ValueMember = valueMember;
			this.ImageIndex = imageIndex;
			this.SelectedImageIndex = selectedImageIndex;
		}
		
		public bool IsLeafNode(TreeNode node)
		{
			return (node.Nodes.Count == 0);
		}
		#region Keeping Everything In Sync
		
		public TreeNode FindNodeByValue(object value)
		{
			return FindNodeByValue(value, this.Nodes);
		}
		
		public TreeNode FindNodeByValue(object Value, TreeNodeCollection nodesToSearch)
		{
			int i = 0;
			TreeNode currNode;
			SPTreeNode leafNode;
			
			while (i < nodesToSearch.Count)
			{
				currNode = nodesToSearch[i];
				i++;
				if (currNode.LastNode == null)
				{
					leafNode = (SPTreeNode) currNode;
					if (leafNode.Value.ToString() == Value.ToString())
					{
						return currNode;
					}
				}
				else
				{
					currNode = FindNodeByValue(Value, currNode.Nodes);
					if (currNode != null)
					{
						return currNode;
					}
				}
			}
			
			return null;
		}
		
		private TreeNode FindNodeByPosition(int posIndex)
		{
			return FindNodeByPosition(posIndex, this.Nodes);
		}
		
		private TreeNode FindNodeByPosition(int posIndex, TreeNodeCollection nodesToSearch)
		{
			int i = 0;
			TreeNode currNode;
			SPTreeNode leafNode;
			
			while (i < nodesToSearch.Count)
			{
				currNode = nodesToSearch[i];
				i++;
				if (currNode.Nodes.Count == 0)
				{
					leafNode = (SPTreeNode) currNode;
					if (leafNode.Position == posIndex)
					{
						return currNode;
					}
					else
					{
						currNode = FindNodeByPosition(posIndex, currNode.Nodes);
						if (currNode != null)
						{
							return currNode;
						}
					}
				}
			}
			return null;
		}
		
		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			SPTreeNode leafNode = (SPTreeNode) e.Node;
			
			if (leafNode != null)
			{
				if (this.m_currencyManager.Position != leafNode.Position)
				{
					this.m_currencyManager.Position = leafNode.Position;
				}
			}
			base.OnAfterSelect(e);
		}
		
		#endregion
		
	}
	
	[Description("Specify Grouping for  a collection of Tree Nodes in TreeView")]public class SPTreeNodeGroup
	{
		
		private string groupName;
		private string groupByMember;
		private string groupByDisplayMember;
		private string groupByValueMember;
		
		private int groupImageIndex;
		private int groupSelectedImageIndex;
		
		public SPTreeNodeGroup(string name, string groupBy, string displayMember, string valueMember, int imageIndex, int selectedImageIndex)
		{
			this.ImageIndex = imageIndex;
			this.Name = name;
			this.GroupBy = groupBy;
			this.DisplayMember = displayMember;
			this.ValueMember = valueMember;
			this.SelectedImageIndex = selectedImageIndex;
		}
		
		public SPTreeNodeGroup(string name, string groupBy, string displayMember, string valueMember, int imageIndex) : this(name, groupBy, displayMember, valueMember, imageIndex, imageIndex)
		{
		}
		
		public SPTreeNodeGroup(string name, string groupBy) : this(name, groupBy, groupBy, groupBy, - 1, - 1)
		{
		}
		
		public int SelectedImageIndex
		{
			get
			{
				return groupSelectedImageIndex;
			}
			set
			{
				groupSelectedImageIndex = value;
			}
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
	[Description("A Node in the TreeView")]public class SPTreeNode : TreeNode
	{
		
		private string m_groupName;
		private object m_value;
		private object m_item;
		private int m_position;
		
		public SPTreeNode()
		{
		}
		
		public SPTreeNode(string GroupName, string text, object item, object value, int imageIndex, int selectedImgIndex, int position)
		{
			this.GroupName = GroupName;
			this.Text = text;
			this.Item = item;
			this.Value = value;
			this.ImageIndex = imageIndex;
			this.SelectedImageIndex = selectedImgIndex;
			this.m_position = position;
		}
		
		public SPTreeNode(string groupName, string text, object item, object value, int position)
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