//using System;
//using System.Collections.Generic;
//using System.ServiceModel.Channels;
//using System.ServiceModel.Dispatcher;
//using System.Text;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

//namespace SoftLogik
//{
//  public class ServiceGlobalExceptionHandler : IErrorHandler
//  {
//    public bool HandleError(Exception ex)
//    {
//      bool handled = !ExceptionPolicy.HandleException(ex, "Service Global");

//      return handled;
//    }

//    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
//    {
//    }
//  }
//}