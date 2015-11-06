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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPPreview : System.Windows.Forms.UserControl
		{
			
			
			//UserControl overrides dispose to clean up the component list.
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
				this.PrintPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
				this.SuspendLayout();
				//
				//PrintPreviewControl1
				//
				this.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.PrintPreviewControl1.Location = new System.Drawing.Point(0, 0);
				this.PrintPreviewControl1.Name = "PrintPreviewControl1";
				this.PrintPreviewControl1.Size = new System.Drawing.Size(397, 358);
				this.PrintPreviewControl1.TabIndex = 0;
				//
				//SPPreview
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.Controls.Add(this.PrintPreviewControl1);
				this.Name = "SPPreview";
				this.Size = new System.Drawing.Size(397, 358);
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.PrintPreviewControl PrintPreviewControl1;
			
		}
	}
	
	
	
}
