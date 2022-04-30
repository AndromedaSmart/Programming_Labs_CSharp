using System.Collections.Generic;

namespace Backups
{
    public class ShowList
    {
        private List<RestorePoint> ShowListOfPoints { get; } = new List<RestorePoint>();

        public void ListOfPoints(out List<RestorePoint> showList)
        {
            showList = new List<RestorePoint>();
        }
    }
}
