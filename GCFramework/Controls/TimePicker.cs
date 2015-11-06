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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			public class TimePicker : WebControl, INamingContainer
			{
				
				
				private System.Web.UI.WebControls.TextBox _innerTbx;
				private System.Web.UI.WebControls.ListBox _innerList;
				private string errorText = null;
				
				public TimePicker() : base(System.Web.UI.HtmlTextWriterTag.Div)
				{
				}
				
				public DateTime SelectedTime
				{
					get
					{
						EnsureChildControls();
						DateTime d;
						try
						{
							d = DateTime.Parse(_innerTbx.Text);
							errorText = null;
						}
						catch
						{
							errorText = "Date needs to be specified as hh:mm";
						}
						return d;
					}
					set
					{
						EnsureChildControls();
						string s = value.ToString("h:mm tt");
						_innerTbx.Text = s;
						ListItem item = _innerList.Items.FindByText(s);
						if (item != null)
						{
							_innerList.SelectedValue = s;
						}
					}
				}
				
				protected override void CreateChildControls()
				{
					base.CreateChildControls();
					_innerTbx = new System.Web.UI.WebControls.TextBox();
					this.Controls.Add(_innerTbx);
					
					_innerList = new System.Web.UI.WebControls.ListBox();
					FillTimes();
					
					Controls.Add(_innerList);
				}
				
				public void FillTimes()
				{
					if (_innerList.Items.Count == 0)
					{
						for (int i = 6; i <= 11; i++)
						{
							_innerList.Items.Add(i + ":00 AM");
							_innerList.Items.Add(i + ":30 AM");
						}
						_innerList.Items.Add("12:00 PM");
						_innerList.Items.Add("12:30 PM");
						for (int i = 1; i <= 11; i++)
						{
							_innerList.Items.Add(i + ":00 PM");
							_innerList.Items.Add(i + ":30 PM");
						}
					}
				}
				
				
				protected override System.Web.UI.HtmlTextWriterTag TagKey
				{
					get
					{
						return HtmlTextWriterTag.Div;
					}
				}
				
				
				protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
				{
					if (this.Width.IsEmpty)
					{
						this.Width = new Unit(150);
					}
					this.Style.Add("display", "inline-table");
					base.AddAttributesToRender(writer);
				}
				private string ImagesPath
				{
					get
					{
						string strSitePath = (HttpContext.Current.Request.ApplicationPath != "/" ? HttpContext.Current.Request.ApplicationPath : "").ToString();
						return strSitePath + "images/";
					}
				}
				protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
				{
					
					string listid = _innerList.ClientID;
					string tbxid = _innerTbx.ClientID;
					
					_innerTbx.Attributes.Add("Align", "AbsMiddle");
					_innerTbx.Width = new Unit(100);
					//_innerTbx.Height = New Unit(16)
					//_innerTbx.Style.Add("padding", "0")
					_innerTbx.RenderControl(writer);
					
					
					
					writer.AddAttribute("Align", "AbsMiddle");
					writer.AddAttribute("src", ImagesPath + "dropdownbtn.gif");
					writer.AddAttribute("onClick", "__timepicker_showpopup(\'" + listid + "\')");
					writer.RenderBeginTag(HtmlTextWriterTag.Img);
					writer.RenderEndTag();
					
					if (errorText != null)
					{
						writer.AddStyleAttribute("color", "red");
						writer.AddStyleAttribute("display", "block");
						writer.RenderBeginTag(HtmlTextWriterTag.Span);
						writer.Write(errorText);
						writer.RenderEndTag();
					}
					
					writer.AddStyleAttribute("position", "relative");
					writer.RenderBeginTag(HtmlTextWriterTag.Div);
					
					_innerList.Width = new Unit(120);
					_innerList.Rows = 8;
					_innerList.Style.Add("position", "absolute");
					_innerList.Style.Add("left", "0px");
					_innerList.Style.Add("display", "none");
					_innerList.Attributes.Add("onfocusout", "__popup_losefocus(this);");
					_innerList.Attributes.Add("onchange", "__timepicker_timechanged(\'" + tbxid + "\',this);");
					
					_innerList.RenderControl(writer);
					
					writer.RenderEndTag();
				}
				
				protected override void OnPreRender(System.EventArgs e)
				{
					base.OnPreRender(e);
					
					commonScript.WritePopupRoutines(Page);
					
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					sb.AppendLine("function __timepicker_showpopup(name)");
					sb.AppendLine("{");
					sb.AppendLine("     if (__popup_panel != null)");
					sb.AppendLine("     {");
					sb.AppendLine("         document.getElementById(__popup_panel).style.display=\'none\';");
					sb.AppendLine("     }");
					sb.AppendLine("     __popup_panel=name;");
					sb.AppendLine("     var panel=document.getElementById(__popup_panel);");
					sb.AppendLine("     panel.style.display=\'block\';");
					sb.AppendLine("     panel.focus();");
					//   sb.AppendLine("     document.onclick=__popup_clear();")
					sb.AppendLine("     window.event.cancelBubble=true;");
					sb.AppendLine("}");
					
					sb.AppendLine("function __timepicker_timechanged(tbxid, selectid)");
					sb.AppendLine("{");
					sb.AppendLine("document.getElementById(tbxid).value=selectid.options[selectid.selectedIndex].text;");
					sb.AppendLine("     if (__popup_panel != null)");
					sb.AppendLine("     {");
					sb.AppendLine("         document.getElementById(__popup_panel).style.display=\'none\';");
					sb.AppendLine("         __popup_panel=null;");
					sb.AppendLine("     }");
					sb.AppendLine("}");
					
					Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", sb.ToString(), true);
					
				}
				
			}
		}
	}
}
