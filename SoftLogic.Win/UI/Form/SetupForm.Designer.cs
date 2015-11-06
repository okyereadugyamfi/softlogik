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

namespace SoftLogik.Win.UI
	{
		public partial class SetupForm : RecordForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
				this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
				this.tvwName = new SoftLogik.Win.UI.DataTreeView();
				this.tvwName.AfterSelect += new TreeViewEventHandler(this.tvwName_AfterSelect);
				this.tbcMain = new SoftLogik.Win.UI.VisualTabControl(this.components);
				this.tabGeneral = new System.Windows.Forms.TabPage();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SplitContainer1.Panel1.SuspendLayout();
				this.SplitContainer1.Panel2.SuspendLayout();
				this.SplitContainer1.SuspendLayout();
				this.tbcMain.SuspendLayout();
				this.SuspendLayout();
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.Images.SetKeyName(0, "DOC.png");
				//
				//SplitContainer1
				//
				this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SplitContainer1.Location = new System.Drawing.Point(0, 40);
				this.SplitContainer1.Name = "SplitContainer1";
				//
				//SplitContainer1.Panel1
				//
				this.SplitContainer1.Panel1.Controls.Add(this.tvwName);
				//
				//SplitContainer1.Panel2
				//
				this.SplitContainer1.Panel2.Controls.Add(this.tbcMain);
				this.SplitContainer1.Size = new System.Drawing.Size(778, 403);
				this.SplitContainer1.SplitterDistance = 257;
				this.SplitContainer1.TabIndex = 10;
				//
				//tvwName
				//
				this.tvwName.AutoBuildTree = true;
				this.tvwName.DataSource = null;
				this.tvwName.DisplayMember = null;
				this.tvwName.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tvwName.HotTracking = true;
				this.tvwName.ImageIndex = 0;
				this.tvwName.ImageList = this.IconSource;
				this.tvwName.Location = new System.Drawing.Point(0, 0);
				this.tvwName.Name = "tvwName";
				this.tvwName.SelectedImageIndex = 0;
				this.tvwName.ShowRootLines = false;
				this.tvwName.Size = new System.Drawing.Size(257, 403);
				this.tvwName.TabIndex = 0;
				this.tvwName.ValueMember = null;
				//
				//tbcMain
				//
				this.tbcMain.Controls.Add(this.tabGeneral);
				this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tbcMain.ItemSize = new System.Drawing.Size(0, 15);
				this.tbcMain.Location = new System.Drawing.Point(0, 0);
				this.tbcMain.Name = "tbcMain";
				this.tbcMain.Padding = new System.Drawing.Point(9, 0);
				this.tbcMain.SelectedIndex = 0;
				this.tbcMain.Size = new System.Drawing.Size(517, 403);
				this.tbcMain.TabIndex = 0;
				//
				//tabGeneral
				//
				this.tabGeneral.CausesValidation = false;
				this.tabGeneral.Location = new System.Drawing.Point(4, 19);
				this.tabGeneral.Name = "tabGeneral";
				this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
				this.tabGeneral.Size = new System.Drawing.Size(509, 380);
				this.tabGeneral.TabIndex = 1;
				this.tabGeneral.Text = "General";
				this.tabGeneral.UseVisualStyleBackColor = true;
				//
				//SetupForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(778, 443);
				this.Controls.Add(this.SplitContainer1);
				this.Name = "SetupForm";
				this.Text = "SetupForm";
				this.Controls.SetChildIndex(this.SplitContainer1, 0);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.SplitContainer1.Panel1.ResumeLayout(false);
				this.SplitContainer1.Panel2.ResumeLayout(false);
				this.SplitContainer1.ResumeLayout(false);
				this.tbcMain.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.SplitContainer SplitContainer1;
			protected internal SoftLogik.Win.UI.DataTreeView tvwName;
			public SoftLogik.Win.UI.VisualTabControl tbcMain;
			public System.Windows.Forms.TabPage tabGeneral;
		}
	}