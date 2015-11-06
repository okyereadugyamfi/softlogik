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
	public class SPPayModeCategories
	{
		
		public static SPPayModeItem[] DefaulList
		{
			get
			{
				SPPayModeItem[] _DefaultList = {new SPPayModeItem("Cash", "CASH"), new SPPayModeItem("Credit", "CREDIT"), new SPPayModeItem("Cheque", "CHEQUE"), new SPPayModeItem("On Account", "ACCOUNT"), new SPPayModeItem("Voucher", "VOUCHER"), new SPPayModeItem("Other", "OTHER")};
				return _DefaultList;
			}
		}
		
		
	}
	
	
	public class SPPayModeItem
	{
		
		
		private string _Name;
		public string Name
		{
			get
			{
				return _Name;
			}
		}
		
		private string _Category;
		public string Category
		{
			get
			{
				return _Category;
			}
		}
		
		internal SPPayModeItem(string Name, string Category)
		{
			this._Name = Name;
			this._Category = Category;
		}
	}
	
	
}
