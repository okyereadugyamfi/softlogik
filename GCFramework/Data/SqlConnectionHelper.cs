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
using System.Web;
using System.Globalization;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Util;
using System.Web.Hosting;
using System.Web.Configuration;
using System.Security.Permissions;
using System.IO;
using System.Web.Management;
using System.Threading;
using System.Configuration.Provider;


namespace ACSGhana.Web.Framework
{
	internal class SqlConnectionHelper
	{
		
		internal const string s_strUpperDataDirWithToken = "|DATADIRECTORY|";
		private static object s_lock = new object();
		
		/// <devdoc>
		/// </devdoc>
		private SqlConnectionHelper()
		{
		}
		internal static SqlConnectionHolder GetConnection(string connectionString, bool revertImpersonation)
		{
			string strTempConnection = connectionString.ToUpperInvariant();
			
			SqlConnectionHolder holder = new SqlConnectionHolder(connectionString);
			bool closeConn = true;
			try
			{
				try
				{
					holder.Open(null, revertImpersonation);
					closeConn = false;
				}
				finally
				{
					if (closeConn)
					{
						holder.Close();
						holder = null;
					}
				}
			}
			catch
			{
				throw;
			}
			return holder;
		}
		
		/// <devdoc>
		/// </devdoc>
		internal static string GetConnectionString(string specifiedConnectionString, bool lookupConnectionString, bool appLevel)
		{
			if (specifiedConnectionString == null || specifiedConnectionString.Length < 1)
			{
				return null;
			}
			
			string connectionString = null;
			
			/////////////////////////////////////////
			// Step 1: Check <connectionStrings> config section for this connection string
			if (lookupConnectionString)
			{
				ConnectionStringSettings connObj = ConfigurationManager.ConnectionStrings[specifiedConnectionString];
				if (connObj != null)
				{
					connectionString = connObj.ConnectionString;
				}
				
				if (connectionString == null)
				{
					return null;
				}
			}
			else
			{
				connectionString = specifiedConnectionString;
			}
			
			return connectionString;
		}
	}
	
	internal sealed class SqlConnectionHolder
	{
		
		internal SqlConnection _Connection;
		private bool _Opened;
		
		internal SqlConnection Connection
		{
			get
			{
				return _Connection;
			}
		}
		
		//////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////
		internal SqlConnectionHolder(string connectionString)
		{
			try
			{
				_Connection = new SqlConnection(connectionString);
			}
			catch (ArgumentException)
			{
				throw (new ArgumentException("SqlConnection Exception: Invalid connection String"));
			}
		}
		
		//////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////
		internal void Open(HttpContext context, bool revertImpersonate)
		{
			if (_Opened)
			{
				return; // Already opened
			}
			
			if (revertImpersonate)
			{
				using (HostingEnvironment.Impersonate())
				{
					Connection.Open();
				}
				
			}
			else
			{
				Connection.Open();
			}
			
			_Opened = true; // Open worked!
		}
		
		//////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////
		internal void Close()
		{
			if (! _Opened) // Not open!
			{
				return;
			}
			// Close connection
			Connection.Close();
			_Opened = false;
		}
	}
	
}
