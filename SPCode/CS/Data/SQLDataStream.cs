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
	namespace Data
	{
		
		#region Data Stream Component
		public class SQLDataStore : ISPDataStore, IDisposable
		{
			
			
			
			private SqlTransaction m_trnTransaction;
			private SqlConnection m_conConnection;
			private bool disposedValue = false; // To detect redundant calls
			
			public SQLDataStore()
			{
				m_conConnection = null;
			}
			public SQLDataStore(SqlConnection AltConnection)
			{
				m_conConnection = AltConnection;
			}
			
			public bool AbortTransaction()
			{
				try
				{
					if (m_trnTransaction != null)
					{
						m_trnTransaction.Rollback();
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			public bool BeginTransaction()
			{
				try
				{
					if (m_trnTransaction == null)
					{
						if (m_conConnection == null)
						{
							m_conConnection = new SqlConnection(DataSupport.NewConnection());
						}
						
						if (m_conConnection.State == ConnectionState.Closed)
						{
							m_conConnection.Open();
						}
						m_trnTransaction = m_conConnection.BeginTransaction();
					}
					
					return true;
				}
				catch (SqlException)
				{
					return false;
				}
				catch (Exception)
				{
					return false;
				}
			}
			public bool CommitTransaction()
			{
				try
				{
					if (m_trnTransaction != null)
					{
						m_trnTransaction.Commit();
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			
			public object ExecuteCommand(string ExecuteText, ref SPDataParamCollection Params)
			{
				RegExpressions.StatementPatternType stMatch = RegExpressions.StatementMatch(ExecuteText.ToUpper());
				
				switch (stMatch)
				{
					case RegExpressions.StatementPatternType.InsertStatement:
					case RegExpressions.StatementPatternType.SelectStatement:
					case RegExpressions.StatementPatternType.UpdateStatement:
					case RegExpressions.StatementPatternType.DeleteStatement:
						return DataSupport.ExecuteSQL(ExecuteText, ref @Params, ref m_conConnection); //DML Statement
						
					default:
						return DataSupport.ExecuteSP(ExecuteText, ref @Params, ref m_conConnection); //Stored Procedure
				}
			}
			public IDataReader GetReader(string ExecuteText, ref SPDataParamCollection Params)
			{
				RegExpressions.StatementPatternType stMatch = RegExpressions.StatementMatch(ExecuteText.ToUpper());
				
				switch (stMatch)
				{
					case RegExpressions.StatementPatternType.SelectStatement:
						return DataSupport.ExecuteSQL_DR(ExecuteText, ref @Params, ref m_conConnection); //Select Statement
					case RegExpressions.StatementPatternType.InsertStatement:
					case RegExpressions.StatementPatternType.UpdateStatement:
					case RegExpressions.StatementPatternType.DeleteStatement:
						throw (new Exception("Invalid argument encountered in ExecuteText."));
						break;
					default:
						return DataSupport.ExecuteSP_DR(ExecuteText, ref @Params, ref m_conConnection); //Stored Procedure
				}
			}
			
			public string GetString(string ExecuteText, ref SPDataParamCollection Params)
			{
				RegExpressions.StatementPatternType stMatch = RegExpressions.StatementMatch(ExecuteText.ToUpper());
				
				switch (stMatch)
				{
					case RegExpressions.StatementPatternType.SelectStatement:
						//Return ExecuteSQL_Str(ExecuteText, Params, m_conConnection) 'Select Statement
						return Constants.vbNullString;
					case RegExpressions.StatementPatternType.InsertStatement:
					case RegExpressions.StatementPatternType.UpdateStatement:
					case RegExpressions.StatementPatternType.DeleteStatement:
						throw (new Exception("Invalid argument encountered in ExecuteText."));
						break;
					default:
						return DataSupport.ExecuteSP_Str(ExecuteText, ref @Params, ref m_conConnection); //Stored Procedure
				}
			}
			
			public System.Data.DataTable GetTable(string ExecuteText, ref SPDataParamCollection Params, bool Direct)
			{
				RegExpressions.StatementPatternType stMatch = RegExpressions.StatementMatch(ExecuteText.ToUpper());
				
				switch (stMatch)
				{
					case RegExpressions.StatementPatternType.SelectStatement:
						return DataSupport.ExecuteSQL_DT(ExecuteText, ref @Params, ref m_conConnection); //Select Statement
					case RegExpressions.StatementPatternType.InsertStatement:
					case RegExpressions.StatementPatternType.UpdateStatement:
					case RegExpressions.StatementPatternType.DeleteStatement:
						throw (new Exception("Invalid argument encountered in ExecuteText."));
						break;
					default:
						return DataSupport.ExecuteSP_DT(ExecuteText, ref @Params, ref m_conConnection, Direct); //Stored Procedure
				}
			}
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (! this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free unmanaged resources when explicitly called
					}
					
					m_trnTransaction.Dispose();
					m_trnTransaction = null;
					m_conConnection.Dispose();
					m_conConnection = null;
				}
				this.disposedValue = true;
			}
			
			#region  IDisposable Support
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			#endregion
			
		}
		#endregion
		
		#region Support
		sealed class DataSupport
		{
			
			public static string ExecuteSP_Str(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				IDataReader drData;
				objCmd.CommandType = CommandType.StoredProcedure;
				
				objCmd.Connection.Open();
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				using (objCmd)
				{
					drData = objCmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				
				
				if (drData != null)
				{
					drData.Read();
					try
					{
						return drData.GetString(0);
					}
					catch (Exception)
					{
						return Constants.vbNullString;
					}
				}
				return Constants.vbNullString;
			}
			
			public static object ExecuteSP(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				objCmd.CommandType = CommandType.StoredProcedure;
				
				objCmd.Connection.Open();
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				using (objCmd)
				{
					try
					{
						return objCmd.ExecuteScalar();
					}
					catch (Exception)
					{
						throw;
					}
					
				}
				
				
			}
			public static DataSet ExecuteSP_DS(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				
				SqlDataAdapter daExecuteSP = new SqlDataAdapter();
				DataSet dsExecuteSP = new DataSet();
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.StoredProcedure;
				
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				daExecuteSP.SelectCommand = objCmd;
				daExecuteSP.Fill(dsExecuteSP);
				return dsExecuteSP;
				
//				daExecuteSP.Dispose();
//				daExecuteSP = null;
//				objCmd.Dispose();
//				objCmd = null;
				
			}
			public static DataTable ExecuteSP_DT(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection, bool Direct)
			{
				
				DataTable dsExecuteSP = new DataTable();
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				SqlDataAdapter taData = new SqlDataAdapter(objCmd);
				
				if (Direct)
				{
					objCmd.CommandType = CommandType.Text;
					objCmd.CommandText = "SELECT * FROM " + ExecuteText;
				}
				else
				{
					objCmd.CommandType = CommandType.StoredProcedure;
				}
				
				objCmd.Connection.Open();
				ProcessParams(objCmd, @Params); //Parse Parameters
				taData.Fill(dsExecuteSP);
				objCmd.Connection.Close();
				return dsExecuteSP;
				
//				objCmd.Dispose();
//				objCmd = null;
				
			}
			public static SqlDataReader ExecuteSP_DR(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.StoredProcedure;
				
				objCmd.Connection.Open();
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				using (objCmd)
				{
					return objCmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				
			}
			
			public static object ExecuteSQL(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.Text;
				
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				return objCmd.ExecuteScalar();
//				objCmd.Dispose();
//				objCmd = null;
			}
			public static DataSet ExecuteSQL_DS(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				
				SqlDataAdapter daExecuteSP = new SqlDataAdapter();
				DataSet dsExecuteSP = new DataSet();
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.Text;
				
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				daExecuteSP.SelectCommand = objCmd;
				daExecuteSP.Fill(dsExecuteSP);
				return dsExecuteSP;
				
//				daExecuteSP.Dispose();
//				daExecuteSP = null;
//				objCmd.Dispose();
//				objCmd = null;
				
			}
			public static DataTable ExecuteSQL_DT(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				
				SqlDataAdapter daExecuteSP = new SqlDataAdapter();
				DataSet dsExecuteSP = new DataSet();
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.Text;
				
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				daExecuteSP.SelectCommand = objCmd;
				daExecuteSP.Fill(dsExecuteSP);
				return dsExecuteSP.Tables[0];
				
//				daExecuteSP.Dispose();
//				daExecuteSP = null;
//				objCmd.Dispose();
//				objCmd = null;
				
			}
			
			public static SqlDataReader ExecuteSQL_DR(string ExecuteText, ref SPDataParamCollection Params, ref SqlConnection AltConnection)
			{
				SqlCommand objCmd = new SqlCommand(ExecuteText, BuildConnection(AltConnection));
				
				objCmd.CommandType = CommandType.Text;
				
				ProcessParams(objCmd, @Params); //Parse Parameters
				
				objCmd.Connection.Open();
				using (objCmd)
				{
					return objCmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				
				
				return objCmd.ExecuteReader();
//				objCmd.Dispose();
//				objCmd = null;
			}
			
			#region Private Procedures
			
			internal static string NewConnection()
			{
				string strConnection = Constants.vbNullString;
				
				try
				{
					strConnection = My.Settings.Default.DBConnection;
				}
				catch (Exception)
				{
				}
				
				
				return strConnection;
			}
			private static SqlConnection BuildConnection(SqlConnection AltConnection)
			{
				if (AltConnection == null)
				{
					return new SqlConnection(NewConnection());
				}
				else
				{
					return AltConnection;
				}
			}
			private static bool ProcessParams(SqlCommand SourceCommand, SPDataParamCollection SourceParams)
			{
				bool boolFoundParam = false;
				
				try
				{
					try
					{
						if (SourceCommand.Connection.State == ConnectionState.Closed)
						{
							SourceCommand.Connection.Open();
						}
						SqlCommandBuilder.DeriveParameters(SourceCommand);
					}
					catch (Exception)
					{
					}
					
					foreach (SPDataParam targetParam in SourceParams)
					{
						boolFoundParam = false;
						foreach (SqlParameter sourceParam in SourceCommand.Parameters)
						{
							if (sourceParam.ParameterName.ToUpper() == targetParam.Name.ToUpper())
							{
								sourceParam.Value = targetParam.Value;
								boolFoundParam = true;
								break;
							}
						}
						
						//if not found in the source list add it
						if (boolFoundParam == false)
						{
							SourceCommand.Parameters.Add(targetParam);
						}
					}
				}
				catch (Exception)
				{
				}
				
			}
			
			#endregion
		}
		
		sealed class RegExpressions
		{
			
			public enum StatementPatternType
			{
				None = 0,
				InsertStatement,
				SelectStatement,
				UpdateStatement,
				DeleteStatement
			}
			//Pattern Matching for Stored Procs & Select Statements
			public const string PkSelectStatementPattern = "^(.*)(\\s*)SELECT\\s(.*)\\sFROM(.*)";
			public const string PkUpdateStatementPattern = "^(.*)(\\s*)UPDATE\\s(.*)\\sSET\\s(.*)";
			public const string PkInsertStatementPattern = "^(.*)(\\s*)INSERT\\s(.*)\\sVALUES(\\s*)[(](.*)[)]$";
			public const string PkDeleteStatementPattern = "^(.*)(\\s*)DELETE\\s(.*)\\s(.*)";
			
			public static StatementPatternType StatementMatch(string Expression)
			{
				if (Regex.Match(Expression, PkInsertStatementPattern).Success)
				{
					return StatementPatternType.InsertStatement;
				}
				else if (Regex.Match(Expression, PkSelectStatementPattern).Success)
				{
					return StatementPatternType.InsertStatement;
				}
				else if (Regex.Match(Expression, PkUpdateStatementPattern).Success)
				{
					return StatementPatternType.InsertStatement;
				}
				else if (Regex.Match(Expression, PkDeleteStatementPattern).Success)
				{
					return StatementPatternType.InsertStatement;
				}
				else
				{
					return StatementPatternType.None;
				}
			}
			
		}
		#endregion
		
	}
	
	
	
}
