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
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Configuration;


namespace SoftLogik.Win
{
	namespace Security
	{
		[DebuggerStepThrough(), WebServiceBinding(Name = "WindowsUserManagerSoap", Namespace = "http://SecurityServices")]partial class UserManager : SoapHttpClientProtocol, IUserManager
		{
			
			public UserManager()
			{
				CookieContainer = new System.Net.CookieContainer();
				string urlSetting = ConfigurationManager.AppSettings["UserManager"];
				if (urlSetting != null)
				{
					Url = urlSetting;
				}
				else
				{
					Trace.TraceWarning("No URL was found in application configuration file");
				}
			}
			public UserManager(string url)
			{
				CookieContainer = new System.Net.CookieContainer();
				url = url;
			}
			[SoapDocumentMethod("http://SecurityServices/Authenticate")]public bool Authenticate(string applicationName, string userName, string password)
			{
				string[] parameters = {applicationName, userName, password};
				object[] results = Invoke("Authenticate", parameters);
				return (System.Convert.ToBoolean(results[0]));
			}
			[SoapDocumentMethod("http://SecurityServices/IsInRole")]public bool IsInRole(string applicationName, string userName, string role)
			{
				string[] parameters = {applicationName, userName, role};
				object[] results = Invoke("IsInRole", parameters);
				return (System.Convert.ToBoolean(results[0]));
			}
			[SoapDocumentMethod("http://SecurityServices/GetRoles")]public string[] GetRoles(string applicationName, string userName)
			{
				string[] parameters = {applicationName, userName};
				object[] results = Invoke("GetRoles", parameters);
				return ((string[]) (results[0]));
			}
		}
	}
	
}
