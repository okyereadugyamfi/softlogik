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
		public partial class ChangePasswordForm
		{
			
			private bool m_Authenticated;
			public ChangePasswordForm()
			{
				Authenticated = false;
				InitializeComponent();
			}
			public bool Authenticated
			{
				get
				{
					return m_Authenticated;
				}
				protected set
				{
					m_Authenticated = value;
				}
			}
			private void OnLogin(object sender, LoginEventArgs args)
			{
				bool successful = args.Authenticated;
				if (successful == false)
				{
					MessageBox.Show("Invalid user name or password. Please try again", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Authenticated = true;
					Close();
				}
			}
			public static void Logout()
			{
				SPLoginControl.Logout();
			}
			public static bool IsLoggedIn
			{
				get
				{
					return SPLoginControl.IsLoggedIn;
				}
			}
		}
	}
}
