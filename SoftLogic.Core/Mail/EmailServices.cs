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
using System.Net.Mail;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;



namespace ACSGhana.Web.Framework
{
	public struct WorkflowMailRecipient
	{
		
		public WorkflowMailRecipient(string FirstName, string Email)
		{
			this.FirstName = FirstName;
			this.Email = Email;
		}
		
		public string FirstName;
		public string Email;
	}
	
	public struct RecipientEmails
	{
		public string @To;
		public string Cc;
		public string Bcc;
		
		public RecipientEmails(string toAddress, string ccAddress, string bccAddress)
		{
			@To = toAddress;
			@Cc = ccAddress;
			@Bcc = bccAddress;
		}
		public RecipientEmails(string[] addressArray)
		{
			@To = addressArray[0];
			@Cc = addressArray[1];
			@Bcc = addressArray[2];
		}
		
	}
	
	public partial class ReportMail
	{
		
		
		public ReportMail(WorkflowMailRecipient Recipient, string ReportName, string ReportFile, string MailBody, MailPriority Priority)
		{
			this._RecipientEmail = Recipient;
			this._ReportName = ReportName;
			if (! string.IsNullOrEmpty(ReportFile))
			{
				this._AttachedReport = new Attachment(ReportFile);
			}
			this._MailBody = MailBody;
			this._Priority = Priority;
		}
		
		private Guid _MailGuid;
		public Guid MailGuid
		{
			get
			{
				if (_MailGuid == Guid.Empty)
				{
					_MailGuid = Guid.NewGuid();
				}
				return _MailGuid;
			}
		}
		
		private WorkflowMailRecipient _RecipientEmail;
		public WorkflowMailRecipient RecipientEmail
		{
			get
			{
				return _RecipientEmail;
			}
		}
		
		private Attachment _AttachedReport = null;
		public Attachment AttachedReport
		{
			get
			{
				return _AttachedReport;
			}
		}
		
		private string _ReportName = null;
		public string ReportName
		{
			get
			{
				return _ReportName;
			}
		}
		
		private string _MailBody = null;
		public string MailBody
		{
			get
			{
				return _MailBody;
			}
		}
		private MailPriority _Priority = MailPriority.Normal;
		public MailPriority Priority
		{
			get
			{
				return _Priority;
			}
		}
		
	}
	
	public class EmailServices
	{
		
		
		public static void AddEmptyItem(DropDownList ddl)
		{
			ListItem li = new ListItem("[None]", "-1");
			ddl.Items.Insert(0, li);
		}
		
		public static void SendSuggestion(string Sender, RecipientEmails RecipientList, string Subject, string BodyText)
		{
			SendNotification(Sender, RecipientList, "Suggestion: " + Subject, BodyText, MailPriority.High);
		}
		
		public static void SendComplaint(string Sender, RecipientEmails RecipientList, string Subject, string BodyText)
		{
			SendNotification(Sender, RecipientList, "Complaint: " + Subject, BodyText, MailPriority.High);
		}
		public static void SendQuestion(string Sender, RecipientEmails RecipientList, string Subject, string BodyText)
		{
			SendNotification(Sender, RecipientList, "Question: " + Subject, BodyText, MailPriority.High);
		}
		
		public static string GetStringEmailList(WorkflowMailRecipient[] emailList)
		{
			List<string> targetString = new List<string>();
			
			foreach (WorkflowMailRecipient emailItem in emailList)
			{
				targetString.Add(emailItem.Email);
			}
			
			string target = string.Join(", ", targetString.ToArray());
			
			return target;
		}
		
		public static void SendNotification(string Sender, RecipientEmails RecipientList, string Subject, string BodyText)
		{
			SendNotification(Sender, RecipientList, Subject, BodyText, MailPriority.Normal);
		}
		public static void SendNotification(string Sender, RecipientEmails RecipientList, string Subject, string BodyText, MailPriority Priority)
		{
			SendNotification(Sender, RecipientList, Subject, BodyText, MailPriority.Normal, null);
			
		}
		public static void SendNotification(string Sender, RecipientEmails RecipientList, string Subject, string BodyText, MailPriority Priority, List<Attachment> Attachments)
		{
			
			try
			{
				
				//(1) Create the MailMessage instance
				using (MailMessage mm = new MailMessage(Sender, RecipientList.To))
				{
					string strBody = "<div style=\'color:#4B6C8B; font-size:1.0em; font-family:Century Gothic,Verdana,Arial,Helvetica,sans-serif;\'>";
					strBody += BodyText + " </div>";
					
					//(2) Assign the MailMessage's properties
					mm.Subject = Subject;
					mm.Body = strBody;
					mm.IsBodyHtml = true;
					mm.Priority = Priority;
					if (RecipientList.Cc != string.Empty)
					{
						mm.CC.Add(RecipientList.Cc);
					}
					if (RecipientList.Bcc != string.Empty)
					{
						mm.Bcc.Add(RecipientList.Bcc);
					}
					if (Attachments != null)
					{
						foreach (Attachment attach in Attachments)
						{
							mm.Attachments.Add(attach);
						}
					}
					
					//(3) Create the SmtpClient object
					SmtpClient smtp = new SmtpClient();

                    bool RetrySend = true;
                    while (RetrySend)
                    {
					    try
					    {
						    smtp.Send(mm);
					    }
					    catch (SmtpFailedRecipientException ex)
					    {
						    switch (ex.StatusCode)
						    {
							    case SmtpStatusCode.MailboxBusy:
							    case SmtpStatusCode.TransactionFailed:
								    continue;
							    default:
								    break;
						    }
					    }
					    catch (SmtpException ex)
					    {
						    switch (ex.StatusCode)
						    {
							    case SmtpStatusCode.MailboxBusy:
							    case SmtpStatusCode.TransactionFailed:
                                    continue;
							    default:
								    break;
						    }
					    }
					    catch (System.Exception)
					    {
					    } 
                    }

				}
				
			}
			catch (System.Exception)
			{
			}
		}
		public static void SendMailReport(string Sender, ReportMail Report)
		{
			
			try
			{
				
				//(1) Create the MailMessage instance
				using (MailMessage mm = new MailMessage(Sender, Report.RecipientEmail.Email))
				{
					string strBody = "<div style=\'color:#4B6C8B; font-size:1.0em; font-family:Century Gothic,Verdana,Arial,Helvetica,sans-serif;\'>";
					strBody += Report.MailBody + " </div>";
					
					//(2) Assign the MailMessage's properties
					mm.Subject = "G.C.P Report Mail: " + Report.ReportName;
					mm.Body = strBody;
					mm.IsBodyHtml = true;
					mm.Priority = Report.Priority;
					if (Report.AttachedReport != null)
					{
						mm.Attachments.Add(Report.AttachedReport);
					}
					
					//(3) Create the SmtpClient object
					SmtpClient smtp = new SmtpClient();

                    bool RetrySend = true;
                    while (RetrySend)
                    {
                        try
					    {

						    smtp.Send(mm);
					    }
					    catch (SmtpFailedRecipientException ex)
					    {
						    switch (ex.StatusCode)
						    {
							    case SmtpStatusCode.MailboxBusy:
							    case SmtpStatusCode.TransactionFailed:
								    continue;
							    default:
								    break;
						    }
					    }
                        catch (SmtpException ex)
                        {
                            switch (ex.StatusCode)
                            {
                                case SmtpStatusCode.MailboxBusy:
                                case SmtpStatusCode.TransactionFailed:
                                    continue;
                                default:
                                    break;
                            }
                        }
                        catch (System.Exception)
                        {
                        }

                        break;
                    }
				}
				
			}
			catch (System.Exception)
			{
			}
		}
		
		public static IAsyncResult SendNotificationAsync(string Sender, RecipientEmails RecipientList, string Subject, string BodyText, MailPriority Priority)
		{
			
			try
			{
				
				//(1) Create the MailMessage instance
				using (MailMessage mm = new MailMessage(Sender, RecipientList.To))
				{
					string strBody = "<div style=\'color:#4B6C8B; font-size:1.0em; font-family:Century Gothic,Verdana,Arial,Helvetica,sans-serif;\'>";
					strBody += BodyText + " </div>";
					
					//(2) Assign the MailMessage's properties
					mm.Subject = Subject;
					mm.Body = strBody;
					mm.IsBodyHtml = true;
					mm.Priority = Priority;
					if (RecipientList.Cc != string.Empty)
					{
						mm.CC.Add(RecipientList.Cc);
					}
					if (RecipientList.Bcc != string.Empty)
					{
						mm.Bcc.Add(RecipientList.Bcc);
					}
					
					//(3) Create the SmtpClient object
					SmtpClient smtp = new SmtpClient();

                    bool RetrySend = true;
                    while (RetrySend)
                    {
                        try
                        {

                            smtp.Send(mm);
                        }
                        catch (SmtpFailedRecipientException ex)
                        {
                            switch (ex.StatusCode)
                            {
                                case SmtpStatusCode.MailboxBusy:
                                case SmtpStatusCode.TransactionFailed:
                                    continue;
                                default:
                                    break;
                            }
                        }
                        catch (SmtpException ex)
                        {
                            switch (ex.StatusCode)
                            {
                                case SmtpStatusCode.MailboxBusy:
                                case SmtpStatusCode.TransactionFailed:
                                    continue;
                                default:
                                    break;
                            }
                        }
                        catch (System.Exception)
                        {
                        }

                        break;
                    }
				}
				
			}
			catch (System.Exception)
			{
			}
			
			return new MailNotificationResult();
		}
		
	}
	
	public class MailNotificationResult : IAsyncResult
	{
		
		
		private object _AsyncState;
		
		public object AsyncState
		{
			get
			{
				return _AsyncState;
			}
		}
		
		public System.Threading.WaitHandle AsyncWaitHandle
		{
			get
			{
				return null;
			}
		}
		
		public bool CompletedSynchronously
		{
			get
			{
				return false;
			}
		}
		
		public bool IsCompleted
		{
			get
			{
				return true;
			}
		}
	}
	
}
