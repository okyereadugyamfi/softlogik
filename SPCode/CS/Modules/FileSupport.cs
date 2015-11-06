using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;


/// <summary>
/// Type of File Parsing
/// </summary>
namespace SoftLogik.Win
{
	public enum FileParseEnum
	{
		ParseFileOnly,
		ParsePathOnly,
		ParseDriveOnly,
		ParseExtensionOnly
	}
	
	sealed class FileSupport
	{
		
		public static string ParsePath(string strPath, FileParseEnum lngPart)
		{
			string returnValue;
			// This procedure takes a file path and returns
			// either the path, file, drive, or file extension portion,
			// depending on which constant was passed in.
			
			int lngPos;
			string strPart = Constants.vbNullString;
			bool blnIncludesFile;
			
			// Check that this is a file path.
			// Find the last path separator.
			lngPos = Strings.InStrRev(strPath, "\\", -1, 0);
			// Determine whether portion of string after last backslash
			// contains a period.
			blnIncludesFile = Strings.InStrRev(strPath, ".", -1, 0) > lngPos;
			
			if (lngPos > 0)
			{
				switch (lngPart)
				{
					// Return file name.
				case FileParseEnum.ParseFileOnly:
					if (blnIncludesFile)
					{
						strPart = Strings.Right(strPath, strPath.Length - lngPos);
					}
					else
					{
						strPart = "";
					}
					break;
					// Return path.
				case FileParseEnum.ParsePathOnly:
					if (blnIncludesFile)
					{
						strPart = Strings.Left(strPath, lngPos);
					}
					else
					{
						strPart = strPath;
					}
					break;
					// Return drive.
				case FileParseEnum.ParseDriveOnly:
					strPart = Strings.Left(strPath, 3);
					break;
					// Return file extension.
				case FileParseEnum.ParseExtensionOnly:
					if (blnIncludesFile)
					{
						// Take three characters after period.
						strPart = strPath.Substring(Strings.InStrRev(strPath, ".", -1, 0) + 1 - 1, 3);
					}
					else
					{
						strPart = "";
					}
					break;
				default:
					strPart = "";
					break;
			}
		}
		returnValue = strPart;
		
ParsePath_End:
		return returnValue;
		
	}
	
}


}
