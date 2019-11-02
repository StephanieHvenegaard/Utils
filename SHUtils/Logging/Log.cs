using SHUtils.EventArguments;
using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SHUtils.Logging
{
    /**********************************
     * Used in
     * ProeventServer2
     * Projectmaneger2
    *********************************/
    public delegate void ChangedLogEventHandler(object sender, MessageArgs e);

    public class Log
    {
        // A delegate type for hooking up change notifications.
        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public static event ChangedLogEventHandler SystemLogChanged;
        public static event ChangedLogEventHandler LapstimeLogChanged;

        private static string SystemTag =           "[System]             : ";
        private static string SocketClientTag =     "[Socket:Client]      : ";
        private static string SocketPokeTag =       "[Socket:Poke]        : ";
        private static string SocketServerTag =     "[Socket:Server]      : ";
        private static string SocketServersAliveTag = "[Socket:ServerAlive] : ";
        private static string LapstimeTag =         "[LapsTime]           : ";
        private static string EventTag =            "[Event]              : ";
        private static string WarningTag =          "[Warning]            : ";
        private static string ErrorTag =            "[Error]              : ";
        private static string InfoTag =             "[Info]               : ";
        private static string NewLineTag =          "                     : ";
        private static string _FormatDatetime = "yyyy-MM-dd";
        private static string _PathLapstimeLog = AppDomain.CurrentDomain.BaseDirectory;
        private static string _PathSysLog = AppDomain.CurrentDomain.BaseDirectory;
        private static bool _AddLapsTimesInSysLog = true;
        private static bool _ReturnTagsInMethods = true;
        private static bool _AddTimeStampsToSyslog = true;
        private static int _SpacerWidth = 10; 
        public static int TagWidth { get { return SystemTag.Length; } }      
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
        /// <summary>
        /// Prefix to the log name.
        /// </summary>
        public static string LogPrefix { get; set; }
        /// <summary>
        /// The width of the spacer int the logs, it defaults to 10, if not set
        /// </summary>
        public static int SpacerWidth { get { return _SpacerWidth; } set { _SpacerWidth = value; } }
        /// <summary>
        /// Return the log tags.
        /// </summary>
        public static bool ReturnTagsInMethods { get { return _ReturnTagsInMethods; } set { _ReturnTagsInMethods = value; } }
        public static bool AddLapsTimesInSysLog { get { return _AddLapsTimesInSysLog; } set { _AddLapsTimesInSysLog = value; } }
        public static bool AddTimeStampsToSyslog { get { return _AddTimeStampsToSyslog; } set { _AddTimeStampsToSyslog = value; } }  
        private static void OnLogSystemChanged(string line, bool isDebug)
        {
            if (SystemLogChanged != null)
            {
                MessageArgs ea = new MessageArgs(line, isDebug);
                SystemLogChanged(new Log(), ea);
            }
        }
        private static void OnLogLapstimeChanged(string line, bool isDebug)
        {
            if (LapstimeLogChanged != null)
            {
                MessageArgs ea = new MessageArgs(line, isDebug);
                LapstimeLogChanged(new Log(), ea);
            }
        }
        //--------------------------------------------------------------------------------------------------
        private static string LogStringBuilderLabstime(TimeSpan Span)
        {
            return /*LapstimeTag + /*"For " + Method +*/ " " + (Span.Seconds != 0 ? Span.TotalSeconds + " s." : Span.TotalMilliseconds + " ms.");
        }
        public static string Spacer()
        { return Spacer(false); }
        public static string Spacer(bool isDebug)
        {
            /* try
             {*/

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < SpacerWidth; i++)
            {
                sb1.Append("-");
            }
            sb2.Append(SystemTag);
            sb2.Append(sb1.ToString());
            sb2.Append(" Spacer ");
            sb2.Append(sb1.ToString());
            return WriteSystemLog(sb2.ToString(), isDebug);
        }
        public static string System(string line)
        {
            return System(line, false);
        }
        public static string System(string Line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = SystemTag + Line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a SystemLog; Message: {0}", e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return Line;
        }
        public static string SocketServersAlive(string line)
        {
            return SocketServersAlive(line, false);
        }
        public static string SocketServersAlive(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = SocketServersAliveTag + line;
                WriteSystemLog(TagLine, isDebug);
            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a SystemLog; Message: {0}", e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        /// <summary>
        /// Speed. 2.0050 ms avg
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public static string LapsTime(DateTime start, DateTime end, string method)
        {
            return LapsTime(start, end, method, false);
        }
        public static string LapsTime(DateTime start, DateTime end, string method, bool isDebug)
        {
            {
                string TagLine = "";
                string Line = "";
                try
                {
                    Line = LogStringBuilderLabstime((end - start));
                    TagLine = LapstimeTag + method + Line;
                    WriteLapstimeLog(start,end,method,TagLine, isDebug);
                }
                catch (Exception e)
                {
                    Warning(string.Format("Failed to at a this timepan {0}, it started: {1} and ended {2}, the Error message was: {3}",
                        (end - start), start, end, e.Message),
                        isDebug);
                }
                if (_ReturnTagsInMethods) return TagLine;
                else return Line;
            }
        }
        /// <summary>
        /// Speed. 0.7896 ms avg
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public static string LapsTime(double elapsedMilliseconds,DateTime end, string method)
        {
            return LapsTime(elapsedMilliseconds,end, method, false);
        }
        public static string LapsTime(double elapsedMilliseconds, DateTime end, string method, bool isDebug)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(elapsedMilliseconds);
            return LapsTime(ts, end, method, isDebug);
        }
        /// <summary>
        /// Speed. 0.8366 ms avg
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        public static string LapsTime(TimeSpan span, DateTime end, string method)
          {
              return LapsTime(span, end, method, false);
          }
        public static string LapsTime(TimeSpan span, DateTime end, string method, bool isDebug)
         {
             string TagLine = "";
             string Line = "";
             try
             {
                 DateTime start = end.AddMilliseconds(-(span.TotalMilliseconds));
                 Line = LogStringBuilderLabstime(span);
                 TagLine = LapstimeTag + method + Line;
                 WriteLapstimeLog(start,end, method, TagLine, isDebug);
             }
             catch (Exception e)
             {
                 Warning(string.Format("Failed to at a this timepan {0}, the Error message was: {1}", span, e.Message), isDebug);
             }
             if (_ReturnTagsInMethods) return TagLine;
             else return Line;
         }
        public static string SocketPoke(string line)
        {
            return SocketPoke(line, false);
        }
        public static string SocketPoke(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = SocketPokeTag + line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a SocketPoke-Log; Message: " + e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string SocketClient(string line)
        {
            return SocketClient(line, false);
        }
        public static string SocketClient(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = SocketClientTag + line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a SocketClient-Log; Message: {0}", e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string SocketServer(string line)
        {
            return SocketServer(line, false);
        }
        public static string SocketServer(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = SocketServerTag + line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a SocketServer-Log; Message: {0}", e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string Event(string line)
        {
            return Event(line, false);
        }
        public static string Event(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = EventTag + line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a Event; Message: {0}", e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string Warning(string line)
        {
            return Warning(line, false);
        }
        public static string Warning(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = WarningTag + line;
                WriteSystemLog(TagLine, isDebug);

            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a Warning; Message: {0}" + e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string Error(string line)
        {
            return Error(line, false);
        }
        public static string Error(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = ErrorTag + line;
                WriteSystemLog(TagLine, isDebug);
            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a Error; Message: " + e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        public static string Info(string line)
        {
            return Info(line, false);
        }
        public static string Info(string line, bool isDebug)
        {
            string TagLine = "";
            try
            {
                TagLine = InfoTag + line;
                WriteSystemLog(TagLine, isDebug);
            }
            catch (Exception e)
            {
                Warning(string.Format("Failed to add a Error; Message: " + e.Message), isDebug);
            }
            if (_ReturnTagsInMethods) return TagLine;
            else return line;
        }
        // A split in events handling nothing more,
        // everything will be writen to the log it is just a 
        // feature to enable users the ability to sort in 
        // the lapstimes away or not.
        //---------------------------------------------------
        private static string WriteSystemLog(string line, bool isDebug)
        {
            string timestampstap = "                         "; //[{0:0000} {1:00}:{2:00}:{3:00}.{4:000}]
            if (_AddTimeStampsToSyslog)
            {
                DateTime time = DateTime.Now;              // Use current time
                line = string.Format("[{0:0000} {1:00}:{2:00}:{3:00}.{4:000}]{5}",
                   time.Date.ToString(Log.FormatDatetime), 
                   time.Hour,
                   time.Minute, 
                   time.Second, 
                   time.Millisecond,
                   line);
            }
            
            string[] lines = Regex.Split(line,"\r\n");
            if (lines.Length > 1)
            {
                line = lines[0];
                for (int i = 1; i < lines.Length; i++)
                {
                    if (_AddTimeStampsToSyslog) line += "\r\n" + timestampstap + NewLineTag + lines[i].Trim();
                    else line += "\r\n" + NewLineTag + lines[i].Trim();
                }
            }
            SystemLog.LogLine(line);
            OnLogSystemChanged(line, isDebug);
            return line;
        }
        private static string WriteLapstimeLog(DateTime start, DateTime end, string method, string tagline, bool isDebug)
        {
            if (_AddLapsTimesInSysLog)
            {
                WriteSystemLog(tagline, isDebug);
            }
            LapsTimeLog.LogALapsTime(start, end, method);
            OnLogLapstimeChanged(tagline, isDebug);
            return tagline;
        }
    }
}
