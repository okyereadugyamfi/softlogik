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
		public partial class TransactionForm
		{
			public TransactionForm()
			{
				InitializeComponent();
			}
			
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				if (! DesignMode)
				{
					OnNewRecord();
				}
			}
		}
	}
	
}
