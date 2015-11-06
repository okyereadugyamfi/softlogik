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
using System.Globalization;


namespace ACSGhana.Web.Framework
{
	namespace Data
	{
		
		#region DataStore Inteface
		public interface ISPDataStore
		{
			// This interface enables a simplified and structured access to any data source
			// all data components should use this inteface
			DataTable GetTable(string ExecuteText, ref SPDataParamCollection Params, bool Direct);
			IDataReader GetReader(string ExecuteText, ref SPDataParamCollection Params);
			string GetString(string ExecuteText, ref SPDataParamCollection Params);
			int GetInteger(string ExecuteText, ref SPDataParamCollection Params);
			object ExecuteCommand(string ExecuteText, ref SPDataParamCollection Params);
			// Function UpdateDataset(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection) As Object
			//Function UpdateTable(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection) As Object
			bool BeginTransaction();
			bool CommitTransaction();
			bool AbortTransaction();
		}
		
		#endregion
		
		#region ISPDataStore Support
		
		
		public class SPDataEntity<DataEntityType>
		{
			
			
		}
		
		public class SPDataParam
		{
			
			private string m_strName;
			private object m_objValue;
			
			
			//Constructors
			public SPDataParam()
			{
				this.Name = Constants.vbNullString;
				this.Value = null;
			}
			
			public SPDataParam(string Name, object Value)
			{
				this.Name = Name;
				this.Value = Value;
			}
			
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
			public object Value
			{
				get
				{
					return m_objValue;
				}
				set
				{
					m_objValue = value;
				}
			}
		}
		public class SPDataParamCollection : CollectionBase
		{
			
			
			public SPDataParam Add(string Name, object Value)
			{
				SPDataParam objNew = new SPDataParam(Name, Value);
				List.Add(objNew);
				
				return objNew;
			}
		}
		
		
		public enum SPDataCommandPriority
		{
			Highest,
			High,
			Medium,
			Low,
			Lowest
		}
		
		public enum SPDataCommandType
		{
			None,
			StoredProcedure,
			CommandText,
			Both
		}
		
		public class SPCommandParam
		{
			
			private string m_strName;
			private object m_objCommand;
			private SPDataCommandPriority m_enmPriority;
			
			
			//Constructors
			public SPCommandParam()
			{
				this.Name = Constants.vbNullString;
				this.Command = null;
			}
			
			public SPCommandParam(string Name, object Value)
			{
				this.Name = Name;
				this.Command = Value;
			}
			
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
			public object Command
			{
				get
				{
					return m_objCommand;
				}
				set
				{
					m_objCommand = value;
				}
			}
			
			public SPDataCommandPriority Priority
			{
				get
				{
					return m_enmPriority;
				}
				set
				{
					m_enmPriority = value;
				}
			}
		}
		public class SPCommandParamCollection : CollectionBase
		{
			
			
			public SPCommandParam Add(string Name, object Value)
			{
				SPCommandParam objNew = new SPCommandParam(Name, Value);
				List.Add(objNew);
				return objNew;
			}
		}
		#endregion
		
	}
	
}
