using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class BackupJobExtra
    {
        public BackupJobExtra(string typeOfAlgorithm, string path)
        {
            TypeOfAlgorithm = typeOfAlgorithm;
            Path = path;
            BackupJob = new BackupJob(typeOfAlgorithm, path);
            ShowListOfPoints = new List<RestorePointExtra>();
        }

        public BackupJobExtra(string typeOfAlgorithm, string parsingPointsPath, string parsingLoggWay, string parsingLoggPath)
        {
            throw new NotImplementedException();
        }

        public static string TypeOfAlgorithm { get; set; }
        public static string Path { get; set; }
        public List<RestorePointExtra> ShowList { get; set; } = new List<RestorePointExtra>();
        public BackupJob BackupJob { get; set; }
        public int FunctionOfTimeOut { get; set; }
        public int Count { get; set; }
        public DateTime Time { get; set; }
        public Logger Log { get; set; }

        public List<RestorePointExtra> ShowListOfPoints { get; set; }
        public RestorePointExtra CreateRestorePointExtra()
        {
            var newExtraPoint = new RestorePointExtra(TypeOfAlgorithm, Path, BackupJob);
            ShowListOfPoints.Add(newExtraPoint);
            Log.ConsoleUserAlert("Restore point added");
            return newExtraPoint;
        }

        public void RangesBorders(int count, DateTime time, int functionOfTimeOut)
        {
            Count = count;
            Time = time;
            FunctionOfTimeOut = functionOfTimeOut;
        }

        public void TestOfRangesBorders()
        {
            switch (FunctionOfTimeOut)
            {
                case 1:
                    TestNumberOfDots();
                    break;
                case 2:
                    TestDataRange(ShowList);
                    break;
                case 3:
                    var roster = new List<RestorePointExtra>();
                    int counter = 0;
                    while ((ShowList.Count - Count) >= counter)
                    {
                        counter++;
                        roster.Add(ShowList[counter]);
                    }

                    TestDataRange(roster);
                    break;
            }
        }

        public void TestNumberOfDots()
        {
            if ((Count >= ShowList.Count) || (Count == 0))
            {
                return;
            }

            RestorePointExtra element = ShowList[0];
            ShowList.Remove(element);

            Directory.Delete(element.Path, true);
            Log.FileUserAlert("You have deleted point");
        }

        public void TestDataRange(List<RestorePointExtra> dots)
        {
            var canceledPoints = new List<RestorePointExtra>();

            foreach (RestorePointExtra point in canceledPoints)
            {
                if (point.Time > Time)
                {
                    canceledPoints = dots;
                }
            }

            if (canceledPoints.Count == dots.Count)
            {
                throw new BackupExtraException("Please, try again with another entered data");
            }

            foreach (RestorePointExtra point in canceledPoints)
            {
                ShowList.Remove(point);
                Directory.Delete(point.Path, true);

                Log.FileUserAlert("You deleted point");
            }
        }

        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }
    }
}