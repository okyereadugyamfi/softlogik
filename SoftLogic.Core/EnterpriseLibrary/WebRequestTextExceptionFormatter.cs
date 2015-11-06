//using System;
//using System.Data;
//using System.Configuration;
//using System.IO;
//using System.Text;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using System.Collections.Specialized;

//namespace SoftLogik.EnterpriseLibrary
//{
//    public class WebRequestTextExceptionFormatter : TextExceptionFormatter
//    {
//        public WebRequestTextExceptionFormatter(TextWriter writer, Exception exception)
//            : base(writer, exception)
//        {
//        }

//        protected override void WriteAdditionalInfo(NameValueCollection additionalInformation)
//        {
//            base.WriteAdditionalInfo(additionalInformation);

//            HttpContext context = HttpContext.Current;

//            if (context != null)
//            {
//                HttpRequest request = context.Request;
//                NameValueCollection httpHeaders = request.Headers;

//                HttpCookie[] httpCookies = new HttpCookie[request.Cookies.Count];
//                request.Cookies.CopyTo(httpCookies, 0);

//                NameValueCollection queryString = request.QueryString;
//                NameValueCollection form = request.Form;
//                NameValueCollection serverVariables = request.ServerVariables;

//                WriteSection(Writer, "Http Headers:", delegate(TextWriter tw)
//                    {
//                        WriteNameValueCollection(tw, httpHeaders, delegate(string name)
//                            {
//                                // don't write redundant headers
//                                return (string.CompareOrdinal(name, "Cookie") != 0);
//                            });
//                    });

//                WriteSection(Writer, "Http Cookies:", delegate(TextWriter tw)
//                    {
//                        foreach (HttpCookie cookie in httpCookies)
//                        {
//                            string value;

//                            if (cookie.HasKeys)
//                            {
//                                StringBuilder sb = new StringBuilder();

//                                foreach (string subKey in cookie.Values)
//                                {
//                                    sb.Append("(");
//                                    sb.Append(subKey);
//                                    sb.Append("=");
//                                    sb.Append(cookie[subKey]);
//                                    sb.Append(")  ");
//                                }

//                                value = sb.ToString();
//                            }
//                            else
//                            {
//                                value = cookie.Value;
//                            }

//                            tw.WriteLine(cookie.Name + " : " + value);
//                        }
//                    });

//                WriteSection(Writer, "Querystring:", delegate(TextWriter tw)
//                    {
//                        WriteNameValueCollection(tw, queryString);
//                    });

//                WriteSection(Writer, "Form:", delegate(TextWriter tw)
//                    {
//                        WriteNameValueCollection(tw, form);
//                    });

//                WriteSection(Writer, "Server Variables:", delegate(TextWriter tw)
//                    {
//                        WriteNameValueCollection(tw, serverVariables, delegate(string name)
//                            {
//                                // don't write redundant values
//                                return (string.CompareOrdinal(name, "ALL_HTTP") != 0
//                                    && string.CompareOrdinal(name, "ALL_RAW") != 0
//                                        && string.CompareOrdinal(name, "QUERY_STRING") != 0
//                                            && string.CompareOrdinal(name, "HTTP_COOKIE") != 0);
//                            });
//                    });
				
//                Writer.WriteLine();
//            }
//        }

//        private void WriteSection(TextWriter writer, string sectionTitle, Action<TextWriter> writerAction)
//        {
//            Writer.WriteLine();
//            Writer.WriteLine(sectionTitle);
//            Writer.WriteLine();

//            writerAction(writer);
//        }

//        private void WriteNameValueCollection(TextWriter writer, NameValueCollection nameValues)
//        {
//            WriteNameValueCollection(writer, nameValues, null);
//        }

//        private void WriteNameValueCollection(TextWriter writer, NameValueCollection nameValues, Predicate<string> filter)
//        {
//            // write all values if no filter is given,
//            // otherwise only write those that the filter returns true
//            foreach (string name in nameValues)
//            {
//                if (filter == null || filter(name))
//                    writer.WriteLine(name + " : " + nameValues[name]);
//            }
//        }
//    }
//}