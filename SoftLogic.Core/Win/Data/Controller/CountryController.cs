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
    /// Controller class for SLCountry
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CountryController
    {
        // Preload our schema..
        Country thisSchemaLoad = new Country();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CountryCollection FetchAll()
        {
            CountryCollection coll = new CountryCollection();
            Query qry = new Query(Country.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryCollection FetchByID(object CountryID)
        {
            CountryCollection coll = new CountryCollection().Where("CountryID", CountryID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryCollection FetchByQuery(Query qry)
        {
            CountryCollection coll = new CountryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CountryID)
        {
            return (Country.Delete(CountryID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CountryID)
        {
            return (Country.Destroy(CountryID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CountryCode,string CountryX,string CurrencyCode,string Currency)
	    {
		    Country item = new Country();
		    
            item.CountryCode = CountryCode;
            
            item.CountryX = CountryX;
            
            item.CurrencyCode = CurrencyCode;
            
            item.Currency = Currency;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CountryID,string CountryCode,string CountryX,string CurrencyCode,string Currency)
	    {
		    Country item = new Country();
		    
				item.CountryID = CountryID;
				
				item.CountryCode = CountryCode;
				
				item.CountryX = CountryX;
				
				item.CurrencyCode = CurrencyCode;
				
				item.Currency = Currency;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

