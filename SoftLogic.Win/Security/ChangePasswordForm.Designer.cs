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
		public partial class ChangePasswordForm : System.Windows.Forms.Form
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
				((System.ComponentModel.ISupportInitialize) this.LogoPictureBox).BeginInit();
				this.SuspendLayout();
				//
				//LogoPictureBox
				//
				this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
				this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
				this.LogoPictureBox.Name = "LogoPictureBox";
				this.LogoPictureBox.Size = new System.Drawing.Size(121, 185);
				this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				this.LogoPictureBox.TabIndex = 0;
				this.LogoPictureBox.TabStop = false;
				//
				//ChangePasswordForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(393, 185);
				this.ControlBox = false;
				this.Controls.Add(this.LogoPictureBox);
				this.DoubleBuffered = true;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "ChangePasswordForm";
				this.Opacity = 0.95;
				this.ShowInTaskbar = false;
				this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Change Password";
				((System.ComponentModel.ISupportInitialize) this.LogoPictureBox).EndInit();
				this.ResumeLayout(false);
				
			}
			
		}
	}
	
	
}
