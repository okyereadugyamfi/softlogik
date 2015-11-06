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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string AutoCode = @"SLAutoCode";
        
		public static string Country = @"SLCountry";
        
		public static string Master = @"SLMaster";
        
		public static string MasterGroup = @"SLMasterGroup";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string WinSubSonicProvider = @"WinSubSonicProvider";
    
}

#endregion
