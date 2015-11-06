using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using System.Xml;
using System.Xml.Serialization; 


namespace SoftLogik.Win.Data
{
    public class SimpleSearchCollection : ActiveList<SimpleSearch, SimpleSearchCollection>
    {
    }
    
    public class SimpleSearch : ActiveRecord<SimpleSearch>
    {
        		#region .ctors and Default Settings
		
		public SimpleSearch()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SimpleSearch(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SimpleSearch(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SimpleSearch(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SimpleSearch", TableType.Table, DataService.GetInstance("WinSubSonicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarID = new TableSchema.TableColumn(schema);
				colvarID.ColumnName = "ID";
				colvarID.DataType = DbType.String;
				colvarID.MaxLength = 50;
				colvarID.AutoIncrement = false;
				colvarID.IsNullable = false;
				colvarID.IsPrimaryKey = true;
				colvarID.IsForeignKey = false;
				colvarID.IsReadOnly = false;
				colvarID.DefaultSetting = @"";
				colvarID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 100;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = true;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["WinSubSonicProvider"].AddSchema("SimpleSearch",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ID")]
		public string ID 
		{
			get { return GetColumnValue<string>("ID"); }

			set { SetColumnValue("ID", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		#endregion
		
		
			

		#region Columns Struct
		public struct Columns
		{
			 public static string ID = @"ID";
			 public static string Name = @"Name";
		}

		#endregion

    }


}
