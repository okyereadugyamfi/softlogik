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

namespace SoftLogik.Win.UI
	{
		public partial class PaymodeForm : SetupForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymodeForm));
				this.gbxOutline = new System.Windows.Forms.GroupBox();
				this.ddlCategory = new System.Windows.Forms.ComboBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.ddlBankID = new System.Windows.Forms.ComboBox();
				this.lblCategory = new System.Windows.Forms.Label();
				this.lblNote = new System.Windows.Forms.Label();
				this.TextBox2 = new System.Windows.Forms.TextBox();
				this.TextBox1 = new System.Windows.Forms.TextBox();
				this.lblName = new System.Windows.Forms.Label();
				this.tbcMain.SuspendLayout();
				this.tabGeneral.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.gbxOutline.SuspendLayout();
				this.SuspendLayout();
				//
				//tvwName
				//
				this.tvwName.LineColor = System.Drawing.Color.Black;
				this.tvwName.Size = new System.Drawing.Size(203, 275);
				this.tvwName.TabIndex = 3;
				//
				//tbcMain
				//
				this.tbcMain.Size = new System.Drawing.Size(408, 275);
				this.tbcMain.TabIndex = 5;
				//
				//tabGeneral
				//
				this.tabGeneral.Controls.Add(this.gbxOutline);
				this.tabGeneral.Size = new System.Drawing.Size(400, 252);
				this.tabGeneral.TabIndex = 6;
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.Images.SetKeyName(0, "wi0054-48.gif");
				//
				//gbxOutline
				//
				this.gbxOutline.Controls.Add(this.ddlCategory);
				this.gbxOutline.Controls.Add(this.Label1);
				this.gbxOutline.Controls.Add(this.ddlBankID);
				this.gbxOutline.Controls.Add(this.lblCategory);
				this.gbxOutline.Controls.Add(this.lblNote);
				this.gbxOutline.Controls.Add(this.TextBox2);
				this.gbxOutline.Controls.Add(this.TextBox1);
				this.gbxOutline.Controls.Add(this.lblName);
				this.gbxOutline.Dock = System.Windows.Forms.DockStyle.Fill;
				this.gbxOutline.Location = new System.Drawing.Point(3, 3);
				this.gbxOutline.Name = "gbxOutline";
				this.gbxOutline.Size = new System.Drawing.Size(394, 246);
				this.gbxOutline.TabIndex = 1;
				this.gbxOutline.TabStop = false;
				//
				//ddlCategory
				//
				this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.ddlCategory.FormattingEnabled = true;
				this.ddlCategory.Location = new System.Drawing.Point(67, 39);
				this.ddlCategory.Name = "ddlCategory";
				this.ddlCategory.Size = new System.Drawing.Size(121, 21);
				this.ddlCategory.TabIndex = 6;
				this.ddlCategory.Tag = "Category";
				//
				//Label1
				//
				this.Label1.AutoSize = true;
				this.Label1.Location = new System.Drawing.Point(9, 69);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(35, 13);
				this.Label1.TabIndex = 5;
				this.Label1.Text = "Bank:";
				//
				//ddlBankID
				//
				this.ddlBankID.FormattingEnabled = true;
				this.ddlBankID.Location = new System.Drawing.Point(67, 66);
				this.ddlBankID.Name = "ddlBankID";
				this.ddlBankID.Size = new System.Drawing.Size(121, 21);
				this.ddlBankID.TabIndex = 4;
				this.ddlBankID.Tag = "BankID";
				//
				//lblCategory
				//
				this.lblCategory.AutoSize = true;
				this.lblCategory.Location = new System.Drawing.Point(6, 42);
				this.lblCategory.Name = "lblCategory";
				this.lblCategory.Size = new System.Drawing.Size(52, 13);
				this.lblCategory.TabIndex = 3;
				this.lblCategory.Text = "Category:";
				//
				//lblNote
				//
				this.lblNote.AutoSize = true;
				this.lblNote.Location = new System.Drawing.Point(9, 94);
				this.lblNote.Name = "lblNote";
				this.lblNote.Size = new System.Drawing.Size(33, 13);
				this.lblNote.TabIndex = 0;
				this.lblNote.Text = "N&ote:";
				//
				//TextBox2
				//
				this.TextBox2.Location = new System.Drawing.Point(67, 91);
				this.TextBox2.Multiline = true;
				this.TextBox2.Name = "TextBox2";
				this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.TextBox2.Size = new System.Drawing.Size(300, 100);
				this.TextBox2.TabIndex = 1;
				this.TextBox2.Tag = "Note";
				//
				//TextBox1
				//
				this.TextBox1.Location = new System.Drawing.Point(67, 13);
				this.TextBox1.Name = "TextBox1";
				this.TextBox1.Size = new System.Drawing.Size(300, 20);
				this.TextBox1.TabIndex = 1;
				this.TextBox1.Tag = "Name";
				//
				//lblName
				//
				this.lblName.AutoSize = true;
				this.lblName.Location = new System.Drawing.Point(6, 16);
				this.lblName.Name = "lblName";
				this.lblName.Size = new System.Drawing.Size(38, 13);
				this.lblName.TabIndex = 0;
				this.lblName.Text = "&Name:";
				//
				//PaymodeForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(615, 300);
				this.Name = "PaymodeForm";
				this.Text = "Payment Modes";
				this.tbcMain.ResumeLayout(false);
				this.tabGeneral.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.gbxOutline.ResumeLayout(false);
				this.gbxOutline.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();
				
			}
			internal System.Windows.Forms.GroupBox gbxOutline;
			internal System.Windows.Forms.Label lblNote;
			internal System.Windows.Forms.TextBox TextBox2;
			internal System.Windows.Forms.TextBox TextBox1;
			internal System.Windows.Forms.Label lblName;
			internal System.Windows.Forms.Label lblCategory;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.ComboBox ddlBankID;
			internal System.Windows.Forms.ComboBox ddlCategory;
		}
	}