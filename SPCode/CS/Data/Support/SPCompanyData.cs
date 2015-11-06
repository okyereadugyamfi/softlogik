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
using System.IO;
using System.Drawing.Imaging;
using SoftLogik.Win.SPDataProxyTableAdapters;


namespace SoftLogik.Win
{
	public class SPCompanyData
	{
		
		public static SPDataProxy.SPCompanyDataTable GetCompanies()
		{
			SPDataProxy.SPCompanyDataTable data;
			using (SPDataProxyTableAdapters.taSPCompany dataCmd = new SPDataProxyTableAdapters.taSPCompany())
			{
				data = dataCmd.GetCompanies();
			}
			
			
			return data;
		}
		public static SPDataProxy.SPCompanyDataTable GetEmptyRecord()
		{
			SPDataProxy.SPCompanyDataTable data;
			using (SPDataProxyTableAdapters.taSPCompany dataCmd = new SPDataProxyTableAdapters.taSPCompany())
			{
				data = dataCmd.GetEmptyCompany();
			}
			
			
			return data;
		}
		
		public static int InsertCompany(string Name, string PhoneList, string EmailAddress, string Address1, string Address2, byte[] Logo, string Motto, string CustomNote)
		{
			using (SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany companyAdapter = new SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany())
			{
				return companyAdapter.Insert(Name, PhoneList, EmailAddress, Address1, Address2, Logo, Motto, CustomNote);
			}
			
		}
		public static int UpdateCompany(long CompanyID, string Name, string PhoneList, string EmailAddress, string Address1, string Address2, byte[] Logo, string Motto, string CustomNote)
		{
			using (SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany companyAdapter = new SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany())
			{
				return companyAdapter.Update(CompanyID, Name, PhoneList, EmailAddress, Address1, Address2, Logo, Motto, CustomNote);
			}
			
		}
		public static int DeleteCompany(long CompanyID)
		{
			using (SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany companyAdapter = new SoftLogik.Win.SPDataProxyTableAdapters.taSPCompany())
			{
				return companyAdapter.Delete(CompanyID);
			}
			
		}
	}
	
}
