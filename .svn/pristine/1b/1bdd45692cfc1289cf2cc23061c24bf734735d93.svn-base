using System;
using System.Text.RegularExpressions;

namespace SHUtils.Logging.ServerLogging
{
    public class LapsTimeLog
    {
        /// <summary>
        /// Generates a string with ; seperation of the tag, start,end,timespan.
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="Tag"></param>
        /// <returns></returns>
        public static string LogALapsTime(DateTime Start, DateTime End,string Tag)
        {
            DateTime failsafe = DateTime.Now.AddYears(-1);
            string line = Tag+";Start;" + Start.ToLongTimeString() + ";End;" + End.ToLongTimeString();
            if (Start.Year < failsafe.Year || End.Year < failsafe.Year)
            {
                throw new ArgumentOutOfRangeException("Start : "+ Start.ToShortDateString() + " End : "+ End.ToShortDateString());
            }
            line = line + ";" + GenerateLapsTime(Start,End).ToString();
            return WriteALapsTime(line);
        }
        public static string LogALapsTime(TimeSpan timespan, string Tag)
        {  
            DateTime failsafe = DateTime.Now.AddYears(-1);
            string line = Tag + ";Start;;End;"+ DateTime.Now.ToLongTimeString();

            line = line + ";" + timespan.ToString();
            return WriteALapsTime(line);
        }
        private static string WriteALapsTime(string Line)
        {
            DateTime time = DateTime.Now;              // Use current time
            string sFilename = Log.PathLapstimeLog + "\\"+Log.LapstimeLogPrefix+"LapsTimes-" + time.ToString(Log.FormatDatetime) + ".log";
            string[] Lines = Regex.Split(Line, Environment.NewLine.ToString());
            LogFile.WriteLinesToFile(sFilename, Lines);
            return Line;
        }
        public static TimeSpan GenerateLapsTime(DateTime start, DateTime end)
        {
            return end - start;
        }
      
    }
}
