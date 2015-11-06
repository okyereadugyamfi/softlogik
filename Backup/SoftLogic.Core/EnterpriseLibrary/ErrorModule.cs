//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

//namespace SoftLogik
//{
//  public class ErrorModule : IHttpModule
//  {
//    public void Dispose()
//    {
//    }

//    public void Init(HttpApplication context)
//    {
//      context.Error += new EventHandler(Error);
//    }

//    private void Error(object sender, EventArgs e)
//    {
//      HttpApplication application = (HttpApplication)sender;
//      HttpContext context = application.Context;
      
//      Exception ex = context.Server.GetLastError();

//      // unwrap unhandled exception
//      if (ex is HttpUnhandledException && ex.InnerException != null)
//        ex = ex.InnerException;

//      bool rethrow = ExceptionPolicy.HandleException(ex, "Exception Policy");

//      if (!rethrow)
//        context.Server.ClearError();
//    }
//  }
//}