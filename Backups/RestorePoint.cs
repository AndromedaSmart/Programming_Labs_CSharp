using System.Collections.Generic;
using Backups.Interfaces;

namespace Backups
{
    public class RestorePoint : IRestorePoint
    {
        private readonly List<RestorePoint> showList;

        private readonly List<JobObject> facilities;

        public RestorePoint(List<JobObject> facilities, string path, string typeOfAlgorithm, List<RestorePoint> showList)
        {
            this.facilities = new List<JobObject>();
            Path = path;
            TypeOfAlgorithm = typeOfAlgorithm;
            this.showList = showList;
        }

        public static int NumberOfPoint { get; set; }
        public static string Path { get; set; }

        public List<string> PointFolders { get; set; }
        public string TypeOfAlgorithm { get; }
        public string Name { get; set; }

        public RestorePoint CreateRestorePoint()
        {
            NumberOfPoint++;

            RestorePoint newPoint = new RestorePoint(facilities, Path, TypeOfAlgorithm, showList);
            showList.Add(newPoint);

            return newPoint;
        }
    }
}
