using Backups;

namespace BackupsExtra.Interfaces
{
    public abstract class IBackupExtra
    {
        public abstract void FacilityExtraCreator(JobObject facility);
        public abstract void FacilityExtraRemover(JobObject facility);
    }
}