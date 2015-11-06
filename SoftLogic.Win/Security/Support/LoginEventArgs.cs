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

namespace SoftLogik.Win
{
	#region Imports directives
	#endregion
	
	namespace Security
	{
		public class LoginEventArgs : EventArgs
		{
			
			
			private bool m_Authenticated;
			
			public LoginEventArgs(bool authenticated)
			{
				this.Authenticated = authenticated;
			}
			
			public bool Authenticated
			{
				get
				{
					return m_Authenticated;
				}
				internal set
				{
					m_Authenticated = value;
				}
			}
		}
	}
	
}
