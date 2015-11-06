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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class LoginForm : System.Windows.Forms.Form
		{
			
			//Form overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (!(components == null))
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			internal System.Windows.Forms.PictureBox LogoPictureBox;
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.LogoPictureBox = new System.Windows.Forms.PictureBox();
				this.m_LogInControl = new SoftLogik.Win.Security.AspNetLoginControl();
				((System.ComponentModel.ISupportInitialize) this.LogoPictureBox).BeginInit();
				this.SuspendLayout();
				//
				//LogoPictureBox
				//
				this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
				this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
				this.LogoPictureBox.Name = "LogoPictureBox";
				this.LogoPictureBox.Size = new System.Drawing.Size(121, 151);
				this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				this.LogoPictureBox.TabIndex = 0;
				this.LogoPictureBox.TabStop = false;
				//
				//m_LogInControl
				//
				this.m_LogInControl.AccessibleName = "";
				this.m_LogInControl.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
				this.m_LogInControl.ApplicationName = "/";
				this.m_LogInControl.BackColor = System.Drawing.SystemColors.Control;
				this.m_LogInControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
				this.m_LogInControl.CacheRoles = false;
				this.m_LogInControl.Location = new System.Drawing.Point(127, 24);
				this.m_LogInControl.Name = "m_LogInControl";
				this.m_LogInControl.Padding = new System.Windows.Forms.Padding(1);
				this.m_LogInControl.Size = new System.Drawing.Size(264, 101);
				this.m_LogInControl.TabIndex = 2;
				//
				//LoginForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(393, 151);
				this.ControlBox = false;
				this.Controls.Add(this.m_LogInControl);
				this.Controls.Add(this.LogoPictureBox);
				this.DoubleBuffered = true;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "LoginForm";
				this.Opacity = 0.95;
				this.ShowInTaskbar = false;
				this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Program Login";
				((System.ComponentModel.ISupportInitialize) this.LogoPictureBox).EndInit();
				this.ResumeLayout(false);
				
			}
			protected internal SoftLogik.Win.Security.AspNetLoginControl m_LogInControl;
			
		}
	}
	
	
}
