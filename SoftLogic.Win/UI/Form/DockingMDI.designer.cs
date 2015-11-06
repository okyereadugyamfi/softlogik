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
		public partial class DockingMDI : DocklessForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockingMDI));
				this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
				this.DockPanel = new WeifenLuo.WinFormsUI.DockPanel();
				this.mnuFChangeLogin = new System.Windows.Forms.ToolStripMenuItem();
				this.mnuFActiveUsers = new System.Windows.Forms.ToolStripMenuItem();
				this.mnuFChangePassword = new System.Windows.Forms.ToolStripMenuItem();
				this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuFSecurity = new System.Windows.Forms.ToolStripMenuItem();
				this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuFPrintSetup = new System.Windows.Forms.ToolStripMenuItem();
				this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuFSend = new System.Windows.Forms.ToolStripMenuItem();
				this.mnuFSAttachment = new System.Windows.Forms.ToolStripMenuItem();
				this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuFSMessage = new System.Windows.Forms.ToolStripMenuItem();
				this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
				this.mnuFExit = new System.Windows.Forms.ToolStripMenuItem();
				this.StatusStrip = new System.Windows.Forms.StatusStrip();
				this.InfoPanel = new System.Windows.Forms.ToolStripStatusLabel();
				this.InfoProgress = new System.Windows.Forms.ToolStripProgressBar();
				this.QuickActions = new System.Windows.Forms.ToolStripSplitButton();
				this.KryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.StatusStrip.SuspendLayout();
				this.SuspendLayout();
				//
				//DockPanel
				//
				this.DockPanel.ActiveAutoHideContent = null;
				this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
				this.DockPanel.Font = new System.Drawing.Font("Tahoma", 11.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
				this.DockPanel.Location = new System.Drawing.Point(0, 0);
				this.DockPanel.Name = "DockPanel";
				this.DockPanel.ShowDocumentIcon = true;
				this.DockPanel.Size = new System.Drawing.Size(665, 416);
				this.DockPanel.TabIndex = 9;
				//
				//mnuFChangeLogin
				//
				this.mnuFChangeLogin.ImageTransparentColor = System.Drawing.Color.Black;
				this.mnuFChangeLogin.Name = "mnuFChangeLogin";
				this.mnuFChangeLogin.ShortcutKeys = (System.Windows.Forms.Keys) (System.Windows.Forms.Keys.Control || System.Windows.Forms.Keys.L);
				this.mnuFChangeLogin.Size = new System.Drawing.Size(192, 22);
				this.mnuFChangeLogin.Text = "&Change Login";
				//
				//mnuFActiveUsers
				//
				this.mnuFActiveUsers.ImageTransparentColor = System.Drawing.Color.Black;
				this.mnuFActiveUsers.Name = "mnuFActiveUsers";
				this.mnuFActiveUsers.ShortcutKeys = (System.Windows.Forms.Keys) (System.Windows.Forms.Keys.Control || System.Windows.Forms.Keys.U);
				this.mnuFActiveUsers.Size = new System.Drawing.Size(192, 22);
				this.mnuFActiveUsers.Text = "Active &User(s)";
				//
				//mnuFChangePassword
				//
				this.mnuFChangePassword.Name = "mnuFChangePassword";
				this.mnuFChangePassword.Size = new System.Drawing.Size(192, 22);
				this.mnuFChangePassword.Text = "Change &Password";
				//
				//ToolStripSeparator3
				//
				this.ToolStripSeparator3.Name = "ToolStripSeparator3";
				this.ToolStripSeparator3.Size = new System.Drawing.Size(189, 6);
				//
				//mnuFSecurity
				//
				this.mnuFSecurity.ImageTransparentColor = System.Drawing.Color.Black;
				this.mnuFSecurity.Name = "mnuFSecurity";
				this.mnuFSecurity.ShortcutKeys = System.Windows.Forms.Keys.F7;
				this.mnuFSecurity.Size = new System.Drawing.Size(192, 22);
				this.mnuFSecurity.Text = "&Security";
				//
				//ToolStripSeparator4
				//
				this.ToolStripSeparator4.Name = "ToolStripSeparator4";
				this.ToolStripSeparator4.Size = new System.Drawing.Size(189, 6);
				//
				//mnuFPrintSetup
				//
				this.mnuFPrintSetup.Name = "mnuFPrintSetup";
				this.mnuFPrintSetup.Size = new System.Drawing.Size(192, 22);
				this.mnuFPrintSetup.Text = "Print Setup";
				//
				//ToolStripSeparator5
				//
				this.ToolStripSeparator5.Name = "ToolStripSeparator5";
				this.ToolStripSeparator5.Size = new System.Drawing.Size(189, 6);
				//
				//mnuFSend
				//
				this.mnuFSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.mnuFSAttachment, this.ToolStripSeparator1, this.mnuFSMessage});
				this.mnuFSend.Name = "mnuFSend";
				this.mnuFSend.Size = new System.Drawing.Size(192, 22);
				this.mnuFSend.Text = "Send";
				//
				//mnuFSAttachment
				//
				this.mnuFSAttachment.Name = "mnuFSAttachment";
				this.mnuFSAttachment.Size = new System.Drawing.Size(153, 22);
				this.mnuFSAttachment.Text = "As Attachment";
				//
				//ToolStripSeparator1
				//
				this.ToolStripSeparator1.Name = "ToolStripSeparator1";
				this.ToolStripSeparator1.Size = new System.Drawing.Size(150, 6);
				//
				//mnuFSMessage
				//
				this.mnuFSMessage.Name = "mnuFSMessage";
				this.mnuFSMessage.Size = new System.Drawing.Size(153, 22);
				this.mnuFSMessage.Text = "&Message";
				//
				//ToolStripSeparator9
				//
				this.ToolStripSeparator9.Name = "ToolStripSeparator9";
				this.ToolStripSeparator9.Size = new System.Drawing.Size(189, 6);
				//
				//mnuFExit
				//
				this.mnuFExit.Name = "mnuFExit";
				this.mnuFExit.ShortcutKeys = (System.Windows.Forms.Keys) (System.Windows.Forms.Keys.Control || System.Windows.Forms.Keys.Q);
				this.mnuFExit.Size = new System.Drawing.Size(192, 22);
				this.mnuFExit.Text = "E&xit";
				//
				//StatusStrip
				//
				this.StatusStrip.Font = new System.Drawing.Font("Segoe UI", 9.0F);
				this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.InfoPanel, this.InfoProgress, this.QuickActions});
				this.StatusStrip.Location = new System.Drawing.Point(0, 394);
				this.StatusStrip.Name = "StatusStrip";
				this.StatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
				this.StatusStrip.Size = new System.Drawing.Size(665, 22);
				this.StatusStrip.TabIndex = 13;
				this.StatusStrip.Text = "StatusStrip";
				//
				//InfoPanel
				//
				this.InfoPanel.AutoSize = false;
				this.InfoPanel.AutoToolTip = true;
				this.InfoPanel.Name = "InfoPanel";
				this.InfoPanel.Size = new System.Drawing.Size(600, 17);
				//
				//InfoProgress
				//
				this.InfoProgress.Name = "InfoProgress";
				this.InfoProgress.Size = new System.Drawing.Size(100, 16);
				//
				//QuickActions
				//
				this.QuickActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.QuickActions.Image = (System.Drawing.Image) (resources.GetObject("QuickActions.Image"));
				this.QuickActions.ImageTransparentColor = System.Drawing.Color.Magenta;
				this.QuickActions.Name = "QuickActions";
				this.QuickActions.Size = new System.Drawing.Size(32, 20);
				this.QuickActions.Text = "Quick Launch";
				this.QuickActions.ToolTipText = "Quick Actions";
				//
				//DockingMDI
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(665, 416);
				this.Controls.Add(this.StatusStrip);
				this.Controls.Add(this.DockPanel);
				this.DoubleBuffered = true;
				this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
				this.IsMdiContainer = true;
				this.Name = "DockingMDI";
				this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.StatusStrip.ResumeLayout(false);
				this.StatusStrip.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();
				
			}
			internal System.Windows.Forms.ToolTip ToolTip;
			protected internal WeifenLuo.WinFormsUI.DockPanel DockPanel;
			internal System.Windows.Forms.ToolStripMenuItem mnuFChangeLogin;
			internal System.Windows.Forms.ToolStripMenuItem mnuFActiveUsers;
			internal System.Windows.Forms.ToolStripMenuItem mnuFChangePassword;
			internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
			internal System.Windows.Forms.ToolStripMenuItem mnuFSecurity;
			internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
			internal System.Windows.Forms.ToolStripMenuItem mnuFPrintSetup;
			internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
			internal System.Windows.Forms.ToolStripMenuItem mnuFSend;
			internal System.Windows.Forms.ToolStripMenuItem mnuFSAttachment;
			internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
			internal System.Windows.Forms.ToolStripMenuItem mnuFSMessage;
			internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
			internal System.Windows.Forms.ToolStripMenuItem mnuFExit;
			public System.Windows.Forms.ToolStripStatusLabel InfoPanel;
			public System.Windows.Forms.ToolStripProgressBar InfoProgress;
			public System.Windows.Forms.ToolStripSplitButton QuickActions;
			protected internal System.Windows.Forms.StatusStrip StatusStrip;
			public ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager1;
			
		}
	}
