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
using AjaxControlToolkit;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;


[assembly:System.Web.UI.WebResource("ACSGhana.Web.Framework.CustomFloatingBehavior.js", "text/javascript")]

namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			[Designer(typeof(CustomFloatingBehaviorDesigner)), ClientScriptResource("ACSGhana.Web.Framework.CustomFloatingBehavior", "ACSGhana.Web.Framework.CustomFloatingBehavior.js"), TargetControlType(typeof(WebControl)), RequiredScript(typeof(DragDropScripts))]public class CustomFloatingBehaviorExtender : ExtenderControlBase
			{
				
				[ExtenderControlProperty(), IDReferenceProperty(typeof(WebControl))]public string DragHandleID
				{
					get
					{
						return GetPropertyValue<string>("DragHandleID", string.Empty);
					}
					set
					{
						SetPropertyValue("DragHandleID", value);
					}
				}
			}
		}
	}
	
}
