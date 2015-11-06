using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Caching;

namespace SoftLogic.Web.Presentation.Handlers
{
public class FileResolver : IHttpHandler
{
	///<summary>File cache item used to store file content date entered into cache</summary>
    internal class FileCacheItem
    {
        internal string Content;
        internal System.DateTime DateEntered = DateTime.Now;

        internal FileCacheItem(string content)
        {
            this.Content = content;
        }
    }
    private FileCacheItem UpdateFileCache(HttpContext context, string filePath)
    {
        string content = null;

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            fs.Close();
        }

        //Get absolute application path
        string relAppPath = HttpRuntime.AppDomainAppVirtualPath;
        if (!(relAppPath.EndsWith("/")))
        {
            relAppPath += "/";
        }

        //Replace virtual paths w/ absolute path
        content = content.Replace("~/", relAppPath);

        FileCacheItem ci = new FileCacheItem(content);

        //Store the FileCacheItem in cache w/ a dependency on the file changing
        CacheDependency cd = new CacheDependency(filePath);
        context.Cache.Insert(filePath, ci, cd);
        return ci;
    }

    public void ProcessRequest(HttpContext context)
    {
        string absFilePath = context.Request.PhysicalPath.Replace(".ashx", "");

        //If a tilde was used in the page to this file, replace it w/ the app path
        if (absFilePath.IndexOf("~\\") > -1)
        {
            absFilePath = absFilePath.Replace("~", "").Replace("\\\\", "\\");
        }

        if (!(File.Exists(absFilePath)))
        {
            context.Response.StatusCode = 404;
            return;
        }

        FileCacheItem ci = (FileCacheItem)(context.Cache[absFilePath]);
        if (ci != null)
        {
            if (context.Request.Headers["If-Modified-Since"] != null)
            {
                try
                {
                    System.DateTime date = DateTime.Parse(context.Request.Headers["If-Modified-Since"]);

                    if (ci.DateEntered.ToString() == date.ToString())
                    {
                        //Don't do anything, nothing has changed since last request
                        context.Response.StatusCode = 304;
                        context.Response.StatusDescription = "Not Modified";
                        context.Response.End();
                        return;
                    }
                }
                catch (Exception e1)
                {
                }
            }
            else
            {
                //In the event that the browser doesn't automatically have this header, add it
                context.Response.AddHeader("If-Modified-Since", ci.DateEntered.ToString());
            }
        }
        else
        {
            //Cache item not found, update cache
            ci = UpdateFileCache(context, absFilePath);
        }

        context.Response.Cache.SetLastModified(ci.DateEntered);
        context.Response.ContentType = "text/" + GetContentType(Path.GetExtension(absFilePath));
        context.Response.Write(ci.Content);
        context.Response.End();
    }

    /// <summary>
    /// Gets the appropriate content type for a specified extension
    /// </summary>
    private string GetContentType(string ext)
    {
        switch (ext.ToLower())
        {
            case ".css":
                return "css";
            case ".xml":
                return "xml";
            case ".js":
                return "javascript";
            default:
                return "plain";
        }
    }

    #region IHttpHandler Members

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
    #endregion
}

}
