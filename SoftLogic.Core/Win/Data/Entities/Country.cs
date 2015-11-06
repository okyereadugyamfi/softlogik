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
	/// Strongly-typed collection for the Country class.
	/// </summary>
	[Serializable]
	public partial class CountryCollection : ActiveList<Country, CountryCollection> 
	{	   
		public CountryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SLCountry table.
	/// </summary>
	[Serializable]
	public partial class Country : ActiveRecord<Country>
	{
		#region .ctors and Default Settings
		
		public Country()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Country(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Country(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Country(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SLCountry", TableType.Table, DataService.GetInstance("WinSubSonicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCountryID = new TableSchema.TableColumn(schema);
				colvarCountryID.ColumnName = "CountryID";
				colvarCountryID.DataType = DbType.Int32;
				colvarCountryID.MaxLength = 0;
				colvarCountryID.AutoIncrement = true;
				colvarCountryID.IsNullable = false;
				colvarCountryID.IsPrimaryKey = true;
				colvarCountryID.IsForeignKey = false;
				colvarCountryID.IsReadOnly = false;
				colvarCountryID.DefaultSetting = @"";
				colvarCountryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryID);
				
				TableSchema.TableColumn colvarCountryCode = new TableSchema.TableColumn(schema);
				colvarCountryCode.ColumnName = "CountryCode";
				colvarCountryCode.DataType = DbType.AnsiStringFixedLength;
				colvarCountryCode.MaxLength = 2;
				colvarCountryCode.AutoIncrement = false;
				colvarCountryCode.IsNullable = false;
				colvarCountryCode.IsPrimaryKey = false;
				colvarCountryCode.IsForeignKey = false;
				colvarCountryCode.IsReadOnly = false;
				colvarCountryCode.DefaultSetting = @"";
				colvarCountryCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryCode);
				
				TableSchema.TableColumn colvarCountryX = new TableSchema.TableColumn(schema);
				colvarCountryX.ColumnName = "Country";
				colvarCountryX.DataType = DbType.String;
				colvarCountryX.MaxLength = 255;
				colvarCountryX.AutoIncrement = false;
				colvarCountryX.IsNullable = false;
				colvarCountryX.IsPrimaryKey = false;
				colvarCountryX.IsForeignKey = false;
				colvarCountryX.IsReadOnly = false;
				colvarCountryX.DefaultSetting = @"";
				colvarCountryX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryX);
				
				TableSchema.TableColumn colvarCurrencyCode = new TableSchema.TableColumn(schema);
				colvarCurrencyCode.ColumnName = "CurrencyCode";
				colvarCurrencyCode.DataType = DbType.AnsiStringFixedLength;
				colvarCurrencyCode.MaxLength = 3;
				colvarCurrencyCode.AutoIncrement = false;
				colvarCurrencyCode.IsNullable = true;
				colvarCurrencyCode.IsPrimaryKey = false;
				colvarCurrencyCode.IsForeignKey = false;
				colvarCurrencyCode.IsReadOnly = false;
				colvarCurrencyCode.DefaultSetting = @"";
				colvarCurrencyCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyCode);
				
				TableSchema.TableColumn colvarCurrency = new TableSchema.TableColumn(schema);
				colvarCurrency.ColumnName = "Currency";
				colvarCurrency.DataType = DbType.String;
				colvarCurrency.MaxLength = 255;
				colvarCurrency.AutoIncrement = false;
				colvarCurrency.IsNullable = true;
				colvarCurrency.IsPrimaryKey = false;
				colvarCurrency.IsForeignKey = false;
				colvarCurrency.IsReadOnly = false;
				colvarCurrency.DefaultSetting = @"";
				colvarCurrency.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrency);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["WinSubSonicProvider"].AddSchema("SLCountry",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CountryID")]
		public int CountryID 
		{
			get { return GetColumnValue<int>("CountryID"); }

			set { SetColumnValue("CountryID", value); }

		}

		  
		[XmlAttribute("CountryCode")]
		public string CountryCode 
		{
			get { return GetColumnValue<string>("CountryCode"); }

			set { SetColumnValue("CountryCode", value); }

		}

		  
		[XmlAttribute("CountryX")]
		public string CountryX 
		{
			get { return GetColumnValue<string>("Country"); }

			set { SetColumnValue("Country", value); }

		}

		  
		[XmlAttribute("CurrencyCode")]
		public string CurrencyCode 
		{
			get { return GetColumnValue<string>("CurrencyCode"); }

			set { SetColumnValue("CurrencyCode", value); }

		}

		  
		[XmlAttribute("Currency")]
		public string Currency 
		{
			get { return GetColumnValue<string>("Currency"); }

			set { SetColumnValue("Currency", value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCountryCode,string varCountryX,string varCurrencyCode,string varCurrency)
		{
			Country item = new Country();
			
			item.CountryCode = varCountryCode;
			
			item.CountryX = varCountryX;
			
			item.CurrencyCode = varCurrencyCode;
			
			item.Currency = varCurrency;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCountryID,string varCountryCode,string varCountryX,string varCurrencyCode,string varCurrency)
		{
			Country item = new Country();
			
				item.CountryID = varCountryID;
				
				item.CountryCode = varCountryCode;
				
				item.CountryX = varCountryX;
				
				item.CurrencyCode = varCurrencyCode;
				
				item.Currency = varCurrency;
				
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
			 public static string CountryID = @"CountryID";
			 public static string CountryCode = @"CountryCode";
			 public static string CountryX = @"Country";
			 public static string CurrencyCode = @"CurrencyCode";
			 public static string Currency = @"Currency";
						
		}

		#endregion
	}

}

