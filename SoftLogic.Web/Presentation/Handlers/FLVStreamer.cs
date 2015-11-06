using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SoftLogic.Web.Presentation.Handlers
{

    public class FLVStreamer : IHttpHandler
    {
        private static readonly byte[] _flvheader = HexToByte("464C5601010000000900000009"); //"FLV\x1\x1" + Constants.vbNullChar + Constants.vbNullChar + Constants.vbNullChar + "\x9" + Constants.vbNullChar + Constants.vbNullChar + Constants.vbNullChar + "\x9"

        public FLVStreamer()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                int pos = 0;
                int length = 0;

                // Check start parameter if present
                string filename = Path.GetFileName(context.Request.FilePath);

                using (FileStream fs = new FileStream(context.Server.MapPath(filename), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    string qs = context.Request.Params["start"];

                    if (string.IsNullOrEmpty(qs))
                    {
                        pos = 0;
                        length = Convert.ToInt32(fs.Length);
                    }
                    else
                    {
                        pos = Convert.ToInt32(qs);
                        length = Convert.ToInt32(fs.Length - pos) + _flvheader.Length;
                    }

                    // Add HTTP header stuff: cache, content type and length        
                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
                    context.Response.Cache.SetLastModified(DateTime.Now);

                    context.Response.AppendHeader("Content-Type", "video/x-flv");
                    context.Response.AppendHeader("Content-Length", length.ToString());

                    // Append FLV header when sending partial file
                    if (pos > 0)
                    {
                        context.Response.OutputStream.Write(_flvheader, 0, _flvheader.Length);
                        fs.Position = pos;
                    }

                    // Read buffer and write stream to the response stream
                    const int buffersize = 16384;
                    byte[] buffer = new byte[buffersize];

                    int count = fs.Read(buffer, 0, buffersize);
                    while (count > 0)
                    {
                        if (context.Response.IsClientConnected)
                        {
                            context.Response.OutputStream.Write(buffer, 0, count);
                            count = fs.Read(buffer, 0, buffersize);
                        }
                        else
                        {
                            count = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            int i = 0;
            while (i < returnBytes.Length)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                i += 1;
            }
            return returnBytes;
        }

    }
}
