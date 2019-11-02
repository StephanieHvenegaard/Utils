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
     * SHutils.Logging.ChangedLogEvent
     *********************************/
    public class MessageArgs : EventArgs
    {
        string _Message;
        bool _IsDebug;
        public MessageArgs()
        {
        }
        public MessageArgs(string message)
        {
            _Message = message;
            _IsDebug = false;
        }
        public MessageArgs(string message, bool isDebug) : this(message)
        {
            _IsDebug = isDebug;
        }
        public string Messege { get { return _Message; } }
        public bool IsDebug { get { return _IsDebug; } }
    }
}
