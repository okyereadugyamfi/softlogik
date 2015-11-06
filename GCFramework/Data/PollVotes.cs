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
using System.Text;
using System.Data.Common;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;

namespace ACSGhana.Web.Framework
{
	namespace Data
	{
		/// <summary>
		/// Strongly-typed collection for the PollVotes class.
		/// </summary>
		[Serializable()]public partial class PollVotesCollection : ActiveList<PollVotes, PollVotesCollection>
		{
			
			public PollVotesCollection()
			{
			}
		}
		/// <summary>
		/// This is an ActiveRecord class which wraps the PollVotes table.
		/// </summary>
		[Serializable()]public partial class PollVotes : ActiveRecord<PollVotes>
		{
			
			#region .ctors and Default Settings
			
			public PollVotes()
			{
				SetSQLProps();
				InitSetDefaults();
				MarkNew();
			}
			
			public PollVotes(bool useDatabaseDefaults)
			{
				SetSQLProps();
				if (useDatabaseDefaults == true)
				{
					ForceDefaults();
				}
				MarkNew();
			}
			public PollVotes(object keyID)
			{
				SetSQLProps();
				InitSetDefaults();
				LoadByKey(keyID);
			}
			public PollVotes(string columnName, object columnValue)
			{
				SetSQLProps();
				InitSetDefaults();
				LoadByParam(columnName, columnValue);
			}
			private void InitSetDefaults()
			{
				SetDefaults();
			}
			
			protected static void SetSQLProps()
			{
				GetTableSchema();
			}
			#endregion
			
			#region Schema and Query Accessor
			
			public static TableSchema.Table Schema
			{
				get
				{
					if (BaseSchema == null)
					{
						SetSQLProps();
					}
					return BaseSchema;
				}
			}
			private static void GetTableSchema()
			{
				if (! IsSchemaInitialized)
				{
					//Schema declaration
					TableSchema.Table schema = new TableSchema.Table("PollVotes", TableType.Table, DataService.GetInstance("ClubStarterKitData"));
					schema.Columns = new TableSchema.TableColumnCollection();
					schema.SchemaName = "dbo";
					//columns
					
					
					TableSchema.TableColumn colvarVoteId = new TableSchema.TableColumn(schema);
					colvarVoteId.ColumnName = "VoteId";
					colvarVoteId.DataType = DbType.Guid;
					colvarVoteId.MaxLength = 0;
					colvarVoteId.AutoIncrement = false;
					colvarVoteId.IsNullable = false;
					colvarVoteId.IsPrimaryKey = true;
					colvarVoteId.IsForeignKey = false;
					colvarVoteId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarVoteId);
					
					TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
					colvarUserId.ColumnName = "UserId";
					colvarUserId.DataType = DbType.Guid;
					colvarUserId.MaxLength = 0;
					colvarUserId.AutoIncrement = false;
					colvarUserId.IsNullable = false;
					colvarUserId.IsPrimaryKey = false;
					colvarUserId.IsForeignKey = false;
					colvarUserId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarUserId);
					
					TableSchema.TableColumn colvarPollAnswerId = new TableSchema.TableColumn(schema);
					colvarPollAnswerId.ColumnName = "PollAnswerId";
					colvarPollAnswerId.DataType = DbType.Guid;
					colvarPollAnswerId.MaxLength = 0;
					colvarPollAnswerId.AutoIncrement = false;
					colvarPollAnswerId.IsNullable = false;
					colvarPollAnswerId.IsPrimaryKey = false;
					colvarPollAnswerId.IsForeignKey = true;
					colvarPollAnswerId.IsReadOnly = false;
					
					
					colvarPollAnswerId.ForeignKeyTableName = "PollAnswers";
					
					schema.Columns.Add(colvarPollAnswerId);
					
					TableSchema.TableColumn colvarCreationDate = new TableSchema.TableColumn(schema);
					colvarCreationDate.ColumnName = "CreationDate";
					colvarCreationDate.DataType = DbType.DateTime;
					colvarCreationDate.MaxLength = 0;
					colvarCreationDate.AutoIncrement = false;
					colvarCreationDate.IsNullable = false;
					colvarCreationDate.IsPrimaryKey = false;
					colvarCreationDate.IsForeignKey = false;
					colvarCreationDate.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarCreationDate);
					
					TableSchema.TableColumn colvarPollId = new TableSchema.TableColumn(schema);
					colvarPollId.ColumnName = "PollId";
					colvarPollId.DataType = DbType.Guid;
					colvarPollId.MaxLength = 0;
					colvarPollId.AutoIncrement = false;
					colvarPollId.IsNullable = false;
					colvarPollId.IsPrimaryKey = false;
					colvarPollId.IsForeignKey = false;
					colvarPollId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarPollId);
					
					BaseSchema = schema;
					
					//add this schema to the provider
					//so we can query it later
					DataService.Providers["ClubStarterKitData"].AddSchema("PollVotes", schema);
				}
			}
			public static Query CreateQuery()
			{
				return new Query(Schema);
			}
			
			#endregion
			
			#region Props
			
			
			[XmlAttribute("VoteId")]public Guid VoteId
			{
				get
				{
					return GetColumnValue<Guid>("VoteId");
				}
				
				set
				{
					SetColumnValue("VoteId", value);
				}
			}
			
			
			
			[XmlAttribute("UserId")]public Guid UserId
			{
				get
				{
					return GetColumnValue<Guid>("UserId");
				}
				
				set
				{
					SetColumnValue("UserId", value);
				}
			}
			
			
			
			[XmlAttribute("PollAnswerId")]public Guid PollAnswerId
			{
				get
				{
					return GetColumnValue<Guid>("PollAnswerId");
				}
				
				set
				{
					SetColumnValue("PollAnswerId", value);
				}
			}
			
			
			
			[XmlAttribute("CreationDate")]public DateTime CreationDate
			{
				get
				{
					return GetColumnValue<DateTime>("CreationDate");
				}
				
				set
				{
					SetColumnValue("CreationDate", value);
				}
			}
			
			
			
			[XmlAttribute("PollId")]public Guid PollId
			{
				get
				{
					return GetColumnValue<Guid>("PollId");
				}
				
				set
				{
					SetColumnValue("PollId", value);
				}
			}
			
			
			
			
			#endregion
			
			
			
			
			
			
			
			
			
			
			#region ForeignKey Methods
			
			/// <summary>
			/// Returns a PollAnswers ActiveRecord object related to this PollVotes
			/// </summary>
			public System.Data.PollAnswers PollAnswers
			{
				get
				{
					return Data.PollAnswers.FetchByID(this.PollAnswerId);
				}
				set
				{
					SetColumnValue("PollAnswerId", value.PollAnswerId);
				}
			}
			
			#endregion
			
			
			
			//no ManyToMany tables defined (0)
			
			
			#region ObjectDataSource support
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			public static void Insert(Guid varVoteId, Guid varUserId, Guid varPollAnswerId, DateTime varCreationDate, Guid varPollId)
			{
				PollVotes item = new PollVotes();
				
				item.VoteId = varVoteId;
				
				item.UserId = varUserId;
				
				item.PollAnswerId = varPollAnswerId;
				
				item.CreationDate = varCreationDate;
				
				item.PollId = varPollId;
				
				if (System.Web.HttpContext.Current != null)
				{
					item.Save(System.Web.HttpContext.Current.User.Identity.Name);
				}
				else
				{
					item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
				}
			}
			/// <summary>
			/// Updates a record, can be used with the Object Data Source
			/// </summary>
			public static void Update(Guid varVoteId, Guid varUserId, Guid varPollAnswerId, DateTime varCreationDate, Guid varPollId)
			{
				PollVotes item = new PollVotes();
				
				item.VoteId = varVoteId;
				
				item.UserId = varUserId;
				
				item.PollAnswerId = varPollAnswerId;
				
				item.CreationDate = varCreationDate;
				
				item.PollId = varPollId;
				
				item.IsNew = false;
				if (System.Web.HttpContext.Current != null)
				{
					item.Save(System.Web.HttpContext.Current.User.Identity.Name);
				}
				else
				{
					item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
				}
			}
			#endregion
			#region Columns Struct
			public struct Columns
			{
				public int x;
				
				public static string VoteId = "VoteId";
				
				public static string UserId = "UserId";
				
				public static string PollAnswerId = "PollAnswerId";
				
				public static string CreationDate = "CreationDate";
				
				public static string PollId = "PollId";
				
			}
			#endregion
		}
	}
	
}
