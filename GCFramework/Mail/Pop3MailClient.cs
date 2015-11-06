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
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;



namespace ACSGhana.Web.Framework
{
	namespace Mail
	{
		namespace Pop3
		{
			
			// Supporting classes and structs
			// ==============================
			
			/// <summary>
			/// Combines Email ID with Email UID for one email
			/// The POP3 server assigns to each message a unique Email UID, which will not change for the life time
			/// of the message and no other message should use the same.
			///
			/// Exceptions:
			/// Throws Pop3Exception if there is a serious communication problem with the POP3 server, otherwise
			///
			/// </summary>
			public struct EmailUid
			{
				/// <summary>
				/// used in POP3 commands to indicate which message (only valid in the present session)
				/// </summary>
				public int EmailId;
				/// <summary>
				/// Uid is always the same for a message, regardless of session
				/// </summary>
				public string Uid;
				
				/// <summary>
				///
				/// </summary>
				/// <param name="EmailId"></param>
				/// <param name="Uid"></param>
				public EmailUid(int EmailId, string Uid)
				{
					this.EmailId = EmailId;
					this.Uid = Uid;
				}
			}
			
			
			/// <summary>
			/// If anything goes wrong within Pop3MailClient, a Pop3Exception is raised
			/// </summary>
			public class Pop3Exception : ApplicationException
			{
				
				/// <summary>
				///
				/// </summary>
				public Pop3Exception()
				{
				}
				/// <summary>
				///
				/// </summary>
				/// <param name="ErrorMessage"></param>
				public Pop3Exception(string ErrorMessage) : base(ErrorMessage)
				{
				}
			}
			
			
			/// <summary>
			/// A pop 3 connection goes through the following states:
			/// </summary>
			public enum Pop3ConnectionStateEnum
			{
				/// <summary>
				/// undefined
				/// </summary>
				None = 0,
				/// <summary>
				/// not connected yet to POP3 server
				/// </summary>
				Disconnected,
				/// <summary>
				/// TCP connection has been opened and the POP3 server has sent the greeting. POP3 server expects user name and password
				/// </summary>
				Authorization,
				/// <summary>
				/// client has identified itself successfully with the POP3, server has locked all messages
				/// </summary>
				Connected,
				/// <summary>
				/// QUIT command was sent, the server has deleted messages marked for deletion and released the resources
				/// </summary>
				Closed
			}
			// Delegates for Pop3MailClient
			// ============================
			
			/// <summary>
			/// If POP3 Server doesn't react as expected or this code has a problem, but
			/// can continue with the execution, a Warning is called.
			/// </summary>
			/// <param name="WarningText"></param>
			/// <param name="Response">string received from POP3 server</param>
			public delegate void WarningHandler(string WarningText, string Response);
			
			
			/// <summary>
			/// Traces all the information exchanged between POP3 client and POP3 server plus some
			/// status messages from POP3 client.
			/// Helpful to investigate any problem.
			/// Console.WriteLine() can be used
			/// </summary>
			/// <param name="TraceText"></param>
			public delegate void TraceHandler(string TraceText);
			
			
			// Pop3MailClient Class
			// ====================
			
			/// <summary>
			/// provides access to emails on a POP3 Server
			/// </summary>
			public class Pop3MailClient
			{
				
				
				//Events
				//------
				
				/// <summary>
				/// Called whenever POP3 server doesn't react as expected, but no runtime error is thrown.
				/// </summary>
				private WarningHandler WarningEvent;
				public event WarningHandler Warning
				{
					add
					{
						WarningEvent = (WarningHandler) System.Delegate.Combine(WarningEvent, value);
					}
					remove
					{
						WarningEvent = (WarningHandler) System.Delegate.Remove(WarningEvent, value);
					}
				}
				
				
				/// <summary>
				/// call warning event
				/// </summary>
				/// <param name="methodName">name of the method where warning is needed</param>
				/// <param name="response">answer from POP3 server causing the warning</param>
				/// <param name="warningText">explanation what went wrong</param>
				/// <param name="warningParameters"></param>
				protected void CallWarning(string methodName, string response, string warningText, params object[] warningParameters)
				{
					warningText = string.Format(warningText, warningParameters);
					if (WarningEvent != null)
					{
						if (WarningEvent != null)
							WarningEvent(methodName + ": " + warningText, response);
					}
					CallTrace("!! {0}", warningText);
				}
				
				
				/// <summary>
				/// Shows the communication between PopClient and PopServer, including warnings
				/// </summary>
				private TraceHandler TraceEvent;
				public event TraceHandler Trace
				{
					add
					{
						TraceEvent = (TraceHandler) System.Delegate.Combine(TraceEvent, value);
					}
					remove
					{
						TraceEvent = (TraceHandler) System.Delegate.Remove(TraceEvent, value);
					}
				}
				
				
				/// <summary>
				/// call Trace event
				/// </summary>
				/// <param name="text">string to be traced</param>
				/// <param name="parameters"></param>
				protected void CallTrace(string text, params object[] parameters)
				{
					if (TraceEvent != null)
					{
						if (TraceEvent != null)
							TraceEvent(DateTime.Now.ToString("hh:mm:ss ") + PopServer + " " + string.Format(text, parameters));
					}
				}
				
				/// <summary>
				/// Trace information received from POP3 server
				/// </summary>
				/// <param name="text">string to be traced</param>
				/// <param name="parameters"></param>
				protected void TraceFrom(string text, params object[] parameters)
				{
					if (TraceEvent != null)
					{
						CallTrace("   " + string.Format(text, parameters), null);
					}
				}
				
				
				//Properties
				//----------
				
				/// <summary>
				/// Get POP3 server name
				/// </summary>
				public string PopServer
				{
					get
					{
						return m_popServer;
					}
				}
				/// <summary>
				/// POP3 server name
				/// </summary>
				protected string m_popServer;
				/// <summary>
				/// Get POP3 server port
				/// </summary>
				public int Port
				{
					get
					{
						return m_port;
					}
				}
				/// <summary>
				/// POP3 server port
				/// </summary>
				protected int m_port;
				
				
				/// <summary>
				/// Should SSL be used for connection with POP3 server
				/// </summary>
				public bool UseSSL
				{
					get
					{
						return m_useSSL;
					}
				}
				/// <summary>
				/// Should SSL be used for connection with POP3 server
				/// </summary>
				private bool m_useSSL;
				
				
				/// <summary>
				/// should Pop3MailClient automatically reconnect if POP3 server has dropped the
				/// connection due to a timeout
				/// </summary>
				public bool IsAutoReconnect
				{
					get
					{
						return n_isAutoReconnect;
					}
					set
					{
						n_isAutoReconnect = value;
					}
				}
				private bool n_isAutoReconnect = false;
				//timeout has occured, we try to perform an autoreconnect
				private bool isTimeoutReconnect = false;
				
				/// <summary>
				/// Get / set read timeout (miliseconds)
				/// </summary>
				public int ReadTimeout
				{
					get
					{
						return System.Convert.ToInt32(m_readTimeout == 0 ? System.Threading.Timeout.Infinite : m_readTimeout);
					}
					set
					{
						m_readTimeout = value;
						if (pop3Stream != null&& pop3Stream.CanTimeout)
						{
							pop3Stream.ReadTimeout = m_readTimeout;
						}
					}
				}
				/// <summary>
				/// POP3 server read timeout
				/// </summary>
				protected int m_readTimeout = - 1;
				
				
				/// <summary>
				/// Get owner name of mailbox on POP3 server
				/// </summary>
				public string Username
				{
					get
					{
						return m_username;
					}
				}
				/// <summary>
				/// Owner name of mailbox on POP3 server
				/// </summary>
				protected string m_username;
				
				
				/// <summary>
				/// Get password for mailbox on POP3 server
				/// </summary>
				public string Password
				{
					get
					{
						return m_password;
					}
				}
				/// <summary>
				/// Password for mailbox on POP3 server
				/// </summary>
				protected string m_password;
				
				
				/// <summary>
				/// Get connection status with POP3 server
				/// </summary>
				public Pop3ConnectionStateEnum Pop3ConnectionState
				{
					get
					{
						return m_pop3ConnectionState;
					}
				}
				/// <summary>
				/// connection status with POP3 server
				/// </summary>
				protected Pop3ConnectionStateEnum m_pop3ConnectionState = Pop3ConnectionStateEnum.Disconnected;
				
				
				// Methods
				// -------
				/// <summary>
				/// set POP3 connection state
				/// </summary>
				/// <param name="State"></param>
				protected void setPop3ConnectionState(Pop3ConnectionStateEnum State)
				{
					m_pop3ConnectionState = State;
					CallTrace("   Pop3MailClient Connection State {0} reached", State);
				}
				
				/// <summary>
				/// throw exception if POP3 connection is not in the required state
				/// </summary>
				/// <param name="requiredState"></param>
				protected void EnsureState(Pop3ConnectionStateEnum requiredState)
				{
					if (m_pop3ConnectionState != requiredState)
					{
						// wrong connection state
						throw (new Pop3Exception("GetMailboxStats only accepted during connection state: " + requiredState.ToString() + Constants.vbLf + " The connection to server " + PopServer + " is in state " + Pop3ConnectionState.ToString()));
					}
				}
				
				
				//private fields
				//--------------
				/// <summary>
				/// TCP to POP3 server
				/// </summary>
				private TcpClient serverTcpConnection;
				/// <summary>
				/// Stream from POP3 server with or without SSL
				/// </summary>
				private Stream pop3Stream;
				/// <summary>
				/// Reader for POP3 message
				/// </summary>
				protected StreamReader pop3StreamReader;
				/// <summary>
				/// char 'array' for carriage return / line feed
				/// </summary>
				protected string CRLF = Constants.vbCrLf;
				
				
				//public methods
				//--------------
				
				/// <summary>
				/// Make POP3 client ready to connect to POP3 server
				/// </summary>
				/// <param name="PopServer"><example>pop.gmail.com</example></param>
				/// <param name="Port"><example>995</example></param>
				/// <param name="useSSL">True: SSL is used for connection to POP3 server</param>
				/// <param name="Username"><example>abc@gmail.com</example></param>
				/// <param name="Password">Secret</param>
				public Pop3MailClient(string PopServer, int Port, bool useSSL, string Username, string Password)
				{
					this.m_popServer = PopServer;
					this.m_port = Port;
					this.m_useSSL = useSSL;
					this.m_username = Username;
					this.m_password = Password;
				}
				/// <summary>
				/// Connect to POP3 server
				/// </summary>
				public void Connect()
				{
					if (Pop3ConnectionState != Pop3ConnectionStateEnum.Disconnected && Pop3ConnectionState != Pop3ConnectionStateEnum.Closed && (! isTimeoutReconnect))
					{
						CallWarning("connect", "", "Connect command received, but connection state is: " + Pop3ConnectionState.ToString(), null);
					}
					else
					{
						//establish TCP connection
						try
						{
							CallTrace("   Connect at port {0}", Port);
							serverTcpConnection = new TcpClient(PopServer, Port);
						}
						catch (System.Exception ex)
						{
							throw (new Pop3Exception("Connection to server " + PopServer + ", port " + Port + " failed." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
						}
						
						if (UseSSL)
						{
							//get SSL stream
							try
							{
								CallTrace("   Get SSL connection", null);
								pop3Stream = new SslStream(serverTcpConnection.GetStream(), false);
								pop3Stream.ReadTimeout = ReadTimeout;
							}
							catch (System.Exception ex)
							{
								throw (new Pop3Exception("Server " + PopServer + " found, but cannot get SSL data stream." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
							}
							
							//perform SSL authentication
							try
							{
								CallTrace("   Get SSL authentication", null);
								((SslStream) pop3Stream).AuthenticateAsClient(PopServer);
							}
							catch (System.Exception ex)
							{
								throw (new Pop3Exception("Server " + PopServer + " found, but problem with SSL Authentication." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
							}
						}
						else
						{
							//create a stream to POP3 server without using SSL
							try
							{
								CallTrace("   Get connection without SSL", null);
								pop3Stream = serverTcpConnection.GetStream();
								pop3Stream.ReadTimeout = ReadTimeout;
							}
							catch (System.Exception ex)
							{
								throw (new Pop3Exception("Server " + PopServer + " found, but cannot get data stream (without SSL)." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
							}
						}
						//get stream for reading from pop server
						//POP3 allows only US-ASCII. The message will be translated in the proper encoding in a later step
						try
						{
							pop3StreamReader = new StreamReader(pop3Stream, Encoding.ASCII);
						}
						catch (System.Exception ex)
						{
							if (UseSSL)
							{
								throw (new Pop3Exception("Server " + PopServer + " found, but cannot read from SSL stream." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
							}
							else
							{
								throw (new Pop3Exception("Server " + PopServer + " found, but cannot read from stream (without SSL)." + Constants.vbLf + "Runtime Error: " + ex.ToString()));
							}
						}
						
						//ready for authorisation
						string response = Constants.vbNullString;
						if (! readSingleLine(ref response))
						{
							throw (new Pop3Exception("Server " + PopServer + " not ready to start AUTHORIZATION." + Constants.vbLf + "Message: " + response));
						}
						setPop3ConnectionState(Pop3ConnectionStateEnum.Authorization);
						
						//send user name
						if (! executeCommand("USER " + Username, ref response))
						{
							throw (new Pop3Exception("Server " + PopServer + " doesn\'t accept username \'" + Username + "\'." + Constants.vbLf + "Message: " + response));
						}
						
						//send password
						if (! executeCommand("PASS " + Password, ref response))
						{
							throw (new Pop3Exception("Server " + PopServer + " doesn\'t accept password \'" + Password + "\' for user \'" + Username + "\'." + Constants.vbLf + "Message: " + response));
						}
						
						setPop3ConnectionState(Pop3ConnectionStateEnum.Connected);
					}
				}
				/// <summary>
				/// Disconnect from POP3 Server
				/// </summary>
				public void Disconnect()
				{
					if (Pop3ConnectionState == Pop3ConnectionStateEnum.Disconnected || Pop3ConnectionState == Pop3ConnectionStateEnum.Closed)
					{
						CallWarning("disconnect", "", "Disconnect received, but was already disconnected.", null);
					}
					else
					{
						//ask server to end session and possibly to remove emails marked for deletion
						try
						{
							string response = Constants.vbNullString;
							if (executeCommand("QUIT", ref response))
							{
								//server says everything is ok
								setPop3ConnectionState(Pop3ConnectionStateEnum.Closed);
							}
							else
							{
								//server says there is a problem
								CallWarning("Disconnect", response, "negative response from server while closing connection: " + response, null);
								setPop3ConnectionState(Pop3ConnectionStateEnum.Disconnected);
							}
						}
						finally
						{
							//close connection
							if (pop3Stream != null)
							{
								pop3Stream.Close();
							}
							
							pop3StreamReader.Close();
						}
					}
				}
				
				
				/// <summary>
				/// Delete message from server.
				/// The POP3 server marks the message as deleted.  Any future
				/// reference to the message-number associated with the message
				/// in a POP3 command generates an error.  The POP3 server does
				/// not actually delete the message until the POP3 session
				/// enters the UPDATE state.
				/// </summary>
				/// <param name="msg_number"></param>
				/// <returns></returns>
				public bool DeleteEmail(int msg_number)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					string response = Constants.vbNullString;
					if (! executeCommand("DELE " + msg_number.ToString(), ref response))
					{
						CallWarning("DeleteEmail", response, "negative response for email (Id: {0}) delete request", msg_number);
						return false;
					}
					return true;
				}
				
				
				/// <summary>
				/// Get a list of all Email IDs available in mailbox
				/// </summary>
				/// <returns></returns>
				public bool GetEmailIdList([System.Runtime.InteropServices.Out()]ref List<int> EmailIds)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					EmailIds = new List<int>();
					
					//get server response status line
					string response = Constants.vbNullString;
					if (! executeCommand("LIST", ref response))
					{
						CallWarning("GetEmailIdList", response, "negative response for email list request", null);
						return false;
					}
					
					//get every email id
					int EmailId;
					while (readMultiLine(ref response))
					{
						if (int.TryParse(response.Split(' ')[0], ref EmailId))
						{
							EmailIds.Add(EmailId);
						}
						else
						{
							CallWarning("GetEmailIdList", response, "first characters should be integer (EmailId)", null);
						}
					}
					TraceFrom("{0} email ids received", EmailIds.Count);
					return true;
				}
				
				
				/// <summary>
				/// get size of one particular email
				/// </summary>
				/// <param name="msg_number"></param>
				/// <returns></returns>
				public int GetEmailSize(int msg_number)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					string response = Constants.vbNullString;
					executeCommand("LIST " + msg_number.ToString(), ref response);
					int EmailSize = 0;
					string[] responseSplit = response.Split(' ');
					if (responseSplit.Length < 2 || (! int.TryParse(responseSplit[2], ref EmailSize)))
					{
						CallWarning("GetEmailSize", response, "\'+OK int int\' format expected (EmailId, EmailSize)", null);
					}
					
					return EmailSize;
				}
				/// <summary>
				/// Get a list with the unique IDs of all Email available in mailbox.
				///
				/// Explanation:
				/// EmailIds for the same email can change between sessions, whereas the unique Email id
				/// never changes for an email.
				/// </summary>
				/// <param name="EmailIds"></param>
				/// <returns></returns>
				public bool GetUniqueEmailIdList([System.Runtime.InteropServices.Out()]ref List<EmailUid> EmailIds)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					EmailIds = new List<EmailUid>();
					
					//get server response status line
					string response = Constants.vbNullString;
					if (! executeCommand("UIDL ", ref response))
					{
						CallWarning("GetUniqueEmailIdList", response, "negative response for email list request", null);
						return false;
					}
					
					//get every email unique id
					int EmailId;
					while (readMultiLine(ref response))
					{
						string[] responseSplit = response.Split(' ');
						if (responseSplit.Length < 2)
						{
							CallWarning("GetUniqueEmailIdList", response, "response not in format \'int string\'", null);
						}
						else if (! int.TryParse(responseSplit[0], ref EmailId))
						{
							CallWarning("GetUniqueEmailIdList", response, "first charaters should be integer (Unique EmailId)", null);
						}
						else
						{
							EmailIds.Add(new EmailUid(EmailId, responseSplit[1]));
						}
					}
					TraceFrom("{0} unique email ids received", EmailIds.Count);
					return true;
				}
				
				
				/// <summary>
				/// get a list with all currently available messages and the UIDs
				/// </summary>
				/// <param name="EmailIds">EmailId Uid list</param>
				/// <returns>false: server sent negative response (didn't send list)</returns>
				public bool GetUniqueEmailIdList([System.Runtime.InteropServices.Out()]ref SortedList<string, int> EmailIds)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					EmailIds = new SortedList<string, int>();
					
					//get server response status line
					string response = Constants.vbNullString;
					if (! executeCommand("UIDL", ref response))
					{
						CallWarning("GetUniqueEmailIdList", response, "negative response for email list request", null);
						return false;
					}
					
					//get every email unique id
					int EmailId;
					while (readMultiLine(ref response))
					{
						string[] responseSplit = response.Split(' ');
						if (responseSplit.Length < 2)
						{
							CallWarning("GetUniqueEmailIdList", response, "response not in format \'int string\'", null);
						}
						else if (! int.TryParse(responseSplit[0], ref EmailId))
						{
							CallWarning("GetUniqueEmailIdList", response, "first charaters should be integer (Unique EmailId)", null);
						}
						else
						{
							EmailIds.Add(responseSplit[1], EmailId);
						}
					}
					TraceFrom("{0} unique email ids received", EmailIds.Count);
					return true;
				}
				
				
				/// <summary>
				/// get size of one particular email
				/// </summary>
				/// <param name="msg_number"></param>
				/// <returns></returns>
				public int GetUniqueEmailId(EmailUid msg_number)
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					string response = Constants.vbNullString;
					executeCommand("LIST " + msg_number.ToString(), ref response);
					int EmailSize = 0;
					string[] responseSplit = response.Split(' ');
					if (responseSplit.Length < 2 || (! int.TryParse(responseSplit[2], ref EmailSize)))
					{
						CallWarning("GetEmailSize", response, "\'+OK int int\' format expected (EmailId, EmailSize)", null);
					}
					
					return EmailSize;
				}
				/// <summary>
				/// Sends an 'empty' command to the POP3 server. Server has to respond with +OK
				/// </summary>
				/// <returns>true: server responds as expected</returns>
				public bool NOOP()
				{
					EnsureState(Pop3ConnectionStateEnum.Connected);
					string response = Constants.vbNullString;
					if (! executeCommand("NOOP", ref response))
					{
						CallWarning("NOOP", response, "negative response for NOOP request", null);
						return false;
					}
					return true;
				}
				
				/// <summary>
				/// Should the raw content, the US-ASCII code as received, be traced
				/// GetRawEmail will switch it on when it starts and off once finished
				///
				/// Inheritors might use it to get the raw email
				/// </summary>
				protected bool isTraceRawEmail = false;
				
				
				/// <summary>
				/// contains one MIME part of the email in US-ASCII, needs to be translated in .NET string (Unicode)
				/// contains the complete email in US-ASCII, needs to be translated in .NET string (Unicode)
				/// For speed reasons, reuse StringBuilder
				/// </summary>
				protected StringBuilder RawEmailSB;
				
				
				/// <summary>
				/// Reads the complete text of a message
				/// </summary>
				/// <param name="MessageNo">Email to retrieve</param>
				/// <param name="EmailText">ASCII string of complete message</param>
				/// <returns></returns>
				public bool GetRawEmail(int MessageNo, [System.Runtime.InteropServices.Out()]ref string EmailText)
				{
					//send 'RETR int' command to server
					if (! SendRetrCommand(MessageNo))
					{
						EmailText = null;
						return false;
					}
					
					//get the lines
					string response = Constants.vbNullString;
					int LineCounter = 0;
					//empty StringBuilder
					if (RawEmailSB == null)
					{
						RawEmailSB = new StringBuilder(100000);
					}
					else
					{
						RawEmailSB.Length = 0;
					}
					isTraceRawEmail = true;
					while (readMultiLine(ref response))
					{
						LineCounter++;
					}
					EmailText = RawEmailSB.ToString();
					TraceFrom("email with {0} lines,  {1} chars received", LineCounter.ToString(), EmailText.Length);
					return true;
				}
				
				
				///// <summary>
				///// Requests from POP3 server a specific email and returns a stream with the message content (header and body)
				///// </summary>
				///// <param name="MessageNo"></param>
				///// <param name="EmailStreamReader"></param>
				///// <returns>false: POP3 server cannot provide this message</returns>
				//public bool GetEmailStream(int MessageNo, out StreamReader EmailStreamReader) {
					//  //send 'RETR int' command to server
					//  if (!SendRetrCommand(MessageNo)) {
						//    EmailStreamReader = null;
						//    return false;
						//  }
						//  EmailStreamReader = sslStreamReader;
						//  return true;
						//}
						
						
						/// <summary>
						/// Unmark any emails from deletion. The server only deletes email really
						/// once the connection is properly closed.
						/// </summary>
						/// <returns>true: emails are unmarked from deletion</returns>
						public bool UndeleteAllEmails()
						{
							EnsureState(Pop3ConnectionStateEnum.Connected);
							string response = Constants.vbNullString;
							return executeCommand("RSET", ref response);
						}
						/// <summary>
						/// Get mailbox statistics
						/// </summary>
						/// <param name="NumberOfMails"></param>
						/// <param name="MailboxSize"></param>
						/// <returns></returns>
						public bool GetMailboxStats([System.Runtime.InteropServices.Out()]ref int NumberOfMails, [System.Runtime.InteropServices.Out()]ref int MailboxSize)
						{
							EnsureState(Pop3ConnectionStateEnum.Connected);
							
							//interpret response
							string response = Constants.vbNullString;
							NumberOfMails = 0;
							MailboxSize = 0;
							if (executeCommand("STAT", ref response))
							{
								//got a positive response
								string[] responseParts = response.Split(' ');
								if (responseParts.Length < 2)
								{
									//response format wrong
									throw (new Pop3Exception("Server " + PopServer + " sends illegally formatted response." + Constants.vbLf + "Expected format: +OK int int" + Constants.vbLf + "Received response: " + response));
								}
								NumberOfMails = int.Parse(responseParts[1]);
								MailboxSize = int.Parse(responseParts[2]);
								return true;
							}
							return false;
						}
						
						
						/// <summary>
						/// Send RETR command to POP 3 server to fetch one particular message
						/// </summary>
						/// <param name="MessageNo">ID of message required</param>
						/// <returns>false: negative server respond, message not delivered</returns>
						protected bool SendRetrCommand(int MessageNo)
						{
							EnsureState(Pop3ConnectionStateEnum.Connected);
							// retrieve mail with message number
							string response = Constants.vbNullString;
							if (! executeCommand("RETR " + MessageNo.ToString(), ref response))
							{
								CallWarning("GetRawEmail", response, "negative response for email (ID: {0}) request", MessageNo);
								return false;
							}
							return true;
						}
						
						
						//Helper methodes
						//---------------
						
						public bool isDebug = false;
						/// <summary>
						/// sends the 4 letter command to POP3 server (adds CRLF) and waits for the
						/// response of the server
						/// </summary>
						/// <param name="commandText">command to be sent to server</param>
						/// <param name="response">answer from server</param>
						/// <returns>false: server sent negative acknowledge, i.e. server could not execute command</returns>
						private bool executeCommand(string commandText, [System.Runtime.InteropServices.Out()]ref string response)
						{
							//send command to server
							byte[] commandBytes = System.Text.Encoding.ASCII.GetBytes((commandText + CRLF).ToCharArray());
							CallTrace("Tx \'{0}\'", commandText);
							bool isSupressThrow = false;
							try
							{
								pop3Stream.Write(commandBytes, 0, commandBytes.Length);
								if (isDebug)
								{
									isDebug = false;
									throw (new IOException("Test", new SocketException(10053)));
								}
							}
							catch (IOException ex)
							{
								//Unable to write data to the transport connection. Check if reconnection should be tried
								isSupressThrow = executeReconnect(ex, commandText, commandBytes);
								if (! isSupressThrow)
								{
									throw;
								}
							}
							pop3Stream.Flush();
							
							//read response from server
							response = null;
							try
							{
								response = pop3StreamReader.ReadLine();
							}
							catch (IOException ex)
							{
								//Unable to write data to the transport connection. Check if reconnection should be tried
								isSupressThrow = executeReconnect(ex, commandText, commandBytes);
								if (isSupressThrow)
								{
									//wait for response one more time
									response = pop3StreamReader.ReadLine();
								}
								else
								{
									throw;
								}
							}
							if (response == null)
							{
								throw (new Pop3Exception("Server " + PopServer + " has not responded, timeout has occured."));
							}
							CallTrace("Rx \'{0}\'", response);
							return (response.Length > 0 && response[0] == '+');
						}
						
						/// <summary>
						/// reconnect, if there is a timeout exception and isAutoReconnect is true
						///
						/// </summary>
						private bool executeReconnect(IOException ex, string command, byte[] commandBytes)
						{
							if (ex.InnerException != null&& ex.InnerException is SocketException)
							{
								//SocketException
								SocketException innerEx = (SocketException) ex.InnerException;
								if (innerEx.ErrorCode == 10053)
								{
									//probably timeout: An established connection was aborted by the software in your host machine.
									CallWarning("ExecuteCommand", "", "probably timeout occured", null);
									if (IsAutoReconnect)
									{
										//try to reconnect and send one more time
										isTimeoutReconnect = true;
										try
										{
											CallTrace("   try to auto reconnect", null);
											Connect();
											
											CallTrace("   reconnect successful, try to resend command", null);
											CallTrace("Tx \'{0}\'", command);
											pop3Stream.Write(commandBytes, 0, commandBytes.Length);
											pop3Stream.Flush();
											return true;
										}
										finally
										{
											isTimeoutReconnect = false;
										}
										
									}
								}
							}
							return false;
						}
						
						
						//
						///// <summary>
						///// sends the 4 letter command to POP3 server (adds CRLF)
						///// </summary>
						///// <param name="command"></param>
						//protected void SendCommand(string command) {
							//byte[] commandBytes = System.Text.Encoding.ASCII.GetBytes((command + CRLF).ToCharArray());
							//CallTrace("Tx '{0}'", command);
							//try {
								//pop3Stream.Write(commandBytes, 0, commandBytes.Length);
								//} catch (IOException ex) {
									////Unable to write data to the transport connection:
									//if (ex.InnerException!=null && ex.InnerException is SocketException) {
										////SocketException
										//SocketException innerEx = (SocketException)ex.InnerException;
										//if (innerEx.ErrorCode==10053) {
											////probably timeout: An established connection was aborted by the software in your host machine.
											//CallWarning("SendCommand", "", "probably timeout occured");
											//if (isAutoReconnect) {
												////try to reconnect and send one more time
												//isTimeoutReconnect = true;
												//try {
													//CallTrace("   try to auto reconnect");
													//Connect();
													
													//CallTrace("   reconnect successful, try to resend command");
													//CallTrace("Tx '{0}'", command);
													//pop3Stream.Write(commandBytes, 0, commandBytes.Length);
													//} finally {
														//isTimeoutReconnect = false;
														//}
														//return;
														//}
														//}
														//}
														//throw;
														//}
														//pop3Stream.Flush();
														//}
														//
														
														
														/// <summary>
														/// read single line response from POP3 server.
														/// <example>Example server response: +OK asdfkjahsf</example>
														/// </summary>
														/// <param name="response">response from POP3 server</param>
														/// <returns>true: positive response</returns>
														protected bool readSingleLine([System.Runtime.InteropServices.Out()]ref string response)
														{
															response = null;
															try
															{
																response = pop3StreamReader.ReadLine();
															}
															catch (System.Exception ex)
															{
																string s = ex.Message;
															}
															if (response == null)
															{
																throw (new Pop3Exception("Server " + PopServer + " has not responded, timeout has occured."));
															}
															CallTrace("Rx \'{0}\'", response);
															return (response.Length > 0 && response[0] == '+');
														}
														/// <summary>
														/// read one line in multiline mode from the POP3 server.
														/// </summary>
														/// <param name="response">line received</param>
														/// <returns>false: end of message</returns>
														protected bool readMultiLine([System.Runtime.InteropServices.Out()]ref string response)
														{
															response = null;
															response = pop3StreamReader.ReadLine();
															if (response == null)
															{
																throw (new Pop3Exception("Server " + PopServer + " has not responded, probably timeout has occured."));
															}
															if (isTraceRawEmail)
															{
																//collect all responses as received
																RawEmailSB.Append(response + CRLF);
															}
															//check for byte stuffing, i.e. if a line starts with a '.', another '.' is added, unless
															//it is the last line
															if (response.Length > 0 && response[0] == '.')
															{
																if (response == ".")
																{
																	//closing line found
																	return false;
																}
																//remove the first '.'
																response = response.Substring(1, response.Length - 1);
															}
															return true;
														}
														
													}
												}
											}
											
										}
