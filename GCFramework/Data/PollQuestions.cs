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
		/// Strongly-typed collection for the PollQuestions class.
		/// </summary>
		[Serializable()]public partial class PollQuestionsCollection : ActiveList<PollQuestions, PollQuestionsCollection>
		{

			public PollQuestionsCollection()
			{
			}
		}
		/// <summary>
		/// This is an ActiveRecord class which wraps the PollQuestions table.
		/// </summary>
		[Serializable()]public partial class PollQuestions : ActiveRecord<PollQuestions>
		{
			
			#region .ctors and Default Settings
			
			public PollQuestions()
			{
				SetSQLProps();
				InitSetDefaults();
				MarkNew();
			}
			
			public PollQuestions(bool useDatabaseDefaults)
			{
				SetSQLProps();
				if (useDatabaseDefaults == true)
				{
					ForceDefaults();
				}
				MarkNew();
			}
			public PollQuestions(object keyID)
			{
				SetSQLProps();
				InitSetDefaults();
				LoadByKey(keyID);
			}
			public PollQuestions(string columnName, object columnValue)
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
					TableSchema.Table schema = new TableSchema.Table("PollQuestions", TableType.Table, DataService.GetInstance("ClubStarterKitData"));
					schema.Columns = new TableSchema.TableColumnCollection();
					schema.SchemaName = "dbo";
					//columns
					
					
					TableSchema.TableColumn colvarPollId = new TableSchema.TableColumn(schema);
					colvarPollId.ColumnName = "PollId";
					colvarPollId.DataType = DbType.Guid;
					colvarPollId.MaxLength = 0;
					colvarPollId.AutoIncrement = false;
					colvarPollId.IsNullable = false;
					colvarPollId.IsPrimaryKey = true;
					colvarPollId.IsForeignKey = false;
					colvarPollId.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarPollId);
					
					TableSchema.TableColumn colvarQuestion = new TableSchema.TableColumn(schema);
					colvarQuestion.ColumnName = "Question";
					colvarQuestion.DataType = DbType.String;
					colvarQuestion.MaxLength = 256;
					colvarQuestion.AutoIncrement = false;
					colvarQuestion.IsNullable = false;
					colvarQuestion.IsPrimaryKey = false;
					colvarQuestion.IsForeignKey = false;
					colvarQuestion.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarQuestion);
					
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
					
					TableSchema.TableColumn colvarMemberid = new TableSchema.TableColumn(schema);
					colvarMemberid.ColumnName = "memberid";
					colvarMemberid.DataType = DbType.Guid;
					colvarMemberid.MaxLength = 0;
					colvarMemberid.AutoIncrement = false;
					colvarMemberid.IsNullable = true;
					colvarMemberid.IsPrimaryKey = false;
					colvarMemberid.IsForeignKey = false;
					colvarMemberid.IsReadOnly = false;
					
					
					schema.Columns.Add(colvarMemberid);
					
					BaseSchema = schema;
					
					//add this schema to the provider
					//so we can query it later
					DataService.Providers["ClubStarterKitData"].AddSchema("PollQuestions", schema);
				}
			}
			public static Query CreateQuery()
			{
				return new Query(Schema);
			}
			
			#endregion
			
			#region Props
			
			
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
			
			
			
			[XmlAttribute("Question")]public string Question
			{
				get
				{
					return GetColumnValue<string>("Question");
				}
				
				set
				{
					SetColumnValue("Question", value);
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
			
			
			
			[XmlAttribute("Memberid")]public Nullable<Guid> Memberid
			{
				get
				{
					return GetColumnValue<Nullable<Guid>>("memberid");
				}
				
				set
				{
					SetColumnValue("memberid", value);
				}
			}
			
			
			
			
			#endregion
			
			
			
			
			#region PrimaryKey Methods
			
			public System.Data.PollAnswersCollection PollAnswersRecords()
			{
				
				return new Data.PollAnswersCollection().Where(PollAnswers.Columns.QuestionId, PollId).Load();
				
			}
			
			public System.Data.PollReactionsCollection PollReactionsRecords()
			{
				
				return new Data.PollReactionsCollection().Where(PollReactions.Columns.PollId, PollId).Load();
				
			}
			
			#endregion
			
			
			
			
			
			
			
			//no foreign key tables defined (0)
			
			
			
			//no ManyToMany tables defined (0)
			
			
			#region ObjectDataSource support
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			public static void Insert(Guid varPollId, string varQuestion, DateTime varCreationDate, Nullable<Guid> varMemberid)
			{
				PollQuestions item = new PollQuestions();
				
				item.PollId = varPollId;
				
				item.Question = varQuestion;
				
				item.CreationDate = varCreationDate;
				
				item.Memberid = varMemberid;
				
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
			public static void Update(Guid varPollId, string varQuestion, DateTime varCreationDate, Nullable<Guid> varMemberid)
			{
				PollQuestions item = new PollQuestions();
				
				item.PollId = varPollId;
				
				item.Question = varQuestion;
				
				item.CreationDate = varCreationDate;
				
				item.Memberid = varMemberid;
				
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
				
				public static string PollId = "PollId";
				
				public static string Question = "Question";
				
				public static string CreationDate = "CreationDate";
				
				public static string Memberid = "memberid";
				
			}
			#endregion
		}
	}
	
}
