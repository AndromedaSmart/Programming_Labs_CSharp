using System;
using System.Collections.Generic;
using Banks.Interfaces;

namespace Banks.MainClasses
{
    public class CentralBank : ICentralBank
    {
        private List<MainBank> banksList = new List<MainBank>();

        public override void CreateNewBank(MainBank name)
        {
            banksList.Add(name);
        }

        public override void DeleteCurrentBank(MainBank name)
        {
            banksList.Remove(name);
        }

        public override List<MainBank> ShowListOfBanks()
        {
            return banksList;
        }

        public override MainBank ShowBank(string name)
        {
            foreach (MainBank bank in banksList)
            {
                if (name == MainBank.Name)
                {
                    return bank;
                }
            }

            return null;
        }
    }
}