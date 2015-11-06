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
		public partial class SPPrintSettings : System.ComponentModel.Component
		{
			
			
			[System.Diagnostics.DebuggerNonUserCode()]public SPPrintSettings(System.ComponentModel.IContainer Container) : this()
			{
				
				//Required for Windows.Forms Class Composition Designer support
				Container.Add(this);
				
			}
			
			[System.Diagnostics.DebuggerNonUserCode()]public SPPrintSettings()
			{
				
				//This call is required by the Component Designer.
				InitializeComponent();
				
			}
			
			//Component overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
			
			//Required by the Component Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Component Designer
			//It can be modified using the Component Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.MyPrintDialog = new System.Windows.Forms.PrintDialog();
				//
				//MyPrintDialog
				//
				this.MyPrintDialog.UseEXDialog = true;
				
			}
			internal System.Windows.Forms.PrintDialog MyPrintDialog;
			
		}
	}
	
	
}
