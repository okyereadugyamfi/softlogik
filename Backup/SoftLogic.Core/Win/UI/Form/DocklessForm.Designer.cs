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
		public partial class DocklessForm : System.Windows.Forms.Form
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
				this.components = new System.ComponentModel.Container();
				this.ErrorNotify = new System.Windows.Forms.ErrorProvider(this.components);
				this.KryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.SuspendLayout();
				//
				//ErrorNotify
				//
				this.ErrorNotify.ContainerControl = this;
				//
				//DocklessForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(335, 278);
				this.KeyPreview = true;
				this.Name = "DocklessForm";
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.ResumeLayout(false);
				
			}
			protected internal System.Windows.Forms.ErrorProvider ErrorNotify;
			protected internal UI.VisualTabOrderManager MyTabOrderManager;
			internal ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager1;
		}
	}