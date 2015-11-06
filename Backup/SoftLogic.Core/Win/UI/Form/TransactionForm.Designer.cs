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
		public partial class TransactionForm : RecordForm
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SuspendLayout();
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.Images.SetKeyName(0, "DOC.png");
				//
				//TransactionForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(778, 443);
				this.Name = "TransactionForm";
				this.Text = "TransactionForm";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.ResumeLayout(false);
				
			}
		}
	}