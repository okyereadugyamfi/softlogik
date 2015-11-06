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
		/// Strongly-typed collection for the PollReactions class.
		/// </summary>
		[Serializable()]public partial class PollReactionsCollection : ActiveList<PollReactions, PollReactionsCollection>
		{

			public PollReactionsCollection()
			{
			}
		}
		/// <summary>
		/// This is an ActiveRecord class which wraps the PollReactions table.
		/// </summary>
		[Serializable()]public partial class PollReactions : ActiveRecord<PollReactions>
		{
			
			#region .ctors and Default Settings
			
			public PollReactions()
			{
				SetSQLProps();
				InitSetDefaults();
				MarkNew();
			}
			
			public PollReactions(bool useDatabaseDefaults)
			{
				SetSQLProps();
				if (useDatabaseDefaults == true)
				{
					ForceDefaults();
				}
				MarkNew();
			}
			public PollReactions(object keyID)
			{
				SetSQLProps();
				InitSetDefaults();
				LoadByKey(keyID);
			}
			public PollReactions(string columnName, object columnValue)
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
					TableSchema.Table schema = new TableSchema.Table("PollReactions", TableType.Table, DataService.GetInstance("ClubStarterKitData"));
					schema.Columns = new TableSchema.TableColumnCollection();
					schema.SchemaName = "dbo";
					//columns
					
					
					TableSchema.TableColumn colvarReactionId = new TableSchema.TableColumn(schema);
					colvarReactionId.ColumnName = "ReactionId";
					colvarReactionId.DataType = DbType.Guid;
					colvarReactionId.MaxLength = 0;
					colvarReactionId.AutoIncrement = false;
					colvarReactionId.IsNullable = false;
					colvarReactionId.IsPrimaryKey = true;
					colvarReactionId.IsForeignKey = false;
					colvarReactionId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarReactionId);
					
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
					
					TableSchema.TableColumn colvarReaction = new TableSchema.TableColumn(schema);
					colvarReaction.ColumnName = "Reaction";
					colvarReaction.DataType = DbType.String;
					colvarReaction.MaxLength = 1024;
					colvarReaction.AutoIncrement = false;
					colvarReaction.IsNullable = false;
					colvarReaction.IsPrimaryKey = false;
					colvarReaction.IsForeignKey = false;
					colvarReaction.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarReaction);
					
					TableSchema.TableColumn colvarPollId = new TableSchema.TableColumn(schema);
					colvarPollId.ColumnName = "PollId";
					colvarPollId.DataType = DbType.Guid;
					colvarPollId.MaxLength = 0;
					colvarPollId.AutoIncrement = false;
					colvarPollId.IsNullable = false;
					colvarPollId.IsPrimaryKey = false;
					colvarPollId.IsForeignKey = true;
					colvarPollId.IsReadOnly = false;
					
					
					colvarPollId.ForeignKeyTableName = "PollQuestions";
					
					schema.Columns.Add(colvarPollId);
					
					BaseSchema = schema;
					
					//add this schema to the provider
					//so we can query it later
					DataService.Providers["ClubStarterKitData"].AddSchema("PollReactions", schema);
				}
			}
			public static Query CreateQuery()
			{
				return new Query(Schema);
			}
			
			#endregion
			
			#region Props
			
			
			[XmlAttribute("ReactionId")]public Guid ReactionId
			{
				get
				{
					return GetColumnValue<Guid>("ReactionId");
				}
				
				set
				{
					SetColumnValue("ReactionId", value);
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
			
			
			
			[XmlAttribute("Reaction")]public string Reaction
			{
				get
				{
					return GetColumnValue<string>("Reaction");
				}
				
				set
				{
					SetColumnValue("Reaction", value);
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
			/// Returns a PollQuestions ActiveRecord object related to this PollReactions
			/// </summary>
			public System.Data.PollQuestions PollQuestions
			{
				get
				{
					return Data.PollQuestions.FetchByID(this.PollId);
				}
				set
				{
					SetColumnValue("PollId", value.PollId);
				}
			}
			
			#endregion
			
			
			
			//no ManyToMany tables defined (0)
			
			
			#region ObjectDataSource support
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			public static void Insert(Guid varReactionId, Guid varUserId, DateTime varCreationDate, string varReaction, Guid varPollId)
			{
				PollReactions item = new PollReactions();
				
				item.ReactionId = varReactionId;
				
				item.UserId = varUserId;
				
				item.CreationDate = varCreationDate;
				
				item.Reaction = varReaction;
				
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
			public static void Update(Guid varReactionId, Guid varUserId, DateTime varCreationDate, string varReaction, Guid varPollId)
			{
				PollReactions item = new PollReactions();
				
				item.ReactionId = varReactionId;
				
				item.UserId = varUserId;
				
				item.CreationDate = varCreationDate;
				
				item.Reaction = varReaction;
				
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
				
				public static string ReactionId = "ReactionId";
				
				public static string UserId = "UserId";
				
				public static string CreationDate = "CreationDate";
				
				public static string Reaction = "Reaction";
				
				public static string PollId = "PollId";
				
			}
			#endregion
		}
	}
	
}
