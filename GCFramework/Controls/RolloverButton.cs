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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			
			[ToolboxData("<{0}:RolloverButton runat=server></{0}:RolloverButton>")]public class RolloverButton : WebControl
			{
				
				
				#region Declarations
				//create private member variables used by this control
				private string mHoverImage = "";
				private string mBackgroundImage = "";
				private string mClickedImage = "";
				private string mJavaScriptCall;
				private string mText = "RolloverButton";
				
				private System.Web.UI.HtmlControls.HtmlInputImage imgButton;
				#endregion
				
				
				#region Methods
				public RolloverButton()
				{
					//initialize new controls with a default height and width
					this.Width = 48;
					this.Height = 24;
				}
				
				private void RolloverButton_Load(object sender, System.EventArgs e)
				{
					EnsureChildControls();
				}
				#endregion
				
				
				#region Properties
				// create public properties for member variables
				[Category("Behavior")][Browsable(true)][Description("Get or Set Image to display when Mouse hovers over the Button.")][Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]public string HoverImage
				{
					get
					{
						return mHoverImage;
					}
					set
					{
						mHoverImage = value;
					}
				}
				[Category("Behavior")][Browsable(true)][Description("Get or Set Image to display when Mouse leaves the Button.")][Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]public string BackgroundImage
				{
					get
					{
						return mBackgroundImage;
					}
					set
					{
						mBackgroundImage = value;
					}
				}
				[Category("Behavior")][Browsable(true)][Description("Get or Set Image to display when Mouse is down on the Button.")][Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]public string ClickedImage
				{
					get
					{
						return mClickedImage;
					}
					set
					{
						mClickedImage = value;
					}
				}
				[Category("Behavior")][Browsable(true)][Description("Gets or Sets the Text to display on the button.")]public string Text
				{
					get
					{
						return mText;
					}
					set
					{
						mText = value;
					}
				}
				
				[Category("JavaScript")][Browsable(true)][Description("Set javascript string for onclick event.")]public string JavaScriptCall
				{
					get
					{
						return mJavaScriptCall;
					}
					set
					{
						mJavaScriptCall = value;
					}
				}
				#endregion
				#region Rendering
				protected override void CreateChildControls()
				{
					imgButton = new System.Web.UI.HtmlControls.HtmlInputImage();
					imgButton.Src = BackgroundImage.ToString();
					
					imgButton.Attributes.Add("onmouseover", "this.src=\'" + HoverImage.ToString() + "\';");
					imgButton.Attributes.Add("onmouseout", "this.src=\'" + BackgroundImage.ToString() + "\';");
					imgButton.Attributes.Add("onmousedown", "this.src=\'" + ClickedImage.ToString() + "\';");
					if (string.IsNullOrEmpty(JavaScriptCall) == false)
					{
						imgButton.Attributes.Add("onclick", JavaScriptCall.ToString());
					}
					
					Controls.Add(imgButton);
				}
				#endregion
			}
			
			/// <summary>
			/// Provides a rollover button, but with client click support for navigation.
			/// </summary>
			/// <remarks></remarks>
			public class RolloverLink : System.Web.UI.WebControls.Button
			{
				
				
				protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
				{
					base.AddAttributesToRender(writer);
					writer.AddAttribute("onmouseover", "this.className=\'buttonsmall-ovr\'");
					writer.AddAttribute("onmouseout", "this.className=\'buttonsmall\'");
					writer.AddAttribute("class", "buttonsmall");
					
					string navurl = NavigateURL;
					if (base.OnClientClick == "" && navurl != "")
					{
						writer.AddAttribute("onclick", "window.navigate(\'" + navurl + "\');");
					}
					
				}
				
				protected override void OnClick(System.EventArgs e)
				{
					base.OnClick(e);
					string navurl = NavigateURL;
					if (navurl != "")
					{
						Page.Response.Redirect(NavigateURL);
					}
				}
				
				public string NavigateURL
				{
					get
					{
						object u = ViewState["NavigateURL"];
						if (u == null)
						{
							return "";
						}
						else
						{
							return u.ToString();
						}
					}
					set
					{
						ViewState["NavigateURL"] = value;
					}
				}
			}
		}
	}
}
