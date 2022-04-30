using System;
using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class RestorePointExtra
    {
        public RestorePointExtra(string typeOfAlgorithm, string path, BackupJob job)
        {
            TypeOfAlgorithm = typeOfAlgorithm;
            PathFromWhere = path;
            RestorePoint = job.CreateRestorePoint();
            Name = RestorePoint.Name;
            PointFolders = RestorePoint.PointFolders;
            Path = $@"{path}\{Name}";
            Number = RestorePoint.NumberOfPoint;
            Time = DateTime.Now;
            ShowListOfPoints = new List<RestorePointExtra>();
        }

        public RestorePointExtra()
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
        public BackupJob BackupJob { get; set; }
        public List<string> PointFolders { get; set; }
        public RestorePoint RestorePoint { get; set; }
        public int Number { get; set; }
        public string Path { get; set; }
        public string TypeOfAlgorithm { get; set; }
        public DateTime Time { get; set; }
        public string PathFromWhere { get; set; }
        public Logger Log { get; set; }

        public List<RestorePointExtra> ShowListOfPoints { get; set; }

        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }
    }
}