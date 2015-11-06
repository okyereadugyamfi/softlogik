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
	sealed class Common
	{
		
		private static Form m_frmMainShell;
		
		public static Form MainShell
		{
			get
			{
				return m_frmMainShell;
			}
		}
		
		internal static void SetMainShell(Form NewShell)
		{
			m_frmMainShell = NewShell;
		}
		
	}
	
	
	public class FormDataState
	{
		
		private bool m_boolShowState;
		private bool m_boolEditState;
		private bool m_boolNewState;
		
		public FormDataState()
		{
			m_boolEditState = false;
			m_boolShowState = false;
			m_boolNewState = false;
		}
		
		public FormDataState(bool ShowState, bool EditState, bool NewState)
		{
			m_boolEditState = ShowState;
			m_boolShowState = EditState;
			m_boolNewState = NewState;
		}
		
		public bool ShowState
		{
			get
			{
				return m_boolShowState;
			}
			set
			{
				m_boolShowState = value;
			}
		}
		public bool EditState
		{
			get
			{
				return m_boolEditState;
			}
			set
			{
				m_boolEditState = value;
			}
		}
		public bool NewState
		{
			get
			{
				return m_boolNewState;
			}
			set
			{
				m_boolNewState = value;
			}
		}
		
	}
	
	
}
