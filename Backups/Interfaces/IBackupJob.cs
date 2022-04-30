using System.Collections.Generic;

namespace Backups.Interfaces
{
    public interface IBackupJob
    {
        public void FacilityCreator(JobObject facility);

        public void FacilityRemover(JobObject facility);
    }
}
