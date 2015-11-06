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
		public sealed class SPDataFormats
		{
			
			public static void CurrencyFormat(object sender, ConvertEventArgs e)
			{
				if (e.Value is System.DBNull)
				{
					return;
				}
				
				e.Value = (Convert.ToDouble(e.Value)).ToString("C");
			}
			
			public static void PercentFormat(object sender, ConvertEventArgs e)
			{
				if (e.Value is System.DBNull)
				{
					return;
				}
				
				double percentValue = Convert.ToDouble(e.Value);
				percentValue = percentValue / 100;
				e.Value = percentValue.ToString("P0");
			}
			
			public static void DateFormat(object sender, ConvertEventArgs e)
			{
				if (e.Value is System.DBNull)
				{
					return;
				}
				
				e.Value = Convert.ToDateTime(e.Value).ToShortDateString();
			}
		}
	}
	
	
}
