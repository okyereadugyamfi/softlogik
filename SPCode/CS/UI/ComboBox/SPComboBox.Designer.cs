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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class SPComboBox : System.Windows.Forms.ComboBox
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
				components = new System.ComponentModel.Container();
			}
			
			public SPComboBox()
			{
				
				// This call is required by the Windows Form Designer.
				InitializeComponent();
				
				// Add any initialization after the InitializeComponent() call.
				
				//Add an Entry for the Lookup Field
				this.LookupIndex = this.Items.Add(LookupText);
				
			}
			
		}
	}
	
	
	
}
