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
		/// Strongly-typed collection for the PollAnswers class.
		/// </summary>
		[Serializable()]public partial class PollAnswersCollection : ActiveList<PollAnswers, PollAnswersCollection>
		{
			
			public PollAnswersCollection()
			{
			}
		}
		/// <summary>
		/// This is an ActiveRecord class which wraps the PollAnswers table.
		/// </summary>
		[Serializable()]public partial class PollAnswers : ActiveRecord<PollAnswers>
		{
			
			#region .ctors and Default Settings
			
			public PollAnswers()
			{
				SetSQLProps();
				InitSetDefaults();
				MarkNew();
			}
			
			public PollAnswers(bool useDatabaseDefaults)
			{
				SetSQLProps();
				if (useDatabaseDefaults == true)
				{
					ForceDefaults();
				}
				MarkNew();
			}
			public PollAnswers(object keyID)
			{
				SetSQLProps();
				InitSetDefaults();
				LoadByKey(keyID);
			}
			public PollAnswers(string columnName, object columnValue)
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
					TableSchema.Table schema = new TableSchema.Table("PollAnswers", TableType.Table, DataService.GetInstance("ClubStarterKitData"));
					schema.Columns = new TableSchema.TableColumnCollection();
					schema.SchemaName = "dbo";
					//columns
					
					
					TableSchema.TableColumn colvarPollAnswerId = new TableSchema.TableColumn(schema);
					colvarPollAnswerId.ColumnName = "PollAnswerId";
					colvarPollAnswerId.DataType = DbType.Guid;
					colvarPollAnswerId.MaxLength = 0;
					colvarPollAnswerId.AutoIncrement = false;
					colvarPollAnswerId.IsNullable = false;
					colvarPollAnswerId.IsPrimaryKey = true;
					colvarPollAnswerId.IsForeignKey = false;
					colvarPollAnswerId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarPollAnswerId);
					
					TableSchema.TableColumn colvarQuestionId = new TableSchema.TableColumn(schema);
					colvarQuestionId.ColumnName = "QuestionId";
					colvarQuestionId.DataType = DbType.Guid;
					colvarQuestionId.MaxLength = 0;
					colvarQuestionId.AutoIncrement = false;
					colvarQuestionId.IsNullable = false;
					colvarQuestionId.IsPrimaryKey = false;
					colvarQuestionId.IsForeignKey = true;
					colvarQuestionId.IsReadOnly = false;
					
					
					colvarQuestionId.ForeignKeyTableName = "PollQuestions";
					
					schema.Columns.Add(colvarQuestionId);
					
					TableSchema.TableColumn colvarAnswer = new TableSchema.TableColumn(schema);
					colvarAnswer.ColumnName = "Answer";
					colvarAnswer.DataType = DbType.String;
					colvarAnswer.MaxLength = 80;
					colvarAnswer.AutoIncrement = false;
					colvarAnswer.IsNullable = false;
					colvarAnswer.IsPrimaryKey = false;
					colvarAnswer.IsForeignKey = false;
					colvarAnswer.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarAnswer);
					
					TableSchema.TableColumn colvarRank = new TableSchema.TableColumn(schema);
					colvarRank.ColumnName = "Rank";
					colvarRank.DataType = DbType.Int32;
					colvarRank.MaxLength = 0;
					colvarRank.AutoIncrement = false;
					colvarRank.IsNullable = true;
					colvarRank.IsPrimaryKey = false;
					colvarRank.IsForeignKey = false;
					colvarRank.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarRank);
					
					BaseSchema = schema;
					
					//add this schema to the provider
					//so we can query it later
					DataService.Providers["ClubStarterKitData"].AddSchema("PollAnswers", schema);
				}
			}
			public static Query CreateQuery()
			{
				return new Query(Schema);
			}
			
			#endregion
			
			#region Props
			
			
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
			
			
			
			[XmlAttribute("QuestionId")]public Guid QuestionId
			{
				get
				{
					return GetColumnValue<Guid>("QuestionId");
				}
				
				set
				{
					SetColumnValue("QuestionId", value);
				}
			}
			
			
			
			[XmlAttribute("Answer")]public string Answer
			{
				get
				{
					return GetColumnValue<string>("Answer");
				}
				
				set
				{
					SetColumnValue("Answer", value);
				}
			}
			
			
			
			[XmlAttribute("Rank")]public Nullable<int> Rank
			{
				get
				{
					return GetColumnValue<Nullable<int>>("Rank");
				}
				
				set
				{
					SetColumnValue("Rank", value);
				}
			}
			
			
			
			
			#endregion
			
			
			
			
			#region PrimaryKey Methods
			
			public System.Data.PollVotesCollection PollVotesRecords()
			{
				
				return new Data.PollVotesCollection().Where(PollVotes.Columns.PollAnswerId, PollAnswerId).Load();
				
			}
			
			#endregion
			
			
			
			
			
			
			
			#region ForeignKey Methods
			
			/// <summary>
			/// Returns a PollQuestions ActiveRecord object related to this PollAnswers
			/// </summary>
			public System.Data.PollQuestions PollQuestions
			{
				get
				{
					return Data.PollQuestions.FetchByID(this.QuestionId);
				}
				set
				{
					SetColumnValue("QuestionId", value.PollId);
				}
			}
			
			#endregion
			
			
			
			//no ManyToMany tables defined (0)
			
			
			#region ObjectDataSource support
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			public static void Insert(Guid varPollAnswerId, Guid varQuestionId, string varAnswer, Nullable<int> varRank)
			{
				PollAnswers item = new PollAnswers();
				
				item.PollAnswerId = varPollAnswerId;
				
				item.QuestionId = varQuestionId;
				
				item.Answer = varAnswer;
				
				item.Rank = varRank;
				
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
			public static void Update(Guid varPollAnswerId, Guid varQuestionId, string varAnswer, Nullable<int> varRank)
			{
				PollAnswers item = new PollAnswers();
				
				item.PollAnswerId = varPollAnswerId;
				
				item.QuestionId = varQuestionId;
				
				item.Answer = varAnswer;
				
				item.Rank = varRank;
				
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
				
				public static string PollAnswerId = "PollAnswerId";
				
				public static string QuestionId = "QuestionId";
				
				public static string Answer = "Answer";
				
				public static string Rank = "Rank";
				
			}
			#endregion
		}
	}
	
}
