using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace SHUtils.ErrorHandlers
{
    public class ServerErrorHandlers
    {
        string WorkerPath = @"C:/temp/";
        string Errorlogspath;
        public ServerErrorHandlers(string errorfileName)
        {
            Errorlogspath = WorkerPath + errorfileName + ".txt";
        }
        public void CritialErrorWithFlag(string errortext)
        {
            using (StreamWriter sw = new StreamWriter(Errorlogspath, true))
            {
                sw.WriteLine("------------------------------------------------------------------------------");
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("------------------------------------------------------------------------------");
                sw.WriteLine(errortext);
            }
            File.Create(WorkerPath + "error.flag").Close();
            
        }
    }
}
