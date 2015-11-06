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
using System.Threading;
using System.Security.Principal;
using System.Reflection;
using System.ComponentModel;

//Questions? Comments? go to
//http://www.idesign.net

namespace SoftLogik.Win
{
	#region Using directives
	
	
	#endregion
	
	namespace Security
	{
		[DefaultEvent("LoginEvent"), ToolboxBitmap(typeof(SPLoginControl), "LoginControl.bmp")]public abstract partial class SPLoginControl
		{
			
			
			private string m_ApplicationName = string.Empty;
			private bool m_CacheRoles = false;
			
			public delegate void LoginEventEventHandler(object Of);
			private LoginEventEventHandler LoginEventEvent;
			
			public event LoginEventEventHandler LoginEvent
			{
				add
				{
					LoginEventEvent = (LoginEventEventHandler) System.Delegate.Combine(LoginEventEvent, value);
				}
				remove
				{
					LoginEventEvent = (LoginEventEventHandler) System.Delegate.Remove(LoginEventEvent, value);
				}
			}
			
			
			[Category("Credentials")]public bool CacheRoles
			{
				get
				{
					return m_CacheRoles;
				}
				set
				{
					m_CacheRoles = value;
				}
			}
			[Category("Credentials")]public string ApplicationName
			{
				get
				{
					return m_ApplicationName;
				}
				
				set
				{
					m_ApplicationName = value;
				}
			}
			
			private string GetAppName()
			{
				if (ApplicationName != string.Empty)
				{
					return ApplicationName;
				}
				System.Reflection.Assembly clientAssembly = System.Reflection.Assembly.GetEntryAssembly();
				AssemblyName assemblyName = clientAssembly.GetName();
				return assemblyName.Name;
			}
			public static void Logout()
			{
				CustomPrincipal customPrincipal = Thread.CurrentPrincipal as customPrincipal;
				if (customPrincipal != null)
				{
					customPrincipal.Detach();
				}
			}
			public static bool IsLoggedIn
			{
				get
				{
					return Thread.CurrentPrincipal is CustomPrincipal;
				}
			}
			
			virtual public void OnLogin(object sender, EventArgs e)
			{
				string userName = m_UserNameBox.Text;
				string password = m_PasswordBox.Text;
				
				if (userName == string.Empty)
				{
					m_ErrorProvider.SetError(m_UserNameBox, "Please Enter User Name");
					return;
				}
				else
				{
					m_ErrorProvider.SetError(m_UserNameBox, string.Empty);
				}
				if (password == string.Empty)
				{
					m_ErrorProvider.SetError(m_PasswordBox, "Please Enter Password");
					return;
				}
				else
				{
					m_ErrorProvider.SetError(m_PasswordBox, string.Empty);
				}
				string applicationName = GetAppName();
				IUserManager userManager = GetUserManager();
				
				bool authenticated = userManager.Authenticate(applicationName, userName, password);
				if (authenticated)
				{
					IIdentity identity = new GenericIdentity(userName);
					CustomPrincipal.Attach(identity, applicationName, userManager, CacheRoles);
				}
				LoginEventArgs loginEventArgs = new LoginEventArgs(authenticated);
				
				if (LoginEventEvent != null)
					LoginEventEvent(this, loginEventArgs);
			}
			
			protected abstract IUserManager GetUserManager();
			
		}
		
		
		
	}
}
