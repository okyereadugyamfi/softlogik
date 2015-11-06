using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace SoftLogik.Win.Data
{
	/// <summary>
	/// Strongly-typed collection for the Master class.
	/// </summary>
	[Serializable]
	public partial class MasterCollection : ActiveList<Master, MasterCollection> 
	{	   
		public MasterCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SLMaster table.
	/// </summary>
	[Serializable]
	public partial class Master : ActiveRecord<Master>
	{
		#region .ctors and Default Settings
		
		public Master()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Master(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Master(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Master(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("SLMaster", TableType.Table, DataService.GetInstance("WinSubSonicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMasterID = new TableSchema.TableColumn(schema);
				colvarMasterID.ColumnName = "MasterID";
				colvarMasterID.DataType = DbType.Int64;
				colvarMasterID.MaxLength = 0;
				colvarMasterID.AutoIncrement = true;
				colvarMasterID.IsNullable = false;
				colvarMasterID.IsPrimaryKey = true;
				colvarMasterID.IsForeignKey = false;
				colvarMasterID.IsReadOnly = false;
				colvarMasterID.DefaultSetting = @"";
				colvarMasterID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMasterID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarNote = new TableSchema.TableColumn(schema);
				colvarNote.ColumnName = "Note";
				colvarNote.DataType = DbType.String;
				colvarNote.MaxLength = 500;
				colvarNote.AutoIncrement = false;
				colvarNote.IsNullable = true;
				colvarNote.IsPrimaryKey = false;
				colvarNote.IsForeignKey = false;
				colvarNote.IsReadOnly = false;
				colvarNote.DefaultSetting = @"";
				colvarNote.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNote);
				
				TableSchema.TableColumn colvarGroupID = new TableSchema.TableColumn(schema);
				colvarGroupID.ColumnName = "GroupID";
				colvarGroupID.DataType = DbType.String;
				colvarGroupID.MaxLength = 5;
				colvarGroupID.AutoIncrement = false;
				colvarGroupID.IsNullable = true;
				colvarGroupID.IsPrimaryKey = false;
				colvarGroupID.IsForeignKey = true;
				colvarGroupID.IsReadOnly = false;
				colvarGroupID.DefaultSetting = @"";
				
					colvarGroupID.ForeignKeyTableName = "SLMasterGroup";
				schema.Columns.Add(colvarGroupID);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["WinSubSonicProvider"].AddSchema("SLMaster",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("MasterID")]
		public long MasterID 
		{
			get { return GetColumnValue<long>("MasterID"); }

			set { SetColumnValue("MasterID", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Note")]
		public string Note 
		{
			get { return GetColumnValue<string>("Note"); }

			set { SetColumnValue("Note", value); }

		}

		  
		[XmlAttribute("GroupID")]
		public string GroupID 
		{
			get { return GetColumnValue<string>("GroupID"); }

			set { SetColumnValue("GroupID", value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>("CreatedOn"); }

			set { SetColumnValue("CreatedOn", value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>("ModifiedOn"); }

			set { SetColumnValue("ModifiedOn", value); }

		}

		  
		[XmlAttribute("ModifiedBy")]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>("ModifiedBy"); }

			set { SetColumnValue("ModifiedBy", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a MasterGroup ActiveRecord object related to this Master
		/// 
		/// </summary>
		public SoftLogik.Win.Data.MasterGroup MasterGroup
		{
			get { return SoftLogik.Win.Data.MasterGroup.FetchByID(this.GroupID); }

			set { SetColumnValue("GroupID", value.GroupID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varNote,string varGroupID,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			Master item = new Master();
			
			item.Name = varName;
			
			item.Note = varNote;
			
			item.GroupID = varGroupID;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varMasterID,string varName,string varNote,string varGroupID,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			Master item = new Master();
			
				item.MasterID = varMasterID;
				
				item.Name = varName;
				
				item.Note = varNote;
				
				item.GroupID = varGroupID;
				
				item.CreatedOn = varCreatedOn;
				
				item.ModifiedOn = varModifiedOn;
				
				item.ModifiedBy = varModifiedBy;
				
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string MasterID = @"MasterID";
			 public static string Name = @"Name";
			 public static string Note = @"Note";
			 public static string GroupID = @"GroupID";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

