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


namespace SoftLogik.Win
{
	namespace Security
	{
		internal class CustomPrincipal : IPrincipal
		{
			
			private IIdentity m_User;
			private IPrincipal m_OldPrincipal;
			private IUserManager m_UserManager;
			private string m_ApplicationName;
			private string[] m_Roles;
			private static bool m_ThreadPolicySet = false;
			
			private CustomPrincipal(IIdentity user, string applicationName, IUserManager userManager, bool cacheRoles)
			{
				m_OldPrincipal = Thread.CurrentPrincipal;
				
				m_User = user;
				m_ApplicationName = applicationName;
				m_UserManager = userManager;
				
				if (cacheRoles)
				{
					m_Roles = m_UserManager.GetRoles(m_ApplicationName, m_User.Name);
				}
				//Make this object the principal for this thread
				Thread.CurrentPrincipal = this;
			}
			public static void Attach(IIdentity user, string applicationName, IUserManager userManager)
			{
				Attach(user, applicationName, userManager, false);
			}
			public static void Attach(IIdentity user, string applicationName, IUserManager userManager, bool cacheRoles)
			{
				Debug.Assert(user.IsAuthenticated);
				
				IPrincipal _customPrincipal = new CustomPrincipal(user, applicationName, userManager, cacheRoles);
				
				//Make sure all future threads in this app domain use this principal
				//but because default principal cannot be set twice:
				if (m_ThreadPolicySet == false)
				{
					AppDomain currentDomain = AppDomain.CurrentDomain;
					currentDomain.SetThreadPrincipal(_customPrincipal);
					m_ThreadPolicySet = true;
				}
			}
			public void Detach()
			{
				Thread.CurrentPrincipal = m_OldPrincipal;
			}
			
			public IIdentity Identity
			{
				get
				{
					return m_User;
				}
			}
			public bool IsInRole(string role)
			{
				if (m_Roles != null)
				{
					foreach (string itm in m_Roles)
					{
						if (itm == role)
						{
							return true;
						}
					}
                    return false;
				}
				else
				{
					return m_UserManager.IsInRole(m_ApplicationName, m_User.Name, role);
				}
			}
			
		}
	}
	
}
