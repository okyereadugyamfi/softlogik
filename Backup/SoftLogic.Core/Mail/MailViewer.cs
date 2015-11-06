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


namespace SoftLogik.Mail
{
	namespace Mail
	{
		namespace Pop3
		{
			
			
			[System.ComponentModel.DataObjectAttribute(true)]public class MailViewer
			{
				
				
				const int MAX_RECENTDAYS = 7;
				private InboxManager m_MailService = null;
				
				
				public InboxItemCollection GetRecentInbox(string ServerName, int PortNumber, bool UseSSL, string UserName, string Password)
				{
					InboxItemCollection colInbox = new InboxItemCollection();
					colInbox = PrepareInbox(ServerName, PortNumber, UseSSL, UserName, Password, true, MAX_RECENTDAYS);
					return colInbox;
				}
				
				public InboxItemCollection GetInbox(string ServerName, int PortNumber, bool UseSSL, string UserName, string Password)
				{
					InboxItemCollection colInbox = new InboxItemCollection();
					colInbox = PrepareInbox(ServerName, PortNumber, UseSSL, UserName, Password, false, - 1);
					return colInbox;
				}
				
				private InboxItemCollection PrepareInbox(string ServerName, int PortNumber, bool UseSSL, string UserName, string Password, bool Recent, int RecentPeriod)
				{
					InboxItemCollection colInbox = new InboxItemCollection();
					try
					{
						if (!(string.IsNullOrEmpty(ServerName) && string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password)))
						{
							m_MailService = new InboxManager(ServerName, PortNumber, UseSSL, UserName, Password);
							List<Mail.Pop3.RxMailMessage> inboxList = m_MailService.DownloadEmail(250);
							
							try
							{
								foreach (Mail.Pop3.RxMailMessage inboxItem in inboxList)
								{
									if (Recent && RecentPeriod != - 1)
									{
										if (inboxItem.DeliveryDate >= DateTime.Now.AddDays(- RecentPeriod))
										{
											colInbox.Add(new InboxItem(inboxItem));
										}
									}
									else
									{
										colInbox.Add(new InboxItem(inboxItem));
									}
									
								}
								
								//Sort the inbox
								colInbox.Sort(new InboxItemComparer());
							}
							catch (System.Exception)
							{
								
							}
						}
					}
					catch (Mail.Pop3.Pop3Exception)
					{
					}
					catch (System.Exception)
					{
					}
					return colInbox;
				}
				
				
			}
			
			#region Inbox Item Comparer
			public class InboxItemComparer : IComparer<InboxItem>
			{
				
				
				public int Compare(InboxItem x, InboxItem y)
				{
					if (x == null)
					{
						if (y == null)
						{
							// If x is Nothing and y is Nothing, they're
							// equal.
							return 0;
						}
						else
						{
							// If x is Nothing and y is not Nothing, y
							// is greater.
							return - 1;
						}
					}
					else
					{
						// If x is not Nothing...
						//
						if (y == null)
						{
							// ...and y is Nothing, x is greater.
							return 1;
						}
						else
						{
							// ...and y is not Nothing, compare the
							// date of the two inbox items.
							//
							int retval = y.DeliveryDate.CompareTo(x.DeliveryDate);
							
							if (retval != 0)
							{
								// If the strings are not of equal length,
								// the longer string is greater.
								//
								return retval;
							}
							else
							{
								// If the strings are of equal length,
								// sort them with ordinary string comparison.
								//
								return x.EmailID.CompareTo(y.EmailID);
							}
						}
					}
					
				}
			}
			#endregion
			
			#region Inbox Collection
			public class InboxItemCollection : List<InboxItem>
			{
				
				
				public InboxItem this[string EmailID]
				{
					get
					{
						InboxItem itm = null;
						
						foreach (InboxItem tempLoopVar_itm in this)
						{
							itm = tempLoopVar_itm;
							if (itm.EmailID == EmailID)
							{
								break;
							}
						}
						return itm;
					}
				}
			}
			#endregion
			
			#region Inbox Item
			public class InboxItem
			{
				
				private string m_strName;
				private string m_strSubject;
				private bool m_Select = false;
				private Mail.Pop3.RxMailMessage m_innerEmail = null;
				private Guid m_guidEmailID;
				
				public InboxItem(Mail.Pop3.RxMailMessage NewMail)
				{
					m_guidEmailID = Guid.NewGuid();
					
					this.m_strName = m_guidEmailID.ToString();
					this.m_innerEmail = NewMail;
				}
				
				public string EmailID
				{
					get
					{
						return m_guidEmailID.ToString();
					}
				}
				
				
				public Mail.Pop3.RxMailMessage Email
				{
					get
					{
						return m_innerEmail;
					}
				}
				public bool @Select
				{
					get
					{
						return m_Select;
					}
					set
					{
						m_Select = value;
					}
				}
				
				public string Sender
				{
					get
					{
						if (m_innerEmail.From != null)
						{
							return m_innerEmail.From.DisplayName;
						}
						else
						{
							return string.Empty;
						}
					}
				}
				
				public string Subject
				{
					get
					{
						return m_innerEmail.Subject;
					}
				}
				
				public DateTime DeliveryDate
				{
					get
					{
						return m_innerEmail.DeliveryDate;
					}
				}
				
			}
			#endregion
			
		}
	}
}
