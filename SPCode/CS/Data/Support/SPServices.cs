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
//using SoftLogik.Win.SPDataProxy;
using SoftLogik.Win.SPDataProxyTableAdapters;


namespace SoftLogik.Win
{
	public class SPServices
	{
		
		
		public static string GenerateAutoID(string Prefix)
		{
			SPAutoIdDataTable data;
			SPAutoIdRow retData;
			using (SoftLogik.Win.SPDataProxyTableAdapters.taSPAutoId dataCmd = new SoftLogik.Win.SPDataProxyTableAdapters.taSPAutoId())
			{
				data = dataCmd.GetAutoID(Prefix, DateTime.Now);
			}
			
			retData = (SPAutoIdRow) (data.Rows[0]);
			return retData.NewID;
		}
		
	}
	
}
