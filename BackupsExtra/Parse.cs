using System;
using System.IO;

namespace BackupsExtra
{
    public class Parse
    {
        public string PointsPath { get; set; }
        public string LoggPath { get; set; }
        public string LoggWay { get; set; }
        public void Parsing(string file)
        {
            string[] parsing = File.ReadAllLines(file);

            LoggWay = parsing[1];
            LoggPath = parsing[3];
            PointsPath = parsing[11];
        }
    }
}