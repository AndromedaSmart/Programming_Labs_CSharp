using Backups;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            var parsing = new Parse();
            var backup = new BackupExtra();
            var backupJob = new BackupJobExtra("split", parsing.PointsPath, parsing.LoggWay, parsing.LoggPath);
            var jobObject = new JobObject("C:\\GitHub\\AndromedaSmart\\BackupsExtra\\MainRepository\\file.docs", "file");
            backup.FacilityExtraCreator(jobObject);
            RestorePointExtra restorePoint = backupJob.CreateRestorePointExtra();

            var backupJob1 = new BackupJob("split", "C:\\GitHub\\AndroemdaSmart\\BackupsExtra\\MainRepository\\Repository");
            var jobObject1 = new JobObject("C:\\GitHub\\AndroemdaSmart\\BackupsExtra\\MainRepository\\Repository\\file.txt", "file");
            backupJob1.FacilityCreator(jobObject1);
            backupJob1.FacilityRemover(jobObject1);
        }
    }
}