namespace Backups
{
    public class JobObject
    {
        public JobObject(string nameOfPath, string nameOfFile)
        {
            NameOfPath = nameOfPath;
            NameOfFile = nameOfFile;
        }

        public string NameOfFile { get; set; }
        public string NameOfPath { get; set; }
    }
}
