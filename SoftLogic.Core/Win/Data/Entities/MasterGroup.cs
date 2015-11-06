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
	/// Strongly-typed collection for the MasterGroup class.
	/// </summary>
	[Serializable]
	public partial class MasterGroupCollection : ActiveList<MasterGroup, MasterGroupCollection> 
	{	   
		public MasterGroupCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SLMasterGroup table.
	/// </summary>
	[Serializable]
	public partial class MasterGroup : ActiveRecord<MasterGroup>
	{
		#region .ctors and Default Settings
		
		public MasterGroup()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public MasterGroup(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public MasterGroup(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public MasterGroup(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SLMasterGroup", TableType.Table, DataService.GetInstance("WinSubSonicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarGroupID = new TableSchema.TableColumn(schema);
				colvarGroupID.ColumnName = "GroupID";
				colvarGroupID.DataType = DbType.String;
				colvarGroupID.MaxLength = 5;
				colvarGroupID.AutoIncrement = false;
				colvarGroupID.IsNullable = false;
				colvarGroupID.IsPrimaryKey = true;
				colvarGroupID.IsForeignKey = false;
				colvarGroupID.IsReadOnly = false;
				colvarGroupID.DefaultSetting = @"";
				colvarGroupID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupID);
				
				TableSchema.TableColumn colvarGroupName = new TableSchema.TableColumn(schema);
				colvarGroupName.ColumnName = "GroupName";
				colvarGroupName.DataType = DbType.String;
				colvarGroupName.MaxLength = 100;
				colvarGroupName.AutoIncrement = false;
				colvarGroupName.IsNullable = true;
				colvarGroupName.IsPrimaryKey = false;
				colvarGroupName.IsForeignKey = false;
				colvarGroupName.IsReadOnly = false;
				colvarGroupName.DefaultSetting = @"";
				colvarGroupName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupName);
				
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
				DataService.Providers["WinSubSonicProvider"].AddSchema("SLMasterGroup",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("GroupID")]
		public string GroupID 
		{
			get { return GetColumnValue<string>("GroupID"); }

			set { SetColumnValue("GroupID", value); }

		}

		  
		[XmlAttribute("GroupName")]
		public string GroupName 
		{
			get { return GetColumnValue<string>("GroupName"); }

			set { SetColumnValue("GroupName", value); }

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
		
		
		#region PrimaryKey Methods
		
		public SoftLogik.Win.Data.MasterCollection MasterRecords()
		{
			return new SoftLogik.Win.Data.MasterCollection().Where(Master.Columns.GroupID, GroupID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varGroupID,string varGroupName,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			MasterGroup item = new MasterGroup();
			
			item.GroupID = varGroupID;
			
			item.GroupName = varGroupName;
			
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
		public static void Update(string varGroupID,string varGroupName,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			MasterGroup item = new MasterGroup();
			
				item.GroupID = varGroupID;
				
				item.GroupName = varGroupName;
				
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
			 public static string GroupID = @"GroupID";
			 public static string GroupName = @"GroupName";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

