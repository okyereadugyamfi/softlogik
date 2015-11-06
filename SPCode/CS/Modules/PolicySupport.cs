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
	public struct SPPolicy
	{
		
		private string m_strName;
		private Hashtable m_hshPolicyData;
		
		public string Name
		{
			get
			{
				return m_strName;
			}
			set
			{
				m_strName = value;
			}
		}
		public Hashtable PolicyData
		{
			get
			{
				return m_hshPolicyData;
			}
			set
			{
				m_hshPolicyData = value;
			}
		}
		
	}
	
	
}
