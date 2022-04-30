using System;
using Banks.ConsoleInterface;
using Banks.MainClasses;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var userConsole = new ConsoleInterface.ConsoleInterface();
            var centralBank = new CentralBank();
            var mainBank = new MainBank("BankNumber1", Category.Credit, 100000, 100, 1);
            centralBank.CreateNewBank(mainBank);
            var director = new Director();
            var builder = new ClientCreator();
            director.Builder = builder;

            string name = userConsole.AddName();
            string surname = userConsole.AddSurname();
            string address = userConsole.AddAddress();
            string username = userConsole.AddUsername();
            string data = userConsole.AddData();
            int id = userConsole.AddId();

            director.MakeNewClient(name, surname, address, username, data, id);
            ClientInfo client = builder.GetClient();
            director.MakeNewClient("Vova", "Samsonov", "SPB", "SamFromSPB", "5564346", 456);

            ClientInfo client2 = builder.GetClient();
            mainBank.CreateNewClient(client2);
            var account2 = new Credit(client2, mainBank.CreditRate, mainBank.Comission);
            mainBank.CreateNewClient(account2);
            client2.CliendId = Convert.ToInt32(account2.UserNumber);
            client2.PersonalSystem = account2;

            while (true)
            {
                switch (userConsole.Interaction())
                {
                    case "1":
                        userConsole.CreateNewAccount(mainBank, client, "type");
                        break;
                    case "2":
                        userConsole.ShowBalance(client.PersonalSystem);
                        break;
                    case "3":
                        userConsole.PutMoneyOnAccount(mainBank, client.PersonalSystem);
                        break;
                    case "4":
                        userConsole.GetMoneyFromAccount(mainBank, client.PersonalSystem);
                        break;
                    case "5":
                        userConsole.MoneyTransfer(mainBank, client.PersonalSystem, client2.PersonalSystem);
                        return;
                }
            }
        }
    }
}
