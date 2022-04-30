using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class BackupExtra : Backup
    {
        public BackupJob BackupJob { get; set; }
        public void FacilityExtraCreator(JobObject facility)
        {
            BackupJob.FacilityCreator(facility);
        }

        public void FacilityExtraRemover(JobObject facility)
        {
            BackupJob.FacilityRemover(facility);
        }
    }
}