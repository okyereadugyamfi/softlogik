using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftLogik.Text; 


namespace SoftLogik
{
    public class Utility
    {

        public static void WriteTrace(string message)
        {
            if (HttpContext.Current != null && HttpContext.Current.Trace.IsEnabled)
            {
                message = DateTime.Now.ToString("H:mm:ss:fff") + " > " + message;
                HttpContext.Current.Trace.Write("SubSonic", message);
            }
            else if (System.Diagnostics.Debug.Listeners.Count > 0)
            {
                message = DateTime.Now.ToString("H:mm:ss:fff") + " > " + message;
                System.Diagnostics.Debug.WriteLine(message, "SoftLogik");
                Console.WriteLine(message);
            }
        }

        #region WebUtility

        /// <summary>
        /// Builds a simple HTML table from the passed-in datatable
        /// </summary>
        /// <param name="tbl">System.Data.DataTable</param>
        /// <param name="tableWidth">The width of the table</param>
        /// <returns>System.String</returns>
        public static string DataTableToHTML(DataTable tbl, string tableWidth)
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(tableWidth))
                tableWidth = "70%";

            if (tbl != null)
            {
                sb.Append("<table width=\"");
                sb.Append(tableWidth);
                sb.Append("\" cellpadding=\"4\" cellspacing=\"0\">");
                sb.Append("<thead bgcolor=\"gainsboro\">");

                //header
                foreach (DataColumn col in tbl.Columns)
                {
                    sb.Append("<th><b>");
                    sb.Append(col.ColumnName);
                    sb.Append("</b></th>");
                }
                sb.Append("</thead>");

                //rows
                bool isEven = false;
                foreach (DataRow dr in tbl.Rows)
                {
                    if (isEven)
                    {
                        sb.Append("<tr>");
                    }
                    else
                    {
                        sb.Append("<tr bgcolor=\"whitesmoke\">");

                    }
                    foreach (DataColumn col in tbl.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(dr[col].ToString());
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");

                    isEven = !isEven;

                }
                sb.Append("</table>");

            }

            return sb.ToString();
        }

        #endregion

        #region Tests

        public static bool IsLogicalDeleteColumn(string columnName)
        {
            return IsMatch(columnName, ReservedColumnName.DELETED) || IsMatch(columnName, ReservedColumnName.IS_DELETED);
        }

        public static bool IsAuditField(string colName)
        {
            return
                IsMatch(colName, ReservedColumnName.CREATED_BY) ||
                IsMatch(colName, ReservedColumnName.CREATED_ON) ||
                IsMatch(colName, ReservedColumnName.MODIFIED_BY) ||
                IsMatch(colName, ReservedColumnName.MODIFIED_ON);
        }

        public static bool IsMatch(string stringA, string stringB)
        {
            return String.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsMatch(string stringA, string stringB, bool trimStrings)
        {
            if (trimStrings)
            {
                return String.Equals(stringA.Trim(), stringB.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }
            return String.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsRegexMatch(string inputString, string matchPattern)
        {
            return Regex.IsMatch(inputString, matchPattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }

        public static string StripWhitespace(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, @"\s", String.Empty);
            }
            return inputString;
        }

        public static bool IsStringNumeric(string str)
        {
            double result;
            return (double.TryParse(str, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.CurrentInfo, out result));
        }

        public static bool IsNullableDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.Binary:
                //case DbType.Byte:
                case DbType.Object:
                case DbType.String:
                case DbType.StringFixedLength:
                    return false;
                default:
                    return true;
            }
        }

        public static bool UserIsAuthenticated()
        {
            HttpContext context = HttpContext.Current;

            if (context.User != null && context.User.Identity != null && !String.IsNullOrEmpty(context.User.Identity.Name))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Types
        public static bool IsParsable(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.Binary:
                case DbType.Guid:
                case DbType.Object:
                case DbType.String:
                case DbType.StringFixedLength:
                    return false;
                default:
                    return true;
            }
        }

        public static SqlDbType GetSqlDBType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString: return SqlDbType.VarChar;
                case DbType.AnsiStringFixedLength: return SqlDbType.Char;
                case DbType.Binary: return SqlDbType.VarBinary;
                case DbType.Boolean: return SqlDbType.Bit;
                case DbType.Byte: return SqlDbType.TinyInt;
                case DbType.Currency: return SqlDbType.Money;
                case DbType.Date: return SqlDbType.DateTime;
                case DbType.DateTime: return SqlDbType.DateTime;
                case DbType.Decimal: return SqlDbType.Decimal;
                case DbType.Double: return SqlDbType.Float;
                case DbType.Guid: return SqlDbType.UniqueIdentifier;
                case DbType.Int16: return SqlDbType.Int;
                case DbType.Int32: return SqlDbType.Int;
                case DbType.Int64: return SqlDbType.BigInt;
                case DbType.Object: return SqlDbType.Variant;
                case DbType.SByte: return SqlDbType.TinyInt;
                case DbType.Single: return SqlDbType.Real;
                case DbType.String: return SqlDbType.NVarChar;
                case DbType.StringFixedLength: return SqlDbType.NChar;
                case DbType.Time: return SqlDbType.DateTime;
                case DbType.UInt16: return SqlDbType.Int;
                case DbType.UInt32: return SqlDbType.Int;
                case DbType.UInt64: return SqlDbType.BigInt;
                case DbType.VarNumeric: return SqlDbType.Decimal;

                default:
                    {
                        return SqlDbType.VarChar;
                    }
            }
        }

        public static string GetSystemType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString: return "System.String";
                case DbType.AnsiStringFixedLength: return "System.String";
                case DbType.Binary: return "System.Byte[]";
                case DbType.Boolean: return "System.Boolean";
                case DbType.Byte: return "System.Byte";
                case DbType.Currency: return "System.Decimal";
                case DbType.Date: return "System.DateTime";
                case DbType.DateTime: return "System.DateTime";
                case DbType.Decimal: return "System.Decimal";
                case DbType.Double: return "System.Double";
                case DbType.Guid: return "System.Guid";
                case DbType.Int16: return "System.Int16";
                case DbType.Int32: return "System.Int32";
                case DbType.Int64: return "System.Int64";
                case DbType.Object: return "System.Object";
                case DbType.SByte: return "System.SByte";
                case DbType.Single: return "System.Single";
                case DbType.String: return "System.String";
                case DbType.StringFixedLength: return "System.String";
                case DbType.Time: return "System.TimeSpan";
                case DbType.UInt16: return "System.UInt16";
                case DbType.UInt32: return "System.UInt32";
                case DbType.UInt64: return "System.UInt64";
                case DbType.VarNumeric: return "System.Decimal";

                default:
                    {
                        return "System.String";
                    }
            }
        }

        public static string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length * 2);
            for (int i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("x2"));
            }
            return sOutput.ToString();
        }

        public static byte[] StringToByteArray(string str)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            byte[] unicodeBytes = unicode.GetBytes(str);
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
            return asciiBytes;
        }

        /// <summary>
        /// Returns an Object with the specified Type and whose value is equivalent to the specified object.
        /// </summary>
        /// <param name="value">An Object that implements the IConvertible interface.</param>
        /// <param name="conversionType">The Type to which value is to be converted.</param>
        /// <returns>An object whose Type is conversionType (or conversionType's underlying type if conversionType
        /// is Nullable&lt;&gt;) and whose value is equivalent to value. -or- a null reference, if value is a null
        /// reference and conversionType is not a value type.</returns>
        /// <remarks>
        /// This method exists as a workaround to System.Convert.ChangeType(Object, Type) which does not handle
        /// nullables as of version 2.0 (2.0.50727.42) of the .NET Framework. The idea is that this method will
        /// be deleted once Convert.ChangeType is updated in a future version of the .NET Framework to handle
        /// nullable types, so we want this to behave as closely to Convert.ChangeType as possible.
        /// This method was written by Peter Johnson at:
        /// http://aspalliance.com/author.aspx?uId=1026.
        /// </remarks>
        public static object ChangeType(object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            } // end if

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // It's a nullable type, so instead of calling Convert.ChangeType directly which would throw a
                // InvalidCastException (per http://weblogs.asp.net/pjohnson/archive/2006/02/07/437631.aspx),
                // determine what the underlying type is
                // If it's null, it won't convert to the underlying type, but that's fine since nulls don't really
                // have a type--so just return null
                // Note: We only do this check if we're converting to a nullable type, since doing it outside
                // would diverge from Convert.ChangeType's behavior, which throws an InvalidCastException if
                // value is null and conversionType is a value type.
                if (value == null)
                {
                    return null;
                } // end if

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            } // end if

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }

        #endregion

        #region String Manipulations
        public static string ParseCamelToProper(string sIn)
        {
            //No transformation if string is alread all caps
            if (Validation.IsUpperCase(sIn))
            {
                return sIn;
            }
            char[] letters = sIn.ToCharArray();
            StringBuilder sOut = new StringBuilder();
            int index = 0;

            if (sIn.Contains("ID"))
            {
                //just upper the first letter
                sOut.Append(letters[0]);
                sOut.Append(sIn.Substring(1, sIn.Length - 1));
            }
            else
            {
                foreach (char c in letters)
                {
                    if (index == 0)
                    {
                        sOut.Append(" ");
                        sOut.Append(c.ToString().ToUpper());
                    }
                    else if (Char.IsUpper(c))
                    {
                        //it's uppercase, add a space
                        sOut.Append(" ");
                        sOut.Append(c);
                    }
                    else
                    {
                        sOut.Append(c);
                    }
                    index++;
                }
            }
            return sOut.ToString().Trim();
        }

        public static string GetProperName(string sIn)
        {
            string propertyName = Inflector.ToPascalCase(sIn);
            if (propertyName.EndsWith("TypeCode"))
            {
                propertyName = propertyName.Substring(0, propertyName.Length - 4);
            }
            return propertyName;
        }


        public static string PluralToSingular(string sIn)
        {
            return Inflector.MakeSingular(sIn);
        }

        public static string SingularToPlural(string sIn)
        {
            return Inflector.MakePlural(sIn);
        }

        public static string KeyWordCheck(string word, string table, string appendWith)
        {
            string newWord = word + appendWith;

            if (word == "Schema")
                newWord = word + appendWith;

            //Can't have a property with same name as class.
            if (word == table)
                return newWord;

            switch (word.ToLower())
            {
                // C# keywords
                case "abstract": return newWord;
                case "as": return newWord;
                case "base": return newWord;
                case "bool": return newWord;
                case "break": return newWord;
                case "byte": return newWord;
                case "case": return newWord;
                case "catch": return newWord;
                case "char": return newWord;
                case "checked": return newWord;
                case "class": return newWord;
                case "const": return newWord;
                case "continue": return newWord;
                case "date": return newWord;
                case "datetime": return newWord;
                case "decimal": return newWord;
                case "default": return newWord;
                case "delegate": return newWord;
                case "do": return newWord;
                case "double": return newWord;
                case "else": return newWord;
                case "enum": return newWord;
                case "event": return newWord;
                case "explicit": return newWord;
                case "extern": return newWord;
                case "false": return newWord;
                case "finally": return newWord;
                case "fixed": return newWord;
                case "float": return newWord;
                case "for": return newWord;
                case "foreach": return newWord;
                case "goto": return newWord;
                case "if": return newWord;
                case "implicit": return newWord;
                case "in": return newWord;
                case "int": return newWord;
                case "interface": return newWord;
                case "internal": return newWord;
                case "is": return newWord;
                case "lock": return newWord;
                case "long": return newWord;
                case "namespace": return newWord;
                case "new": return newWord;
                case "null": return newWord;
                case "object": return newWord;
                case "operator": return newWord;
                case "out": return newWord;
                case "override": return newWord;
                case "params": return newWord;
                case "private": return newWord;
                case "protected": return newWord;
                case "public": return newWord;
                case "readonly": return newWord;
                case "ref": return newWord;
                case "return": return newWord;
                case "sbyte": return newWord;
                case "sealed": return newWord;
                case "short": return newWord;
                case "sizeof": return newWord;
                case "stackalloc": return newWord;
                case "static": return newWord;
                case "string": return newWord;
                case "struct": return newWord;
                case "switch": return newWord;
                case "this": return newWord;
                case "throw": return newWord;
                case "true": return newWord;
                case "try": return newWord;
                case "typeof": return newWord;
                case "uint": return newWord;
                case "ulong": return newWord;
                case "unchecked": return newWord;
                case "unsafe": return newWord;
                case "ushort": return newWord;
                case "using": return newWord;
                case "virtual": return newWord;
                case "volatile": return newWord;
                case "void": return newWord;
                case "while": return newWord;

                // C# contextual keywords
                case "get": return newWord;
                case "partial": return newWord;
                case "set": return newWord;
                case "value": return newWord;
                case "where": return newWord;
                case "yield": return newWord;

                // VB.NET keywords (commented out keywords that are the same as in C#)
                case "alias": return newWord;
                case "addHandler": return newWord;
                case "ansi": return newWord;
                //case "as": return newWord;
                case "assembly": return newWord;
                case "auto": return newWord;
                case "binary": return newWord;
                case "byref": return newWord;
                case "byval": return newWord;
                //case "case": return newWord;
                //case "catch": return newWord;
                //case "class": return newWord;
                case "custom": return newWord;
                //case "date": return newWord;
                //case "datetime": return newWord;
                //case "default": return newWord;
                case "directcast": return newWord;
                case "each": return newWord;
                //case "else": return newWord;
                case "elseif": return newWord;
                case "end": return newWord;
                case "error": return newWord;
                //case "false": return newWord;
                //case "finally": return newWord;
                //case "for": return newWord;
                case "friend": return newWord;
                case "global": return newWord;
                case "handles": return newWord;
                case "implements": return newWord;
                //case "in": return newWord;
                //case "is": return newWord;
                case "lib": return newWord;
                case "loop": return newWord;
                case "me": return newWord;
                case "module": return newWord;
                case "mustinherit": return newWord;
                case "mustoverride": return newWord;
                case "mybase": return newWord;
                case "myclass": return newWord;
                case "narrowing": return newWord;
                //case "new": return newWord;
                case "next": return newWord;
                case "nothing": return newWord;
                case "notinheritable": return newWord;
                case "notoverridable": return newWord;
                case "of": return newWord;
                case "off": return newWord;
                case "on": return newWord;
                case "option": return newWord;
                case "optional": return newWord;
                case "overloads": return newWord;
                case "overridable": return newWord;
                case "overrides": return newWord;
                case "paramarray": return newWord;
                //case "partial": return newWord;
                case "preserve": return newWord;
                //case "private": return newWord;
                case "property": return newWord;
                //case "protected": return newWord;
                //case "public": return newWord;
                case "raiseevent": return newWord;
                //case "readonly": return newWord;
                case "resume": return newWord;
                case "shadows": return newWord;
                case "shared": return newWord;
                //case "static": return newWord;
                case "step": return newWord;
                case "structure": return newWord;
                case "text": return newWord;
                case "then": return newWord;
                case "to": return newWord;
                //case "true": return newWord;
                case "trycast": return newWord;
                case "unicode": return newWord;
                case "until": return newWord;
                case "when": return newWord;
                //case "while": return newWord;
                case "widening": return newWord;
                case "withevents": return newWord;
                case "writeonly": return newWord;

                // VB.NET unreserved keywords
                case "compare": return newWord;
                //case "explicit": return newWord;
                case "isfalse": return newWord;
                case "istrue": return newWord;
                case "mid": return newWord;
                case "strict": return newWord;

                // SubSonic keywords
                case "schema": return newWord;

                default: return word;
            }
        }


        public static string FastReplace(string original, string pattern, string replacement, StringComparison comparisonType)
        {
            if (original == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(pattern))
            {
                return original;
            }

            int lenPattern = pattern.Length;
            int idxPattern = -1;
            int idxLast = 0;

            StringBuilder result = new StringBuilder();

            while (true)
            {
                idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

                if (idxPattern < 0)
                {
                    result.Append(original, idxLast, original.Length - idxLast);
                    break;
                }

                result.Append(original, idxLast, idxPattern - idxLast);
                result.Append(replacement);

                idxLast = idxPattern + lenPattern;
            }

            return result.ToString();
        }

        public static string StripText(string inputString, string stripString)
        {
            if (!String.IsNullOrEmpty(stripString))
            {
                string[] replace = stripString.Split(new char[] { ',' });
                for (int i = 0; i < replace.Length; i++)
                {
                    if (!String.IsNullOrEmpty(inputString))
                    {
                        inputString = Regex.Replace(inputString, replace[i], String.Empty);
                    }
                }
            }
            return inputString;
        }

        /// <summary>
        /// Replaces most non-alpha-numeric chars
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        public static string StripNonAlphaNumeric(string sIn)
        {
            //remove whitespace
            //sIn = sIn.Replace(" ", "");
            ////char[] chars = sIn.ToCharArray();
            //string result = "";
            StringBuilder sb = new StringBuilder(sIn);
            char c = " ".ToCharArray()[0];
            //these are illegal characters - remove zem
            string stripList = ".'?\\/><$!@%^*&+,;:\"{}[]|-#";

            for (int i = 0; i < stripList.Length; i++)
            {
                sb.Replace(stripList[i], c);
            }
            sb.Replace(" ", String.Empty);
            return sb.ToString();
        }

        /// <summary>
        /// Replaces any matches found in word from list.
        /// </summary>
        /// <param name="word">The string to check against.</param>
        /// <param name="find">A comma separated list of values to replace.</param>
        /// <param name="replaceWith">The value to replace with.</param>
        /// <param name="removeUnderscores">Whether or not underscores will be kept.</param>
        public static string Replace(string word, string find, string replaceWith, bool removeUnderscores)
        {
            string[] findList = Split(find);
            string newWord = word;
            foreach (string f in findList)
                if (f.Length > 0)
                    newWord = newWord.Replace(f, replaceWith);
            if (removeUnderscores)
                return newWord.Replace(" ", "").Replace("_", "").Trim();
            else
                return newWord.Replace(" ", "").Trim();
        }

        /// <summary>
        /// Finds a match in word using comma separted list.
        /// </summary>
        /// <param name="word">The string to check against.</param>
        /// <param name="list">A comma separted list of values to find.</param>
        /// <returns>true if a match is found or list is empty, otherwise false.</returns>
        public static bool StartsWith(string word, string list)
        {
            if (string.IsNullOrEmpty(list))
                return true;

            string[] find = Split(list);
            foreach (string f in find)
                if (word.StartsWith(f, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            return false;
        }

        /// <summary>
        /// A custom split method
        /// </summary>
        /// <param name="list">A list of values separated by either ", " or ","</param>
        public static string[] Split(string list)
        {
            string[] find;
            try
            {
                find = list.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                find = new string[] { string.Empty };
            }
            return find;
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

        public static string CheckStringLength(string stringToCheck, int maxLength)
        {
            string checkedString;

            if (stringToCheck.Length <= maxLength)
                return stringToCheck;

            // If the string to check is longer than maxLength 
            // and has no whitespace we need to trim it down.
            if ((stringToCheck.Length > maxLength) && (stringToCheck.IndexOf(" ") == -1))
            {
                checkedString = stringToCheck.Substring(0, maxLength) + "...";
            }
            else if (stringToCheck.Length > 0)
            {
                //string[] words;
                //int expectedWhitespace = stringToCheck.Length / 8;

                //// How much whitespace is there?
                //words = stringToCheck.Split(' ');

                checkedString = stringToCheck.Substring(0, maxLength) + "...";
            }
            else
            {
                checkedString = stringToCheck;
            }

            return checkedString;
        }

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
            string pattern = @"<(.|\n)*?>";
            string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
            sOut = sOut.Replace("&nbsp;", "");
            sOut = sOut.Replace("&amp;", "&");

            if (stripExcessSpaces)
            {
                // If there is excess whitespace, this will remove
                // like "THE      WORD".
                char[] delim = { ' ' };
                string[] lines = sOut.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                //sOut = "";
                StringBuilder sb = new StringBuilder();
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
        #endregion

        #region Conversions
        public static object StringToEnum(Type t, string Value)
        {
            object oOut = null;
            foreach (System.Reflection.FieldInfo fi in t.GetFields())
                if (IsMatch(fi.Name, Value))
                    oOut = fi.GetValue(null);
            return oOut;
        }

        #endregion

        #region URL Related
        public static string GetSiteRoot()
        {
            string port = HttpContext.Current.Request.ServerVariables[ServerVariable.SERVER_PORT];
            if (port == null || port == Ports.HTTP || port == Ports.HTTPS)
            {
                port = String.Empty;
            }
            else
            {
                port = ":" + port;
            }

            string protocol = HttpContext.Current.Request.ServerVariables[ServerVariable.SERVER_PORT_SECURE];
            if (protocol == null || protocol == "0")
            {
                protocol = ProtocolPrefix.HTTP;
            }
            else
            {
                protocol = ProtocolPrefix.HTTPS;
            }

            string appPath = HttpContext.Current.Request.ApplicationPath;
            if (appPath == "/")
            {
                appPath = String.Empty;
            }

            string sOut = protocol + HttpContext.Current.Request.ServerVariables[ServerVariable.SERVER_NAME] + port + appPath;
            return sOut;
        }

        public static string GetParameter(string sParam)
        {
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                return HttpContext.Current.Request[sParam];
            }
            else
            {
                return String.Empty;
            }
        }

        public static int GetIntParameter(string sParam)
        {
            int iOut = 0;
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string sOut = HttpContext.Current.Request[sParam];
                if (!String.IsNullOrEmpty(sOut))
                    int.TryParse(sOut, out iOut);
            }
            return iOut;
        }

        public static Guid GetGuidParameter(string sParam)
        {
            Guid gOut = Guid.Empty;
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string sOut = HttpContext.Current.Request[sParam];
                if (Validation.IsGuid(sOut))
                    gOut = new Guid(sOut);
            }
            return gOut;
        }

        #endregion

        #region Random Generators
        public static string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, false));
            builder.Append(RandomInt(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch;
                ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        #endregion

        #region Lists
        public static void LoadDropDown(DropDownList ddl, ICollection collection, string textField, string valueField, string initialSelection)
        {
            ddl.DataSource = collection;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();

            ddl.SelectedValue = initialSelection;
        }


        public static void LoadDropDown(DropDownList ddl, IDataReader rdr, bool closeReader)
        {
            ddl.Items.Clear();

            while (rdr.Read())
            {
                string sText = rdr[1].ToString();
                string sVal = rdr[0].ToString();

                ddl.Items.Add(new ListItem(sText, sVal));
            }
            if (closeReader)
            {
                rdr.Close();
            }
        }

        public static void LoadListItems(ListItemCollection list, DataTable tblBind, DataTable tblVals, string textField, string valField)
        {
            for (int i = 0; i < tblBind.Rows.Count; i++)
            {
                ListItem l = new ListItem(tblBind.Rows[i][textField].ToString(), tblBind.Rows[i][valField].ToString());

                for (int x = 0; x < tblVals.Rows.Count; x++)
                {
                    DataRow dr = tblVals.Rows[x];
                    if (IsMatch(dr[valField].ToString(), l.Value))
                    {
                        l.Selected = true;
                    }
                }
                list.Add(l);
            }
        }

        public static void LoadListItems(ListItemCollection list, IDataReader rdr, string textField, string valField, string selectedValue, bool closeReader)
        {
            list.Clear();

            while (rdr.Read())
            {
                string sText = rdr[textField].ToString();
                string sVal = rdr[valField].ToString();

                ListItem l;
                l = new ListItem(sText, sVal);
                if (!String.IsNullOrEmpty(selectedValue))
                {
                    if (IsMatch(selectedValue, sVal))
                    {
                        l.Selected = true;
                    }
                }
                list.Add(l);
            }
            if (closeReader)
                rdr.Close();
        }


        public static void SetListSelection(ListItemCollection lc, string Selection)
        {
            for (int i = 0; i < lc.Count; i++)
            {
                if (lc[i].Value == Selection)
                {
                    lc[i].Selected = true;
                    break;
                }
            }
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
                    pattern = defaultDatePattern + " " + defaultTimePattern;
                else
                    pattern = defaultDatePattern;
            }

            return theDate.ToString(pattern);
        }
        #endregion

        #region ToggleHtmlBR

        public static string ToggleHtmlBR(string text, bool isOn)
        {
            string outS;

            if (isOn)
                outS = text.Replace(Environment.NewLine, "<br />");
            else
            {
                // TODO: do this with via regex
                //
                outS = text.Replace("<br />", Environment.NewLine);
                outS = outS.Replace("<br>", Environment.NewLine);
                outS = outS.Replace("<br >", Environment.NewLine);
            }

            return outS;
        }

        #endregion
    }
}
