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
using System.Text;


namespace SoftLogik.Win
{
	namespace Data
	{
		namespace Services
		{
			
			internal class SPDataTracer
			{
				
				private static readonly TraceSwitch tracerSwitch;
				
				private SPDataTracer()
				{
				}
				static SPDataTracer()
				{
					tracerSwitch = new TraceSwitch("TraceSwitch", "application trace switch");
				}
				
				public static void Write(IDbCommand cmd)
				{
					if (tracerSwitch.Level >= TraceLevel.Verbose)
					{
						Trace.WriteLine(GetCommandDescription(cmd));
					}
				}
				
				public static void Write(System.Exception err)
				{
					if (tracerSwitch.Level >= TraceLevel.Error)
					{
						Trace.WriteLine(GetExceptionDescription(err));
					}
				}
				
				private static string GetCommandDescription(IDbCommand cmd)
				{
					StringBuilder sb = new StringBuilder(300);
					
					sb.Append(Constants.vbCrLf);
					sb.Append("-- CommandText: " + Constants.vbCrLf);
					sb.Append(cmd.CommandText + Constants.vbCrLf);
					sb.Append("-- CommandType: " + Constants.vbCrLf);
					sb.Append(cmd.CommandType.ToString() + Constants.vbCrLf);
					sb.Append("-- Parameters: " + Constants.vbCrLf);
					
					int i = 0;
					while (i < cmd.Parameters.Count)
					{
						IDataParameter parmater = (IDataParameter) (cmd.Parameters[i]);
						sb.Append(i + ". Name: " + parmater.ParameterName + ", Value: " + parmater.Value.ToString() + ", Type: " + parmater.DbType + ", Direction: " + parmater.Direction + "." + Constants.vbCrLf);
						i++;
					}
					
					sb.Append(Constants.vbCrLf);
					return sb.ToString();
				}
				
				private static string GetExceptionDescription(Exception e)
				{
					StringBuilder sb = new StringBuilder(200);
					
					sb.Append("Error: " + e.Message).Append(Constants.vbCrLf);
					sb.Append("Type: " + e.GetType().FullName).Append(Constants.vbCrLf);
					sb.Append("Source: " + e.Source).Append(Constants.vbCrLf);
					sb.Append("Target: " + e.TargetSite.ToString()).Append(Constants.vbCrLf);
					sb.Append("Stack: " + e.StackTrace).Append(Constants.vbCrLf);
					
					e = e.InnerException;
					while (e != null)
					{
						sb.Append(" ---------- Inner Exception: ---------- ").Append(Constants.vbCrLf);
						sb.Append(GetExceptionDescription(e));
						e = e.InnerException;
					}
					
					return sb.ToString();
				}
			}
		}
	}
	
	
}
