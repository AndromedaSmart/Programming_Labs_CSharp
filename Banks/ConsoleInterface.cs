using System;
using Banks.MainClasses;

namespace Banks.ConsoleInterface
{
    public class ConsoleInterface
    {
        public string Interaction()
        {
            Console.WriteLine("Hello! Welcome to our Bank!\n");
            Console.WriteLine("Your have some options.\n");
            Console.WriteLine("Choose one of them:\n" +
                              "1) Create new account\n" +
                              "2) Show your balance\n" +
                              "3) Put money\n" +
                              "4) Get money\n" +
                              "5) Transfer money to another account\n" +
                              "6) Add your name\n" +
                              "7) Add your surname\n" +
                              "8) Add your address\n" +
                              "9) Add your username\n");

            return Console.ReadLine();
        }

        public void CreateNewAccount(MainBank bank, ClientInfo newClient, string type)
        {
            Console.WriteLine("Please, choose one of the type of your bank account:\n" +
                              "1) Credit\n" +
                              "2) Debit\n" +
                              "3) Deposit\n");

            string choose = Console.ReadLine();

            if (choose == "1) Credit")
            {
                MainBank.AddTypeOfAccount(bank, newClient, type);
            }

            if (choose == "2) Debit")
            {
                MainBank.AddTypeOfAccount(bank, newClient, type);
            }

            if (choose == "3) Deposit")
            {
                MainBank.AddTypeOfAccount(bank, newClient, type);
            }
        }

        public int CountMoney()
        {
            Console.WriteLine("How much sum do you want to operate with?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void ShowBalance(ClientAccount name)
        {
            Console.WriteLine($"Your balance right now is - {name.CountMoney}\n");
        }

        public void PutMoneyOnAccount(MainBank bank, ClientAccount name)
        {
            bank.PutMoneyOnAccount(CountMoney(), name);
            Console.WriteLine("Done");
        }

        public void GetMoneyFromAccount(MainBank bank, ClientAccount name)
        {
            bank.GetMoneyFromAccount(CountMoney(), name);
            Console.WriteLine("Done");
        }

        public string AddName()
        {
            Console.WriteLine("Please, write your name: ");
            {
                return Console.ReadLine();
            }
        }

        public string AddSurname()
        {
            Console.WriteLine("Please, write your surname: ");
            {
                return Console.ReadLine();
            }
        }

        public string AddAddress()
        {
            Console.WriteLine("Please, write your address: ");
            {
                return Console.ReadLine();
            }
        }

        public string AddUsername()
        {
            Console.WriteLine("Please, come up your unique Username: ");
            {
                return Console.ReadLine();
            }
        }

        public string AddData()
        {
            Console.WriteLine("Please, enter your passport data: ");
            {
                return Console.ReadLine();
            }
        }

        public int AddId()
        {
            Console.WriteLine("Please, enter your ID: ");
            {
                return Convert.ToInt32(Console.ReadLine());
            }
        }

        public void MoneyTransfer(MainBank bank, ClientAccount clientAccount, ClientAccount forWho)
        {
            var fromWho = new ClientAccount();

            foreach (ClientAccount clientAccount1 in bank.ListOfClientsAccounts)
            {
                if (clientAccount.UserNumber == AddUsername())
                {
                    fromWho = clientAccount1;
                }
            }

            bank.MoneyTransfer(CountMoney(), fromWho, forWho);

            Console.WriteLine("Done");
        }
    }
}