using System;
using System.Text.RegularExpressions;

namespace SHUtils.Logging
{
    class LapsTimeLog
    {
        /// <summary>
        /// Generates a string with ; seperation of the tag, start,end,timespan.
        /// </summary>
        /// <param name="Start">start of the lapstime</param>
        /// <param name="End">end of the lapstime</param>
        /// <param name="Tag">tag of the lapstime</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when start is more then a year ago or end is more then datetime.now</exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <returns>void</returns>
        public static void LogALapsTime(DateTime Start, DateTime End,string Tag)
        {
            DateTime failsafe = DateTime.Now.AddYears(-1); 
            if (Start.Year < failsafe.Year || End > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Start : "+ Start.ToShortDateString() + " End : "+ End.ToShortDateString());
            }
            else if(End < Start)
            {
                throw new ArgumentException("Start cannot have a newer date then end, are you sure you didnt switched them by mastake ?");
            } 
            // ADDS THE TIMESPAN TO THE LINE!
            string line = Tag+";" + Start.ToLongTimeString() + ";" + End.ToLongTimeString()+";"+ Math.Round(GenerateLapsTime(Start,End).TotalMilliseconds) + ";ms.";
            WriteALapsTime(line);
        }
        private static void WriteALapsTime(string Line)
        {
            DateTime time = DateTime.Now;              // Use current time
            string sFileName =time.ToString(Log.FormatDatetime) + "-LapsTimes" +(string.IsNullOrEmpty(Log.LogPrefix) ? "":" - ")+ Log.LogPrefix + ".log";
            string sFullPath = Log.PathLapstimeLog + "\\" + sFileName;
            if(!LogFile.Exists(sFullPath))
            {
                 LogFile.WriteLinesToFile(sFullPath,new string[]{"Method;Start;End;time;units"});
            }
            string[] Lines = Regex.Split(Line, Environment.NewLine.ToString());
            LogFile.WriteLinesToFile(sFullPath, Lines);
        }
        public static TimeSpan GenerateLapsTime(DateTime start, DateTime end)
        {
            return end - start;
        }
      
    }
}
