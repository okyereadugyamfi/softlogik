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
		public partial class DockableForm
		{
			
			//Form overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				this.ErrorNotify = new System.Windows.Forms.ErrorProvider(this.components);
				this.DockingContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
				this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
				this.mnuClose.Click += new System.EventHandler(mnuClose_Click);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.DockingContextMenu.SuspendLayout();
				this.SuspendLayout();
				//
				//ErrorNotify
				//
				this.ErrorNotify.ContainerControl = this;
				//
				//DockingContextMenu
				//
				this.DockingContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ToolStripMenuItem1, this.mnuClose});
				this.DockingContextMenu.Name = "DockingContextMenu";
				this.DockingContextMenu.Size = new System.Drawing.Size(151, 32);
				//
				//ToolStripMenuItem1
				//
				this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
				this.ToolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
				//
				//mnuClose
				//
				this.mnuClose.Name = "mnuClose";
				this.mnuClose.Size = new System.Drawing.Size(150, 22);
				this.mnuClose.Text = "&Close Window";
				//
				//DockableForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(335, 278);
				this.KeyPreview = true;
				this.Name = "DockableForm";
				this.TabPageContextMenuStrip = this.DockingContextMenu;
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.DockingContextMenu.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			protected internal System.Windows.Forms.ErrorProvider ErrorNotify;
			protected internal UI.VisualTabOrderManager MyTabOrderManager;
			protected internal System.Windows.Forms.ContextMenuStrip DockingContextMenu;
			internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
			internal System.Windows.Forms.ToolStripMenuItem mnuClose;
		}
	}