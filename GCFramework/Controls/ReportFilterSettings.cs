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
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			
			[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), Designer(typeof(ReportFilterSettingsDesigner)), DefaultProperty("Title"), ToolboxData("<{0}:ReportFilterSettings runat=server></{0}:ReportFilterSettings>")]public class ReportFilterSettings : CompositeControl
			{
				
				
				private ITemplate _ContentTemplate;
				private TemplateOwner _owner;
				
				[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]public TemplateOwner Owner
				{
					get
					{
						return _owner;
					}
				}
				
				[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(typeof(ITemplate), ""), Description("Content of ReportOption filter template"), TemplateContainer(typeof(ReportFilterSettings))]public virtual ITemplate ContentTemplate
				{
					get
					{
						return _ContentTemplate;
					}
					set
					{
						_ContentTemplate = value;
					}
				}
				
				[Bindable(true), Category("Data"), DefaultValue(""), Description("Title"), Localizable(true)]public string Title
				{
					get
					{
						string s = ViewState["Title"].ToString();
						if (s == null)
						{
							s = string.Empty;
						}
						return s;
					}
					set
					{
						ViewState["Title"] = value;
					}
				}
				
				protected override void CreateChildControls()
				{
					Controls.Clear();
					_owner = new TemplateOwner();
					
					ITemplate temp = _ContentTemplate;
					if (temp == null)
					{
						temp = new DefaultContentTemplate();
					}
					
					temp.InstantiateIn(_owner);
					this.Controls.Add(_owner);
				}
				
				public override void DataBind()
				{
					CreateChildControls();
					ChildControlsCreated = true;
					base.DataBind();
				}
				
			}
			
			[ToolboxItem(false)]public class TemplateOwner : WebControl
			{
				
			}
			
			#region DefaultTemplate
			sealed public class DefaultContentTemplate : ITemplate
			{
				
				
				public void InstantiateIn(System.Web.UI.Control owner)
				{
					LiteralControl emptyDataLabel = new LiteralControl("There are no report filters defined");
					owner.Controls.Add(emptyDataLabel);
				}
				
			}
			#endregion
			
			
			public class ReportFilterSettingsDesigner : ControlDesigner
			{
				
				
				public override void Initialize(IComponent Component)
				{
					base.Initialize(Component);
					SetViewFlags(ViewFlags.TemplateEditing, true);
				}
				
				public override string GetDesignTimeHtml()
				{
					return "<span>No Report Settings Defined</span>";
				}
				
				public override TemplateGroupCollection TemplateGroups
				{
					get
					{
						TemplateGroupCollection collection = new TemplateGroupCollection();
						TemplateGroup group;
						TemplateDefinition template;
						ReportFilterSettings control;
						
						control = (ReportFilterSettings) Component;
						group = new TemplateGroup("Item");
						template = new TemplateDefinition(this, "ContentTemplate", control, "ContentTemplate", true);
						group.AddTemplateDefinition(template);
						collection.Add(group);
						return collection;
					}
				}
			}
		}
	}
	
}
