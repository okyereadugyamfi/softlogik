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
	namespace Security
	{
		public interface IUserManager
		{
			bool Authenticate(string applicationName, string userName, string password);
			bool IsInRole(string applicationName, string userName, string role);
			string[] GetRoles(string applicationName, string userName);
		}
	}
	
	
	
}
