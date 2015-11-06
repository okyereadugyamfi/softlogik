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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class RecordForm : DockableForm
		{
			
			//Form overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				try
				{
					if (disposing && (components != null))
					{
						components.Dispose();
					}
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordForm));
				this.IconSource = new System.Windows.Forms.ImageList(this.components);
				this.Panel1 = new System.Windows.Forms.Panel();
				this.tbrMain = new System.Windows.Forms.ToolStrip();
				this.tbrMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(tbrMain_ItemClicked);
				this.NewRecord = new System.Windows.Forms.ToolStripButton();
				this.DeleteRecord = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
				this.SaveRecord = new System.Windows.Forms.ToolStripButton();
				this.UndoRecord = new System.Windows.Forms.ToolStripButton();
				this.CopyRecord = new System.Windows.Forms.ToolStripButton();
				this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
				this.RefreshRecord = new System.Windows.Forms.ToolStripButton();
				this.SortRecord = new System.Windows.Forms.ToolStripButton();
				this.SearchRecord = new System.Windows.Forms.ToolStripButton();
				this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
				this.FirstRecord = new System.Windows.Forms.ToolStripButton();
				this.PreviousRecord = new System.Windows.Forms.ToolStripButton();
				this.NextRecord = new System.Windows.Forms.ToolStripButton();
				this.LastRecord = new System.Windows.Forms.ToolStripButton();
				this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
				this.CloseWindow = new System.Windows.Forms.ToolStripButton();
				this.Panel2 = new System.Windows.Forms.Panel();
				this.DetailBinding = new System.Windows.Forms.BindingSource(this.components);
				this.DetailBinding.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(DetailBinding_BindingComplete);
				this.DetailBinding.DataSourceChanged += new System.EventHandler(DetailBinding_DataSourceChanged);
				this.DetailBinding.ListChanged += new System.ComponentModel.ListChangedEventHandler(DetailBinding_ListChanged);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.Panel1.SuspendLayout();
				this.tbrMain.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.DetailBinding).BeginInit();
				this.SuspendLayout();
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.TransparentColor = System.Drawing.Color.Transparent;
				this.IconSource.Images.SetKeyName(0, "DOC.png");
				//
				//Panel1
				//
				this.Panel1.Controls.Add(this.tbrMain);
				this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
				this.Panel1.Location = new System.Drawing.Point(0, 0);
				this.Panel1.Name = "Panel1";
				this.Panel1.Size = new System.Drawing.Size(778, 40);
				this.Panel1.TabIndex = 7;
				//
				//tbrMain
				//
				this.tbrMain.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tbrMain.Font = new System.Drawing.Font("Segoe UI", 9.0F);
				this.tbrMain.ImageScalingSize = new System.Drawing.Size(22, 22);
				this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.NewRecord, this.DeleteRecord, this.toolStripSeparator, this.SaveRecord, this.UndoRecord, this.CopyRecord, this.toolStripSeparator1, this.RefreshRecord, this.SortRecord, this.SearchRecord, this.ToolStripSeparator3, this.FirstRecord, this.PreviousRecord, this.NextRecord, this.LastRecord, this.ToolStripSeparator2, this.CloseWindow});
				this.tbrMain.Location = new System.Drawing.Point(0, 0);
				this.tbrMain.Name = "tbrMain";
				this.tbrMain.Size = new System.Drawing.Size(778, 40);
				this.tbrMain.Stretch = true;
				this.tbrMain.TabIndex = 7;
				this.tbrMain.Text = "Main Toolbar";
				//
				//NewRecord
				//
				this.NewRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.NewRecord.Image = global::My.Resources.Resources.Edit_file_24;
				this.NewRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.NewRecord.Name = "NewRecord";
				this.NewRecord.Size = new System.Drawing.Size(26, 37);
				this.NewRecord.Text = "Create a &New Record";
				//
				//DeleteRecord
				//
				this.DeleteRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.DeleteRecord.Image = global::My.Resources.Resources.editdelete;
				this.DeleteRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.DeleteRecord.Name = "DeleteRecord";
				this.DeleteRecord.Size = new System.Drawing.Size(26, 37);
				this.DeleteRecord.Text = "&Delete an Existing Record";
				//
				//toolStripSeparator
				//
				this.toolStripSeparator.Name = "toolStripSeparator";
				this.toolStripSeparator.Size = new System.Drawing.Size(6, 40);
				//
				//SaveRecord
				//
				this.SaveRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.SaveRecord.Image = global::My.Resources.Resources.filesave;
				this.SaveRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.SaveRecord.Name = "SaveRecord";
				this.SaveRecord.Size = new System.Drawing.Size(26, 37);
				this.SaveRecord.Text = "&Save a Modified Record";
				//
				//UndoRecord
				//
				this.UndoRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.UndoRecord.Image = (System.Drawing.Image) (resources.GetObject("UndoRecord.Image"));
				this.UndoRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.UndoRecord.Name = "UndoRecord";
				this.UndoRecord.Size = new System.Drawing.Size(26, 37);
				this.UndoRecord.Text = "&Undo modifications to selected Record";
				//
				//CopyRecord
				//
				this.CopyRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.CopyRecord.Image = global::My.Resources.Resources.copy;
				this.CopyRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.CopyRecord.Name = "CopyRecord";
				this.CopyRecord.Size = new System.Drawing.Size(26, 37);
				this.CopyRecord.Text = "D&uplicate selected Record";
				//
				//toolStripSeparator1
				//
				this.toolStripSeparator1.Name = "toolStripSeparator1";
				this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
				//
				//RefreshRecord
				//
				this.RefreshRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.RefreshRecord.Image = global::My.Resources.Resources.reload;
				this.RefreshRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.RefreshRecord.Name = "RefreshRecord";
				this.RefreshRecord.Size = new System.Drawing.Size(26, 37);
				this.RefreshRecord.Text = "Refresh";
				//
				//SortRecord
				//
				this.SortRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.SortRecord.Image = global::My.Resources.Resources.sort_incr;
				this.SortRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.SortRecord.Name = "SortRecord";
				this.SortRecord.Size = new System.Drawing.Size(26, 37);
				this.SortRecord.Text = "Sort";
				//
				//SearchRecord
				//
				this.SearchRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.SearchRecord.Image = global::My.Resources.Resources.search22;
				this.SearchRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.SearchRecord.Name = "SearchRecord";
				this.SearchRecord.Size = new System.Drawing.Size(26, 37);
				this.SearchRecord.Text = "&Search for Records";
				//
				//ToolStripSeparator3
				//
				this.ToolStripSeparator3.Name = "ToolStripSeparator3";
				this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 40);
				//
				//FirstRecord
				//
				this.FirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.FirstRecord.Image = global::My.Resources.Resources._2leftarrow;
				this.FirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.FirstRecord.Name = "FirstRecord";
				this.FirstRecord.Size = new System.Drawing.Size(26, 37);
				this.FirstRecord.Text = "First";
				this.FirstRecord.ToolTipText = "Goto First Record";
				//
				//PreviousRecord
				//
				this.PreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.PreviousRecord.Image = global::My.Resources.Resources._1leftarrow;
				this.PreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.PreviousRecord.Name = "PreviousRecord";
				this.PreviousRecord.Size = new System.Drawing.Size(26, 37);
				this.PreviousRecord.Text = "Previous";
				this.PreviousRecord.ToolTipText = "Goto Previous Record";
				//
				//NextRecord
				//
				this.NextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.NextRecord.Image = global::My.Resources.Resources._1rightarrow;
				this.NextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.NextRecord.Name = "NextRecord";
				this.NextRecord.Size = new System.Drawing.Size(26, 37);
				this.NextRecord.Text = "Next";
				this.NextRecord.ToolTipText = "Goto Next Record";
				//
				//LastRecord
				//
				this.LastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.LastRecord.Image = global::My.Resources.Resources._2rightarrow;
				this.LastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.LastRecord.Name = "LastRecord";
				this.LastRecord.Size = new System.Drawing.Size(26, 37);
				this.LastRecord.Text = "Last";
				this.LastRecord.ToolTipText = "Goto Last Record";
				//
				//ToolStripSeparator2
				//
				this.ToolStripSeparator2.Name = "ToolStripSeparator2";
				this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 40);
				//
				//CloseWindow
				//
				this.CloseWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.CloseWindow.Image = (System.Drawing.Image) (resources.GetObject("CloseWindow.Image"));
				this.CloseWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.CloseWindow.Name = "CloseWindow";
				this.CloseWindow.Size = new System.Drawing.Size(26, 37);
				this.CloseWindow.Text = "ToolStripButton1";
				this.CloseWindow.ToolTipText = "Close this Screen.";
				//
				//Panel2
				//
				this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
				this.Panel2.Location = new System.Drawing.Point(0, 40);
				this.Panel2.Name = "Panel2";
				this.Panel2.Size = new System.Drawing.Size(778, 403);
				this.Panel2.TabIndex = 8;
				//
				//DetailBinding
				//
				//
				//RecordForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(778, 443);
				this.Controls.Add(this.Panel2);
				this.Controls.Add(this.Panel1);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				this.DoubleBuffered = true;
				this.Name = "RecordForm";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.Panel1.ResumeLayout(false);
				this.Panel1.PerformLayout();
				this.tbrMain.ResumeLayout(false);
				this.tbrMain.PerformLayout();
				((System.ComponentModel.ISupportInitialize) this.DetailBinding).EndInit();
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.BindingSource DetailBinding;
			protected internal System.Windows.Forms.ImageList IconSource;
			public System.Windows.Forms.ToolStrip tbrMain;
			internal System.Windows.Forms.Panel Panel1;
			internal System.Windows.Forms.Panel Panel2;
			protected internal System.Windows.Forms.ToolStripButton NewRecord;
			protected internal System.Windows.Forms.ToolStripButton DeleteRecord;
			protected internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
			protected internal System.Windows.Forms.ToolStripButton SaveRecord;
			protected internal System.Windows.Forms.ToolStripButton UndoRecord;
			protected internal System.Windows.Forms.ToolStripButton CopyRecord;
			protected internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
			protected internal System.Windows.Forms.ToolStripButton SearchRecord;
			protected internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
			protected internal System.Windows.Forms.ToolStripButton FirstRecord;
			protected internal System.Windows.Forms.ToolStripButton PreviousRecord;
			protected internal System.Windows.Forms.ToolStripButton NextRecord;
			protected internal System.Windows.Forms.ToolStripButton LastRecord;
			protected internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
			protected internal System.Windows.Forms.ToolStripButton CloseWindow;
			protected internal System.Windows.Forms.ToolStripButton SortRecord;
			protected internal System.Windows.Forms.ToolStripButton RefreshRecord;
		}
	}
	
	
}
