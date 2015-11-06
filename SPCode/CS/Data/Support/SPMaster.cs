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
	public class SPMaster
	{
		
		
		
		public static SPDataProxy.SPMasterDataTable GetMasterDetail(long MasterID)
		{
			SPDataProxy.SPMasterDataTable data;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				data = dataCmd.GetMaster(MasterID);
			}
			
			
			return data;
		}
		
		public static SPDataProxy.SPMasterDataTable GetMaster(string TypeID)
		{
			SPDataProxy.SPMasterDataTable data;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				data = dataCmd.GetMasterLookup(TypeID);
			}
			
			
			return data;
		}
		public static SPDataProxy.SPMasterDataTable GetEmptyMaster(string TypeID)
		{
			SPDataProxy.SPMasterDataTable data;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				data = dataCmd.GetEmptyMaster(TypeID);
			}
			
			
			return data;
		}
		public static int InsertMaster(string Name, string Note, string TypeID)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				retval = dataCmd.Insert(Name, Note, TypeID);
			}
			
			
			return retval;
		}
		public static int UpdateMaster(long MasterID, string Name, string Note)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				retval = dataCmd.Update(MasterID, Name, Note);
			}
			
			
			return retval;
		}
		public static int DeleteMaster(long MasterID)
		{
			int retval;
			using (SPDataProxyTableAdapters.taSPMaster dataCmd = new SPDataProxyTableAdapters.taSPMaster())
			{
				retval = dataCmd.Delete(MasterID);
			}
			
			
			return retval;
		}
		
	}
	
}
