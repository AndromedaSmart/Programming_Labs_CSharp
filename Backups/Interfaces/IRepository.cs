using System.Collections.Generic;

namespace Backups.Interfaces
{
    public interface IRepository
    {
        public void FacilityCopier(string oldPath, string newPath);

        public void FacilityMovier(string oldPath, string newPath);
    }
}