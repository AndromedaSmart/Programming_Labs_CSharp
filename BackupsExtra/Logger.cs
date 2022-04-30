using System;
using System.IO;

namespace BackupsExtra
{
    public class Logger
    {
        public Logger(string logPath)
        {
            LogPath = logPath;
        }

        public string LogPath { get; set; }
        public Logger Log { get; set; }
        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }

        public void FileUserAlert(string alert)
        {
            using var message = new StreamWriter(LogPath, true);
            DateTime time = DateTime.Now;

            message.Write(time + alert + "(file logging)");
        }

        public void ConsoleUserAlert(string alert)
        {
            DateTime time = DateTime.Now;

            Console.WriteLine(time + alert + "(console logging)");
        }
    }
}