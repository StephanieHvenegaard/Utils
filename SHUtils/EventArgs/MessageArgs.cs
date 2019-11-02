using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.EventArguments
{
    /**********************************
     * Used in
     * SHutils.net.asyncClient
     * SHutils.net.asyncServer
     * SHutils.Logging.
     *********************************/
    public class MessageArgs : EventArgs
    {
        public MessageArgs()
        {
        }
        public MessageArgs(string s)
        {
            messege = s;
        }
        public string messege { get; set; }
    }
}
