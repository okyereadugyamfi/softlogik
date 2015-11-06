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
using SoftLogik.Win.Data;
//using SoftLogik.Win.SPDataProxy;
using SoftLogik.Win.SPDataProxyTableAdapters;


namespace SoftLogik.Win
{
	namespace UI
	{
		public class SPSearchHelper
		{
			
			
			public static SPDataProxy.SPLookupDataTable GetSearchResults(string SearchType, string SubType, string SearchFor, string SearchItem, string ConnectionString)
			{
				if (string.IsNullOrEmpty(ConnectionString))
				{
					using (SoftLogik.Win.SPDataProxyTableAdapters.taSPLookup lookupAdapter = new SoftLogik.Win.SPDataProxyTableAdapters.taSPLookup())
					{
						return lookupAdapter.GetSearchResults(SearchType, SubType, SearchFor, SearchItem);
					}
					
				}
				else
				{
					SoftLogik.Win.Data.ISPDataStore lookupAdapter = new SQLDataStore(new System.Data.SqlClient.SqlConnection(ConnectionString));
					SPDataParamCollection objParams = new SPDataParamCollection();
					
					objParams.Add("@SearchType", SearchType);
					objParams.Add("@SubType", SubType);
					objParams.Add("@SearchFor", SearchFor);
					objParams.Add("@SearchItem", SearchItem);
					
					DataTable genericSearchTable = lookupAdapter.GetTable("SPLookup_Search", ref objParams, false);
					SPDataProxy.SPLookupDataTable searchTable = new SPDataProxy.SPLookupDataTable();
					searchTable.Load(genericSearchTable.CreateDataReader());
					return searchTable;
				}
			}
		}
	}
	
	
}
