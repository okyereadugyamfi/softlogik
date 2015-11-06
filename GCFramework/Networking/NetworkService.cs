using System.Diagnostics;
using System;
using System.Management;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.Design;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using System.Net;


namespace ACSGhana.Web.Framework
{
	public class NetworkService
	{
		
		
		[DllImport("iphlpapi.dll", ExactSpelling = true)]public static  extern int SendARP(int DestIP, int SrcIP, [@Out()]byte[] pMacAddr, ref int PhyAddrLen);
		
		public static string GetMACAddress(string HostIPAddress)
		{
			byte[] macBytes = new byte[6]();
			int len = macBytes.Length;
			string mac = string.Empty;
			
			try
			{
				int iAddr = BitConverter.ToInt32((new IPAddress(HostIPAddress)).GetAddressBytes(), 0);
				
				// This Function Used to Get The Physical Address
				int r = SendARP(iAddr, 0, macBytes, ref len);
				mac = BitConverter.ToString(macBytes, 0, 6);
			}
			catch (System.Exception)
			{
			}
			
			return mac;
		}
		
	}
	
}
