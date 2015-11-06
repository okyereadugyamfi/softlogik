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
using System.Net;
using System.Net.Sockets;

namespace SoftLogik.Miscellaneous
{
  public class UdpClientDataGetter : IDataGetter
  {
    private int _port;
    private UdpClient _udpClient;

    public int Port
    {
      get { return _port; }
      set { _port = value; }
    }

    public UdpClientDataGetter(int port)
    {
      _port = port;
    }

    public byte[] GetData()
    {
      if (_udpClient == null)
        _udpClient = new UdpClient(_port);

      // I don't know why remoteEP parameter on Receive is ref
      // default this to null
      IPEndPoint remoteEndPoint = null;

      try
      {
        return _udpClient.Receive(ref remoteEndPoint);
      }
      catch (SocketException e)
      {
        // an exception will get thrown if UdpClient is waiting 
        // on receive and is closed
        if (e.SocketErrorCode == SocketError.Interrupted)
          return null;
        else
          throw;
      }
    }

    void IDisposable.Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_udpClient != null)
          _udpClient.Close();
      }
    }

    ~UdpClientDataGetter()
    {
      Dispose(false);
    }
  }
}