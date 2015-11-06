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
	public class SPPayMode
	{
		
		public static SPDataProxy.SPPayModeDataTable GetPayMode(long PayModeID)
		{
			SPDataProxy.SPPayModeDataTable data;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				data = dataCmd.GetPayMode(PayModeID);
			}
			
			
			return data;
		}
		public static SPDataProxy.SPPayModeDataTable GetPayModes()
		{
			SPDataProxy.SPPayModeDataTable data;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				data = dataCmd.GetPayModes();
			}
			
			
			return data;
		}
		public static SPDataProxy.SPPayModeDataTable GetEmptyPayMode()
		{
			SPDataProxy.SPPayModeDataTable data;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				data = dataCmd.GetEmptyPayMode();
			}
			
			
			return data;
		}
		public static int InsertPayMode(string Name, string Category, long BankId, string Note)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				retval = dataCmd.Insert(Name, Category, BankId, Note);
			}
			
			
			return retval;
		}
		public static int UpdatePayMode(long PayModeID, string Name, string Category, long BankId, string Note)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				retval = dataCmd.Update(PayModeID, Name, Category, BankId, Note);
			}
			
			
			return retval;
		}
		public static int DeletePayMode(long PayModeID)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPPayMode dataCmd = new SPDataProxyTableAdapters.taSPPayMode())
			{
				retval = dataCmd.Delete(PayModeID);
			}
			
			
			return retval;
		}
		
	}
	
}
