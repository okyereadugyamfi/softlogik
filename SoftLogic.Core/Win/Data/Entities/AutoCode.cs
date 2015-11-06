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
	/// Strongly-typed collection for the AutoCode class.
	/// </summary>
	[Serializable]
	public partial class AutoCodeCollection : ActiveList<AutoCode, AutoCodeCollection> 
	{	   
		public AutoCodeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SLAutoCode table.
	/// </summary>
	[Serializable]
	public partial class AutoCode : ActiveRecord<AutoCode>
	{
		#region .ctors and Default Settings
		
		public AutoCode()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AutoCode(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AutoCode(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AutoCode(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SLAutoCode", TableType.Table, DataService.GetInstance("WinSubSonicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodePrefix = new TableSchema.TableColumn(schema);
				colvarCodePrefix.ColumnName = "CodePrefix";
				colvarCodePrefix.DataType = DbType.String;
				colvarCodePrefix.MaxLength = 50;
				colvarCodePrefix.AutoIncrement = false;
				colvarCodePrefix.IsNullable = false;
				colvarCodePrefix.IsPrimaryKey = true;
				colvarCodePrefix.IsForeignKey = false;
				colvarCodePrefix.IsReadOnly = false;
				colvarCodePrefix.DefaultSetting = @"";
				colvarCodePrefix.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodePrefix);
				
				TableSchema.TableColumn colvarCodeFormat = new TableSchema.TableColumn(schema);
				colvarCodeFormat.ColumnName = "CodeFormat";
				colvarCodeFormat.DataType = DbType.String;
				colvarCodeFormat.MaxLength = 50;
				colvarCodeFormat.AutoIncrement = false;
				colvarCodeFormat.IsNullable = false;
				colvarCodeFormat.IsPrimaryKey = true;
				colvarCodeFormat.IsForeignKey = false;
				colvarCodeFormat.IsReadOnly = false;
				colvarCodeFormat.DefaultSetting = @"";
				colvarCodeFormat.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodeFormat);
				
				TableSchema.TableColumn colvarLastCodeDate = new TableSchema.TableColumn(schema);
				colvarLastCodeDate.ColumnName = "LastCodeDate";
				colvarLastCodeDate.DataType = DbType.DateTime;
				colvarLastCodeDate.MaxLength = 0;
				colvarLastCodeDate.AutoIncrement = false;
				colvarLastCodeDate.IsNullable = false;
				colvarLastCodeDate.IsPrimaryKey = true;
				colvarLastCodeDate.IsForeignKey = false;
				colvarLastCodeDate.IsReadOnly = false;
				colvarLastCodeDate.DefaultSetting = @"";
				colvarLastCodeDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastCodeDate);
				
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
				DataService.Providers["WinSubSonicProvider"].AddSchema("SLAutoCode",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CodePrefix")]
		public string CodePrefix 
		{
			get { return GetColumnValue<string>("CodePrefix"); }

			set { SetColumnValue("CodePrefix", value); }

		}

		  
		[XmlAttribute("CodeFormat")]
		public string CodeFormat 
		{
			get { return GetColumnValue<string>("CodeFormat"); }

			set { SetColumnValue("CodeFormat", value); }

		}

		  
		[XmlAttribute("LastCodeDate")]
		public DateTime LastCodeDate 
		{
			get { return GetColumnValue<DateTime>("LastCodeDate"); }

			set { SetColumnValue("LastCodeDate", value); }

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
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodePrefix,string varCodeFormat,DateTime varLastCodeDate,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			AutoCode item = new AutoCode();
			
			item.CodePrefix = varCodePrefix;
			
			item.CodeFormat = varCodeFormat;
			
			item.LastCodeDate = varLastCodeDate;
			
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
		public static void Update(string varCodePrefix,string varCodeFormat,DateTime varLastCodeDate,DateTime? varCreatedOn,DateTime? varModifiedOn,string varModifiedBy)
		{
			AutoCode item = new AutoCode();
			
				item.CodePrefix = varCodePrefix;
				
				item.CodeFormat = varCodeFormat;
				
				item.LastCodeDate = varLastCodeDate;
				
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
			 public static string CodePrefix = @"CodePrefix";
			 public static string CodeFormat = @"CodeFormat";
			 public static string LastCodeDate = @"LastCodeDate";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

