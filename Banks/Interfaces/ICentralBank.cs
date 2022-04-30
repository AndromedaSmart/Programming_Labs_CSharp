using System;
using System.Collections.Generic;
using Banks.MainClasses;

namespace Banks.Interfaces
{
    public abstract class ICentralBank
    {
        public abstract void CreateNewBank(MainBank name);
        public abstract MainBank ShowBank(string name);

        public abstract void DeleteCurrentBank(MainBank name);

        public abstract List<MainBank> ShowListOfBanks();
    }
}