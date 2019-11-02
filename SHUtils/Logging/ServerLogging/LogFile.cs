using System;
using System.IO;

namespace SHUtils.Logging.ServerLogging
{
    class LogFile
    {
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
