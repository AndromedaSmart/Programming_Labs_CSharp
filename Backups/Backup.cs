using System.Collections.Generic;
using Backups.Interfaces;

namespace Backups
{
    public class Backup : IBackup
    {
        private readonly List<JobObject> _facilities;

        public Backup(List<JobObject> facilities)
        {
            _facilities = facilities;
        }

        protected Backup()
        {
            throw new System.NotImplementedException();
        }

        public List<JobObject> ShowListOfFacilities()
        {
            return _facilities;
        }
    }
}
