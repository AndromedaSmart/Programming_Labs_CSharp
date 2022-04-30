using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackupsExtra
{
    public class Merge
    {
        private List<string> folders = new List<string>();
        public Logger Log { get; set; }
        public List<RestorePointExtra> ShowList { get; set; }

        public void MergeAlgorithm(RestorePointExtra earlyCreated, RestorePointExtra laterCreated)
        {
            var earliest = new RestorePointExtra();
            if (earlyCreated.Time > laterCreated.Time)
            {
                earliest = laterCreated;
            }

            if (earlyCreated.Time < laterCreated.Time)
            {
                earliest = earlyCreated;
            }

            var latest = new RestorePointExtra();
            if (earlyCreated.Time < laterCreated.Time)
            {
                latest = earlyCreated;
            }

            if (earlyCreated.Time > laterCreated.Time)
            {
                latest = laterCreated;
            }

            foreach (string folder in folders)
            {
                if (!earliest.PointFolders.Contains(folder))
                {
                    folders = latest.PointFolders;
                }
            }

            foreach (string folder in folders)
            {
                string where = $@"{latest.Path}\{folder}.{latest.Number}.zip";
                string whereFor = $@"{earliest.Path}\{folder}.{earliest.Number}.zip";

                File.Move(where, whereFor);
                File.Delete($@"{latest.Path}\{folder}.{latest.Number}");

                latest.PointFolders.Remove(folder);
                earliest.PointFolders.Add(folder);

                Log.FileUserAlert("Merge is done successfuly");
            }

            ShowList.Remove(latest);
        }

        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }
    }
}