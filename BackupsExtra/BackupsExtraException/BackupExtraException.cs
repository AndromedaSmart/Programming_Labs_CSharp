using System;

namespace BackupsExtra
{
    public class BackupExtraException : Exception
    {
        public BackupExtraException()
        {
        }

        public BackupExtraException(string message)
            : base(message)
        {
        }
    }
}