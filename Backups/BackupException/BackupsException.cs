using System;

namespace Backups.BackupException
{
    public class BackupsException : Exception
    {
        public BackupsException()
        {
        }

        public BackupsException(string message)
            : base(message)
        {
        }
    }
}