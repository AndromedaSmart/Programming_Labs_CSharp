using System;

namespace Banks.MainClasses
{
    public class Operations
    {
        public Operations(decimal money, string fromWho, string forWho, int numberOfOperation)
        {
            Money = money;
            FromWho = fromWho;
            ForWho = forWho;
            NumberOfOperation = numberOfOperation;
        }

        public Operations()
        {
            throw new NotImplementedException();
        }

        public int NumberOfOperation { get; set; }
        internal decimal Money { get; }
        internal string FromWho { get; }
        internal string ForWho { get; }

        public static Operations Find(Func<object, object> func)
        {
            throw new NotImplementedException();
        }

        public static void Remove(Operations operation)
        {
            throw new NotImplementedException();
        }
    }
}