﻿using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SoftLogik;

namespace SoftLogik.Text
{
    public static class Strings
    {


        private static readonly Dictionary<int, string> _entityTable = new Dictionary<int, string>();

        static Strings()
        {
            FillEntities();
        }

        public static string GetCommaSeparatedText(string sourceText)
        {
            string[] textArray = { };
            if (sourceText.Contains("\n"))
            {
                textArray = sourceText.Split("\n".ToCharArray());
            }

            if (sourceText.Contains(","))
            {
                textArray = sourceText.Split(',');
            }

            if (sourceText.Length > 0 && textArray.Length == 0)
            {

                return sourceText;
            }
            else
            {
                return string.Join(", ", textArray);
            }
        }

        public static string GetCommaSeparatedText(CheckBoxList sourceControl)
        {
            ListItemCollection sbuItems = sourceControl.Items;
            string resultantItems = string.Empty;
            foreach (ListItem item in sbuItems)
            {
                if (item.Selected)
                {
                    resultantItems += ", " + item.Value;
                }
            }
            return resultantItems.TrimStart(',');
        }

        /// <summary>
        /// Strips the last specified chars from a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Chop(string s, int removeFromEnd)
        {
            string result = s;
            if (s.Length > removeFromEnd - 1)
                result = result.Remove(s.Length - removeFromEnd, removeFromEnd);
            return result;
        }
        /// <summary>
        /// Strips the last specified chars from a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Chop(string s, string backDownTo)
        {

            int removeDownTo = s.LastIndexOf(backDownTo);
            int removeFromEnd = 0;
            if (removeDownTo > 0)
                removeFromEnd = s.Length - removeDownTo;

            string result = s;
            if (s.Length > removeFromEnd - 1)
                result = result.Remove(removeDownTo, removeFromEnd);
            return result;
        }
        /// <summary>
        /// Removes the specified chars from the beginning of a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Clip(string s, int removeFromBeginning)
        {
            string result = s;
            if (s.Length > removeFromBeginning)
                result = result.Remove(0, removeFromBeginning);
            return result;
        }

        /// <summary>
        /// Removes chars from the beginning of a string, up to the specified string
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Clip(string s, string removeUpTo)
        {
            int removeFromBeginning = s.IndexOf(removeUpTo);
            string result = s;
            if (s.Length > removeFromBeginning && removeFromBeginning > 0)
                result = result.Remove(0, removeFromBeginning);
            return result;
        }

        /// <summary>
        /// Strips the last char from a a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Chop(string s)
        {
            return Chop(s, 1);

        }

        /// <summary>
        /// Strips the last char from a a string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Clip(string s)
        {
            return Clip(s, 1);

        }
        /// <summary>
        /// Returns text that is located between the startText and endText tags.
        /// </summary>
        /// <param name="startText">The text from which to start the crop</param>
        /// <param name="endText">The endpoint of the crop</param>
        /// <returns></returns>
        public static string Crop(string input, string startText, string endText)
        {
            string sIn = input;
            string sOut;
            int cropStart = sIn.ToLower().IndexOf(startText.ToLower());

            try
            {
                sIn = sIn.Remove(0, cropStart);
                sIn = sIn.Replace(startText, "");
                int cropEnd = sIn.ToLower().IndexOf(endText.ToLower());

                sOut = sIn.Substring(0, cropEnd);

            }
            catch
            {
                sOut = "";
            }
            return sOut;
        }

        public static string Squeeze(string input)
        {
            char[] delim = { ' ' };
            string[] lines = input.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in lines)
            {
                if (!String.IsNullOrEmpty(s.Trim()))
                {
                    sb.Append(s + " ");
                }
            }
            //remove the last pipe
            string result = Chop(sb.ToString());
            return result.Trim();
        }

        /// <summary>
        /// Creates a string array based on the words in a sentence
        /// </summary>
        /// <param name="s">The string to parse</param>
        /// <returns></returns>
        public static string[] ToWords(string s)
        {
            string result = s.Trim();
            return result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Strips all HTML tags from a string
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static string StripHTML(string htmlString)
        {


            return StripHTML(htmlString, string.Empty);

        }

        /// <summary>
        /// Strips all HTML tags from a string and replaces the tags with the specified replacement
        /// </summary>
        /// <param name="htmlString"></param>
        /// <param name="htmlPlaceHolder"></param>
        /// <returns></returns>
        public static string StripHTML(string htmlString, string htmlPlaceHolder)
        {

            string pattern = @"<(.|\n)*?>";
            string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
            sOut = sOut.Replace("&nbsp;", "");
            sOut = sOut.Replace("&amp;", "&");
            sOut = sOut.Replace("&gt;", ">");
            sOut = sOut.Replace("&lt;", "<");
            return sOut;
        }


        /// <summary>
        /// Convert string to proper case
        /// </summary>
        /// <param name="sIn">The string to be converted</param>
        /// <returns></returns>
        public static string ToProper(string sIn)
        {
            string propertyName = Inflector.ToPascalCase(sIn);
            if (propertyName.EndsWith("TypeCode"))
            {
                propertyName = propertyName.Substring(0, propertyName.Length - 4);
            }
            return propertyName;
        }

        /// <summary>
        /// Camels to proper.
        /// </summary>
        /// <param name="sIn">The s in.</param>
        /// <returns></returns>
        public static string CamelToProper(string sIn)
        {
            return Utility.ParseCamelToProper(sIn);
        }

        /// <summary>
        /// Plurals to singular.
        /// </summary>
        /// <param name="sIn">The s in.</param>
        /// <returns></returns>
        public static string PluralToSingular(string sIn)
        {
            return Inflector.MakeSingular(sIn);
        }

        /// <summary>
        /// Singulars to plural.
        /// </summary>
        /// <param name="sIn">The s in.</param>
        /// <returns></returns>
        public static string SingularToPlural(string sIn)
        {
            return Inflector.MakePlural(sIn);
        }

        /// <summary>
        /// Strips the specified input.
        /// </summary>
        /// <param name="input">The input text</param>
        /// <param name="stripValue">The strip value.</param>
        /// <returns></returns>
        public static string Strip(string input, string stripValue)
        {
            if (!String.IsNullOrEmpty(stripValue))
            {
                string[] replace = stripValue.Split(new char[] { ',' });
                for (int i = 0; i < replace.Length; i++)
                {
                    if (!String.IsNullOrEmpty(input))
                    {
                        input = Regex.Replace(input, replace[i], String.Empty);
                    }
                }
            }
            return input;
        }

        /// <summary>
        /// Replaces most non-alpha-numeric chars
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        public static string StripNonAlphaNumeric(string sIn)
        {
            return SoftLogik.Utility.StripNonAlphaNumeric(sIn);
        }

        public static string AsciiToUnicode(int asciiCode)
        {
            Encoding ascii = Encoding.UTF32;
            char c = (char)asciiCode;
            Byte[] b = ascii.GetBytes(c.ToString());
            return ascii.GetString((b));
        }

        public static string TextToEntity(string textString)
        {
            foreach (KeyValuePair<int, string> key in _entityTable)
            {
                textString = textString.Replace(AsciiToUnicode(key.Key), key.Value);
            }
            return textString.Replace(AsciiToUnicode(38), "&amp;");
        }

        public static string EntityToText(string entityText)
        {
            entityText = entityText.Replace("&amp;", "&");
            foreach (KeyValuePair<int, string> key in _entityTable)
            {
                entityText = entityText.Replace(key.Value, AsciiToUnicode(key.Key));
            }
            return entityText;
        }

        private static void FillEntities()
        {
            _entityTable.Add(160, "&nbsp;");
            _entityTable.Add(161, "&iexcl;");
            _entityTable.Add(162, "&cent;");
            _entityTable.Add(163, "&pound;");
            _entityTable.Add(164, "&curren;");
            _entityTable.Add(165, "&yen;");
            _entityTable.Add(166, "&brvbar;");
            _entityTable.Add(167, "&sect;");
            _entityTable.Add(168, "&uml;");
            _entityTable.Add(169, "&copy;");
            _entityTable.Add(170, "&ordf;");
            _entityTable.Add(171, "&laquo;");
            _entityTable.Add(172, "&not;");
            _entityTable.Add(173, "&shy;");
            _entityTable.Add(174, "&reg;");
            _entityTable.Add(175, "&macr;");
            _entityTable.Add(176, "&deg;");
            _entityTable.Add(177, "&plusmn;");
            _entityTable.Add(178, "&sup2;");
            _entityTable.Add(179, "&sup3;");
            _entityTable.Add(180, "&acute;");
            _entityTable.Add(181, "&micro;");
            _entityTable.Add(182, "&para;");
            _entityTable.Add(183, "&middot;");
            _entityTable.Add(184, "&cedil;");
            _entityTable.Add(185, "&sup1;");
            _entityTable.Add(186, "&ordm;");
            _entityTable.Add(187, "&raquo;");
            _entityTable.Add(188, "&frac14;");
            _entityTable.Add(189, "&frac12;");
            _entityTable.Add(190, "&frac34;");
            _entityTable.Add(191, "&iquest;");
            _entityTable.Add(192, "&Agrave;");
            _entityTable.Add(193, "&Aacute;");
            _entityTable.Add(194, "&Acirc;");
            _entityTable.Add(195, "&Atilde;");
            _entityTable.Add(196, "&Auml;");
            _entityTable.Add(197, "&Aring;");
            _entityTable.Add(198, "&AElig;");
            _entityTable.Add(199, "&Ccedil;");
            _entityTable.Add(200, "&Egrave;");
            _entityTable.Add(201, "&Eacute;");
            _entityTable.Add(202, "&Ecirc;");
            _entityTable.Add(203, "&Euml;");
            _entityTable.Add(204, "&Igrave;");
            _entityTable.Add(205, "&Iacute;");
            _entityTable.Add(206, "&Icirc;");
            _entityTable.Add(207, "&Iuml;");
            _entityTable.Add(208, "&ETH;");
            _entityTable.Add(209, "&Ntilde;");
            _entityTable.Add(210, "&Ograve;");
            _entityTable.Add(211, "&Oacute;");
            _entityTable.Add(212, "&Ocirc;");
            _entityTable.Add(213, "&Otilde;");
            _entityTable.Add(214, "&Ouml;");
            _entityTable.Add(215, "&times;");
            _entityTable.Add(216, "&Oslash;");
            _entityTable.Add(217, "&Ugrave;");
            _entityTable.Add(218, "&Uacute;");
            _entityTable.Add(219, "&Ucirc;");
            _entityTable.Add(220, "&Uuml;");
            _entityTable.Add(221, "&Yacute;");
            _entityTable.Add(222, "&THORN;");
            _entityTable.Add(223, "&szlig;");
            _entityTable.Add(224, "&agrave;");
            _entityTable.Add(225, "&aacute;");
            _entityTable.Add(226, "&acirc;");
            _entityTable.Add(227, "&atilde;");
            _entityTable.Add(228, "&auml;");
            _entityTable.Add(229, "&aring;");
            _entityTable.Add(230, "&aelig;");
            _entityTable.Add(231, "&ccedil;");
            _entityTable.Add(232, "&egrave;");
            _entityTable.Add(233, "&eacute;");
            _entityTable.Add(234, "&ecirc;");
            _entityTable.Add(235, "&euml;");
            _entityTable.Add(236, "&igrave;");
            _entityTable.Add(237, "&iacute;");
            _entityTable.Add(238, "&icirc;");
            _entityTable.Add(239, "&iuml;");
            _entityTable.Add(240, "&eth;");
            _entityTable.Add(241, "&ntilde;");
            _entityTable.Add(242, "&ograve;");
            _entityTable.Add(243, "&oacute;");
            _entityTable.Add(244, "&ocirc;");
            _entityTable.Add(245, "&otilde;");
            _entityTable.Add(246, "&ouml;");
            _entityTable.Add(247, "&divide;");
            _entityTable.Add(248, "&oslash;");
            _entityTable.Add(249, "&ugrave;");
            _entityTable.Add(250, "&uacute;");
            _entityTable.Add(251, "&ucirc;");
            _entityTable.Add(252, "&uuml;");
            _entityTable.Add(253, "&yacute;");
            _entityTable.Add(254, "&thorn;");
            _entityTable.Add(255, "&yuml;");
            _entityTable.Add(402, "&fnof;");
            _entityTable.Add(913, "&Alpha;");
            _entityTable.Add(914, "&Beta;");
            _entityTable.Add(915, "&Gamma;");
            _entityTable.Add(916, "&Delta;");
            _entityTable.Add(917, "&Epsilon;");
            _entityTable.Add(918, "&Zeta;");
            _entityTable.Add(919, "&Eta;");
            _entityTable.Add(920, "&Theta;");
            _entityTable.Add(921, "&Iota;");
            _entityTable.Add(922, "&Kappa;");
            _entityTable.Add(923, "&Lambda;");
            _entityTable.Add(924, "&Mu;");
            _entityTable.Add(925, "&Nu;");
            _entityTable.Add(926, "&Xi;");
            _entityTable.Add(927, "&Omicron;");
            _entityTable.Add(928, "&Pi;");
            _entityTable.Add(929, "&Rho;");
            _entityTable.Add(931, "&Sigma;");
            _entityTable.Add(932, "&Tau;");
            _entityTable.Add(933, "&Upsilon;");
            _entityTable.Add(934, "&Phi;");
            _entityTable.Add(935, "&Chi;");
            _entityTable.Add(936, "&Psi;");
            _entityTable.Add(937, "&Omega;");
            _entityTable.Add(945, "&alpha;");
            _entityTable.Add(946, "&beta;");
            _entityTable.Add(947, "&gamma;");
            _entityTable.Add(948, "&delta;");
            _entityTable.Add(949, "&epsilon;");
            _entityTable.Add(950, "&zeta;");
            _entityTable.Add(951, "&eta;");
            _entityTable.Add(952, "&theta;");
            _entityTable.Add(953, "&iota;");
            _entityTable.Add(954, "&kappa;");
            _entityTable.Add(955, "&lambda;");
            _entityTable.Add(956, "&mu;");
            _entityTable.Add(957, "&nu;");
            _entityTable.Add(958, "&xi;");
            _entityTable.Add(959, "&omicron;");
            _entityTable.Add(960, "&pi;");
            _entityTable.Add(961, "&rho;");
            _entityTable.Add(962, "&sigmaf;");
            _entityTable.Add(963, "&sigma;");
            _entityTable.Add(964, "&tau;");
            _entityTable.Add(965, "&upsilon;");
            _entityTable.Add(966, "&phi;");
            _entityTable.Add(967, "&chi;");
            _entityTable.Add(968, "&psi;");
            _entityTable.Add(969, "&omega;");
            _entityTable.Add(977, "&thetasym;");
            _entityTable.Add(978, "&upsih;");
            _entityTable.Add(982, "&piv;");
            _entityTable.Add(8226, "&bull;");
            _entityTable.Add(8230, "&hellip;");
            _entityTable.Add(8242, "&prime;");
            _entityTable.Add(8243, "&Prime;");
            _entityTable.Add(8254, "&oline;");
            _entityTable.Add(8260, "&frasl;");
            _entityTable.Add(8472, "&weierp;");
            _entityTable.Add(8465, "&image;");
            _entityTable.Add(8476, "&real;");
            _entityTable.Add(8482, "&trade;");
            _entityTable.Add(8501, "&alefsym;");
            _entityTable.Add(8592, "&larr;");
            _entityTable.Add(8593, "&uarr;");
            _entityTable.Add(8594, "&rarr;");
            _entityTable.Add(8595, "&darr;");
            _entityTable.Add(8596, "&harr;");
            _entityTable.Add(8629, "&crarr;");
            _entityTable.Add(8656, "&lArr;");
            _entityTable.Add(8657, "&uArr;");
            _entityTable.Add(8658, "&rArr;");
            _entityTable.Add(8659, "&dArr;");
            _entityTable.Add(8660, "&hArr;");
            _entityTable.Add(8704, "&forall;");
            _entityTable.Add(8706, "&part;");
            _entityTable.Add(8707, "&exist;");
            _entityTable.Add(8709, "&empty;");
            _entityTable.Add(8711, "&nabla;");
            _entityTable.Add(8712, "&isin;");
            _entityTable.Add(8713, "&notin;");
            _entityTable.Add(8715, "&ni;");
            _entityTable.Add(8719, "&prod;");
            _entityTable.Add(8721, "&sum;");
            _entityTable.Add(8722, "&minus;");
            _entityTable.Add(8727, "&lowast;");
            _entityTable.Add(8730, "&radic;");
            _entityTable.Add(8733, "&prop;");
            _entityTable.Add(8734, "&infin;");
            _entityTable.Add(8736, "&ang;");
            _entityTable.Add(8743, "&and;");
            _entityTable.Add(8744, "&or;");
            _entityTable.Add(8745, "&cap;");
            _entityTable.Add(8746, "&cup;");
            _entityTable.Add(8747, "&int;");
            _entityTable.Add(8756, "&there4;");
            _entityTable.Add(8764, "&sim;");
            _entityTable.Add(8773, "&cong;");
            _entityTable.Add(8776, "&asymp;");
            _entityTable.Add(8800, "&ne;");
            _entityTable.Add(8801, "&equiv;");
            _entityTable.Add(8804, "&le;");
            _entityTable.Add(8805, "&ge;");
            _entityTable.Add(8834, "&sub;");
            _entityTable.Add(8835, "&sup;");
            _entityTable.Add(8836, "&nsub;");
            _entityTable.Add(8838, "&sube;");
            _entityTable.Add(8839, "&supe;");
            _entityTable.Add(8853, "&oplus;");
            _entityTable.Add(8855, "&otimes;");
            _entityTable.Add(8869, "&perp;");
            _entityTable.Add(8901, "&sdot;");
            _entityTable.Add(8968, "&lceil;");
            _entityTable.Add(8969, "&rceil;");
            _entityTable.Add(8970, "&lfloor;");
            _entityTable.Add(8971, "&rfloor;");
            _entityTable.Add(9001, "&lang;");
            _entityTable.Add(9002, "&rang;");
            _entityTable.Add(9674, "&loz;");
            _entityTable.Add(9824, "&spades;");
            _entityTable.Add(9827, "&clubs;");
            _entityTable.Add(9829, "&hearts;");
            _entityTable.Add(9830, "&diams;");
            _entityTable.Add(34, "&quot;");
            //_entityTable.Add(38, "&amp;");
            _entityTable.Add(60, "&lt;");
            _entityTable.Add(62, "&gt;");
            _entityTable.Add(338, "&OElig;");
            _entityTable.Add(339, "&oelig;");
            _entityTable.Add(352, "&Scaron;");
            _entityTable.Add(353, "&scaron;");
            _entityTable.Add(376, "&Yuml;");
            _entityTable.Add(710, "&circ;");
            _entityTable.Add(732, "&tilde;");
            _entityTable.Add(8194, "&ensp;");
            _entityTable.Add(8195, "&emsp;");
            _entityTable.Add(8201, "&thinsp;");
            _entityTable.Add(8204, "&zwnj;");
            _entityTable.Add(8205, "&zwj;");
            _entityTable.Add(8206, "&lrm;");
            _entityTable.Add(8207, "&rlm;");
            _entityTable.Add(8211, "&ndash;");
            _entityTable.Add(8212, "&mdash;");
            _entityTable.Add(8216, "&lsquo;");
            _entityTable.Add(8217, "&rsquo;");
            _entityTable.Add(8218, "&sbquo;");
            _entityTable.Add(8220, "&ldquo;");
            _entityTable.Add(8221, "&rdquo;");
            _entityTable.Add(8222, "&bdquo;");
            _entityTable.Add(8224, "&dagger;");
            _entityTable.Add(8225, "&Dagger;");
            _entityTable.Add(8240, "&permil;");
            _entityTable.Add(8249, "&lsaquo;");
            _entityTable.Add(8250, "&rsaquo;");
            _entityTable.Add(8364, "&euro;");
        }


        [Obsolete("Will be removed in future versions. Use Validation.IsAlpha instead")]
        public static bool IsAlpha(string s)
        {
            return Validation.IsAlpha(s);
        }

        [Obsolete("Will be removed in future versions. Use Validation.IsAlphaNumeric instead")]
        public static bool IsAlphaNumeric(string s)
        {
            return Validation.IsAlphaNumeric(s);
        }

    }

}
