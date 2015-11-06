//#region License
//// Copyright (c) 2007, James Newton-King
//// All rights reserved.
////
//// Redistribution and use in source and binary forms, with or without
//// modification, are permitted provided that the following conditions are met:
////     * Redistributions of source code must retain the above copyright
////       notice, this list of conditions and the following disclaimer.
////     * Redistributions in binary form must reproduce the above copyright
////       notice, this list of conditions and the following disclaimer in the
////       documentation and/or other materials provided with the distribution.
////     * Neither the name of the Newtonsoft nor the
////       names of its contributors may be used to endorse or promote products
////       derived from this software without specific prior written permission.
////
//// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ``AS IS''
//// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//// DISCLAIMED. IN NO EVENT SHALL <copyright holder> BE LIABLE FOR ANY
//// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//#endregion

//using System;
//using System.Collections.ObjectModel;
//using System.ServiceModel;
//using System.ServiceModel.Channels;
//using System.ServiceModel.Description;
//using System.ServiceModel.Dispatcher;

//namespace SoftLogik.Services
//{
//  public class ErrorBehaviorAttribute : Attribute, IServiceBehavior
//  {
//    private readonly Type _errorHandlerType;

//    public ErrorBehaviorAttribute(Type errorHandlerType)
//    {
//      _errorHandlerType = errorHandlerType;
//    }

//    void IServiceBehavior.Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
//    {
//    }

//    void IServiceBehavior.AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
//    {
//    }

//    void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
//    {
//      IErrorHandler errorHandler;

//      try
//      {
//        errorHandler = (IErrorHandler)Activator.CreateInstance(_errorHandlerType);
//      }
//      catch (MissingMethodException e)
//      {
//        throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must have a public empty constructor.", e);
//      }
//      catch (InvalidCastException e)
//      {
//        throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
//      }

//      foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
//      {
//        ChannelDispatcher channelDispatcher = (ChannelDispatcher)channelDispatcherBase;
//        channelDispatcher.ErrorHandlers.Add(errorHandler);
//      }
//    }
//  }
//}