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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class MasterForm : SetupForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
				this.gbxOutline = new System.Windows.Forms.GroupBox();
				this.TypeIDField = new System.Windows.Forms.TextBox();
				this.NoteLabel = new System.Windows.Forms.Label();
				this.NoteTextField = new System.Windows.Forms.TextBox();
				this.NameTextField = new System.Windows.Forms.TextBox();
				this.NameLabel = new System.Windows.Forms.Label();
				this.tbcMain.SuspendLayout();
				this.tabGeneral.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.gbxOutline.SuspendLayout();
				this.SuspendLayout();
				//
				//tvwName
				//
				this.tvwName.LineColor = System.Drawing.Color.Black;
				this.tvwName.TabIndex = 3;
				//
				//tbcMain
				//
				this.tbcMain.TabIndex = 5;
				//
				//tabGeneral
				//
				this.tabGeneral.Controls.Add(this.gbxOutline);
				this.tabGeneral.TabIndex = 6;
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.Images.SetKeyName(0, "DOC.png");
				//
				//gbxOutline
				//
				this.gbxOutline.Controls.Add(this.TypeIDField);
				this.gbxOutline.Controls.Add(this.NoteLabel);
				this.gbxOutline.Controls.Add(this.NoteTextField);
				this.gbxOutline.Controls.Add(this.NameTextField);
				this.gbxOutline.Controls.Add(this.NameLabel);
				this.gbxOutline.Dock = System.Windows.Forms.DockStyle.Fill;
				this.gbxOutline.Location = new System.Drawing.Point(3, 3);
				this.gbxOutline.Name = "gbxOutline";
				this.gbxOutline.Size = new System.Drawing.Size(503, 389);
				this.gbxOutline.TabIndex = 0;
				this.gbxOutline.TabStop = false;
				//
				//TypeIDField
				//
				this.TypeIDField.Location = new System.Drawing.Point(90, 298);
				this.TypeIDField.Name = "TypeIDField";
				this.TypeIDField.Size = new System.Drawing.Size(100, 20);
				this.TypeIDField.TabIndex = 2;
				this.TypeIDField.Tag = "TypeID";
				this.TypeIDField.Visible = false;
				//
				//NoteLabel
				//
				this.NoteLabel.AutoSize = true;
				this.NoteLabel.Location = new System.Drawing.Point(33, 95);
				this.NoteLabel.Name = "NoteLabel";
				this.NoteLabel.Size = new System.Drawing.Size(33, 13);
				this.NoteLabel.TabIndex = 0;
				this.NoteLabel.Text = "N&ote:";
				//
				//NoteTextField
				//
				this.NoteTextField.Location = new System.Drawing.Point(90, 92);
				this.NoteTextField.Multiline = true;
				this.NoteTextField.Name = "NoteTextField";
				this.NoteTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.NoteTextField.Size = new System.Drawing.Size(300, 200);
				this.NoteTextField.TabIndex = 1;
				this.NoteTextField.Tag = "Note";
				//
				//NameTextField
				//
				this.NameTextField.Location = new System.Drawing.Point(90, 66);
				this.NameTextField.Name = "NameTextField";
				this.NameTextField.Size = new System.Drawing.Size(300, 20);
				this.NameTextField.TabIndex = 1;
				this.NameTextField.Tag = "Name";
				//
				//NameLabel
				//
				this.NameLabel.AutoSize = true;
				this.NameLabel.Location = new System.Drawing.Point(33, 69);
				this.NameLabel.Name = "NameLabel";
				this.NameLabel.Size = new System.Drawing.Size(38, 13);
				this.NameLabel.TabIndex = 0;
				this.NameLabel.Text = "&Name:";
				//
				//MasterForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.ClientSize = new System.Drawing.Size(778, 443);
				this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
				this.Name = "MasterForm";
				this.tbcMain.ResumeLayout(false);
				this.tabGeneral.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.gbxOutline.ResumeLayout(false);
				this.gbxOutline.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();
				
			}
			internal System.Windows.Forms.GroupBox gbxOutline;
			protected internal System.Windows.Forms.Label NoteLabel;
			protected internal System.Windows.Forms.TextBox NoteTextField;
			protected internal System.Windows.Forms.TextBox NameTextField;
			protected internal System.Windows.Forms.Label NameLabel;
			protected internal System.Windows.Forms.TextBox TypeIDField;
			
		}
	}
	
	
}
