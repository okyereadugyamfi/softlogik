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
	namespace Reporting
	{
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPReportSettings : UI.NavigatorForm
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
				this.FilterView = new SPReportFilterUI();
				this.AppNavigation.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SuspendLayout();
				//
				//AppNavigation
				//
				this.AppNavigation.Controls.Add(this.FilterView);
				this.AppNavigation.Dock = System.Windows.Forms.DockStyle.None;
				this.AppNavigation.Size = new System.Drawing.Size(222, 391);
				//
				//FilterView
				//
				this.FilterView.Location = new System.Drawing.Point(165, 12);
				this.FilterView.Name = "FilterView";
				this.FilterView.Size = new System.Drawing.Size(339, 428);
				this.FilterView.TabIndex = 5;
				//
				//SPReportSettings
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(317, 391);
				this.Name = "SPReportSettings";
				this.Text = "Report Settings";
				this.Controls.SetChildIndex(this.AppNavigation, 0);
				this.AppNavigation.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.ResumeLayout(false);
				
			}
			internal SPReportFilterUI FilterView;
		}
	}
	
	
}
