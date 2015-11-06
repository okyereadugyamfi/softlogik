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
	sealed class PopulateSupport
	{
		
		
		
		public static bool BuildSetupList(object TreeViewControl, ImageList ImageListControl, DataTable SourceData, string ParentField, string CompareField, string DisplayField, string NodeIDField, bool ClearTree)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			TreeView tvwTreeView = (TreeView) TreeViewControl;
			ImageList imlImageList = ImageListControl;
			
			tvwTreeView.BeginUpdate();
			if (ClearTree)
			{
				tvwTreeView.Nodes.Clear();
			}
			tvwTreeView.ImageList = imlImageList;
			
			DataView dvTreeTable = new DataView();
			TreeNode currentNode;
			
			dvTreeTable.Table = SourceData;
			
			
			
			if (ClearTree == false) //Might be a root node
			{
				tvwTreeView.BeginUpdate();
				try
				{
					currentNode = tvwTreeView.Nodes[0];
					BuildSetupNode(currentNode, dvTreeTable, null, ParentField, CompareField, NodeIDField, DisplayField);
					
					currentNode.Expand();
				}
				catch (Exception)
				{
					
				}
				tvwTreeView.EndUpdate();
			}
			else
			{
				dvTreeTable.RowFilter = " IsNull(" + ParentField + ",\'\') = \'\' ";
				foreach (DataRowView drvRow in dvTreeTable)
				{
					tvwTreeView.BeginUpdate();
					currentNode = tvwTreeView.Nodes.Add(drvRow[DisplayField].ToString());
					currentNode.Tag = drvRow[NodeIDField].ToString();
					BuildNode(currentNode, dvTreeTable, drvRow, ParentField, CompareField, NodeIDField, DisplayField);
					currentNode.Expand();
					tvwTreeView.EndUpdate();
				}
				
			}
			
			tvwTreeView.EndUpdate();
			Cursor.Current = Cursors.Default;
			return true;
		}
		public static bool BuildTree(TreeView TreeViewControl, ImageList ImageListControl, DataTable SourceData, string ParentField, string CompareField, string DisplayField, string NodeIDField, bool ClearTree)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			TreeView tvwTreeView = TreeViewControl;
			ImageList imlImageList = ImageListControl;
			
			tvwTreeView.BeginUpdate();
			if (ClearTree)
			{
				tvwTreeView.Nodes.Clear();
			}
			tvwTreeView.ImageList = imlImageList;
			
			
			DataView dvTreeTable = new DataView();
			TreeNode currentNode;
			
			dvTreeTable.Table = SourceData;
			
			
			
			if (ClearTree == false) //Might be a root node
			{
				tvwTreeView.BeginUpdate();
				try
				{
					currentNode = tvwTreeView.Nodes[0];
					BuildNode(currentNode, dvTreeTable, null, ParentField, CompareField, NodeIDField, DisplayField);
					
					currentNode.Expand();
				}
				catch (Exception)
				{
					
				}
				tvwTreeView.EndUpdate();
			}
			else
			{
				dvTreeTable.RowFilter = " IsNull(" + ParentField + ",\'\') = \'\' ";
				foreach (DataRowView drvRow in dvTreeTable)
				{
					tvwTreeView.BeginUpdate();
					currentNode = tvwTreeView.Nodes.Add(drvRow[DisplayField].ToString());
					currentNode.Tag = drvRow[NodeIDField].ToString();
					BuildNode(currentNode, dvTreeTable, drvRow, ParentField, CompareField, NodeIDField, DisplayField);
					currentNode.Expand();
					tvwTreeView.EndUpdate();
				}
				
			}
			
			tvwTreeView.EndUpdate();
			Cursor.Current = Cursors.Default;
			return true;
		}
		
		
		private static void BuildSetupNode(TreeNode currentNode, DataView sourceData, DataRowView currentRecord, string ParentField, string CompareField, string NodeIDField, string DisplayField)
		{
			DataView newData = new DataView(sourceData.Table);
			TreeNode newNode;
			
			sourceData.RowFilter = Constants.vbNullString;
			if (currentRecord != null)
			{
				sourceData.RowFilter = ParentField + " = \'" + currentRecord[CompareField].ToString() + "\'";
			}
			
			currentNode.TreeView.BeginUpdate();
			
			foreach (DataRowView drvRow in sourceData)
			{
				newData.RowFilter = ParentField + "  = \'" + drvRow[CompareField].ToString() + "\'";
				newNode = currentNode.Nodes.Add(drvRow[DisplayField].ToString());
				newNode.Tag = drvRow[NodeIDField].ToString();
				if (newData.Count > 0)
				{
					BuildSetupNode(newNode, newData, drvRow, ParentField, CompareField, NodeIDField, DisplayField);
				}
			}
			
			currentNode.TreeView.EndUpdate();
		}
		private static void BuildNode(TreeNode currentNode, DataView sourceData, DataRowView currentRecord, string ParentField, string CompareField, string NodeIDField, string DisplayField)
		{
			DataView newData = new DataView(sourceData.Table);
			TreeNode newNode;
			
			sourceData.RowFilter = Constants.vbNullString;
			if (currentRecord != null)
			{
				sourceData.RowFilter = ParentField + " = \'" + currentRecord[CompareField].ToString() + "\'";
			}
			
			currentNode.TreeView.BeginUpdate();
			
			foreach (DataRowView drvRow in sourceData)
			{
				newData.RowFilter = ParentField + "  = \'" + drvRow[CompareField].ToString() + "\'";
				newNode = currentNode.Nodes.Add(drvRow[DisplayField].ToString());
				newNode.Tag = drvRow[NodeIDField].ToString();
				if (newData.Count > 0)
				{
					BuildNode(newNode, newData, drvRow, ParentField, CompareField, NodeIDField, DisplayField);
				}
			}
			
			currentNode.TreeView.EndUpdate();
		}
		
		public static int TreeNodeID(TreeNode SourceNode, int SelectedIndex)
		{
			if (SourceNode.Index != SelectedIndex)
			{
				foreach (TreeNode curNode in SourceNode.Nodes)
				{
					if (curNode.Index != SelectedIndex)
					{
						if (curNode.Nodes != null)
						{
							TreeNodeID(curNode, SelectedIndex);
						}
					}
				}
			}
			else
			{
				return System.Convert.ToInt32(SourceNode.Tag);
			}
		}
		public static TreeNode TreeNodeSearch(TreeNode SourceNode, int SearchID)
		{
			if (System.Convert.ToInt32(SourceNode.Tag) != SearchID)
			{
				foreach (TreeNode curNode in SourceNode.Nodes)
				{
					if (System.Convert.ToInt32(curNode.Tag) != SearchID)
					{
						if (curNode.Nodes != null)
						{
							TreeNodeSearch(curNode, SearchID);
						}
					}
				}
			}
			return SourceNode;
		}
		
	}
	
	
}
