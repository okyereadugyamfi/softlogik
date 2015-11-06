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
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			
			
			/// <summary>
			/// A simple control that shows page numbers
			/// </summary>
			/// <remarks>You feed it the number of pages, how many pages to show and it will show links for that many pages along with
			/// next and previous buttons as applicable. For example with a high count and current page being 5 and 5 displayed pages, it will show
			///  first prev 3, 4, 5, 6, 7 next last  </remarks>
			public class PageNumberer : WebControl, IPostBackEventHandler
			{
				
				
				private int m_SelectedPage;
				private int m_Count;
				private int m_displayedPages;
				
				
				/// <summary>
				/// The currently selected page
				/// </summary>
				/// <value>The page number, with 1 being the first page</value>
				/// <remarks></remarks>
				public int SelectedPage
				{
					get
					{
						if (m_SelectedPage == 0)
						{
							object o = ViewState["SelectedPage"];
							if (o == null)
							{
								m_SelectedPage = 1;
							}
							else
							{
								m_SelectedPage = System.Convert.ToInt32(o);
							}
						}
						return m_SelectedPage;
					}
					set
					{
						ViewState["SelectedPage"] = value;
						m_SelectedPage = value;
					}
				}
				
				/// <summary>
				/// The total number of pages
				/// </summary>
				public int Count
				{
					get
					{
						if (m_Count == 0)
						{
							object o = ViewState["Count"];
							if (o == null)
							{
								m_Count = 1;
							}
							else
							{
								m_Count = System.Convert.ToInt32(o);
							}
						}
						return m_Count;
					}
					set
					{
						ViewState["Count"] = value;
						m_Count = value;
					}
				}
				
				/// <summary>
				/// How many pages to show in the display
				/// </summary>
				/// <value></value>
				/// <remarks></remarks>
				public int DisplayedPages
				{
					get
					{
						if (m_displayedPages == 0)
						{
							object o = ViewState["DisplayedPages"];
							if (o == null)
							{
								m_displayedPages = 1;
							}
							else
							{
								m_displayedPages = System.Convert.ToInt32(o);
							}
						}
						return m_displayedPages;
					}
					set
					{
						ViewState["DisplayedPages"] = value;
						m_displayedPages = value;
					}
				}
				
				protected override System.Web.UI.HtmlTextWriterTag TagKey
				{
					get
					{
						return HtmlTextWriterTag.Div;
					}
				}
				
				protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
				{
					int prevListCount;
					int nextListCount;
					int startPage;
					int endPage;
					
					prevListCount = Math.Abs((m_displayedPages - 1) / 2);
					if (m_SelectedPage <= prevListCount)
					{
						prevListCount = m_SelectedPage - 1;
					}
					
					nextListCount = m_displayedPages - prevListCount - 1;
					if (m_SelectedPage + nextListCount > m_Count)
					{
						nextListCount = m_Count - m_SelectedPage;
					}
					
					startPage = m_SelectedPage - prevListCount;
					endPage = m_SelectedPage + nextListCount;
					
					if (startPage > 1)
					{
						renderItem(writer, "&laquo; First", 1);
					}
					
					if (SelectedPage > 1)
					{
						renderItem(writer, "&lt; Prev", SelectedPage - 1);
					}
					
					for (int count = startPage; count <= endPage; count++)
					{
						string label;
						if (count != endPage)
						{
							label = count.ToString() + ",";
						}
						else
						{
							label = count.ToString();
						}
						
						if (count == m_SelectedPage)
						{
							renderItem(writer, label, 0);
						}
						else
						{
							renderItem(writer, label, count);
						}
					}
					
					if (SelectedPage < m_Count)
					{
						renderItem(writer, "Next &gt;", SelectedPage + 1);
					}
					if (endPage < m_Count)
					{
						renderItem(writer, "Last &raquo;", m_Count);
					}
				}
				
				public void renderItem(HtmlTextWriter writer, string text, int pageNum)
				{
					writer.RenderBeginTag(HtmlTextWriterTag.Span);
					
					if (pageNum != 0)
					{
						
						writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.ClientScript.GetPostBackClientHyperlink(this, pageNum.ToString()));
						writer.RenderBeginTag(HtmlTextWriterTag.A);
					}
					
					writer.Write(text);
					
					if (pageNum != 0)
					{
						writer.RenderEndTag();
					}
					
					writer.RenderEndTag();
				}
				
				/// <summary>
				/// Event is fired when user clicks on a different page number.
				/// </summary>
				/// <remarks></remarks>
				private EventHandler SelectedPageChangedEvent;
				public event EventHandler SelectedPageChanged
				{
					add
					{
						SelectedPageChangedEvent = (EventHandler) System.Delegate.Combine(SelectedPageChangedEvent, value);
					}
					remove
					{
						SelectedPageChangedEvent = (EventHandler) System.Delegate.Remove(SelectedPageChangedEvent, value);
					}
				}
				
				
				public void RaisePostBackEvent(string eventArgument)
				{
					int newPage;
					if (int.TryParse(eventArgument, ref newPage))
					{
						
						this.SelectedPage = newPage;
						OnSelectedPageChanged(EventArgs.Empty);
					}
				}
				
				protected virtual void OnSelectedPageChanged(EventArgs e)
				{
					if (SelectedPageChangedEvent != null)
						SelectedPageChangedEvent(this, e);
				}
				
			}
		}
	}
	
}
