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
	public class EmailService
	{
		
		
		private Mail.Pop3.Pop3MimeClient m_popClient;
		
		public EmailService(string ServerName, int PortNumber, bool UseSSL, string UserName, string Password)
		{
			m_popClient = new Mail.Pop3.Pop3MimeClient(ServerName, PortNumber, UseSSL, UserName, Password);
		}
		
		public List<Mail.Pop3.RxMailMessage> DownloadEmail(int MaxEmailCount)
		{
			List<Mail.Pop3.RxMailMessage> emailList = new List<Mail.Pop3.RxMailMessage>();
			try
			{
				
				m_popClient.Connect();
				
				Mail.Pop3.RxMailMessage emailItem = null;
				//get mailbox stats
				int numberOfMailsInMailbox;
				int mailboxSize;
				m_popClient.GetMailboxStats(numberOfMailsInMailbox, mailboxSize);
				
				int downloadNumberOfEmails;
				if (numberOfMailsInMailbox < MaxEmailCount)
				{
					downloadNumberOfEmails = numberOfMailsInMailbox;
				}
				else
				{
					downloadNumberOfEmails = MaxEmailCount;
				}
				int i = 1;
				while (i <= downloadNumberOfEmails)
				{
					m_popClient.GetEmail(i, emailItem);
					if (emailItem != null)
					{
						emailList.Add(emailItem);
					}
					i++;
				}
				
				m_popClient.Disconnect();
			}
			catch (System.Exception)
			{
			}
			
			return emailList;
		}
		
	}
	
}
