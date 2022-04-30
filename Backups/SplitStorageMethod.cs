using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.BackupException;

namespace Backups
{
    public class SplitStorageMethod
    {
        public SplitStorageMethod(List<JobObject> facilities, string path)
        {
            Facilities = facilities;
            Path = path;
        }

        private string FolderPath { get; set; }
        private string StoragePoint { get; set; }

        private string Path { get; }

        private List<JobObject> Facilities { get; }

        public void SplitStorage()
        {
            var createdFilesInFolder = new List<string>();

            foreach (JobObject facility in Facilities)
            {
                StoragePoint = $"{RestorePoint.NumberOfPoint}";

                if (File.Exists($"{Path}\\{StoragePoint}\\{facility.NameOfFile}.{RestorePoint.NumberOfPoint}.zip"))
                {
                    throw new BackupsException("File has already created");
                }

                if (createdFilesInFolder != null)
                {
                    createdFilesInFolder.Add(facility.NameOfFile);
                }

                if (!Directory.Exists($"{Path}\\{StoragePoint}"))
                {
                    Directory.CreateDirectory($"{Path}\\{StoragePoint}");
                }

                FolderPath = $"{Path}\\{StoragePoint}\\{facility.NameOfFile}.{RestorePoint.NumberOfPoint}.zip";

                using ZipArchive archiveZip = ZipFile.Open(FolderPath, ZipArchiveMode.Update);
                archiveZip.CreateEntryFromFile(facility.NameOfPath, facility.NameOfFile);
            }
        }
    }
}
