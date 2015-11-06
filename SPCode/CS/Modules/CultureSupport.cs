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
using Microsoft.VisualBasic.CompilerServices;




namespace SoftLogik.Win
{
	sealed class CultureSupport
	{
		
		public enum TextReturnTypeEnum
		{
			PureString,
			RawString
		}
		
		private static Hashtable m_dctLanguageDictionary;
		
		public static System.Collections.Hashtable LanguageDictionary
		{
			get
			{
				return m_dctLanguageDictionary;
			}
			set
			{
				m_dctLanguageDictionary = value;
			}
		}
		public static string TextDictionary(string TextID, TextReturnTypeEnum ParseType)
		{
			try
			{
				switch (ParseType)
				{
					case TextReturnTypeEnum.PureString:
						return StringSupport.DeleteChar(LanguageDictionary[TextID.Trim()].ToString(), "&,:");
					case TextReturnTypeEnum.RawString:
						return LanguageDictionary[TextID.Trim()].ToString();
				}
			}
			catch (Exception)
			{
				
			}
			
			return Constants.vbNullString;
		}
	}
	
	sealed class DateSupport
	{
		public static bool DateCheck(string strValue)
		{
			bool returnValue;
			returnValue = true; // Assume True
			if (strValue != "")
			{
				if (! Information.IsDate(strValue))
				{
					return false;
				}
			}
			return returnValue;
		}
		
	}
	
	sealed class StringSupport
	{
		public static string Substitute(string sString, string sFind, string sReplace)
		{
			string returnValue;
			// Substitutes string sReplace in place of string sFind in sString
			int lEnd;
			int lStart;
			int lFindLength;
			string sNewString;
			
_1:
			sNewString = "";
_2:
			lFindLength = sFind.Length;
_3:
			lStart = 1;
_4:
			lEnd = sString.IndexOf(sFind, lStart - 1) + 1;
_5:
			while (lEnd > 0)
			{
_6:
				sNewString = sNewString + sString.Substring(lStart - 1, lEnd - lStart) + sReplace;
_7:
				lStart = lEnd + lFindLength;
_8:
				lEnd = sString.IndexOf(sFind, lStart - 1) + 1;
_9:
				1.GetHashCode() ; //nop
			}
_10:
			returnValue = sNewString + sString.Substring(lStart - 1);
			return returnValue;
		}
		public static string RemoveAmpersands(ref string strString)
		{
			// Removes the ampersands in the specified string.
1: RemoveAmpersands = Substitute(strString, "&", "");
		}
		public static string NullTruncate(string strText)
		{
			// Returns the specified string truncated at the first null character
			int lLen;
			
_1:
			lLen = strText.IndexOf(('\0').ToString()) + 1;
_2:
			if (lLen < 1)
			{
_3:
				return strText;
_4:
			}
			else
			{
_5:
				return strText.Substring(0, lLen - 1);
_6:
				1.GetHashCode() ; //nop
			}
		}
		public static string ResolveResString(short resID, params object[] varReplacements)
		{
			string returnValue;
			//-----------------------------------------------------------
			// FUNCTION: ResolveResString
			// Reads resource and replaces given macros with given values
			//
			// Example, given a resource number 14:
			//    "Could not read '|1' in drive |2"
			//   The call
			//     ResolveResString(14, "|1", "TXTFILE.TXT", "|2", "A:")
			//   would return the string
			//     "Could not read 'TXTFILE.TXT' in drive A:"
			//
			// IN: [resID] - resource identifier
			//     [varReplacements] - pairs of macro/replacement value
			//-----------------------------------------------------------
			//
			int intMacro;
			string strResString = Constants.vbNullString;
			
_1: //strResString = VB6.LoadResString(resID)

			// For each macro/value pair passed in...
_2:
			string strMacro;
			string strValue;
			int intPos;
			for (intMacro = 0; intMacro <= varReplacements.Length; intMacro += 2)
			{
				
_3: //UPGRADE_WARNING: Couldn't resolve default property of object varReplacements(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				strMacro = varReplacements[intMacro].ToString();
_4:
				//On Error Goto MismatchedPairs VBConversions Warning: On Error Goto not supported in C#
_5: //UPGRADE_WARNING: Couldn't resolve default property of object varReplacements(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				strValue = varReplacements[intMacro + 1].ToString();
_6:
				Microsoft.VisualBasic.CompilerServices.ProjectData.ClearProjectError();
				
				// Replace all occurrences of strMacro with strValue
_7:
				do
				{
_8:
					intPos = strResString.IndexOf(strMacro) + 1;
_9:
					if (intPos > 0)
					{
_10:
						strResString = strResString.Substring(0, intPos - 1) + strValue + strResString.Substring(strResString.Length - strResString.Length - strMacro.Length - intPos + 1, strResString.Length - strMacro.Length - intPos + 1);
_11:
						1.GetHashCode() ; //nop
					}
_12:
					1.GetHashCode() ; //nop
				} while (!(intPos == 0));
_13:
				1.GetHashCode() ; //nop
			}
			
_14:
			returnValue = strResString;
			
_15:
			return returnValue;
			
MismatchedPairs:
_16:
			1.GetHashCode() ; //nop
			//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
			return returnValue;
		}
		public static string DeleteChar(string SourceString, string SourceCharacters)
		{
			string returnValue;
			//-------------------------------------------------------------------------------
			//
			// DeleteChar - Function to delete a specified char in a passed string
			//              The characters might be separated by a comma ','
			//
			// Parameters:
			//    srField2String - I:   (String) holds the string to be processed
			//    srcChar   - I:   (String)holds the characters to remove from string
			//
			// Returns:
			//   String
			//
			// Comments:
			//   None.
			//
			//-------------------------------------------------------------------------------
			
			const string PkComma = ",";
			
			string[] astrSource;
			string finalString;
			string[] asrcSplitChar;
			
			if (SourceString == Constants.vbNullString)
			{
				returnValue = Constants.vbNullString;
				return returnValue;
			}
			
			//Extract the characters to delete from source string
			asrcSplitChar = Strings.Split(SourceCharacters, PkComma, -1, CompareMethod.Binary);
			
			//Exit if no characters to delete
			if (asrcSplitChar.Length == 0)
			{
				returnValue = SourceString;
				return returnValue;
			}
			
			finalString = SourceString;
			//Loop through the characters and delete each from source string
			foreach (string strChar in asrcSplitChar)
			{
				astrSource = Strings.Split(finalString, strChar, -1, CompareMethod.Binary);
				finalString = string.Join(Constants.vbNullString, astrSource);
			}
			
			
			returnValue = finalString;
			return returnValue;
		}
		
		public static bool ValidateEmail(string Expression)
		{
			string[] arrstrEmail;
			bool idOk;
			
			try
			{
				arrstrEmail = Expression.Split('@');
				if (arrstrEmail.Length > 0)
				{
					idOk = (StringType.StrLike(arrstrEmail[arrstrEmail.Length], "*.*", CompareMethod.Binary)) && (arrstrEmail[0] != Constants.vbNullString) && (arrstrEmail[(arrstrEmail.Length - 1)].Length > 3);
				}
			}
			catch (Exception)
			{
				
			}
			return idOk;
		}
		
		public static bool IsAlphabet(string strExp)
		{
			return Regex.IsMatch(strExp, "^[a-zA-Z]+$");
		}
		
		public static bool IsValidEmail(string strExp)
		{
			return Regex.IsMatch(strExp, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$");
		}
		
		public static bool IsValidTime(string strExp)
		{
			return Regex.IsMatch(strExp, "(([01]+[\\d]+)/(2[0-3])):[0-5]+[0-9]+");
		}
		
	}
	
	
}
