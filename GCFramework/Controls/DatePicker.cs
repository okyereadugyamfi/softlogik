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
			
			sealed class commonScript
			{
				static public void WritePopupRoutines(System.Web.UI.Page Page)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					sb = new System.Text.StringBuilder();
					sb.AppendLine("var __popup_panel;");
					
					sb.AppendLine("function __popup_clear() {");
					sb.AppendLine(" if (__popup_panel != null ) ");
					sb.AppendLine(" {");
					sb.AppendLine("     document.getElementById(__popup_panel).style.display=\'none\';");
					sb.AppendLine("     __popup_panel=null;");
					//    sb.AppendLine("     document.onclick=null;")
					sb.AppendLine(" }");
					sb.AppendLine("}");
					sb.AppendLine("function __popup_losefocus(panel)");
					sb.AppendLine("{");
					sb.AppendLine("     if (!panel.contains(document.activeElement))");
					sb.AppendLine("     {");
					sb.AppendLine("         panel.style.display=\'none\';");
					sb.AppendLine("     }");
					sb.AppendLine("}");
					
					Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "PopupRoutines", sb.ToString(), true);
				}
			}
			
			public class DatePicker : WebControl, INamingContainer
			{
				
				
				private Calendar _innerCal;
				private System.Web.UI.WebControls.TextBox _innerTbx;
				private string errorText = null;
				private bool _panelvisible = false;
				
				public DatePicker() : base(System.Web.UI.HtmlTextWriterTag.Div)
				{
				}
				
				public DateTime SelectedDate
				{
					get
					{
						EnsureChildControls();
						DateTime d;
						try
						{
							d = DateTime.Parse(_innerTbx.Text);
							errorText = null;
							_innerCal.SelectedDate = d;
						}
						catch
						{
							errorText = "Date needs to be specified as mm/dd/yyyy";
						}
						return d;
					}
					set
					{
						EnsureChildControls();
						_innerCal.SelectedDate = value;
						_innerTbx.Text = value.ToShortDateString();
					}
				}
				
				protected override void CreateChildControls()
				{
					base.CreateChildControls();
					_innerTbx = new System.Web.UI.WebControls.TextBox();
					this.Controls.Add(_innerTbx);
					
					_innerCal = new Calendar();
					_innerCal.SelectionChanged += new System.EventHandler(_innerCal_SelectionChanged);
					_innerCal.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(_innerCal_MonthChanged);
					Controls.Add(_innerCal);
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
					_innerTbx.Attributes.Add("Align", "AbsMiddle");
					_innerTbx.Width = new Unit(100);
					//_innerTbx.Height = New Unit(20)
					_innerTbx.RenderControl(writer);
					
					string innerid = this.UniqueID + "_inner";
					
					writer.AddAttribute("Align", "AbsMiddle");
					writer.AddAttribute("src", ImagesPath + "dropdownbtn.gif");
					writer.AddAttribute("onClick", "__datepicker_showpopup(\'" + innerid + "\')");
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
					
					
					writer.AddStyleAttribute("position", "absolute");
					writer.AddStyleAttribute("left", "0px");
					writer.AddStyleAttribute("top", "0px");
					writer.AddStyleAttribute("z-index", "100");
					string panelvisible;
					if (_panelvisible)
					{
						panelvisible = "block";
					}
					else
					{
						panelvisible = "none";
					}
					writer.AddStyleAttribute("display", panelvisible);
					writer.AddStyleAttribute("background-color", "white");
					writer.AddAttribute("id", innerid);
					writer.AddAttribute("onfocusout", "__popup_losefocus(this)");
					writer.RenderBeginTag(HtmlTextWriterTag.Div);
					
					_innerCal.RenderControl(writer);
					
					writer.RenderEndTag();
					writer.RenderEndTag();
				}
				
				protected override void OnPreRender(System.EventArgs e)
				{
					base.OnPreRender(e);
					
					commonScript.WritePopupRoutines(Page);
					
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					
					if (_panelvisible)
					{
						sb.AppendLine("__popup_panel = \'" + this.UniqueID + "_inner\';");
					}
					sb.AppendLine("function __datepicker_showpopup(name)");
					sb.AppendLine("{");
					sb.AppendLine("     if (__popup_panel != null)");
					sb.AppendLine("     {");
					sb.AppendLine("         document.getElementById(__popup_panel).style.display=\'none\';");
					sb.AppendLine("     }");
					sb.AppendLine("     __popup_panel=name;");
					sb.AppendLine("     var panel=document.getElementById(__popup_panel);");
					sb.AppendLine("     panel.style.display=\'block\';");
					sb.AppendLine("     var links=panel.getElementsByTagName(\'A\');");
					sb.AppendLine("     links[0].focus();");
					//  sb.AppendLine("     document.onclick=__popup_clear();")
					sb.AppendLine("     window.event.cancelBubble=true;");
					sb.AppendLine("}");
					
					Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", sb.ToString(), true);
					Page.MaintainScrollPositionOnPostBack = true;
				}
				
				
				private void _innerCal_SelectionChanged(object sender, System.EventArgs e)
				{
					EnsureChildControls();
					_innerTbx.Text = _innerCal.SelectedDate.ToShortDateString();
				}
				
				//keep the panel for another
				private void _innerCal_MonthChanged(object sender, MonthChangedEventArgs e)
				{
					_panelvisible = true;
				}
			}
		}
	}
}
