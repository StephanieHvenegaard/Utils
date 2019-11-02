using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace SHUtils.Log
{
    public class LogHandling
    {
        static object _Lock = new object();
        public void SaveLogfileClearFormat(string Messege, string sLogFolder, bool FirstMessege)
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "yyyy-MM-dd";
            string sFilename = sLogFolder +"\\" +  time.ToString(format) + ".log";
            lock (_Lock)// TreadSafe the bitch.
            {
                if (File.Exists(sFilename))
                {
                    if (FirstMessege)
                    {
                        File.AppendAllText(sFilename, "--------------------------------------------------------------\r\n" +
                                                      "Restarted\r\n" +
                                                      "--------------------------------------------------------------\r\n");
                    }
                }
                else
                {
                    File.Create(sFilename).Close();
                    if (!FirstMessege)
                    {
                        DateTime yesterday = time.AddDays(-1);
                        string stime = yesterday.ToString(format);
                        File.AppendAllText(sFilename, "--------------------------------------------------------------\r\n" +
                                                      "Continuation of the log from " + stime + "\r\n" +
                                                      "--------------------------------------------------------------\r\n");
                    }

                }
                WritingLog(sFilename, Messege);
            }
        }
        public void WritingLog(string logname, string message)
        {
            string[]MessageLines = Regex.Split(message,Environment.NewLine);
           
            if (MessageLines.Length > 1)
            { 
                List<string> OtherLines = new List<string>();
                OtherLines.Add(MessageLines[0].Trim());
                for (int i = 1; i < MessageLines.Length; i++)
                {
                    // Add a big ass tap to symbolize these lines are with the first one.
                    if(!string.IsNullOrWhiteSpace(MessageLines[i]))OtherLines.Add("                     "+MessageLines[i].Trim());
                }
                MessageLines = OtherLines.ToArray();
            }
           
            File.AppendAllLines(logname, MessageLines);
        }
    }
}
