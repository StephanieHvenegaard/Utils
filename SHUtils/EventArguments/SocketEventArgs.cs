using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SHUtils.EventArguments
{

    class SocketEventArgs : SocketAsyncEventArgs
    {
        public SocketEventArgs(Socket socket)
        {
            this.AcceptSocket = socket;
        }
    }
}
