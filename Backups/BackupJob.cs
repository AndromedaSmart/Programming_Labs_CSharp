using System.Collections.Generic;
using Backups.Interfaces;

namespace Backups
{
    public class BackupJob : IBackupJob
    {
        private static List<JobObject> _facilities;

        public BackupJob(string typeOfAlgorithm, string path)
        {
            TypeOfAlgorithm = typeOfAlgorithm;
            Path = path;
            _facilities = new List<JobObject>();
        }

        public static int NumberOfPoint { get; set; }
        public string Path { get; set; }
        public string TypeOfAlgorithm { get; set; }

        public void FacilityCreator(JobObject facility)
        {
            _facilities.Add(facility);
        }

        public void FacilityRemover(JobObject facility)
        {
            _facilities.Remove(facility);
        }

        public RestorePoint CreateRestorePoint()
        {
            throw new System.NotImplementedException();
        }
    }
}
