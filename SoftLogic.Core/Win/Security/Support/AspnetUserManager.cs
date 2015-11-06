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
using System.Reflection;
using System.Web.Security;


namespace SoftLogik.Win.Security
{
	internal class AspNetUserManager : IUserManager
	{
		
		public bool Authenticate(string applicationName, string userName, string password)
		{
			Membership.ApplicationName = applicationName;
			return Membership.ValidateUser(userName, password);
		}
		public bool IsInRole(string applicationName, string userName, string role)
		{
			Roles.ApplicationName = applicationName;
			return Roles.IsUserInRole(userName, role);
		}
		public string[] GetRoles(string applicationName, string userName)
		{
			Roles.ApplicationName = applicationName;
			return Roles.GetRolesForUser(userName);
		}
	}
}
