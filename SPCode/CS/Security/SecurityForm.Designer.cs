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
	namespace Security
	{
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SecurityForm : UI.DockableForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityForm));
				this.SplitContainer = new System.Windows.Forms.SplitContainer();
				this.tvwSecurity = new System.Windows.Forms.TreeView();
				this.splSecurity = new System.Windows.Forms.SplitContainer();
				this.pnlApplication = new System.Windows.Forms.Panel();
				this.lblNote = new System.Windows.Forms.Label();
				this.lblAppName = new System.Windows.Forms.Label();
				this.txtAppNote = new System.Windows.Forms.TextBox();
				this.txtAppName = new System.Windows.Forms.TextBox();
				this.pnlRole = new System.Windows.Forms.Panel();
				this.gbxRoleCreated = new System.Windows.Forms.GroupBox();
				this.Label7 = new System.Windows.Forms.Label();
				this.Label8 = new System.Windows.Forms.Label();
				this.Label9 = new System.Windows.Forms.Label();
				this.Label10 = new System.Windows.Forms.Label();
				this.txtRoleNote = new System.Windows.Forms.TextBox();
				this.lblRoleNote = new System.Windows.Forms.Label();
				this.txtRoleName = new System.Windows.Forms.TextBox();
				this.lblRoleName = new System.Windows.Forms.Label();
				this.pnlUser = new System.Windows.Forms.Panel();
				this.gbxUserCreated = new System.Windows.Forms.GroupBox();
				this.lblModifiedDate = new System.Windows.Forms.Label();
				this.lblUserCreateDate = new System.Windows.Forms.Label();
				this.lblUserModified = new System.Windows.Forms.Label();
				this.Label2 = new System.Windows.Forms.Label();
				this.txtUserCreated = new System.Windows.Forms.Label();
				this.lblUserCreated = new System.Windows.Forms.Label();
				this.txtUserNote = new System.Windows.Forms.TextBox();
				this.lblUserNote = new System.Windows.Forms.Label();
				this.txtLName = new System.Windows.Forms.TextBox();
				this.txtFName = new System.Windows.Forms.TextBox();
				this.lblLName = new System.Windows.Forms.Label();
				this.lblFName = new System.Windows.Forms.Label();
				this.txtUserName = new System.Windows.Forms.TextBox();
				this.lblUserName = new System.Windows.Forms.Label();
				this.tvwPolicy = new System.Windows.Forms.TreeView();
				this.SPApplicationBindingSource = new System.Windows.Forms.BindingSource(this.components);
				this.SPUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
				this.m_dsUserSecurity = new SoftLogik.Win.dsUserSecurity();
				this.TreeNodeImageList = new System.Windows.Forms.ImageList(this.components);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SplitContainer.Panel1.SuspendLayout();
				this.SplitContainer.Panel2.SuspendLayout();
				this.SplitContainer.SuspendLayout();
				this.splSecurity.Panel1.SuspendLayout();
				this.splSecurity.Panel2.SuspendLayout();
				this.splSecurity.SuspendLayout();
				this.pnlApplication.SuspendLayout();
				this.pnlRole.SuspendLayout();
				this.gbxRoleCreated.SuspendLayout();
				this.pnlUser.SuspendLayout();
				this.gbxUserCreated.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.SPApplicationBindingSource).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.SPUserBindingSource).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.m_dsUserSecurity).BeginInit();
				this.SuspendLayout();
				//
				//SplitContainer
				//
				this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SplitContainer.Location = new System.Drawing.Point(0, 0);
				this.SplitContainer.Name = "SplitContainer";
				//
				//SplitContainer.Panel1
				//
				this.SplitContainer.Panel1.Controls.Add(this.tvwSecurity);
				//
				//SplitContainer.Panel2
				//
				this.SplitContainer.Panel2.Controls.Add(this.splSecurity);
				this.SplitContainer.Size = new System.Drawing.Size(858, 449);
				this.SplitContainer.SplitterDistance = 193;
				this.SplitContainer.TabIndex = 1;
				this.SplitContainer.Text = "SplitContainer1";
				//
				//tvwSecurity
				//
				this.tvwSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tvwSecurity.HotTracking = true;
				this.tvwSecurity.Location = new System.Drawing.Point(0, 0);
				this.tvwSecurity.Name = "tvwSecurity";
				this.tvwSecurity.ShowLines = false;
				this.tvwSecurity.Size = new System.Drawing.Size(193, 449);
				this.tvwSecurity.TabIndex = 0;
				//
				//splSecurity
				//
				this.splSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
				this.splSecurity.Location = new System.Drawing.Point(0, 0);
				this.splSecurity.Name = "splSecurity";
				this.splSecurity.Orientation = System.Windows.Forms.Orientation.Horizontal;
				//
				//splSecurity.Panel1
				//
				this.splSecurity.Panel1.Controls.Add(this.pnlApplication);
				this.splSecurity.Panel1.Controls.Add(this.pnlRole);
				this.splSecurity.Panel1.Controls.Add(this.pnlUser);
				//
				//splSecurity.Panel2
				//
				this.splSecurity.Panel2.Controls.Add(this.tvwPolicy);
				this.splSecurity.Size = new System.Drawing.Size(661, 449);
				this.splSecurity.SplitterDistance = 241;
				this.splSecurity.TabIndex = 3;
				//
				//pnlApplication
				//
				this.pnlApplication.Controls.Add(this.lblNote);
				this.pnlApplication.Controls.Add(this.lblAppName);
				this.pnlApplication.Controls.Add(this.txtAppNote);
				this.pnlApplication.Controls.Add(this.txtAppName);
				this.pnlApplication.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnlApplication.Location = new System.Drawing.Point(0, 0);
				this.pnlApplication.Name = "pnlApplication";
				this.pnlApplication.Size = new System.Drawing.Size(661, 241);
				this.pnlApplication.TabIndex = 10;
				//
				//lblNote
				//
				this.lblNote.AutoSize = true;
				this.lblNote.Location = new System.Drawing.Point(37, 86);
				this.lblNote.Name = "lblNote";
				this.lblNote.Size = new System.Drawing.Size(33, 13);
				this.lblNote.TabIndex = 15;
				this.lblNote.Text = "&Note:";
				//
				//lblAppName
				//
				this.lblAppName.AutoSize = true;
				this.lblAppName.Location = new System.Drawing.Point(36, 60);
				this.lblAppName.Name = "lblAppName";
				this.lblAppName.Size = new System.Drawing.Size(38, 13);
				this.lblAppName.TabIndex = 14;
				this.lblAppName.Text = "Name:";
				//
				//txtAppNote
				//
				this.txtAppNote.BackColor = System.Drawing.SystemColors.Control;
				this.txtAppNote.ForeColor = System.Drawing.SystemColors.Highlight;
				this.txtAppNote.Location = new System.Drawing.Point(76, 83);
				this.txtAppNote.Multiline = true;
				this.txtAppNote.Name = "txtAppNote";
				this.txtAppNote.ReadOnly = true;
				this.txtAppNote.Size = new System.Drawing.Size(353, 88);
				this.txtAppNote.TabIndex = 13;
				//
				//txtAppName
				//
				this.txtAppName.BackColor = System.Drawing.SystemColors.Control;
				this.txtAppName.ForeColor = System.Drawing.SystemColors.Highlight;
				this.txtAppName.Location = new System.Drawing.Point(76, 57);
				this.txtAppName.Name = "txtAppName";
				this.txtAppName.ReadOnly = true;
				this.txtAppName.Size = new System.Drawing.Size(318, 20);
				this.txtAppName.TabIndex = 12;
				//
				//pnlRole
				//
				this.pnlRole.Controls.Add(this.gbxRoleCreated);
				this.pnlRole.Controls.Add(this.txtRoleNote);
				this.pnlRole.Controls.Add(this.lblRoleNote);
				this.pnlRole.Controls.Add(this.txtRoleName);
				this.pnlRole.Controls.Add(this.lblRoleName);
				this.pnlRole.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnlRole.Location = new System.Drawing.Point(0, 0);
				this.pnlRole.Name = "pnlRole";
				this.pnlRole.Size = new System.Drawing.Size(661, 241);
				this.pnlRole.TabIndex = 8;
				//
				//gbxRoleCreated
				//
				this.gbxRoleCreated.Controls.Add(this.Label7);
				this.gbxRoleCreated.Controls.Add(this.Label8);
				this.gbxRoleCreated.Controls.Add(this.Label9);
				this.gbxRoleCreated.Controls.Add(this.Label10);
				this.gbxRoleCreated.Location = new System.Drawing.Point(405, 7);
				this.gbxRoleCreated.Name = "gbxRoleCreated";
				this.gbxRoleCreated.Size = new System.Drawing.Size(189, 180);
				this.gbxRoleCreated.TabIndex = 22;
				this.gbxRoleCreated.TabStop = false;
				this.gbxRoleCreated.Text = "More Information";
				//
				//Label7
				//
				this.Label7.AutoSize = true;
				this.Label7.Location = new System.Drawing.Point(104, 41);
				this.Label7.Name = "Label7";
				this.Label7.Size = new System.Drawing.Size(0, 13);
				this.Label7.TabIndex = 13;
				//
				//Label8
				//
				this.Label8.AutoSize = true;
				this.Label8.Location = new System.Drawing.Point(8, 41);
				this.Label8.Name = "Label8";
				this.Label8.Size = new System.Drawing.Size(90, 13);
				this.Label8.TabIndex = 12;
				this.Label8.Text = "Last Modified On:";
				//
				//Label9
				//
				this.Label9.AutoSize = true;
				this.Label9.Location = new System.Drawing.Point(79, 16);
				this.Label9.Name = "Label9";
				this.Label9.Size = new System.Drawing.Size(0, 13);
				this.Label9.TabIndex = 11;
				//
				//Label10
				//
				this.Label10.AutoSize = true;
				this.Label10.Location = new System.Drawing.Point(6, 16);
				this.Label10.Name = "Label10";
				this.Label10.Size = new System.Drawing.Size(67, 13);
				this.Label10.TabIndex = 10;
				this.Label10.Text = "Created On: ";
				//
				//txtRoleNote
				//
				this.txtRoleNote.Location = new System.Drawing.Point(67, 45);
				this.txtRoleNote.Multiline = true;
				this.txtRoleNote.Name = "txtRoleNote";
				this.txtRoleNote.Size = new System.Drawing.Size(327, 99);
				this.txtRoleNote.TabIndex = 21;
				//
				//lblRoleNote
				//
				this.lblRoleNote.AutoSize = true;
				this.lblRoleNote.Location = new System.Drawing.Point(11, 48);
				this.lblRoleNote.Name = "lblRoleNote";
				this.lblRoleNote.Size = new System.Drawing.Size(33, 13);
				this.lblRoleNote.TabIndex = 20;
				this.lblRoleNote.Text = "&Note:";
				//
				//txtRoleName
				//
				this.txtRoleName.Location = new System.Drawing.Point(67, 19);
				this.txtRoleName.Name = "txtRoleName";
				this.txtRoleName.Size = new System.Drawing.Size(291, 20);
				this.txtRoleName.TabIndex = 19;
				//
				//lblRoleName
				//
				this.lblRoleName.AutoSize = true;
				this.lblRoleName.Location = new System.Drawing.Point(11, 22);
				this.lblRoleName.Name = "lblRoleName";
				this.lblRoleName.Size = new System.Drawing.Size(38, 13);
				this.lblRoleName.TabIndex = 18;
				this.lblRoleName.Text = "Name:";
				//
				//pnlUser
				//
				this.pnlUser.Controls.Add(this.gbxUserCreated);
				this.pnlUser.Controls.Add(this.txtUserNote);
				this.pnlUser.Controls.Add(this.lblUserNote);
				this.pnlUser.Controls.Add(this.txtLName);
				this.pnlUser.Controls.Add(this.txtFName);
				this.pnlUser.Controls.Add(this.lblLName);
				this.pnlUser.Controls.Add(this.lblFName);
				this.pnlUser.Controls.Add(this.txtUserName);
				this.pnlUser.Controls.Add(this.lblUserName);
				this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
				this.pnlUser.Location = new System.Drawing.Point(0, 0);
				this.pnlUser.Name = "pnlUser";
				this.pnlUser.Size = new System.Drawing.Size(661, 241);
				this.pnlUser.TabIndex = 9;
				//
				//gbxUserCreated
				//
				this.gbxUserCreated.Controls.Add(this.lblModifiedDate);
				this.gbxUserCreated.Controls.Add(this.lblUserCreateDate);
				this.gbxUserCreated.Controls.Add(this.lblUserModified);
				this.gbxUserCreated.Controls.Add(this.Label2);
				this.gbxUserCreated.Controls.Add(this.txtUserCreated);
				this.gbxUserCreated.Controls.Add(this.lblUserCreated);
				this.gbxUserCreated.Location = new System.Drawing.Point(401, 3);
				this.gbxUserCreated.Name = "gbxUserCreated";
				this.gbxUserCreated.Size = new System.Drawing.Size(188, 180);
				this.gbxUserCreated.TabIndex = 21;
				this.gbxUserCreated.TabStop = false;
				this.gbxUserCreated.Text = "More Information";
				//
				//lblModifiedDate
				//
				this.lblModifiedDate.AutoSize = true;
				this.lblModifiedDate.Location = new System.Drawing.Point(94, 41);
				this.lblModifiedDate.Name = "lblModifiedDate";
				this.lblModifiedDate.Size = new System.Drawing.Size(42, 13);
				this.lblModifiedDate.TabIndex = 15;
				this.lblModifiedDate.Text = "<Date>";
				//
				//lblUserCreateDate
				//
				this.lblUserCreateDate.AutoSize = true;
				this.lblUserCreateDate.Location = new System.Drawing.Point(80, 16);
				this.lblUserCreateDate.Name = "lblUserCreateDate";
				this.lblUserCreateDate.Size = new System.Drawing.Size(42, 13);
				this.lblUserCreateDate.TabIndex = 14;
				this.lblUserCreateDate.Text = "<Date>";
				//
				//lblUserModified
				//
				this.lblUserModified.AutoSize = true;
				this.lblUserModified.Location = new System.Drawing.Point(104, 41);
				this.lblUserModified.Name = "lblUserModified";
				this.lblUserModified.Size = new System.Drawing.Size(0, 13);
				this.lblUserModified.TabIndex = 13;
				//
				//Label2
				//
				this.Label2.AutoSize = true;
				this.Label2.Location = new System.Drawing.Point(8, 41);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(90, 13);
				this.Label2.TabIndex = 12;
				this.Label2.Text = "Last Modified On:";
				//
				//txtUserCreated
				//
				this.txtUserCreated.AutoSize = true;
				this.txtUserCreated.Location = new System.Drawing.Point(79, 16);
				this.txtUserCreated.Name = "txtUserCreated";
				this.txtUserCreated.Size = new System.Drawing.Size(0, 13);
				this.txtUserCreated.TabIndex = 11;
				//
				//lblUserCreated
				//
				this.lblUserCreated.AutoSize = true;
				this.lblUserCreated.Location = new System.Drawing.Point(6, 16);
				this.lblUserCreated.Name = "lblUserCreated";
				this.lblUserCreated.Size = new System.Drawing.Size(67, 13);
				this.lblUserCreated.TabIndex = 10;
				this.lblUserCreated.Text = "Created On: ";
				//
				//txtUserNote
				//
				this.txtUserNote.Location = new System.Drawing.Point(76, 84);
				this.txtUserNote.Multiline = true;
				this.txtUserNote.Name = "txtUserNote";
				this.txtUserNote.Size = new System.Drawing.Size(319, 99);
				this.txtUserNote.TabIndex = 20;
				//
				//lblUserNote
				//
				this.lblUserNote.AutoSize = true;
				this.lblUserNote.Location = new System.Drawing.Point(9, 84);
				this.lblUserNote.Name = "lblUserNote";
				this.lblUserNote.Size = new System.Drawing.Size(33, 13);
				this.lblUserNote.TabIndex = 19;
				this.lblUserNote.Text = "&Note:";
				//
				//txtLName
				//
				this.txtLName.Location = new System.Drawing.Point(76, 60);
				this.txtLName.Name = "txtLName";
				this.txtLName.Size = new System.Drawing.Size(319, 20);
				this.txtLName.TabIndex = 18;
				//
				//txtFName
				//
				this.txtFName.Location = new System.Drawing.Point(76, 35);
				this.txtFName.Name = "txtFName";
				this.txtFName.Size = new System.Drawing.Size(319, 20);
				this.txtFName.TabIndex = 17;
				//
				//lblLName
				//
				this.lblLName.AutoSize = true;
				this.lblLName.Location = new System.Drawing.Point(9, 60);
				this.lblLName.Name = "lblLName";
				this.lblLName.Size = new System.Drawing.Size(61, 13);
				this.lblLName.TabIndex = 16;
				this.lblLName.Text = "Last Name:";
				//
				//lblFName
				//
				this.lblFName.AutoSize = true;
				this.lblFName.Location = new System.Drawing.Point(7, 35);
				this.lblFName.Name = "lblFName";
				this.lblFName.Size = new System.Drawing.Size(60, 13);
				this.lblFName.TabIndex = 15;
				this.lblFName.Text = "First Name:";
				//
				//txtUserName
				//
				this.txtUserName.Location = new System.Drawing.Point(76, 11);
				this.txtUserName.Name = "txtUserName";
				this.txtUserName.Size = new System.Drawing.Size(319, 20);
				this.txtUserName.TabIndex = 14;
				//
				//lblUserName
				//
				this.lblUserName.AutoSize = true;
				this.lblUserName.Location = new System.Drawing.Point(7, 14);
				this.lblUserName.Name = "lblUserName";
				this.lblUserName.Size = new System.Drawing.Size(63, 13);
				this.lblUserName.TabIndex = 13;
				this.lblUserName.Text = "User Name:";
				//
				//tvwPolicy
				//
				this.tvwPolicy.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tvwPolicy.Location = new System.Drawing.Point(0, 0);
				this.tvwPolicy.Name = "tvwPolicy";
				this.tvwPolicy.Size = new System.Drawing.Size(661, 204);
				this.tvwPolicy.TabIndex = 0;
				//
				//SPApplicationBindingSource
				//
				this.SPApplicationBindingSource.DataMember = "SPApplication";
				//
				//SPUserBindingSource
				//
				this.SPUserBindingSource.DataMember = "SPUser";
				//
				//m_dsUserSecurity
				//
				this.m_dsUserSecurity.DataSetName = "dsUserSecurity";
				this.m_dsUserSecurity.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
				//
				//TreeNodeImageList
				//
				this.TreeNodeImageList.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("TreeNodeImageList.ImageStream"));
				this.TreeNodeImageList.TransparentColor = System.Drawing.Color.Transparent;
				this.TreeNodeImageList.Images.SetKeyName(0, "ApplicationNode");
				this.TreeNodeImageList.Images.SetKeyName(1, "UserNode");
				this.TreeNodeImageList.Images.SetKeyName(2, "RoleNode");
				this.TreeNodeImageList.Images.SetKeyName(3, "RootNode");
				this.TreeNodeImageList.Images.SetKeyName(4, "EditNode");
				//
				//SecurityManager
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(858, 449);
				this.Controls.Add(this.SplitContainer);
				this.Name = "SecurityManager";
				this.Text = "SecurityManager";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.SplitContainer.Panel1.ResumeLayout(false);
				this.SplitContainer.Panel2.ResumeLayout(false);
				this.SplitContainer.ResumeLayout(false);
				this.splSecurity.Panel1.ResumeLayout(false);
				this.splSecurity.Panel2.ResumeLayout(false);
				this.splSecurity.ResumeLayout(false);
				this.pnlApplication.ResumeLayout(false);
				this.pnlApplication.PerformLayout();
				this.pnlRole.ResumeLayout(false);
				this.pnlRole.PerformLayout();
				this.gbxRoleCreated.ResumeLayout(false);
				this.gbxRoleCreated.PerformLayout();
				this.pnlUser.ResumeLayout(false);
				this.pnlUser.PerformLayout();
				this.gbxUserCreated.ResumeLayout(false);
				this.gbxUserCreated.PerformLayout();
				((System.ComponentModel.ISupportInitialize) this.SPApplicationBindingSource).EndInit();
				((System.ComponentModel.ISupportInitialize) this.SPUserBindingSource).EndInit();
				((System.ComponentModel.ISupportInitialize) this.m_dsUserSecurity).EndInit();
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.SplitContainer SplitContainer;
			internal System.Windows.Forms.TreeView tvwSecurity;
			internal System.Windows.Forms.SplitContainer splSecurity;
			internal System.Windows.Forms.Panel pnlApplication;
			internal System.Windows.Forms.Label lblNote;
			internal System.Windows.Forms.Label lblAppName;
			internal System.Windows.Forms.TextBox txtAppNote;
			internal System.Windows.Forms.TextBox txtAppName;
			internal System.Windows.Forms.Panel pnlRole;
			internal System.Windows.Forms.GroupBox gbxRoleCreated;
			internal System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.Label Label8;
			internal System.Windows.Forms.Label Label9;
			internal System.Windows.Forms.Label Label10;
			internal System.Windows.Forms.TextBox txtRoleNote;
			internal System.Windows.Forms.Label lblRoleNote;
			internal System.Windows.Forms.TextBox txtRoleName;
			internal System.Windows.Forms.Label lblRoleName;
			internal System.Windows.Forms.Panel pnlUser;
			internal System.Windows.Forms.GroupBox gbxUserCreated;
			internal System.Windows.Forms.Label lblModifiedDate;
			internal System.Windows.Forms.Label lblUserCreateDate;
			internal System.Windows.Forms.Label lblUserModified;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.Label txtUserCreated;
			internal System.Windows.Forms.Label lblUserCreated;
			internal System.Windows.Forms.TextBox txtUserNote;
			internal System.Windows.Forms.Label lblUserNote;
			internal System.Windows.Forms.TextBox txtLName;
			internal System.Windows.Forms.TextBox txtFName;
			internal System.Windows.Forms.Label lblLName;
			internal System.Windows.Forms.Label lblFName;
			internal System.Windows.Forms.TextBox txtUserName;
			internal System.Windows.Forms.Label lblUserName;
			internal System.Windows.Forms.TreeView tvwPolicy;
			internal System.Windows.Forms.BindingSource SPApplicationBindingSource;
			internal System.Windows.Forms.BindingSource SPUserBindingSource;
			internal SoftLogik.Win.dsUserSecurity m_dsUserSecurity;
			internal System.Windows.Forms.ImageList TreeNodeImageList;
		}
	}
	
	
}
