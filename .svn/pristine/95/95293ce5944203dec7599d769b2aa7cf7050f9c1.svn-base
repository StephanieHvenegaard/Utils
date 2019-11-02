using System;
using System.Text.RegularExpressions;

namespace SHUtils.Logging
{
    class SystemLog
    {
        static object _lock = new object();
        private static DateTime dtCurrentDate;
        private static bool bFirstMessege = true;
        private static bool FirstMessege
        {
            get
            {
                if(dtCurrentDate.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    dtCurrentDate = DateTime.Now;
                    bFirstMessege = true;
                }
                   return bFirstMessege;
            }
            set{bFirstMessege = value;}
        }
        public static void LogLine(string line)
        {
            DateTime time = DateTime.Now;              // Use current time
            
           // if(Log.AddTimeToSyslog) Line = string.Format("[{0:0000} {1:00}:{2:00}:{3:00}.{4:000}]{5}", time.Date.ToString(Log.FormatDatetime), time.Hour, time.Minute, time.Second, time.Millisecond, Line);
            
            string sFileName = time.ToString(Log.FormatDatetime) + "-System" + (string.IsNullOrEmpty(Log.LogPrefix) ? "" : " - ") + Log.LogPrefix + ".log";
            string sFullPath = Log.PathLapstimeLog + "\\" + sFileName;
            lock (_lock)
            {
                if (LogFile.Exists(sFullPath))
                {
                    if (FirstMessege)
                    {
                        line = "----------------------------------------------------------------------------------------------\r\n" +
                               "Restarted\r\n" +
                               "----------------------------------------------------------------------------------------------\r\n" + line;
                        FirstMessege = false;
                    }
                }
                else
                {
                    if (!FirstMessege)
                    {
                        DateTime yesterday = time.AddDays(-1);
                        string stime = yesterday.ToString(Log.FormatDatetime);
                        line = "----------------------------------------------------------------------------------------------\r\n" +
                               "Continuation of the log from " + stime + "\r\n" +
                               "----------------------------------------------------------------------------------------------\r\n" + line;
                    }
                }
            }
            string[] Lines = Regex.Split(line, Environment.NewLine.ToString());
            //for (int i = 0; i < Lines.Length;i++)
            //{
            //    Lines[i] = string.Format("[{0}]{1}", DateTime.Now.ToShortTimeString(), Lines[i]);
            //}
            LogFile.WriteLinesToFile(sFullPath, Lines);
        }
    }
}
