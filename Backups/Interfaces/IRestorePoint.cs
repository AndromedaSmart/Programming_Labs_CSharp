using System.Collections.Generic;

namespace Backups.Interfaces
{
    public interface IRestorePoint
    {
        public RestorePoint CreateRestorePoint();
    }
}
