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
using System.ComponentModel;

namespace SoftLogik.Win
{
	#region Imports directives
	
	
	#endregion
	
	namespace Security
	{
		[ToolboxBitmap(typeof(WSLoginControl), "LoginControl.bmp")]public partial class WSLoginControl : SPLoginControl
		{
			
			protected override IUserManager GetUserManager()
			{
				return new UserManager();
			}
		}
	}
	
}
