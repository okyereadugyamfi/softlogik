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

namespace ACSGhana.Web.Framework
{
	sealed class DSupport
	{
		
		public static t SafeRead<t>(object source)
		{
			t defaultValue;
			
			
			if (source == null || source == System.DBNull.Value)
			{
				return defaultValue;
			}
			else
			{
				return Convert.ChangeType(source, typeof(t));
			}
		}
		
	}
	
}
