using System.Collections.Generic;

namespace Backups.Interfaces
{
    public interface IBackup
    {
        public List<JobObject> ShowListOfFacilities();
    }
}
