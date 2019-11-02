using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SHUtils.Logging
{
    public class LogHandling
    {
        public void SaveLogfileClearFormat(string Messege, string sLogFolder, bool FirstMessege)
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "yyyy-M-d";
            string sFilename = sLogFolder +"\\" +  time.ToString(format) + ".log";
            if (File.Exists(sFilename))
            {
                if (FirstMessege)
                {
                    File.AppendAllText(sFilename, "\r\n--------------------------------------------------------------\r\n" +
                                                  "Restarted\r\n" +
                                                  "--------------------------------------------------------------\r\n");
                }
                File.AppendAllText(sFilename, Messege);
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
                File.AppendAllText(sFilename, Messege);
            }
        }
    }
}
