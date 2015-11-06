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
		public partial class SPPrintSettings
		{
			
			
			
		}
		public sealed class PrintSupport
		{
			
			private static SPPrintSettings m_PrintSettings = new SPPrintSettings();
			
			public static bool ChoosePrinter()
			{
				m_PrintSettings.MyPrintDialog.ShowDialog();
			}
		}
	}
	
	
	
	
	
	
}
