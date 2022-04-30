using System;
using System.Collections.Generic;
using Banks;
using Banks.MainClasses;
using NUnit.Framework;

namespace Banks.Tests
{
    [TestFixture]
    public class BankTest1
    {
        List<MainBank> list = new List<MainBank>();
        CentralBank centralBank = new CentralBank();
        MainBank bank = new MainBank("Банк1", Category.Credit, 100000, 100, 567);
        
        // нет доступа к переменной centralBank и Bank (не понятно, в чём ошибка)
        // centralBank.CreateNewBank(bank)
        // centralBank.ShowListOfBanks();
    }
}