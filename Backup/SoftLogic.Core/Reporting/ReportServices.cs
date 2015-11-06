using System.Diagnostics;
using System;
using System.Management;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.Design;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace SoftLogik.Reporting
{
		
		public struct ConnectionPartValues
		{
			public string ServerName;
			public string DatabaseName;
			public string UserName;
			public string Password;
			public bool IntegratedSecurity;
		}
		
		public class ReportServices
		{
			
			
			public static FileStream GenerateExportStream(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft)
			{
				return new FileStream(GenerateExport(selectedReport, eft), FileMode.Open);
			}
			public static string GenerateExport(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft)
			{
				return GenerateExport(selectedReport, eft, string.Empty);
			}
			public static string GenerateExport(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft, string ExportFileName)
			{
				selectedReport.ExportOptions.ExportFormatType = eft;
				
				string contentType = "";
				
				// Make sure asp.net has create and delete permissions in the directory
				string tempDir = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["tempDir"]);
				string tempFileName = string.Concat(Path.GetFileNameWithoutExtension(selectedReport.FileName), ".");
				if (! string.IsNullOrEmpty(ExportFileName))
				{
					tempFileName = string.Concat(ExportFileName, ".");
				}
				
				switch (eft)
				{
					case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
						tempFileName += "pdf";
						break;
					case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
						tempFileName += "doc";
						break;
					case CrystalDecisions.Shared.ExportFormatType.Excel:
						tempFileName += "xls";
						break;
					case CrystalDecisions.Shared.ExportFormatType.HTML32:
					case CrystalDecisions.Shared.ExportFormatType.HTML40:
						tempFileName += "htm";
						CrystalDecisions.Shared.HTMLFormatOptions hop = new CrystalDecisions.Shared.HTMLFormatOptions();
						hop.HTMLBaseFolderName = tempDir;
						hop.HTMLFileName = tempFileName;
						selectedReport.ExportOptions.FormatOptions = hop;
						break;
				}
				
				CrystalDecisions.Shared.DiskFileDestinationOptions dfo = new CrystalDecisions.Shared.DiskFileDestinationOptions();
				dfo.DiskFileName = Path.Combine(tempDir, tempFileName);
				selectedReport.ExportOptions.DestinationOptions = dfo;
				selectedReport.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
				
				selectedReport.Export();
				selectedReport.Close();
				
				string tempFileNameUsed;
				if (eft == CrystalDecisions.Shared.ExportFormatType.HTML32 || eft == CrystalDecisions.Shared.ExportFormatType.HTML40)
				{
					string[] fp = selectedReport.FilePath.Split("\\" .ToCharArray());
					string leafDir = fp[fp.Length - 1];
					// strip .rpt extension
					leafDir = leafDir.Substring(0, leafDir.Length - 4);
					tempFileNameUsed = string.Format("{0}{1}\\{2}", tempDir, leafDir, tempFileName);
				}
				else
				{
					tempFileNameUsed = Path.Combine(tempDir, tempFileName);
				}
				
				return tempFileNameUsed;
			}
			public static void ExportReport(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft, ref HttpResponse TargetResponse)
			{
				ExportReport(selectedReport, eft, TargetResponse, null);
			}
			public static void ExportReport(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft, string ExportFileName)
			{
				ExportReport(selectedReport, eft, null, ExportFileName);
			}
			
			public static void ExportReport(CrystalDecisions.CrystalReports.Engine.ReportDocument selectedReport, CrystalDecisions.Shared.ExportFormatType eft, HttpResponse TargetResponse, string ExportFileName)
			{
				string contentType = "";
				HttpResponse currentReponse = TargetResponse;
				if (currentReponse == null)
				{
					currentReponse = HttpContext.Current.Response;
				}
				string tempFileNameUsed = GenerateExport(selectedReport, eft, ExportFileName);
				
				switch (eft)
				{
					case ExportFormatType.Excel:
						contentType = "application/vnd.ms-excel";
						break;
					case ExportFormatType.PortableDocFormat:
						contentType = "application/pdf";
						break;
					case ExportFormatType.RichText:
						contentType = "application/rtf";
						break;
					case ExportFormatType.WordForWindows:
						contentType = "application/doc";
						break;
					case ExportFormatType.HTML32:
						contentType = "application/text";
						break;
					case ExportFormatType.HTML40:
						contentType = "application/text";
						break;
				}
				
				currentReponse.ClearContent();
				currentReponse.ClearHeaders();
				currentReponse.ContentType = contentType;
				currentReponse.WriteFile(tempFileNameUsed);
				currentReponse.Flush();
				currentReponse.Close();
				try
				{
					System.IO.File.Delete(tempFileNameUsed);
				}
				catch (System.Exception)
				{
				}
			}
			
			public static void SetReportParameters(ReportDocument TargetReport, NameValueCollection Params)
			{
				try
				{
					if (@Params.Count > 0)
					{
						ParameterFieldDefinitions crParameterFieldDefinitions = TargetReport.DataDefinition.ParameterFields;
						foreach (ParameterFieldDefinition parafld in crParameterFieldDefinitions)
						{
							if (parafld.DiscreteOrRangeKind.ToString() == "DiscreteValue")
							{
								ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
								ParameterValues curvalues = new ParameterValues();
								
								discreteVal.Value = @Params[parafld.ParameterFieldName];
								if (discreteVal.Value != null)
								{
									curvalues.Add(discreteVal);
									parafld.ApplyCurrentValues(curvalues);
								}
								else
								{
									
								}
							}
						}
					}
				}
				catch (System.Exception)
				{
				}
			}
			
			public static ConnectionPartValues GetConnectionInfo(string ConnectionString)
			{
				try
				{
					
					string strConn = ConnectionString;
					string[] strArrConn = strConn.Split(';');
					ConnectionPartValues strPartValue = new ConnectionPartValues();
					
					foreach (string itm in strArrConn)
					{
						if (itm.Trim().StartsWith("Data Source="))
						{
							strPartValue.ServerName = itm.Split('=')[1];
						}
						if (itm.Trim().StartsWith("Initial Catalog="))
						{
							strPartValue.DatabaseName = itm.Split('=')[1];
						}
						if (itm.Trim().StartsWith("UID="))
						{
							strPartValue.UserName = itm.Split('=')[1];
						}
						if (itm.Trim().StartsWith("User ID="))
						{
							strPartValue.UserName = itm.Split('=')[1];
						}
						if (itm.Trim().StartsWith("Password="))
						{
							strPartValue.Password = itm.Split('=')[1];
						}
						if (itm.Trim().StartsWith("Integrated Security="))
						{
							strPartValue.IntegratedSecurity = true;
						}
						if (itm.Trim().StartsWith("Trusted Connection="))
						{
							strPartValue.IntegratedSecurity = true;
						}
						if (itm.Trim().EndsWith("SSPI"))
						{
							strPartValue.IntegratedSecurity = true;
						}
					}
					
					return strPartValue;
				}
				catch (System.Exception)
				{
                    return new ConnectionPartValues();
				}
				
			}
			
			public static void ParseReport(ref ReportDocument TargetReport, string NewConnectionString, NameValueCollection QueryString)
			{
				
				TableLogOnInfo crTableLogonInfo;
				ConnectionInfo crConnectionInfo = new ConnectionInfo();
				
				crTableLogonInfo = new TableLogOnInfo();
				ConnectionPartValues partNames = GetConnectionInfo(NewConnectionString);
				
				crConnectionInfo.ServerName = partNames.ServerName;
				crConnectionInfo.DatabaseName = partNames.DatabaseName;
				if (! partNames.IntegratedSecurity)
				{
					crConnectionInfo.UserID = partNames.UserName;
					crConnectionInfo.Password = partNames.Password;
				}
				else
				{
					crConnectionInfo.IntegratedSecurity = true;
				}
				
				foreach (CrystalDecisions.CrystalReports.Engine.Table sourceTable in TargetReport.Database.Tables)
				{
					crTableLogonInfo.ConnectionInfo = crConnectionInfo;
					sourceTable.ApplyLogOnInfo(crTableLogonInfo);
					string strLocation = sourceTable.Location;
					sourceTable.Location = crTableLogonInfo.ConnectionInfo.DatabaseName + ".dbo." + strLocation.Substring(strLocation.LastIndexOf(".") + 1);
				}
				
				SetReportParameters(TargetReport, QueryString);
			}
		}
	}

	

