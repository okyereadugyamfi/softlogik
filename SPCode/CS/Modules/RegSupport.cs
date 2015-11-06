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
	sealed class RegSupport
	{
		
		private static CSPRegistry m_objReg;
		
		public static CSPRegistry Reg
		{
			get
			{
				if (m_objReg == null)
				{
					m_objReg = new CSPRegistry();
				}
				return m_objReg;
			}
		}
		
	}
	
	public class CSPRegistry
	{
		
		#region Public Procedures
		public bool SetValue(ref Microsoft.Win32.RegistryHive KeyRoot, string KeyPath, string KeyName, object Value, string RemoteMachine)
		{
			RegistryKey objKey;
			
			try
			{
				objKey = OpenKey(KeyRoot, KeyName, RemoteMachine, Constants.vbNullString);
				objKey.SetValue(KeyName, Value);
				objKey.Close();
			}
			catch (Exception)
			{
				
			}
			
			return true;
		}
		public object GetValue(Microsoft.Win32.RegistryHive Key, string KeyPath, string Name, object DefaultValue, string RemoteMachine)
		{
			RegistryKey objKey;
			object objValue = null;
			
			try
			{
				switch (Key)
				{
					case RegistryHive.ClassesRoot:
						objKey = Registry.ClassesRoot.OpenSubKey(KeyPath, true);
						break;
					case RegistryHive.LocalMachine:
						objKey = Registry.LocalMachine.OpenSubKey(KeyPath, true);
						break;
					case RegistryHive.CurrentUser:
						objKey = Registry.CurrentUser.OpenSubKey(KeyPath, true);
						break;
					default:
						objKey = RegistryKey.OpenRemoteBaseKey(Key, RemoteMachine).OpenSubKey(KeyPath, true);
						break;
				}
				
				objKey.GetValue(Name);
				objKey.Close();
			}
			catch (Exception)
			{
				
			}
			
			return System.Convert.ToString(objValue);
		}
		
		public bool KeyExists(ref RegistryHive KeyRoot, string KeyName, string RemoteMachine)
		{
			
			return !(OpenKey(KeyRoot, KeyName, RemoteMachine, Constants.vbNullString) == null);
		}
		public bool ValueExists(ref RegistryHive KeyRoot, string KeyName, string ValueName, string RemoteMachine)
		{
			RegistryKey objKey = OpenKey(KeyRoot, KeyName, RemoteMachine, Constants.vbNullString);
			
			return (objKey.GetValue(ValueName) == null);
		}
		#endregion
		
		#region Private Procedures
		private RegistryKey OpenKey(Microsoft.Win32.RegistryHive Key, string KeyPath, string Name, string RemoteMachine)
		{
			
			RegistryKey objKey;
			
			try
			{
				
				switch (Key)
				{
					case RegistryHive.ClassesRoot:
						objKey = Registry.ClassesRoot.OpenSubKey(KeyPath, true);
						break;
					case RegistryHive.LocalMachine:
						objKey = Registry.LocalMachine.OpenSubKey(KeyPath, true);
						break;
					case RegistryHive.CurrentUser:
						objKey = Registry.CurrentUser.OpenSubKey(KeyPath, true);
						break;
					default:
						objKey = RegistryKey.OpenRemoteBaseKey(Key, RemoteMachine).OpenSubKey(KeyPath, true);
						break;
				}
				
				return objKey;
			}
			catch (Exception)
			{
				return null;
			}
			
		}
		#endregion
	}
	
	
}
