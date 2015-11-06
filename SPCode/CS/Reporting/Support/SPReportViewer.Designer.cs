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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPReportViewer : UI.DockableForm
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
				this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SuspendLayout();
				//
				//ReportViewer1
				//
				this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
				this.ReportViewer1.Name = "ReportViewer1";
				this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
				this.ReportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
				this.ReportViewer1.Size = new System.Drawing.Size(600, 353);
				this.ReportViewer1.TabIndex = 2;
				//
				//SPReportViewer
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(600, 353);
				this.Controls.Add(this.ReportViewer1);
				this.Name = "SPReportViewer";
				this.Text = "Report Viewer";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.ResumeLayout(false);
				
			}
			internal Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
		}
	}
	
	
}
