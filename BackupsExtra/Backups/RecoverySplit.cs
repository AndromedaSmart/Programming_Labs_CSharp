using System.IO;
using System.IO.Compression;

namespace BackupsExtra
{
    public class RecoverySplit
    {
        public Logger Log { get; set; }
        public string Path { get; set; }

        public void RecoveryStorageToFolder(RestorePointExtra point, string directoryPath)
        {
            foreach (string folder in point.PointFolders)
            {
                ZipFile.ExtractToDirectory($"{Path}\\Point{point.Number}\\{folder}.{point.Number}.zip", directoryPath);
                Log.FileUserAlert($"All files were moved from {point.Name} to {directoryPath}");
            }
        }

        public void RecoverSingleToLatestDirectory(RestorePointExtra point)
        {
            RecoveryStorageToFolder(point, point.PathFromWhere);
        }

        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }
    }
}