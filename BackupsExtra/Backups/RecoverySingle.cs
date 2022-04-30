using System.IO.Compression;

namespace BackupsExtra.Backups
{
    public class RecoverySingle
    {
        public Logger Log { get; set; }
        public void RecoverySingleToFolder(RestorePointExtra point, string directoryPath)
        {
            ZipFile.ExtractToDirectory($"{point.Path}\\{point.Name}\\name.zip", directoryPath);
            Log.FileUserAlert($"All files were moved from {point.Name} to {directoryPath}");
        }

        public void RecoverSingleToLatestDirectory(RestorePointExtra point)
        {
            RecoverySingleToFolder(point, point.PathFromWhere);
        }

        public void LoggerCreator(string path)
        {
            Log = new Logger(path);
        }
    }
}