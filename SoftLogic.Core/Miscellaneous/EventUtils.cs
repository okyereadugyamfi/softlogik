#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace SoftLogik.Miscellaneous
{
  /// <summary>
  /// </summary>
  public static class EventUtils
  {
    public static void Raise<TDelegate>(TDelegate del, Action<TDelegate> raise) where TDelegate : class
    {
      if (del != null)
        raise(del);
    }

    public static void Raise<TEventArgs>(EventHandler<TEventArgs> del, object sender, TEventArgs args) where TEventArgs : EventArgs
    {
      if (del != null)
        del(sender, args);
    }

    public static TReturn Raise<TDelegate, TReturn>(TDelegate del, Func<TDelegate, TReturn> raise) where TDelegate : class
    {
      if (del != null)
        return raise(del);
      else
        return default(TReturn);
    }

    public static void RaiseAsync<TDelegate>(TDelegate del, Action<TDelegate> raise) where TDelegate : class
    {
      RaiseAsync<TDelegate>(del, raise, null);
    }

    public static void RaiseAsync<TDelegate>(TDelegate del, Action<TDelegate> raise, EventCallBack callback) where TDelegate : class
    {
      RaiseAsync<TDelegate, object>(del, delegate(TDelegate d)
                                         {
                                           // call Action inside dummy Action<T>
                                           raise(d);
                                           return null;
                                         },
                                         delegate (EventResult<object> result)
                                         {
                                           // call EventCallBack inside dummy EventCallBack<T>
                                           if (callback != null)
                                            callback(result);
                                         });
    }

    public static void RaiseAsync<TDelegate, TReturn>(TDelegate del, Func<TDelegate, TReturn> raise) where TDelegate : class
    {
      RaiseAsync<TDelegate, TReturn>(del, raise, null);
    }

    public static void RaiseAsync<TDelegate, TReturn>(TDelegate del, Func<TDelegate, TReturn> raise, EventCallBack<TReturn> callback) where TDelegate : class
    {
      if (del != null)
      {
        raise.BeginInvoke(del, delegate(IAsyncResult r)
                               {
                                 Exception eventException = null;
                                 TReturn returnValue = default(TReturn);

                                 try
                                 {
                                   // if an exception was thrown in the delegate, it will get raised here
                                   returnValue = raise.EndInvoke(r);
                                 }
                                 catch (Exception e)
                                 {
                                   eventException = e;
                                 }

                                 if (callback != null)
                                   callback(new EventResult<TReturn>(returnValue, eventException));
                               }, null);
      }
    }
  }
}