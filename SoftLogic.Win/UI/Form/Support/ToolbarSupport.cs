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
using SoftLogik.Win.UI;


namespace SoftLogik.Win.UI.Support
{
	sealed class ToolbarSupport
	{
		
		public class MasterToolbarButtonNames
		{
			
			public const string ToolbarNew = "NewRecord";
			public const string ToolbarDelete = "DeleteRecord";
			public const string ToolbarSave = "SaveRecord";
			public const string ToolbarUndo = "UndoRecord";
			public const string ToolbarCopy = "CopyRecord";
			public const string ToolbarRefresh = "RefreshRecord";
			public const string ToolbarSort = "SortRecord";
			public const string ToolbarSearch = "SearchRecord";
			public const string ToolbarLast = "LastRecord";
			public const string ToolbarFirst = "FirstRecord";
			public const string ToolbarNext = "NextRecord";
			public const string ToolbarPrevious = "PreviousRecord";
			public const string ToolbarClose = "CloseWindow";
		}
		
		public static void ToolbarToggle(ToolStrip tbrAny, bool InitialState)
		{
			try
			{
				if (InitialState)
				{
					ToolStrip with_1 = tbrAny;
					with_1.Items[MasterToolbarButtonNames.ToolbarSave].Enabled = false;
					with_1.Items[MasterToolbarButtonNames.ToolbarUndo].Enabled = false;
					
				}
			}
			catch (Exception)
			{
				
			}
		}
		public static void ToolbarToggleDefault(ref ToolStrip tbrAny)
		{
			ToolbarToggleDefault(tbrAny, null);
		}
		public static void ToolbarToggleDefault(ToolStrip tbrAny, DataTreeView treeVw)
		{
			//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
			ToolStrip with_1 = tbrAny;
			with_1.Items[MasterToolbarButtonNames.ToolbarSave].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarUndo].Enabled = false;
			
			with_1.Items[MasterToolbarButtonNames.ToolbarDelete].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarSearch].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarCopy].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarNew].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarRefresh].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarSort].Enabled = true;
			
			
			with_1.Items[MasterToolbarButtonNames.ToolbarFirst].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarNext].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarPrevious].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarLast].Enabled = true;
			if (treeVw != null)
			{
				treeVw.Enabled = true;
			}
			
		}
		public static void ToolbarToggleSave(ref ToolStrip tbrAny)
		{
			ToolbarToggleSave(tbrAny, null);
		}
		public static void ToolbarToggleSave(ToolStrip tbrAny, DataTreeView treeVw)
		{
			
			//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
			ToolStrip with_1 = tbrAny;
			with_1.Items[MasterToolbarButtonNames.ToolbarSave].Enabled = true;
			with_1.Items[MasterToolbarButtonNames.ToolbarUndo].Enabled = true;
			
			with_1.Items[MasterToolbarButtonNames.ToolbarDelete].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarSearch].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarCopy].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarNew].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarRefresh].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarSort].Enabled = false;
			
			with_1.Items[MasterToolbarButtonNames.ToolbarFirst].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarNext].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarPrevious].Enabled = false;
			with_1.Items[MasterToolbarButtonNames.ToolbarLast].Enabled = false;
			
			
			if (treeVw != null)
			{
				treeVw.Enabled = false;
			}
		}
		public static void ToolbarToggle(ToolStrip tbrAny)
		{
			try
			{
				ToolStrip with_1 = tbrAny;
				with_1.Items[MasterToolbarButtonNames.ToolbarNew].Enabled = ! with_1.Items[MasterToolbarButtonNames.ToolbarNew].Enabled;
				
				with_1.Items[MasterToolbarButtonNames.ToolbarDelete].Enabled = ! with_1.Items[MasterToolbarButtonNames.ToolbarDelete].Enabled;
				
				with_1.Items[MasterToolbarButtonNames.ToolbarSave].Enabled = ! with_1.Items[MasterToolbarButtonNames.ToolbarSave].Enabled;
				
				with_1.Items[MasterToolbarButtonNames.ToolbarUndo].Enabled = ! with_1.Items[MasterToolbarButtonNames.ToolbarUndo].Enabled;
				
				with_1.Items[MasterToolbarButtonNames.ToolbarSearch].Enabled = ! with_1.Items[MasterToolbarButtonNames.ToolbarSearch].Enabled;
				
			}
			catch (Exception)
			{
				
			}
		}
		public static void TransactionToolStrip(ToolStrip SourceToolbar)
		{
			ToolStripItem btn = null;
			
			try
			{
				ToolStrip with_1 = SourceToolbar;
				with_1.Items.Add(new ToolStripSeparator()); //Add a Separator
				
				btn = new ToolStripButton();
				ToolStripButton with_2 = ((ToolStripButton) btn);
				with_2.AutoToolTip = true;
				with_2.ToolTipText = CultureSupport.TextDictionary("TT_SAVECHANGES", TextReturnTypeEnum.PureString);
				with_2.Tag = "Save";
				with_1.Items.Add(btn);
				
				btn = new ToolStripButton();
				ToolStripButton with_3 = ((ToolStripButton) btn);
				with_3.AutoToolTip = true;
				with_3.ToolTipText = CultureSupport.TextDictionary("TT_UNDOCHANGES", TextReturnTypeEnum.PureString);
				with_3.Tag = "Undo";
				with_1.Items.Add(btn);
				
				with_1.Items.Add(new ToolStripSeparator());
				
				btn = new ToolStripButton();
				ToolStripButton with_4 = ((ToolStripButton) btn);
				with_4.AutoToolTip = true;
				with_4.ToolTipText = CultureSupport.TextDictionary("TT_CLOSE", TextReturnTypeEnum.PureString);
				with_4.Tag = "Exit";
				with_1.Items.Add(btn);
			}
			catch (Exception)
			{
			}
			finally
			{
				btn.Dispose();
			}
		}
		
		public static void MasterToolStrip(ToolStrip SourceToolbar)
		{
			ToolStripButton btn = null;
			//This procedure assumes an Image List has been already attached to the
			//supplied Toolbar with the required images in the required order
			try
			{
				ToolStrip with_1 = SourceToolbar;
				with_1.Items.Add(new ToolStripSeparator()); //Add a Separator
				
				btn = new ToolStripButton();
				ToolStripButton with_2 = btn;
				with_2.AutoToolTip = true;
				with_2.ToolTipText = CultureSupport.TextDictionary("TT_NEW", TextReturnTypeEnum.PureString);
				with_2.Tag = "New";
				with_2.ImageIndex = 0;
				with_1.Items.Add(btn);
				
				btn = new ToolStripButton();
				ToolStripButton with_3 = btn;
				with_3.AutoToolTip = true;
				with_3.ToolTipText = CultureSupport.TextDictionary("TT_DELETE", TextReturnTypeEnum.PureString);
				with_3.Tag = "Delete";
				with_3.ImageIndex = 1;
				with_1.Items.Add(btn);
				
				btn = new ToolStripButton();
				ToolStripButton with_4 = btn;
				with_4.AutoToolTip = true;
				with_4.ToolTipText = CultureSupport.TextDictionary("TT_SAVECHANGES", TextReturnTypeEnum.PureString);
				with_4.Tag = "Save";
				with_4.ImageIndex = 2;
				with_1.Items.Add(btn);
				
				btn = new ToolStripButton();
				ToolStripButton with_5 = btn;
				with_5.AutoToolTip = true;
				with_5.ToolTipText = CultureSupport.TextDictionary("TT_UNDOCHANGES", TextReturnTypeEnum.PureString);
				with_5.Tag = "Undo";
				with_5.ImageIndex = 3;
				with_1.Items.Add(btn);
				
				with_1.Items.Add(new ToolStripSeparator());
				
				btn = new ToolStripButton();
				ToolStripButton with_6 = btn;
				with_6.AutoToolTip = true;
				with_6.ToolTipText = CultureSupport.TextDictionary("TT_FIND", TextReturnTypeEnum.PureString);
				with_6.Tag = "Find";
				with_6.ImageIndex = 4;
				with_1.Items.Add(btn);
				
				with_1.Items.Add(new ToolStripSeparator());
				
				btn = new ToolStripButton();
				ToolStripButton with_7 = btn;
				with_7.AutoToolTip = true;
				with_7.ToolTipText = CultureSupport.TextDictionary("TT_CLOSE", TextReturnTypeEnum.PureString);
				with_7.Tag = "Exit";
				with_7.ImageIndex = 5;
				with_1.Items.Add(btn);
				
			}
			catch (Exception)
			{
			}
			finally
			{
				btn.Dispose();
			}
		}
		
	}
	
}
