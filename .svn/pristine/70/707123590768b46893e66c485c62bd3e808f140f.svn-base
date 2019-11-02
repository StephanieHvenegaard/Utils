using System;
using System.IO;
using System.Threading;

namespace SHUtils.Logging
{
    class LogFile
    {
        static object _Lock = new object();
        /// <summary>
        /// write to file. throws new ArgumentException at empty path.
        /// </summary>
        /// <param name="FullFilePath"></param>
        /// <param name="Lines"></param>
        public static void WriteLinesToFile(string FullFilePath, string[] Lines)
        {
            if (string.IsNullOrEmpty(FullFilePath) || string.IsNullOrWhiteSpace(FullFilePath)||Path.GetDirectoryName(FullFilePath)=="\\")
            {
                throw new ArgumentException("Path cannot be Empty!");
            }

            if (Directory.Exists(Path.GetDirectoryName(FullFilePath)))
            {
                lock (_Lock)
                {
                    try
                    {
                        if (!Exists(FullFilePath))
                        {
                            File.Create(FullFilePath).Close();
                            File.WriteAllLines(FullFilePath, Lines);
                        }
                        else
                        {
                            File.AppendAllLines(FullFilePath, Lines);
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error("Ups this whent wrong doring log. wil try again in a 0,1 sec :" + e.Message);
                        Thread.Sleep(100);
                        WriteLinesToFile(FullFilePath, Lines);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FullFilePath));
                WriteLinesToFile(FullFilePath, Lines);
            }
            
        }
        public static DateTime LastChangeToFile(string Path)
        {
            return File.GetLastAccessTime(Path);//          return DateTime.Now;
        }
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
