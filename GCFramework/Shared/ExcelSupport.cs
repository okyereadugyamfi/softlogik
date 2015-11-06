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
using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Threading;


namespace ACSGhana.Web.Framework
{
	public sealed class ExcelSupport
	{
		
		private static object _lock = new object();
		
		public static DataTable GetExcelTable(string SourceFile, string WorkSheets)
		{
			//dim ex as
			System.Data.OleDb.OleDbConnection cn;
			System.Data.OleDb.OleDbDataAdapter cmd;
			DataTable ds = new DataTable();
			
			cn = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + "data source=" + SourceFile + ";Extended Properties=Excel 8.0;");
			
			try
			{
				// Select the data from Sheet1 of the workbook.
				cmd = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + WorkSheets, cn);
				
				cn.Open();
				cmd.Fill(ds);
			}
			catch (System.Exception)
			{
			}
			finally
			{
				cn.Close();
			}
			
			return ds;
		}
		
		private static OleDbConnection GetExcelConnection(string SourceFile, bool UseExcelMethod)
		{
			OleDbConnection ExcelConnection = null;
			if (! UseExcelMethod)
			{
				ExcelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SourceFile + ";Extended Properties=\"HTML Import;\"");
			}
			else
			{
				ExcelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SourceFile + ";Extended Properties=\"Excel 8.0;IMEX=1;HDR=Yes;\"");
			}
			
			try
			{
				//Test the connection
				ExcelConnection.Open();
			}
			catch (System.Exception)
			{
				if (! UseExcelMethod)
				{
					ExcelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SourceFile + ";Extended Properties=\"Excel 8.0;IMEX=1;HDR=Yes;\"");
				}
				else
				{
					ExcelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SourceFile + ";Extended Properties=\"HTML Import;\"");
				}
			}
			finally
			{
				if (ExcelConnection.State != ConnectionState.Closed)
				{
					ExcelConnection.Close();
				}
			}
			
			return ExcelConnection;
		}
		
		public static DataTable GetExcelWorkSheet(string SourceFile, int workSheetNumber)
		{
			return GetExcelWorkSheet(SourceFile, workSheetNumber, null);
		}
		
		public static DataTable GetExcelWorkSheet(string SourceFile, int workSheetNumber, ExcelDataColumnCollection AdditionalColumns)
		{
			bool IsFirstRetry = true;
			bool IsFirstColumnRetry = true;
			OleDbConnection ExcelConnection = GetExcelConnection(SourceFile, false);
			
RetryConnection_Line:
			OleDbCommand ExcelCommand = new OleDbCommand();
			ExcelCommand.Connection = ExcelConnection;
			OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
			DataTable ExcelDataTable = new DataTable();
			
			try
			{
				lock(_lock)
				{
					ExcelConnection.Open();
					DataTable ExcelSheets = ExcelConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
					string SpreadSheetName;
					
					if ((ExcelSheets != null)&& ExcelSheets.Rows.Count > 0)
					{
						SpreadSheetName = "[" + ExcelSheets.Rows[workSheetNumber]["TABLE_NAME"].ToString() + "]";
					}
					else
					{
						SpreadSheetName = "[Sheet1$]";
					}
					
					if (AdditionalColumns != null)
					{
						if (AdditionalColumns.Count > 0)
						{
							ExcelCommand.CommandText = "SELECT *, " + AdditionalColumns.SqlText + " FROM " + SpreadSheetName;
						}
					}
					else
					{
						ExcelCommand.CommandText = "SELECT * FROM " + SpreadSheetName;
					}
					
					try
					{
						ExcelAdapter.Fill(ExcelDataTable);
					}
					catch (System.Exception)
					{
					}
					finally
					{
						if (ExcelDataTable.Columns.Count == 0 && IsFirstColumnRetry)
						{
							IsFirstColumnRetry = false;
							ExcelCommand.CommandText = "SELECT * FROM [" + Path.GetFileNameWithoutExtension(SourceFile) + "]";
							ExcelAdapter.Fill(ExcelDataTable);
						}
					}
				}
				
			}
			catch (System.Exception)
			{
				if (IsFirstRetry)
				{
					IsFirstRetry = false;
					ExcelConnection = GetExcelConnection(SourceFile, true);
					goto RetryConnection_Line;
				}
			}
			finally
			{
				if (ExcelConnection.State != ConnectionState.Closed)
				{
					ExcelConnection.Close();
				}
			}
			
			return ExcelDataTable;
			
		}
		public static IDataReader GetExcelReader(string SourceFile, int workSheetNumber)
		{
			bool IsFirstRetry = true;
			OleDbConnection ExcelConnection = GetExcelConnection(SourceFile, false);
			
RetryConnection_Line:
			OleDbCommand ExcelCommand = new OleDbCommand();
			ExcelCommand.Connection = ExcelConnection;
			OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
			DataTable ExcelDataTable = new DataTable();
			
			try
			{
				ExcelConnection.Open();
				DataTable ExcelSheets = ExcelConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
				string SpreadSheetName;
				
				if ((ExcelSheets != null)&& ExcelSheets.Rows.Count > 0)
				{
					SpreadSheetName = "[" + ExcelSheets.Rows[workSheetNumber]["TABLE_NAME"].ToString() + "]";
				}
				else
				{
					SpreadSheetName = "[Sheet1]";
				}
				
				ExcelCommand.CommandText = "SELECT * FROM " + SpreadSheetName;
				return ((IDataReader) (ExcelCommand.ExecuteReader()));
			}
			catch (System.Exception)
			{
				if (IsFirstRetry)
				{
					IsFirstRetry = false;
					ExcelConnection = GetExcelConnection(SourceFile, true);
					goto RetryConnection_Line;
				}
			}
			finally
			{
				if (ExcelConnection.State != ConnectionState.Closed)
				{
					ExcelConnection.Close();
				}
			}
			
			return ExcelDataTable;
			
		}
		public static DataTable GetDBFileData(string SourceFile, string TableName)
		{
			OleDbConnection DBFileConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + Path.GetDirectoryName(SourceFile) + "\\;Mode=Share Deny Write;Extended Properties=\";Jet OLEDB:System database=\";Jet OLEDB:Registry Path=\";Jet OLEDB:Engine Type=82;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password=\";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don\'t Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False");
			OleDbCommand DBFileCommand = new OleDbCommand();
			DBFileCommand.Connection = DBFileConnection;
			OleDbDataAdapter DBFileAdapter = new OleDbDataAdapter(DBFileCommand);
			DataTable DBFileDataTable = new DataTable();
			
			try
			{
				DBFileConnection.Open();
				DBFileCommand.CommandType = CommandType.TableDirect;
				DBFileCommand.CommandText = TableName;
				DBFileAdapter.Fill(DBFileDataTable);
			}
			catch (System.Exception)
			{
			}
			finally
			{
				if (DBFileConnection.State != ConnectionState.Closed)
				{
					DBFileConnection.Close();
				}
			}
			return DBFileDataTable;
		}
		
	}
	
	
	public class ExcelDataColumn
	{
		
		
		private string _Name;
		public string @Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}
		
		private string _Value;
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}
		
		private DbType _DataType;
		public DbType DataType
		{
			get
			{
				return _DataType;
			}
			set
			{
				_DataType = value;
			}
		}
		
		public ExcelDataColumn(string Name, string Value, DbType DataType)
		{
			this._Name = Name;
			this._Value = Value;
			this._DataType = DataType;
		}
		
		public ExcelDataColumn(string Name, string Value)
		{
			this._Name = Name;
			this._Value = Value;
			this._DataType = DbType.String;
		}
	}
	
	public class ExcelDataColumnCollection : System.Collections.ObjectModel.KeyedCollection<string, ExcelDataColumn>
	{
		
		
		protected override string GetKeyForItem(ExcelDataColumn item)
		{
			return item.Name;
		}
		
		public string SqlText
		{
			get
			{
				StringBuilder sb = new StringBuilder(1024);
				
				foreach (ExcelDataColumn itm in this)
				{
					switch (itm.DataType)
					{
						case DbType.String:
						case DbType.StringFixedLength:
						case DbType.DateTime:
						case DbType.AnsiString:
						case DbType.AnsiStringFixedLength:
						case DbType.Date:
						case DbType.DateTime2:
						case DbType.DateTimeOffset:
						case DbType.Guid:
						case DbType.Time:
						case DbType.Xml:
							sb.AppendFormat(" \'{0}\' as {1}, ", itm.Value, itm.Name);
							break;
						default:
							sb.AppendFormat(" {0} as {1}, ", itm.Value, itm.Name);
							break;
					}
					
				}
				
				string retString = sb.ToString().Trim();
				return retString.Substring(0, retString.Length - 1);
			}
		}
		
		public void Add(string Name, string Value, DbType DataType)
		{
			this.Add(new ExcelDataColumn(Name, Value, DataType));
		}
		public void Add(string Name, string Value)
		{
			this.Add(new ExcelDataColumn(Name, Value));
		}
	}
	
}
