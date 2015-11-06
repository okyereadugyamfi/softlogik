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
	sealed class DSNSupport
	{
		
		public static string CreateDSN(string Name, string Description, string ServerName, string InitialCatalog, string UserID, string Password, bool IntegratedSecurity, string DriverName)
		{
			//---------------------------------------------------------------------------------------
			// Procedure : Create
			// DateTime  : 24/11/2005 16:14
			// Author    : Jefferson O. Adu - Gyamfi
			// Purpose   :
			//
			// Returns:
			//String
			//
			//---------------------------------------------------------------------------------------
			
			
			string strDSNName;
			string strDBName;
			string strDSNDescription;
			string strDriverPath;
			string strDriverName;
			string strLastUser;
			string strPassword;
			string strServer;
			string strRegPath;
			
			string szProcedureSign;
_1:
			szProcedureSign = "CSystemDSN" + "." + "Create()";
			#if DEBUGMODE
			#if TRACEMODE
			2 Call err.TraceIn(szProcedureSign);
			#endif
			3OnLocalErrorgotoCreate_Err;
			#endif
			//>=====User Code Section Begins======
			
			//Specify the DSN parameters.
			
_4:
			strDSNName = Strings.Trim(Name);
_5:
			strDBName = Strings.Trim(InitialCatalog);
_6:
			strDSNDescription = Strings.Trim(Description);
_7:
			strDriverName = Strings.Trim(DriverName);
_8:
			strDriverPath = System.Convert.ToString(RegSupport.Reg.GetValue(RegistryHive.LocalMachine, "SOFTWARE\\ODBC\\ODBCINST.INI\\" + strDriverName, "Driver", null, Constants.vbNullString));
_9:
			strLastUser = Strings.Trim(UserID);
_10:
			strServer = Strings.Trim(ServerName);
_11:
			strPassword = Strings.Trim(Password);
			
			//Create the new DSN key.
_12:
			strRegPath = "SOFTWARE\\ODBC\\ODBC.INI\\" + strDSNName;
			//Database
_13:
			if (strDBName != Constants.vbNullString)
			{
_14:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Database", strDBName, Constants.vbNullString);
_15:
				1.GetHashCode() ; //nop
			}
_16:
			if (strDSNDescription != Constants.vbNullString)
			{
_17:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Description", strDSNDescription, Constants.vbNullString);
_18:
				1.GetHashCode() ; //nop
			}
			
_19:
			if (strDriverPath != Constants.vbNullString)
			{
_20:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Driver", strDriverPath, Constants.vbNullString);
_21:
				1.GetHashCode() ; //nop
			}
_22:
			if (UserID != Constants.vbNullString)
			{
_23:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "User ID", UserID, Constants.vbNullString);
_24:
				1.GetHashCode() ; //nop
			}
			
_25:
			if (strPassword != Constants.vbNullString)
			{
_26:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Password", strPassword, Constants.vbNullString);
_27:
				1.GetHashCode() ; //nop
			}
			
_28:
			if (strServer != Constants.vbNullString)
			{
_29:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Server", strServer, Constants.vbNullString);
_30:
				1.GetHashCode() ; //nop
			}
_31:
			if (IntegratedSecurity == true)
			{
_32:
				RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, "Trusted_Connection", (IntegratedSecurity ? "Yes" : ""), Constants.vbNullString);
_33:
				1.GetHashCode() ; //nop
			}
			
			//Open ODBC Data Sources key to list the new DSN in the ODBC Manager.
			//Specify the new value.
_34:
			strRegPath = "SOFTWARE\\ODBC\\ODBC.INI\\" + "ODBC Data Sources\\";
_35:
			RegSupport.Reg.SetValue(ref RegistryHive.LocalMachine, strRegPath, strDSNName, strDriverName, Constants.vbNullString);
			
_36:
			return Name;
			
		}
	}
	
	
}
