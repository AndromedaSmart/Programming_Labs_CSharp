using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups
{
    public class Repository : IRepository
    {
        public void FacilityCopier(string oldPath, string newPath)
        {
            File.Copy(oldPath, newPath);
        }

        public void FacilityMovier(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }
    }
}
