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
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;

/// <summary>
/// Summary description for Utility
/// </summary>
namespace ACSGhana.Web.Framework
{
	public class Utility
	{
		
		
		#region Many to Many Helpers
		/// <summary>
		/// Deletes records from mapping table where the value this object's primary key value
		/// and the mapColumnValue is the matching map record value
		/// </summary>
		/// <param name="mapTableName">The Mapping Table</param>
		/// <returns>Number of records deleted</returns>
		private Utility()
		{
		}
		public static int DeleteManyToManyRecord(string mapTableName, string column1, string column2, int column1Value, int column2Value)
		{
			//remove all records from the Map Table
			string delSql = "DELETE FROM " + mapTableName + " WHERE " + column1 + "=@c1 AND " + column2 + "=@c2";
			QueryCommand cmd = new QueryCommand(delSql);
			cmd.Parameters.Add("@c1", column1Value);
			cmd.Parameters.Add("@c2", column2Value);
			//execute it
			int iOut = DataService.ExecuteQuery(cmd);
			return iOut;
		}
		/// <summary>
		/// Deletes records from mapping table where the value this object's primary key value
		/// and the mapColumnValue is the matching map record value
		/// </summary>
		/// <param name="mapTableName">The Mapping Table</param>
		/// <returns>Number of records deleted</returns>
		public static int SaveManyToManyRecord(string mapTableName, string column1, string column2, int column1Value, int column2Value)
		{
			//remove all records from the Map Table\
			//delete them first to be sure of no errors
			DeleteManyToManyRecord(mapTableName, column1, column2, column1Value, column2Value);
			
			string sql = "INSERT INTO " + mapTableName + " (" + column1 + "," + column2 + ") " + "VALUES (@c1, @c2)";
			
			QueryCommand cmd = new QueryCommand(sql);
			cmd.Parameters.Add("@c1", column1Value);
			cmd.Parameters.Add("@c2", column2Value);
			
			//execute it
			int iOut = DataService.ExecuteQuery(cmd);
			return iOut;
		}
		/// <summary>
		/// Deletes records from mapping table where the value this object's primary key value
		/// and the mapColumnValue is the matching map record value
		/// </summary>
		/// <param name="mapTableName">The Mapping Table</param>
		/// <returns>Number of records deleted</returns>
		public static int DeleteManyToMany(string pkColumnName, object pkValue, string mapTableName, string mapColumnName, int mapColumnValue)
		{
			
			string delSql = "DELETE FROM " + mapTableName + " WHERE " + pkColumnName + "=@pk AND " + mapColumnName + "=@map";
			QueryCommand cmd = new QueryCommand(delSql);
			
			//remove all records from the Map Table
			cmd.Parameters.Add("@pk", pkValue);
			cmd.Parameters.Add("@map", mapColumnValue);
			
			
			//execute it
			int iOut = DataService.ExecuteQuery(cmd);
			return iOut;
		}
		/// <summary>
		/// Deletes records from mapping table where the value this object's primary key value
		/// </summary>
		/// <param name="mapTableName">The Mapping Table</param>
		/// <returns>Number of records deleted</returns>
		public static int DeleteAllManyToMany(string pkColumnName, object pkValue, string mapTableName)
		{
			
			//remove all records from the Map Table
			string delSql = "DELETE FROM " + mapTableName + " WHERE " + pkColumnName + "=@pk";
			QueryCommand cmd = new QueryCommand(delSql);
			cmd.Parameters.Add("@pk", pkValue);
			
			//execute it
			int iOut = DataService.ExecuteQuery(cmd);
			return iOut;
		}
		
		/// <summary>
		/// Saves records to a mapping table. Deletes all associative records first
		/// </summary>
		/// <param name="mapTableName">The Mapping Table</param>
		/// <param name="mapTableForiegnField">The associated foreign key</param>
		/// <param name="items">ListItemCollection, such as a CheckList.Items</param>
		public static void SaveManyToMany(string pkColumnName, object pkValue, string mapTableName, string mapTableForiegnKey, ListItemCollection items)
		{
			//remove all existing
			DeleteAllManyToMany(pkColumnName, pkValue, mapTableName);
			QueryCommand cmd = null;
			QueryCommandCollection coll = new QueryCommandCollection();
			//loop the items and insert
			string iSql = "";
			foreach (ListItem l in items)
			{
				if (l.Selected)
				{
					
					iSql = "INSERT INTO " + mapTableName + " (" + pkColumnName + ", " + mapTableForiegnKey + ")" + " VALUES (@" + pkColumnName + ",@" + mapTableForiegnKey + ")";
					cmd = new QueryCommand(iSql);
					cmd.Parameters.Add("@" + pkColumnName, pkValue);
					cmd.Parameters.Add("@" + mapTableForiegnKey, l.Value);
					
					coll.Add(cmd);
					
				}
			}
			//execute
			DataService.ExecuteTransaction(coll);
			
		}
		#endregion
		
		#region Debugging
		public static void WriteTrace(string message)
		{
			if (DataService.EnableTrace)
			{
				if (HttpContext.Current != null&& HttpContext.Current.Trace.IsEnabled)
				{
					message = DateTime.Now.ToString("H:mm:ss:fff") + " > " + message;
					HttpContext.Current.Trace.Write("ACSWebFramework", message);
				}
				else if (System.Diagnostics.Trace.Listeners.Count > 0)
				{
					message = DateTime.Now.ToString("H:mm:ss:fff") + " > " + message;
					System.Diagnostics.Trace.WriteLine(message, "ACSWebFramework");
					System.Diagnostics.Debug.WriteLine(message, "ACSWebFramework");
					Console.WriteLine(message);
				}
			}
		}
		
		#endregion
		public static string ParseString(string sVal, string startTag, string EndTag)
		{
			string sIn = sVal;
			string sOut = "";
			int tagStart = sIn.ToLower().IndexOf(startTag.ToLower());
			
			try
			{
				sIn = sIn.Remove(0, tagStart);
				sIn = sIn.Replace(startTag, "");
				int tagEnd = sIn.ToLower().IndexOf(EndTag.ToLower());
				
				string sName = sIn.Substring(0, tagEnd);
				
				sOut = sName;
			}
			catch
			{
			}
			return sOut;
		}
		/// <summary>
		/// Returns the Xml representation of object-specific data as a string
		/// </summary>
		/// <returns></returns>
		public static string ObjectToXML(Type type, object obby)
		{
			//Create the serializer
			XmlSerializer ser = new XmlSerializer(type);
			using (System.IO.MemoryStream stm = new System.IO.MemoryStream())
			{
				
				//serialize to a memory stream
				ser.Serialize(stm, obby);
				
				//reset to beginning so we can read it.
				stm.Position = 0;
				//Convert a string.
				using (System.IO.StreamReader stmReader = new System.IO.StreamReader(stm))
				{
					string xmlData = stmReader.ReadToEnd();
					return xmlData;
				}
				
			}
			
			
		}
		
		public static object XmlToObject(Type type, string xml)
		{
			object oOut = null;
			//hydrate based on private string var
			if (xml != null)
			{
				if (xml.Length > 0)
				{
					try
					{
						System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
						System.Text.StringBuilder sb = new System.Text.StringBuilder();
						sb.Append(xml);
						System.IO.StringReader sReader = new System.IO.StringReader(xml);
						oOut = serializer.Deserialize(sReader);
						sb = null;
						sReader.Close();
					}
					catch (System.Exception)
					{
					}
					
				}
			}
			
			return oOut;
		}
		/// <summary>
		/// This method will examine the current URL for use of https. If https:// isn't present,
		/// the page will reset itself to the secure url. This does NOT happen for localhost.
		/// </summary>
		public static void TestForSSL()
		{
			
			//this is the current url
			System.Uri currentUrl = System.Web.HttpContext.Current.Request.Url;
			//don't redirect if this is localhost
			if (! currentUrl.IsLoopback)
			{
				if (! currentUrl.Scheme.Equals("https", StringComparison.CurrentCultureIgnoreCase))
				{
					////show a warning
					////System.Web.HttpContext.Current.Response.Write("<div style='height:30px; border:1px red solid;background-color:#ffffcc; font-weight:bold'>SSL is NOT enabled for this page which is a critical security issue. Please enable SSL on this page.</div>");
					////build the secure uri
					System.UriBuilder secureUrlBuilder = new UriBuilder(currentUrl);
					secureUrlBuilder.Scheme = "https";
					secureUrlBuilder.Port = - 1;
					//redirect and end the response.
					System.Web.HttpContext.Current.Response.Redirect(secureUrlBuilder.Uri.ToString(), true);
					//System.Web.HttpContext.Current.Response.Status = "301 Moved Permanently";
					//System.Web.HttpContext.Current.Response.AddHeader("Location", secureUrlBuilder.Uri.ToString());
				}
				
				
			}
		}
		
		/// <summary>
		/// Returns an SSL-enabled URL
		/// </summary>
		/// <returns></returns>
		public static string GetSecureRoot()
		{
			//this is the current url
			string siteUrl = Utility.GetSiteRoot();
			if (! siteUrl.ToLower().StartsWith("https://"))
			{
				siteUrl = siteUrl.Replace("http:", "https:");
			}
			return siteUrl;
		}
		
		/// <summary>
		/// Returns a regular URL
		/// </summary>
		/// <returns></returns>
		public static string GetNonSSLRoot()
		{
			//this is the current url
			return Utility.GetSiteRoot();
			
		}
		/// <summary>
		/// Rewrites an internal url like Product.aspx?id=1 to a nicely formatted URL
		/// that can be used for site navigation. These rules are simple; if you want to
		/// do more complex rewriting, UrlRewriter.NET is a very nice option.
		/// </summary>
		/// <param name="pageTo">This is a page where the request is going</param>
		/// <param name="paramValue">The querystring param value, usually the ID</param>
		/// <returns></returns>
		public static string GetRewriterUrl(string pageTo, string paramValue, string extendedQString)
		{
			string sOut = "";
			try
			{
				paramValue = paramValue.ToLower().Replace(" ", "");
				if (extendedQString != string.Empty)
				{
					extendedQString = "?" + extendedQString;
				}
				
			}
			catch
			{
				
			}
			if (pageTo.ToLower().Contains("catalog"))
			{
				//for the catalog, the name is passed along as a page
				sOut = Utility.GetSiteRoot() + "/catalog/" + paramValue + ".aspx" + extendedQString;
			}
			else if (pageTo.ToLower().Contains("product"))
			{
				//for the product, the sku is passed along
				sOut = Utility.GetSiteRoot() + "/product/" + paramValue + ".aspx" + extendedQString;
				
			}
			return sOut;
		}
		
		public static string ParseCamelToProper(string sIn)
		{
			
			char[] letters = sIn.ToCharArray();
			string sOut = "";
			foreach (char c in letters)
			{
				if (c.ToString() != c.ToString().ToLower())
				{
					//it's uppercase, add a space
					sOut += " " + c.ToString();
				}
				else
				{
					sOut += c.ToString();
					
				}
			}
			return sOut;
		}
		
		public static string MaskCreditCard(string cardNumber)
		{
			if (string.IsNullOrEmpty(cardNumber))
			{
				return string.Empty;
			}
			string lastFour = "XXXX";
			if (cardNumber.Length > 4)
			{
				//get the last 4 digits
				lastFour = cardNumber.Substring(cardNumber.Length - 4, 4);
			}
			else
			{
				
			}
			string ccNumReplaced = "";
			int i = 0;
			while (i < cardNumber.Length - 4)
			{
				ccNumReplaced += "X";
				i++;
			}
			ccNumReplaced += lastFour;
			return ccNumReplaced;
		}
		
		public static object StringToEnum(Type t, string Value)
		{
			object oOut = null;
			foreach (System.Reflection.FieldInfo fi in t.GetFields())
			{
				if (fi.Name.ToLower() == Value.ToLower())
				{
					oOut = fi.GetValue(null);
				}
			}
			return oOut;
		}
		
		public static string GetRandomString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(RandomString(4, false));
			builder.Append(RandomInt(1000, 9999));
			builder.Append(RandomString(2, false));
			return builder.ToString();
		}
		private static int RandomInt(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}
		private static string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			char ch;
			int i = 0;
			while (i < size)
			{
				ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
				builder.Append(ch);
				i++;
			}
			if (lowerCase)
			{
				return builder.ToString().ToLower();
			}
			return builder.ToString();
		}
		public static string GetSiteRoot()
		{
			string Port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
			if (Port == null || Port == "80" || Port == "443")
			{
				Port = "";
			}
			else
			{
				Port = ":" + Port;
			}
			
			string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
			if (Protocol == null || Protocol == "0")
			{
				Protocol = "http://";
			}
			else
			{
				Protocol = "https://";
			}
			
			string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
			if (appPath == "/")
			{
				appPath = "";
			}
			
			string sOut = Protocol + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + appPath;
			return sOut;
		}
		
		public static string GetParameter(string sParam)
		{
			
			if (! System.Web.HttpContext.Current.Request.QueryString[sParam] == null)
			{
				return System.Web.HttpContext.Current.Request[sParam].ToString();
			}
			else
			{
				return "";
			}
			
		}
		public static string GetUrlFromQueryString(string UrlParam)
		{
			if (! System.Web.HttpContext.Current.Request.QueryString[UrlParam] == null)
			{
				string excludeParam = System.Web.HttpContext.Current.Request[UrlParam].ToString();
				string sbNewQuery = excludeParam + "?";
				foreach (string paramValue in System.Web.HttpContext.Current.Request.QueryString)
				{
					if (paramValue != excludeParam)
					{
						sbNewQuery = string.Concat(sbNewQuery, paramValue, "&");
					}
				}
				return sbNewQuery.TrimEnd("&");
			}
			else
			{
				return "";
			}
		}
		public static string GetUrlFromQueryString(string UrlParam, System.Web.HttpContext Context)
		{
			if (! Context.Request.QueryString[UrlParam] == null)
			{
				string excludeParam = Context.Request[UrlParam].ToString();
				string sbNewQuery = excludeParam + "?";
				foreach (string paramValue in Context.Request.QueryString)
				{
					if (paramValue != excludeParam)
					{
						sbNewQuery = string.Concat(sbNewQuery, paramValue, "&");
					}
				}
				return sbNewQuery.TrimEnd("&");
			}
			else
			{
				return "";
			}
		}
		public static int GetIntParameter(string sParam)
		{
			int iOut = 0;
			if (! System.Web.HttpContext.Current.Request.QueryString[sParam] == null)
			{
				string sOut = System.Web.HttpContext.Current.Request[sParam].ToString();
				if (! string.IsNullOrEmpty(sOut))
				{
					int.TryParse(sOut, ref iOut);
				}
			}
			return iOut;
		}
		public static string ShortenText(object sIn, int length)
		{
			string sOut = sIn.ToString();
			if (sOut.Length > length)
			{
				sOut = sOut.Substring(0, length) + " ...";
			}
			return sOut;
			
		}
		public static void LoadDropDown(DropDownList ddl, ICollection collection, string textField, string valueField, string initialSelection)
		{
			ddl.DataSource = collection;
			ddl.DataTextField = textField;
			ddl.DataValueField = valueField;
			ddl.DataBind();
			
			ddl.SelectedValue = initialSelection;
		}
		public static void LoadListItems(System.Web.UI.WebControls.ListItemCollection list, DataTable tblBind, DataTable tblVals, string textField, string valField)
		{
			ListItem l;
			int i = 0;
			while (i < tblBind.Rows.Count)
			{
				l = new ListItem(tblBind.Rows[i][textField].ToString(), tblBind.Rows[i][valField].ToString());
				
				DataRow dr;
				int x = 0;
				while (x < tblVals.Rows.Count)
				{
					dr = tblVals.Rows[x];
					if (dr[valField].ToString().ToLower().Equals(l.Value.ToLower()))
					{
						l.Selected = true;
					}
					x++;
				}
				list.Add(l);
				i++;
			}
			
			
		}
		public static void LoadListItems(System.Web.UI.WebControls.ListItemCollection list, System.Data.IDataReader rdr, string textField, string valField, string selectedValue, bool closeReader)
		{
			ListItem l;
			string sText = "";
			string sVal = "";
			list.Clear();
			
			while (rdr.Read())
			{
				
				sText = rdr(textField).ToString();
				sVal = rdr(valField).ToString();
				
				l = new ListItem(sText, sVal);
				if (selectedValue != string.Empty)
				{
					if (selectedValue.ToLower() == sVal.ToLower())
					{
						l.Selected = true;
					}
				}
				list.Add(l);
			}
			if (closeReader)
			{
				rdr.Close();
			}
			
		}
		
		
		
		public static string GetFileText(string virtualPath)
		{
			//Read from file
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(virtualPath));
			}
			catch
			{
				sr = new StreamReader(virtualPath);
				
			}
			string strOut = sr.ReadToEnd();
			sr.Close();
			return strOut;
		}
		/// <summary>
		/// Updates the text in a file with the passed in values
		/// </summary>
		/// <param name="AbsoluteFilePath"></param>
		/// <param name="LookFor"></param>
		/// <param name="ReplaceWith"></param>
		public static void UpdateFileText(string AbsoluteFilePath, string LookFor, string ReplaceWith)
		{
			string sIn = GetFileText(AbsoluteFilePath);
			string sOut = sIn.Replace(LookFor, ReplaceWith);
			WriteToFile(AbsoluteFilePath, sOut);
		}
		/// <summary>
		/// Writes out a file
		/// </summary>
		/// <param name="AbsoluteFilePath"></param>
		/// <param name="fileText"></param>
		public static void WriteToFile(string AbsoluteFilePath, string fileText)
		{
			StreamWriter sw = new StreamWriter(AbsoluteFilePath, false);
			sw.Write(fileText);
			sw.Close();
			
		}
		public static void SetListSelection(System.Web.UI.WebControls.ListItemCollection lc, string Selection)
		{
			
			int i = 0;
			while (i < lc.Count)
			{
				if (lc[i].Value == Selection)
				{
					lc[i].Selected = true;
					break;
				}
				
				i++;
			}
		}
		
		
		public static string GetUserName()
		{
			
			string sUserName = "";
			if (HttpContext.Current.User.Identity.IsAuthenticated)
			{
				sUserName = HttpContext.Current.User.Identity.Name;
			}
			else
			{
				
				//we'll tag them with an anon userName until they register
				if (! HttpContext.Current.Request.Cookies["shopperID"] == null)
				{
					sUserName = HttpContext.Current.Request.Cookies["shopperID"].Value;
				}
				else
				{
					
					//if we have never seen them, return the current anonymous ID for the user
					sUserName = HttpContext.Current.Profile.UserName;
				}
			}
			HttpContext.Current.Response.Cookies["shopperID"].Value = sUserName;
			HttpContext.Current.Response.Cookies["shopperID"].Expires = DateTime.Today.AddDays(365);
			return sUserName;
		}
		
		#region Formatting bits
		#region IsNullOrEmpty
		
		public static bool IsNullOrEmpty(string text)
		{
			if (text == null || (text != null&& text.Length == 0))
			{
				return true;
			}
			
			return false;
		}
		
		#endregion
		
		#region CheckStringLength
		
		public static string CheckStringLength(string stringToCheck, int maxLength)
		{
			string checkedString = null;
			
			if (stringToCheck.Length <= maxLength)
			{
				return stringToCheck;
			}
			
			// If the string to check is longer than maxLength
			// and has no whitespace we need to trim it down.
			if ((stringToCheck.Length > maxLength) && (stringToCheck.IndexOf(" ") == - 1))
			{
				checkedString = stringToCheck.Substring(0, maxLength) + "...";
			}
			else if (stringToCheck.Length > 0)
			{
				string[] words;
				int expectedWhitespace = stringToCheck.Length / 8;
				
				// How much whitespace is there
				words = stringToCheck.Split(' ');
				
				checkedString = stringToCheck.Substring(0, maxLength) + "...";
			}
			else
			{
				checkedString = stringToCheck;
			}
			
			return checkedString;
		}
		
		#endregion
		
		#region FormatDate
		
		public static string FormatDate(DateTime theDate)
		{
			return FormatDate(theDate, false, null);
		}
		
		public static string FormatDate(DateTime theDate, bool showTime)
		{
			return FormatDate(theDate, showTime, null);
		}
		
		public static string FormatDate(DateTime theDate, bool showTime, string pattern)
		{
			string defaultDatePattern = "MMMM d, yyyy";
			string defaultTimePattern = "hh:mm tt";
			
			if (pattern == null)
			{
				if (showTime)
				{
					pattern = defaultDatePattern + " " + defaultTimePattern;
				}
				else
				{
					pattern = defaultDatePattern;
				}
			}
			
			return theDate.ToString(pattern);
		}
		
		#endregion
		
		#region UserIsAuthenticated
		
		public static bool UserIsAuthenticated()
		{
			HttpContext context = HttpContext.Current;
			
			if (context.User != null&& context.User.Identity != null&& (! Utility.IsNullOrEmpty(context.User.Identity.Name)))
			{
				return true;
			}
			
			return false;
		}
		
		#endregion
		
		#region StripHTML
		
		public static string StripHTML(string htmlString)
		{
			return StripHTML(htmlString, "", true);
		}
		
		public static string StripHTML(string htmlString, string htmlPlaceHolder)
		{
			return StripHTML(htmlString, htmlPlaceHolder, true);
		}
		
		public static string StripHTML(string htmlString, string htmlPlaceHolder, bool stripExcessSpaces)
		{
			string pattern = "<(.|\\n)*?>";
			string sOut = System.Text.RegularExpressions.Regex.Replace(htmlString, pattern, htmlPlaceHolder);
			sOut = sOut.Replace("&nbsp;", "");
			sOut = sOut.Replace("&amp;", "&");
			
			if (stripExcessSpaces)
			{
				// If there is excess whitespace, this will remove
				// like "THE      WORD".
				char[] delim = {' '};
				string[] lines = sOut.Split(delim, StringSplitOptions.RemoveEmptyEntries);
				
				sOut = "";
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				foreach (string s in lines)
				{
					sb.Append(s);
					sb.Append(" ");
				}
				return sb.ToString().Trim();
			}
			else
			{
				return sOut;
			}
			
		}
		
		#endregion
		
		#region ToggleHtmlBR
		
		public static string ToggleHtmlBR(string text, bool isOn)
		{
			string outS = "";
			
			if (isOn)
			{
				outS = text.Replace(Constants.vbLf, "<br />");
			}
			else
			{
				// TODO: do this with via regex
				//
				outS = text.Replace("<br />", Constants.vbLf);
				outS = text.Replace("<br>", Constants.vbLf);
				outS = text.Replace("<br >", Constants.vbLf);
			}
			
			return outS;
		}
		
		#endregion
		
		#endregion
		
	}
	
}
