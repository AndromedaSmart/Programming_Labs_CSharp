namespace BackupsExtra.Interfaces
{
    public abstract class ILogger
    {
        public abstract void FileUserAlert(string alert);

        public abstract void ConsoleUserAlert(string alert);
    }
}