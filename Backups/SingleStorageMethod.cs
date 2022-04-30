using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.BackupException;

namespace Backups
{
    public class SingleStorageMethod
    {
        public SingleStorageMethod(List<JobObject> facilities, string path)
        {
            Facilities = facilities;
            Path = path;
        }

        private string FolderPath { get; set; }
        private string StoragePoint { get; set; }

        private string Path { get; }

        private List<JobObject> Facilities { get; }

        public void SingleStorage()
        {
            var createdFilesInFolder = new List<string>();

            Algorithm typeOfAlgorithm = Algorithm.SingleStorage;

            StoragePoint = $"{RestorePoint.NumberOfPoint}";

            if (!Directory.Exists($"{Path}\\{StoragePoint}"))
            {
                Directory.CreateDirectory($"{Path}\\{StoragePoint}");
            }

            FolderPath = $"{Path}\\{StoragePoint}\\{typeOfAlgorithm}.zip";

            using ZipArchive archiveZip = ZipFile.Open(FolderPath, ZipArchiveMode.Update);

            foreach (JobObject facility in Facilities)
            {
                if (File.Exists(FolderPath))
                {
                    throw new BackupsException("File has already created");
                }

                archiveZip.CreateEntryFromFile(facility.NameOfFile, facility.NameOfFile);
                if (createdFilesInFolder != null)
                {
                    createdFilesInFolder.Add(facility.NameOfFile);
                }
            }
        }
    }
}
