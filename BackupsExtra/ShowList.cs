using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class ShowList
    {
        public List<RestorePointExtra> ShowListOfPoints { get; set; }

        public void ListOfPoints(out List<RestorePointExtra> showList)
        {
            showList = new List<RestorePointExtra>();
        }
    }
}