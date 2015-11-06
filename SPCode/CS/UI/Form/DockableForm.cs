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
		public partial class DockableForm : WeifenLuo.WinFormsUI.DockContent
		{
			public DockableForm()
			{
				InitializeComponent();
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				
				this.TabText = this.Text;
				try
				{
					if (! DesignMode)
					{
						if (this.MdiParent != null)
						{
							this.Show(((DockingMDI) this.MdiParent).DockPanel, WeifenLuo.WinFormsUI.DockState.Document);
						}
					}
				}
				catch (Exception)
				{
				}
				
				base.OnLoad(e);
			}
			
			public void mnuClose_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
		}
	}
	
}
