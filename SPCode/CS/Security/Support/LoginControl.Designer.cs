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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPLoginControl : System.Windows.Forms.UserControl
		{
			
			
			//UserControl overrides dispose to clean up the component list.
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
			private System.Windows.Forms.Label m_UserNameLabel;
			private System.Windows.Forms.Label m_PasswordLabel;
			private System.Windows.Forms.ErrorProvider m_ErrorProvider;
			private System.Windows.Forms.Button m_LogInButton;
			internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
			internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPLoginControl));
				this.m_UserNameLabel = new System.Windows.Forms.Label();
				this.m_PasswordLabel = new System.Windows.Forms.Label();
				this.m_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
				this.m_LogInButton = new System.Windows.Forms.Button();
				this.m_LogInButton.Click += new System.EventHandler(OnLogin);
				this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
				this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
				this.m_PasswordBox = new System.Windows.Forms.TextBox();
				this.m_UserNameBox = new System.Windows.Forms.TextBox();
				((System.ComponentModel.ISupportInitialize) this.m_ErrorProvider).BeginInit();
				this.TableLayoutPanel1.SuspendLayout();
				this.TableLayoutPanel2.SuspendLayout();
				this.SuspendLayout();
				//
				//m_UserNameLabel
				//
				resources.ApplyResources(this.m_UserNameLabel, "m_UserNameLabel");
				this.m_UserNameLabel.Name = "m_UserNameLabel";
				//
				//m_PasswordLabel
				//
				resources.ApplyResources(this.m_PasswordLabel, "m_PasswordLabel");
				this.m_PasswordLabel.Name = "m_PasswordLabel";
				//
				//m_ErrorProvider
				//
				this.m_ErrorProvider.ContainerControl = this;
				//
				//m_LogInButton
				//
				resources.ApplyResources(this.m_LogInButton, "m_LogInButton");
				this.m_LogInButton.Name = "m_LogInButton";
				//
				//TableLayoutPanel1
				//
				resources.ApplyResources(this.TableLayoutPanel1, "TableLayoutPanel1");
				this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 0);
				this.TableLayoutPanel1.Controls.Add(this.m_LogInButton, 1, 1);
				this.TableLayoutPanel1.Name = "TableLayoutPanel1";
				//
				//TableLayoutPanel2
				//
				resources.ApplyResources(this.TableLayoutPanel2, "TableLayoutPanel2");
				this.TableLayoutPanel1.SetColumnSpan(this.TableLayoutPanel2, 2);
				this.TableLayoutPanel2.Controls.Add(this.m_PasswordLabel, 0, 1);
				this.TableLayoutPanel2.Controls.Add(this.m_UserNameBox, 1, 0);
				this.TableLayoutPanel2.Controls.Add(this.m_PasswordBox, 1, 1);
				this.TableLayoutPanel2.Controls.Add(this.m_UserNameLabel, 0, 0);
				this.TableLayoutPanel2.Name = "TableLayoutPanel2";
				//
				//m_PasswordBox
				//
				resources.ApplyResources(this.m_PasswordBox, "m_PasswordBox");
				this.m_PasswordBox.Name = "m_PasswordBox";
				//
				//m_UserNameBox
				//
				resources.ApplyResources(this.m_UserNameBox, "m_UserNameBox");
				this.m_UserNameBox.Name = "m_UserNameBox";
				//
				//SPLoginControl
				//
				resources.ApplyResources(this, "$this");
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.Controls.Add(this.TableLayoutPanel1);
				this.DoubleBuffered = true;
				this.Name = "SPLoginControl";
				((System.ComponentModel.ISupportInitialize) this.m_ErrorProvider).EndInit();
				this.TableLayoutPanel1.ResumeLayout(false);
				this.TableLayoutPanel2.ResumeLayout(false);
				this.TableLayoutPanel2.PerformLayout();
				this.ResumeLayout(false);
				
			}
			private System.Windows.Forms.TextBox m_UserNameBox;
			private System.Windows.Forms.TextBox m_PasswordBox;
			
		}
	}
	
	
}
