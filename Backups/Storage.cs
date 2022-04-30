namespace Backups
{
    public class Storage
    {
        public Storage(string nameOfPath)
        {
            NameOfPath = nameOfPath;
        }

        public string NameOfPath { get; set; }
    }
}
