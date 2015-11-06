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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPRadioButtonList : System.Windows.Forms.UserControl
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
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.RadioGroupBox = new System.Windows.Forms.GroupBox();
				this.RadioTableLayout = new System.Windows.Forms.TableLayoutPanel();
				this.RadioGroupBox.SuspendLayout();
				this.SuspendLayout();
				//
				//RadioGroupBox
				//
				this.RadioGroupBox.Controls.Add(this.RadioTableLayout);
				this.RadioGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
				this.RadioGroupBox.Location = new System.Drawing.Point(0, 0);
				this.RadioGroupBox.Name = "RadioGroupBox";
				this.RadioGroupBox.Size = new System.Drawing.Size(206, 194);
				this.RadioGroupBox.TabIndex = 0;
				this.RadioGroupBox.TabStop = false;
				//
				//RadioTableLayout
				//
				this.RadioTableLayout.ColumnCount = 2;
				this.RadioTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0));
				this.RadioTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0));
				this.RadioTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
				this.RadioTableLayout.Location = new System.Drawing.Point(3, 16);
				this.RadioTableLayout.Name = "RadioTableLayout";
				this.RadioTableLayout.RowCount = 2;
				this.RadioTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0));
				this.RadioTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0));
				this.RadioTableLayout.Size = new System.Drawing.Size(200, 175);
				this.RadioTableLayout.TabIndex = 0;
				//
				//SPRadioButtonGroup
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.Controls.Add(this.RadioGroupBox);
				this.Name = "SPRadioButtonGroup";
				this.Size = new System.Drawing.Size(206, 194);
				this.RadioGroupBox.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.GroupBox RadioGroupBox;
			internal System.Windows.Forms.TableLayoutPanel RadioTableLayout;
			
		}
	}
	
	
}
