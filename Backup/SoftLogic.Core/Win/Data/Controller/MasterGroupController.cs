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
    /// Controller class for SLMasterGroup
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MasterGroupController
    {
        // Preload our schema..
        MasterGroup thisSchemaLoad = new MasterGroup();
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
        public MasterGroupCollection FetchAll()
        {
            MasterGroupCollection coll = new MasterGroupCollection();
            Query qry = new Query(MasterGroup.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MasterGroupCollection FetchByID(object GroupID)
        {
            MasterGroupCollection coll = new MasterGroupCollection().Where("GroupID", GroupID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MasterGroupCollection FetchByQuery(Query qry)
        {
            MasterGroupCollection coll = new MasterGroupCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object GroupID)
        {
            return (MasterGroup.Delete(GroupID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object GroupID)
        {
            return (MasterGroup.Destroy(GroupID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string GroupID,string GroupName,DateTime? CreatedOn,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    MasterGroup item = new MasterGroup();
		    
            item.GroupID = GroupID;
            
            item.GroupName = GroupName;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedOn = ModifiedOn;
            
            item.ModifiedBy = ModifiedBy;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string GroupID,string GroupName,DateTime? CreatedOn,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    MasterGroup item = new MasterGroup();
		    
				item.GroupID = GroupID;
				
				item.GroupName = GroupName;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedOn = ModifiedOn;
				
				item.ModifiedBy = ModifiedBy;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

