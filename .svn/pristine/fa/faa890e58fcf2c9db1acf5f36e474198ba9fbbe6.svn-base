using System;
using System.Text.RegularExpressions;

namespace SHUtils.Logging.ServerLogging
{
    class SystemLog
    {
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
        public static void LogLine(string Line)
        {
            DateTime time = DateTime.Now;              // Use current time
            string sFilename = Log.PathSysLog + "\\"+Log.SysLogPrefix +"SystemLog-" + time.ToString(Log.FormatDatetime) + ".log";
            if (LogFile.Exists(sFilename))
            {
                if (FirstMessege)
                {
                    Line = "\r\n--------------------------------------------------------------\r\n" +
                           "Restarted\r\n" +
                           "--------------------------------------------------------------\r\n" + Line;
                    FirstMessege = false;
                }
            }
            else
            {
                if (!FirstMessege)
                {
                    DateTime yesterday = time.AddDays(-1);
                    string stime = yesterday.ToString(Log.FormatDatetime);
                    Line = "--------------------------------------------------------------\r\n" +
                            "Continuation of the log from " + stime + "\r\n" +
                            "--------------------------------------------------------------\r\n" + Line;
                }
            }
            string[] Lines = Regex.Split(Line, Environment.NewLine.ToString());
            LogFile.WriteLinesToFile(sFilename, Lines);
        }
    }
}
