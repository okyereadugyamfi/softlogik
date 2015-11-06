using System;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Text;
using System.Security.Principal;

namespace SoftLogik.Web
{
    public abstract class XmlResponseHandlerBase : Handlers.HandlerBase, IHttpHandler
	{
		public event EventHandler Error;

		protected abstract void WriteResult(XmlTextWriter result);

		public static void XmlResponse(HttpResponse response, Action<XmlTextWriter> writeAction)
		{
			response.ClearHeaders();
			response.ClearContent();
			response.ContentType = "text/xml";

			XmlTextWriter writer = new XmlTextWriter(response.Output);

			writeAction(writer);

			writer.Flush();
		}

		protected virtual void OnError(EventArgs e)
		{
			if (Error != null)
			{
				Error(this, e);
			}
		}

		void IHttpHandler.ProcessRequest(HttpContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			Context = context;

			try
			{
				XmlResponseHandlerBase.XmlResponse(context.Response, new Action<XmlTextWriter>(WriteResult));
			}
			catch (Exception exception)
			{
				context.AddError(exception);
				OnError(EventArgs.Empty);
				if (context.Error != null)
				{
					throw new HttpUnhandledException("blah", exception);
				}
			}
		}

		bool IHttpHandler.IsReusable
		{
			get { return false; }
		}
	}
}