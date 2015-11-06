using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using SoftLogic.Core.Utilities;

namespace SoftLogic.Web.Presentation.Support
{
    public static class WebSupport
    {
        
        /// <summary>
        /// Queries the string.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static t QueryString<t>(string param)
        {
            t result = default(t);

            if (HttpContext.Current.Request.QueryString[param] != null)
            {
                object paramValue = HttpContext.Current.Request[param];
                result = (t)Utility.ChangeType(paramValue, typeof(t));
            }

            return result;
        }

        /// <summary>
        /// Cookies the specified param.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static t Cookie<t>(string param)
        {
            t result = default(t);
            if (HttpContext.Current.Request.Cookies[param] != null)
            {
                string paramValue = HttpContext.Current.Request.Cookies[param].Value;
                result = (t)Utility.ChangeType(paramValue, typeof(t));
            }

            return result;
        }

        /// <summary>
        /// Sessions the value.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static t SessionValue<t>(string param)
        {
            t result = default(t);
            if (HttpContext.Current.Session[param] != null)
            {
                object paramValue = HttpContext.Current.Session[param];
                result = (t)Utility.ChangeType(paramValue, typeof(t));
            }

            return result;
        }

        /// <summary>
        /// Gets a ViewState value on a Page.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public static t PageValue<t>(string param)
        {
            t result = default(t);
            //Page currentHandler = (Page)HttpContext.Current.Handler;

            //if (currentHandler.ViewState[param] != null)
            //{
            //    object paramValue = currentHandler.ViewState[param];
            //    result = (t)Utility.ChangeType(paramValue, typeof(t));
            //}

            return result;
        }

        //many thanks to ASP Alliance for the code below
        //http://authors.aspalliance.com/olson/methods/

        /// <summary>
        /// Fetches a web page
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ReadWebPage(string url)
        {
            WebRequest request = HttpWebRequest.Create(url);
            Stream stream = request.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string webPage = sr.ReadToEnd();
            sr.Close();

            return webPage;
        }

        /// <summary>
        /// Gets DNS information about a url and puts it in an array of strings
        /// </summary>
        /// <param name="url">either an ip address or a host name</param>
        /// <returns>a list with the host name, all the aliases, and all the addresses. </returns>
        public static string[] DNSLookup(string url)
        {
            ArrayList al = new ArrayList();

            //check whether url is ipaddress or hostname
            IPHostEntry ipEntry = Dns.GetHostEntry(url);

            al.Add("HostName," + ipEntry.HostName);

            foreach (string name in ipEntry.Aliases)
            {
                al.Add("Aliases," + name);
            }

            foreach (IPAddress ip in ipEntry.AddressList)
            {
                al.Add("Address," + ip);
            }
            string[] ipInfo = (string[])al.ToArray(typeof(string));

            return ipInfo;
        }

        /// <summary>
        /// Scrapes the image tags from a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns>string array of all images on a page</returns>
        public static string[] ScrapeImages(string url)
        {
            //get the content of the url
            //ReadWebPage is another method in this useful methods collection
            string htmlPage = ReadWebPage(url);

            //set up the regex for finding images
            StringBuilder imgPattern = new StringBuilder();
            imgPattern.Append("<img[^>]+"); //start 'img' tag
            imgPattern.Append("src\\s*=\\s*"); //start src property
            //three possibilities  for what src property --
            //(1) enclosed in double quotes
            //(2) enclosed in single quotes
            //(3) enclosed in spaces
            imgPattern.Append("(?:\"(?<src>[^\"]*)\"|'(?<src>[^']*)'|(?<src>[^\"'>\\s]+))");
            imgPattern.Append("[^>]*>"); //end of tag
            Regex imgRegex = new Regex(imgPattern.ToString(), RegexOptions.IgnoreCase);

            //look for matches 
            Match imgcheck = imgRegex.Match(htmlPage);
            ArrayList imagelist = new ArrayList();
            //add base href for relative urls
            imagelist.Add("<BASE href=\"" + url + "\">" + url);
            while (imgcheck.Success)
            {
                string src = imgcheck.Groups["src"].Value;
                string image = "<img src=\"" + src + "\">";
                imagelist.Add(image);
                imgcheck = imgcheck.NextMatch();
            }
            string[] images = new string[imagelist.Count];
            imagelist.CopyTo(images);

            return images;
        }

        /// <summary>
        /// Scrapes a web page and parses out all the links.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="makeLinkable"></param>
        /// <returns></returns>
        public static string[] ScrapeLinks(string url, bool makeLinkable)
        {
            //get the content of the url
            //ReadWebPage is another method in this useful methods collection
            string htmlPage = ReadWebPage(url);

            //set up the regex for finding the link urls
            StringBuilder hrefPattern = new StringBuilder();
            hrefPattern.Append("<a[^>]+"); //start 'a' tag and anything that comes before 'href' tag
            hrefPattern.Append("href\\s*=\\s*"); //start href property
            //three possibilities  for what href property --
            //(1) enclosed in double quotes
            //(2) enclosed in single quotes
            //(3) enclosed in spaces
            hrefPattern.Append("(?:\"(?<href>[^\"]*)\"|'(?<href>[^']*)'|(?<href>[^\"'>\\s]+))");
            hrefPattern.Append("[^>]*>.*?</a>"); //end of 'a' tag
            Regex hrefRegex = new Regex(hrefPattern.ToString(), RegexOptions.IgnoreCase);

            //look for matches 
            Match hrefcheck = hrefRegex.Match(htmlPage);
            ArrayList linklist = new ArrayList();
            //add base href for relative links
            linklist.Add("<BASE href=\"" + url + "\">" + url);
            while (hrefcheck.Success)
            {
                string href = hrefcheck.Groups["href"].Value; //link url
                string link = (makeLinkable)
                  ? "<a href=\"" + href + "\" target=\"_blank\">" + href + "</a>" : href;
                linklist.Add(link);
                hrefcheck = hrefcheck.NextMatch();
            }
            string[] links = new string[linklist.Count];
            linklist.CopyTo(links);

            return links;
        }

        /// <summary>
        /// Calls the Gravatar service to and returns an HTML <img></img> tag for use on your pages.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="size">The size of the Gravatar image - 60 is standard</param>
        /// <returns>HTML image tag</returns>
        public static string GetGravatar(string email, int size)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.ASCII.GetBytes(email));

            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            for (int i = 0; i < result.Length; i++)
                hash.Append(result[i].ToString("x2"));

            System.Text.StringBuilder image = new System.Text.StringBuilder();
            image.Append("<img src=\"");
            image.Append("http://www.gravatar.com/avatar.php?");
            image.Append("gravatar_id=" + hash.ToString());
            image.Append("&amp;rating=G");
            image.Append("&amp;size=" + size);
            image.Append("&amp;default=");
            image.Append(System.Web.HttpContext.Current.Server.UrlEncode("http://example.com/noavatar.gif"));
            image.Append("\" alt=\"\" />");
            return image.ToString();
        }
        /// <summary>
        /// Whether or not the request originated from the local network, or more specifically from localhost or a NAT address.
        /// This property is only accurate if NAT addresses are a valid indicators of a request being from within the internal network.
        /// </summary>
        public static bool IsLocalNetworkRequest
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Request.IsLocal)
                    {
                        return true;
                    }
                    string hostPrefix = HttpContext.Current.Request.UserHostAddress;
                    string[] ipClass = hostPrefix.Split(new char[] { '.' });
                    int classA = Convert.ToInt16(ipClass[0]);
                    int classB = Convert.ToInt16(ipClass[1]);
                    if (classA == 10 || classA == 127)
                    {
                        return true;
                    }
                    else if (classA == 192 && classB == 168)
                    {
                        return true;
                    }
                    else if (classA == 172 && (classB > 15 && classB < 33))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }

        /// <summary>
        /// Given a valid email address, returns a short javascript block that will emit a valid
        /// mailto: link that can't be picked up by address harvesters. Call this method where you
        /// would normally place the link in your html code.
        /// </summary>
        /// <param name="emailText">The email address to convert to spam-free format</param>
        /// <returns></returns>
        public static string CreateSpamFreeEmailLink(string emailText)
        {
            if (!String.IsNullOrEmpty(emailText))
            {
                string[] parts = emailText.Split(new char[] { '@' });
                if (parts.Length == 2)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("var m = '" + parts[0] + "';");
                    sb.Append("var a = '" + parts[1] + "';");
                    sb.Append("var l = '" + emailText + "';");
                    sb.Append("document.write('<a href=\"mailto:' + m + '@' + a + '\">' + l + '</a>');");
                    sb.Append("</script>");
                    return sb.ToString();
                }
            }
            return String.Empty;
        }

    }

}
