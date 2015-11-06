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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class NavigatorForm : DockableForm
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
				MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarTheme NavigateBarTheme1 = new MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarTheme();
				this.AppNavigation = new MT.Common.Controls.OutlookStyleNavigateBar.NavigateBar();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SuspendLayout();
				//
				//AppNavigation
				//
				this.AppNavigation.BackColor = System.Drawing.SystemColors.ControlLightLight;
				this.AppNavigation.CollapsibleScreenWidth = 120;
				this.AppNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
				this.AppNavigation.IsShowCollapsibleScreen = true;
				this.AppNavigation.Location = new System.Drawing.Point(0, 0);
				this.AppNavigation.MinimumSize = new System.Drawing.Size(22, 100);
				this.AppNavigation.Name = "AppNavigation";
				this.AppNavigation.NavigateBarButtonHeight = 32;
				this.AppNavigation.NavigateBarDisplayedButtonCount = 0;
				this.AppNavigation.NavigateBarPaintAngle = (float) 90.0;
				this.AppNavigation.SaveAndRestoreSettings = true;
				this.AppNavigation.SelectedButton = null;
				this.AppNavigation.Size = new System.Drawing.Size(277, 427);
				this.AppNavigation.TabIndex = 1;
				NavigateBarTheme1.DarkColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (123)), System.Convert.ToInt32((byte) (164)), System.Convert.ToInt32((byte) (224)));
				NavigateBarTheme1.DarkDarkColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (0)), System.Convert.ToInt32((byte) (45)), System.Convert.ToInt32((byte) (150)));
				NavigateBarTheme1.LightColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (203)), System.Convert.ToInt32((byte) (225)), System.Convert.ToInt32((byte) (252)));
				NavigateBarTheme1.MouseOverDarkColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (255)), System.Convert.ToInt32((byte) (203)), System.Convert.ToInt32((byte) (136)));
				NavigateBarTheme1.MouseOverLightColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (255)), System.Convert.ToInt32((byte) (255)), System.Convert.ToInt32((byte) (222)));
				NavigateBarTheme1.SelectedDarkColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (255)), System.Convert.ToInt32((byte) (223)), System.Convert.ToInt32((byte) (154)));
				NavigateBarTheme1.SelectedLightColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32((byte) (254)), System.Convert.ToInt32((byte) (128)), System.Convert.ToInt32((byte) (62)));
				this.AppNavigation.Theme = NavigateBarTheme1;
				//
				//NavigatorForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(277, 427);
				this.Controls.Add(this.AppNavigation);
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "NavigatorForm";
				this.Text = "NavigatorForm";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.ResumeLayout(false);
				
			}
			protected internal MT.Common.Controls.OutlookStyleNavigateBar.NavigateBar AppNavigation;
		}
	}
	
	
}
