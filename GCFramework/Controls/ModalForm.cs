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
using System.Text;
using System.Drawing.Design;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			[ToolboxData("<{0}:ModalForm runat=server></{0}:ModalForm>")]public class ModalForm : Panel
			{
				
				#region Class Level Variables
				
				//Control property variables.
				private string _title = "";
				private string _contentCss = "";
				private string _headerCss = "";
				private string _closeImageUrl = "";
				private string _backgroundCss = "";
				private bool _dropShadow = false;
				private string _okControlId = "";
				private string _cancelControlId = "";
				private string _onOkScript = "";
				private string _activateControlId = "";
				
				//ModalPopup extender associated with this panel.
				private ModalPopupExtender extender = null;
				
				private Panel header = null;
				private const string DragInclude = "Drag";
				private const string ModalFormInclude = "ModalForm";
				
				#endregion // Class Level Variables
				
				#region Constructor
				
				public ModalForm()
				{
				}
				
				#endregion // Constructor
				
				#region Properties
				
				[Bindable(true), Category("Header Appearance"), DefaultValue(""), Themeable(false), Description("The title in the header of the form.")]public string Title
				{
					get
					{
						return _title;
					}
					set
					{
						_title = value;
					}
				}
				
				[Bindable(true), Category("Header Appearance"), DefaultValue(""), Editor(typeof(ImageUrlEditor), typeof(UITypeEditor)), Description("The image to use as the close icon in the header.")]public string CloseImageUrl
				{
					get
					{
						return _closeImageUrl;
					}
					set
					{
						_closeImageUrl = value;
					}
				}
				
				[Bindable(true), Category("Appearance"), DefaultValue(""), Description("Stylesheet class to apply to the content area.")]public string ContentCss
				{
					get
					{
						return _contentCss;
					}
					set
					{
						_contentCss = value;
					}
				}
				
				[Bindable(true), Category("Appearance"), DefaultValue(""), Description("Stylesheet class to apply to the header area.")]public string HeaderCss
				{
					get
					{
						return _headerCss;
					}
					set
					{
						_headerCss = value;
					}
				}
				
				[Bindable(true), Category("Appearance"), DefaultValue(""), Description("The stylesheet that describes that background that will fill the screen when the modal form is loaded.")]public string BackgroundCss
				{
					get
					{
						return _backgroundCss;
					}
					set
					{
						_backgroundCss = value;
					}
				}
				
				[Bindable(true), Category("Appearance"), DefaultValue(false), Description("Should a drop shadow appear behind the modal form.")]public bool DropShadow
				{
					get
					{
						return DropShadow;
					}
					set
					{
						_dropShadow = value;
					}
				}
				
				[Bindable(true), Category("Behavior"), DefaultValue(""), Description("The ID of the control that will signal a save of the modal form.")]public string OkControlID
				{
					get
					{
						return _okControlId;
					}
					set
					{
						_okControlId = value;
					}
				}
				
				[Bindable(true), Category("Behavior"), DefaultValue(""), Description("The ID of the control that will cancel out of the modal form.")]public string CancelControlID
				{
					get
					{
						return _cancelControlId;
					}
					set
					{
						_cancelControlId = value;
					}
				}
				
				[Bindable(true), Category("Behavior"), DefaultValue(""), Description("The client side javascript function that should execute when the modal form is saved.")]public string OnOkScript
				{
					get
					{
						return _onOkScript;
					}
					set
					{
						_onOkScript = value;
					}
				}
				
				[Bindable(true), Category("Behavior"), DefaultValue(""), Description("The ID of the control that will activate the modal form.")]public string ActivateControlID
				{
					get
					{
						return _activateControlId;
					}
					set
					{
						_activateControlId = value;
					}
				}
				
				#endregion // Properties
				
				#region Methods
				
				/// <summary>
				/// Force the creation of child controls now so that the ModalPopup extender is created on init.
				/// </summary>
				/// <param name="e"></param>
				protected override void OnInit(EventArgs e)
				{
					EnsureChildControls();
					
					base.OnInit(e);
				}
				/// <summary>
				/// Create the ModalPopup extender and add it as a child of this control.
				/// </summary>
				protected override void CreateChildControls()
				{
					base.CreateChildControls();
					
					// Create the extender
					extender = new ModalPopupExtender();
					extender.ID = ID + "_ModalPopupExtender";
					
					//Pass on ModalPopup extender properties of this control to the extender.
					extender.TargetControlID = ActivateControlID;
					extender.BackgroundCssClass = BackgroundCss;
					extender.CancelControlID = CancelControlID;
					extender.OkControlID = OkControlID;
					extender.DropShadow = DropShadow;
					extender.OnOkScript = OnOkScript;
					extender.PopupControlID = ID;
					
					if (! this.DesignMode)
					{
						Controls.AddAt(0, extender);
					}
				}
				
				
				/// <summary>
				/// Register javascript needed.
				/// </summary>
				/// <param name="e"></param>
				protected override void OnPreRender(EventArgs e)
				{
					Page.ClientScript.RegisterClientScriptInclude(DragInclude, Page.ClientScript.GetWebResourceUrl(this.GetType(), "ACSGhana.Web.Framework.Drag.js"));
					Page.ClientScript.RegisterClientScriptInclude(ModalFormInclude, Page.ClientScript.GetWebResourceUrl(this.GetType(), "ACSGhana.Web.Framework.ModalForm.js"));
					
					//Create the header and content panels and add them to the base panel.
					header = CreateContainerControls();
					
					base.OnPreRender(e);
					
				}
				
				
				/// <summary>
				/// Render HTML for control.
				/// </summary>
				/// <param name="output"></param>
				protected override void Render(HtmlTextWriter output)
				{
					base.Render(output);
					
					//Include the script to make the modal form draggable.
					string script = string.Format("<script type=\'text/javascript\' language=\'javascript\'>" + "<!--" + Constants.vbLf + "MakeDraggableHandle(document.getElementById(\"{0}\"), \"{1}\");" + Constants.vbLf + "-->" + Constants.vbLf + "</script>" + Constants.vbLf, header.ClientID, this.ClientID);
					
					output.Write(script);
				}
				
				/// <summary>
				/// Create the header and content panels and place the existing child controls in the content panel.
				/// </summary>
				private Panel CreateContainerControls()
				{
					Panel header = new Panel();
					header.ID = "Header";
					header.CssClass = this.HeaderCss;
					
					Panel title = new Panel();
					
					//Add title text to title panel.
					LiteralControl titleText = new LiteralControl(this.Title);
					title.Controls.Add(titleText);
					
					//Place title on left of header panel.
					title.Style.Add("float", "left");
					
					//Only create a close image panel if a close image and cancel control id have been specified.
					HtmlImage imageButton = null;
					if (CloseImageUrl != "" && CancelControlID != "")
					{
						Panel closeImage = new Panel();
						
						//Add image to image panel.
						imageButton = new HtmlImage();
						imageButton.ID = "button";
						imageButton.Border = 0;
						imageButton.Src = GetCloseImageUrl();
						imageButton.Style.Add("cursor", "pointer");
						closeImage.Controls.Add(imageButton);
						
						//Place image on right of header panel.
						closeImage.Style.Add("float", "right");
						header.Controls.Add(closeImage);
					}
					
					header.Controls.Add(title);
					
					Panel content = new Panel();
					content.CssClass = this.ContentCss;
					
					//Move all the children of the base panel to the children of the content panel.
					//Note as a child control is added to content, it is automatically removed from the base panel.
					int numChildren = this.Controls.Count;
					int i = 0;
					while (i < numChildren)
					{
						content.Controls.Add(this.Controls[0]);
						i++;
					}
					
					//Clear all the children of the base panel and add the header and content panels.
					Controls.Clear();
					Controls.Add(header);
					Controls.Add(content);
					
					//Now that all controls are in their proper places, create the cancel javascript for the CancelControlId.
					if (CloseImageUrl != "" && CancelControlID != "")
					{
						imageButton.Attributes.Add("onClick", GetCloseScript());
					}
					
					//Make sure this panel is hidden to begin.
					this.Style.Add("display", "none");
					
					return header;
				}
				
				
				/// <summary>
				/// Get the javascript to close the modal form.
				/// </summary>
				/// <returns>
				/// The javascript which forces a click on the cancel control.
				/// </returns>
				private string GetCloseScript()
				{
					System.Web.UI.Control cancelControl = GetControl(this, CancelControlID);
					if (cancelControl != null)
					{
						return string.Format("ModalFormClose(\"{0}\")", cancelControl.ClientID); //strScript
					}
					else
					{
						return "";
					}
				}
				
				/// <summary>
				/// Perform a recursive search for the indicated control.
				/// </summary>
				/// <param name="root">
				/// The control whose children should be searched for the indicated control.
				/// </param>
				/// <param name="id">
				/// The id of the control to get.
				/// </param>
				/// <returns>
				/// The control with the indicated id.
				/// </returns>
				private System.Web.UI.Control GetControl(System.Web.UI.Control root, string id)
				{
					if (root.ID == id)
					{
						return root;
					}
					
					foreach (System.Web.UI.Control c in root.Controls)
					{
						System.Web.UI.Control t = GetControl(c, id);
						if (t != null)
						{
							return t;
						}
					}
					
					return null;
				}
				
				
				/// <summary>
				/// Get the url for the close image, taking into account any active theme.
				/// </summary>
				/// <returns>
				/// The url for the close image, taking into account any active theme.
				/// </returns>
				private string GetCloseImageUrl()
				{
					string image = CloseImageUrl;
					
					//Look for image in theme specific Images directory if a theme is in use.
					if (Page.Theme != "")
					{
						//Check to see if this file exists.
						if (File.Exists(Page.Request.MapPath("~") + "/App_Themes/" + Page.Theme + "/" + image))
						{
							image = "App_Themes/" + Page.Theme + "/" + image;
						}
					}
					
					return image;
				}
				
				#endregion // Methods
			}
			
		}
	}
	
	
}
