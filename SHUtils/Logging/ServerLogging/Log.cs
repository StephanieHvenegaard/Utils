using SHUtils.EventArguments;
using System;
using System.Windows.Forms;

namespace SHUtils.Logging.ServerLogging
{ 
    public delegate void ChangedLogEvent(object sender, EventArgs e);

    public class Log
    {
        // A delegate type for hooking up change notifications.
        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public static event ChangedLogEvent Changed;

        private static string SystemTag =       "[System]        : ";
        private static string SocketClientTag = "[Socket:Client] : ";
        private static string SocketPokeTag =   "[Socket:Poke]   : ";
        private static string SocketServerTag = "[Socket:Server] : ";
        private static string LapstimeTag =     "[LapsTime]      : ";
        private static string EventTag =        "[Event]         : ";
        private static string WarningTag =      "[Warning]       : ";
        private static string ErrorTag =        "[Error]         : ";
        private static string _FormatDatetime = "yyyy-MM-dd";
        private static string _PathLapstimeLog = AppDomain.CurrentDomain.BaseDirectory;
        private static string _PathSysLog = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Defaults to format YYYY-MM-DD, if not set
        /// </summary>
        public static string FormatDatetime { get { return _FormatDatetime; } set { _FormatDatetime = value; } }
        /// <summary>
        /// Defaults to the Running Dir, if not set
        /// </summary>
        public static string PathLapstimeLog { get { return _PathLapstimeLog; } set { _PathLapstimeLog = value; } }
        /// <summary>
        /// Defaults to the Running Dir, if not set
        /// </summary>
        public static string PathSysLog { get { return _PathSysLog; } set { _PathSysLog = value; } }
        public static string SysLogPrefix { get; set; }
        public static string LapstimeLogPrefix { get; set; }
        // -------------------------------------------------------
        // Logging   
        // -------------------------------------------------------
        // Log Pattern:
        // -------------------------------------------------------
        // sWorkingOn = "what are we doing"
        // startProcces = DateTime.Now;
        // Log.System(sWorkingOn));
        // Do stuff
        // EndProcces = DateTime.Now;
        // Log.System("Done" + Environment.NewLine + Log.LapsTime(startProcces, EndProcces, sWorkingOn));
        // Log.Spacer());
        // -------------------------------------------------------
        public static void OnNewLogEvent(string Line)
        {
            if (Changed != null)
            {
                MessegeEventArgs ea = new MessegeEventArgs(Line);
                Changed(new Log(), ea);
            }
        }
        //--------------------------------------------------------------------------------------------------
        public static string Spacer()
        {
            string Line = SystemTag + "------------Spacer------------";
            return WriteSystemLog(Line);
        }
        public static string System(string Line)
        {
            Line = SystemTag + Line;
            try
            {
                SystemLog.LogLine(Line);
            }
            catch (Exception e)
            {
                return (SystemTag + "Failed To log, Error Messege: " + e.Message);
            }
            OnNewLogEvent(Line);
            return Line;
        }
        public static string LapsTime(DateTime Start, DateTime End, string Method)
        { string Line="";
            try
            {
                Line = LapstimeTag + (LapsTimeLog.GenerateLapsTime(Start, End).TotalSeconds != 0 ? LapsTimeLog.GenerateLapsTime(Start, End).TotalSeconds + " s." : LapsTimeLog.GenerateLapsTime(Start, End).TotalMilliseconds + " ms.");
                LapsTimeLog.LogALapsTime(Start, End, Method);
                //SystemLog.LogLine(Line);
            
            }
            catch (Exception e)
            {
                Line= LapstimeTag+"Failed To log, Error Messege: " + e.Message;
            }
            OnNewLogEvent(Line);
            return Line;
        }
        public static string SocketPoke(string Line)
        {
            Line = SocketPokeTag + Line;
            return WriteSystemLog(Line); 
        }
        public static string SocketClient(string Line)
        {
            Line = SocketClientTag + Line;
            return WriteSystemLog(Line);
        }
        public static string SocketServer(string Line)
        {
            Line = SocketServerTag + Line;
            return WriteSystemLog(Line);
        }
        public static string Event(string Line)
        {
            Line = EventTag + Line;
            return WriteSystemLog(Line);
        }
        public static string Warning(string Line)
        {
            Line = WarningTag + Line;
            return WriteSystemLog(Line);
        }
        public static string Error(string Line)
        {
            Line = ErrorTag + Line;
            return WriteSystemLog(Line);
        }
        private static string WriteSystemLog(string Line)
        {
            try
            {
                SystemLog.LogLine(Line);
            }
            catch (Exception e)
            {
                Line = SocketClientTag+"Failed To log, Error Messege: " + e.Message;
            }
            OnNewLogEvent(Line);
            return Line;
        }
    }
}
