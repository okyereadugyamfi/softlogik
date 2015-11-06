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
using System.Web;
using Microsoft.Win32;


namespace ACSGhana.Web.Framework
{
	public class DownloadService
	{
		
		
		
		
		//Sends primary file containing links To other files
		//  As one response To http request.
		//  Primary file - main HTML file
		//  OtherFiles - array of referenced files going with HTML document
		public static void SendFileWithImages(object PrimaryFile, object OtherFiles)
		{
			//Unique multipart boundary string.
			const string Boundary = "----=_NextPart_000_0000_01C31FDD.14FE27E0";
			HttpContext.Current.Response.ContentType = "message/rfc822";
			
			//mime header For files.
			HttpContext.Current.Response.Write(MimeHeader(PrimaryFile, Boundary));
			
			//Write primary file
			WriteFilePart(Boundary, PrimaryFile);
			
			//Write other files.
			
			foreach (object FileName in OtherFiles)
			{
				WriteFilePart(Boundary, FileName);
			}
			
			//Closing boundary
			HttpContext.Current.Response.Write("\r\n" + "--" + Boundary + "--");
		}
		
		//Write MIME header And HTML part For primary HTML
		private static void WriteMimeHeaderAndHTMLPart(string Boundary, string StartHTML)
		{
			string HTML = "MIME-Version: 1.0" + "\r\n";
			HTML = HTML + "Content-Type: multipart/related;" + "\r\n";
			HTML = HTML + "\t" + "type=\"text/html\";" + "\r\n";
			HTML = HTML + "\t" + "boundary=\"" + Boundary + "\"" + "\r\n";
			HTML = HTML + "\r\n" + "This is a multi-part message In MIME format." + "\r\n";
			
			HttpContext.Current.Response.Write(HTML);
			
			//Write boundary with file multipart header.
			HttpContext.Current.Response.Write("\r\n" + "--" + Boundary + "\r\n");
			HttpContext.Current.Response.Write("Content-Type: text/html" + "\r\n");
			HttpContext.Current.Response.Write("Content-Location: start.html" + "\r\n");
			
			//Write contents of the file. You can use BASE64 encoding For binary files.
			HttpContext.Current.Response.Write("\r\n");
			HttpContext.Current.Response.Write(StartHTML);
			HttpContext.Current.Response.Write("\r\n");
		}
		
		//write main MIME header of the document.
		public static object MimeHeader(string PrimaryFile, string Boundary)
		{
			object returnValue;
			string HTML = "MIME-Version: 1.0" + "\r\n";
			HTML = HTML + "Content-Type: multipart/related;" + "\r\n";
			//	HTML = HTML & vbTab & "type=""text/html"";" & vbCrLf
			HTML = HTML + "\t" + "type=\"" + GetContentType(PrimaryFile) + "\";" + "\r\n";
			//	HTML = HTML & vbTab & "start=""" & GetFileName(PrimaryFile) & """" & vbCrLf
			HTML = HTML + "\t" + "boundary=\"" + Boundary + "\"" + "\r\n";
			HTML = HTML + "\r\n" + "This is a multi-part message In MIME format." + "\r\n";
			returnValue = HTML;
			return returnValue;
		}
		
		//Write one mp header with contents.
		protected static void WriteFilePart(string Boundary, string FileName)
		{
			string CT = GetContentType(FileName);
			
			//Write boundary with file multipart header.
			HttpContext.Current.Response.Write("\r\n" + "--" + Boundary + "\r\n");
			HttpContext.Current.Response.Write("Content-Type: " + GetContentType(FileName) + "" + "\r\n");
			HttpContext.Current.Response.Write("Content-Location: " + GetFileName(FileName) + "" + "\r\n");
			//	Response.Write "Content-Disposition: attachment; filename=""" & GetFileName(FileName) & """" & vbCrLf
			//	Response.Write "Content-ID: " & GetFileName(FileName) & "" & vbCrLf
			
			//Write contents of the file. You can use BASE64 encoding For binary files.
			if (CT.Substring(0, 4) == "text")
			{
				HttpContext.Current.Response.Write("\r\n");
				HttpContext.Current.Response.BinaryWrite(ReadBinaryFile(FileName));
			}
			else
			{
				//Use Base64 For binary files.
				HttpContext.Current.Response.Write("\r\n");
				//		Response.Write "Content-Transfer-Encoding: base64" & vbCrLf
				HttpContext.Current.Response.BinaryWrite(ReadBinaryFile(FileName));
				//		Response.BinaryWrite GetFileAsBase64(FileName)
			}
			HttpContext.Current.Response.Write("\r\n");
		}
		
		
		
		
		
		public static object GetFileExtension(object FileName)
		{
			object Pos;
			Pos = Strings.InStrRev(FileName, ".", -1, 0);
			if (Pos > 0)
			{
				return Strings.Mid(FileName, Pos + 1);
			}
		}
		
		public static object GetContentType(object FileName)
		{
			object returnValue;
			returnValue = GetContentTypeByExt(GetFileExtension(FileName));
			return returnValue;
		}
		
		
		//This Function reads content type from windows registry
		public static object GetContentTypeByExt(object Extension)
		{
			//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
			return Registry.GetValue("HKCR\\." + Extension, "Content Type", "application/x-msdownload");
		}
		
		public static object SplitFileName(object FileName)
		{
			object returnValue;
			returnValue = Strings.InStrRev(FileName, "\\", -1, 0);
			return returnValue;
		}
		
		public static object GetFileName(object fullPath)
		{
			object returnValue;
			returnValue = Strings.Mid(fullPath, SplitFileName(fullPath) + 1);
			return returnValue;
		}
		
		
		public static byte[] ReadBinaryFile(string FileName)
		{
			FileStream BinaryStream = new FileStream(FileName, FileMode.Open);
			byte[] retBytes = null;
			BinaryStream.Read(retBytes, 0, BinaryStream.Length);
			return retBytes;
		}
		
		public static object GetFileSize(object FileName)
		{
			try
			{
				return (new FileInfo(FileName)).Length;
			}
			catch (System.Exception)
			{
				return - 1;
			}
		}
	}
	
}
