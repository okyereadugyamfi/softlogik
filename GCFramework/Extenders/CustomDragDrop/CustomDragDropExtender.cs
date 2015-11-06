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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using AjaxControlToolkit;

// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.



[assembly:System.Web.UI.WebResource("ACSGhana.Web.Framework.CustomDragDropBehavior.js", "text/javascript")]

namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			[Designer(typeof(CustomDragDropDesigner)), ClientScriptResource("ACSGhana.Web.Framework.CustomDragDropBehavior", "ACSGhana.Web.Framework.CustomDragDropBehavior.js"), TargetControlType(typeof(WebControl)), RequiredScript(typeof(DragDropScripts))]public class CustomDragDropExtender : ExtenderControlBase
			{
				
				// TODO: Add your property accessors here.
				//
				[ExtenderControlProperty()]public string DragItemClass
				{
					get
					{
						return GetPropertyValue<string>("DragItemClass", string.Empty);
					}
					set
					{
						SetPropertyValue("DragItemClass", value);
					}
				}
				
				[ExtenderControlProperty()]public string DragItemHandleClass
				{
					get
					{
						return GetPropertyValue<string>("DragItemHandleClass", string.Empty);
					}
					set
					{
						SetPropertyValue("DragItemHandleClass", value);
					}
				}
				
				[ExtenderControlProperty(), IDReferenceProperty(typeof(WebControl))]public string DropCueID
				{
					get
					{
						return GetPropertyValue<string>("DropCueID", string.Empty);
					}
					set
					{
						SetPropertyValue("DropCueID", value);
					}
				}
				
				[ExtenderControlProperty()]public string DropCallbackFunction
				{
					get
					{
						return GetPropertyValue<string>("DropCallbackFunction", string.Empty);
					}
					set
					{
						SetPropertyValue("DropCallbackFunction", value);
					}
				}
				
			}
		}
	}
	
}
