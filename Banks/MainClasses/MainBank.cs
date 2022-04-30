using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace Banks.MainClasses
{
    public class MainBank : CentralBank
    {
        public MainBank(string name, Category typeOfBank, decimal comission, decimal creditRate, int numberOfAccount)
        {
            Name = name;
            TypeOfBank = typeOfBank;
            Comission = comission;
            CreditRate = creditRate;
            NumberOfAccount = numberOfAccount;
        }

        public static int NumberOfAccount { get; set; } = 0;
        public static List<ClientInfo> ListOfClients { get; set; } = new List<ClientInfo>();
        public static string Name { get; set; }
        public decimal Comission { get; set; }
        public decimal CreditRate { get; set; }
        public Category TypeOfBank { get; set; }
        public int IdOfOperation { get; set; }
        public int DayProcent { get; set; }
        internal List<ClientAccount> ListOfClientsAccounts { get; } = new List<ClientAccount>();
        private List<Credit> ListOfCredit { get; } = new List<Credit>();
        private List<Deposit> ListOfDeposit { get; } = new List<Deposit>();
        private List<Debit> ListOfDebit { get; } = new List<Debit>();
        private List<Operations> ListOfOperations { get; } = new List<Operations>();

        public static void AddTypeOfAccount(MainBank bank, ClientInfo newClient, string type)
        {
            if (type == Category.Credit.ToString())
            {
                bank.CreateNewClient(newClient);
                Credit clientAccount = new Credit(newClient, bank.Comission, bank.CreditRate) { UserNumber = Convert.ToInt32($"{Category.Credit}{NumberOfAccount}").ToString() };
                bank.ListOfClientsAccounts.Add(clientAccount);
                bank.ListOfCredit.Add(clientAccount);
            }

            if (type == Category.Debit.ToString())
            {
                bank.CreateNewClient(newClient);
                Debit clientAccount = new Debit(newClient, bank.DayProcent) { UserNumber = $"{Category.Debit}{NumberOfAccount}" };
                bank.ListOfClientsAccounts.Add(clientAccount);
                bank.ListOfDebit.Add(clientAccount);
            }

            if (type == Category.Deposit.ToString())
            {
                bank.CreateNewClient(newClient);
                Deposit clientAccount = new Deposit(newClient, bank.DayProcent, DateTime.Today.AddMonths(5)) { UserNumber = $"{Category.Deposit}{NumberOfAccount}" };
                bank.ListOfClientsAccounts.Add(clientAccount);
                bank.ListOfDeposit.Add(clientAccount);
            }
        }

        public void CreateNewClient(ClientInfo newClient)
        {
            ListOfClients.Add(newClient);
        }

        public void CreateNewAccount(ClientAccount newAccount)
        {
            ListOfClientsAccounts.Add(newAccount);

            if (newAccount.Category == Category.Credit)
            {
                ListOfCredit.Add((Credit)newAccount);
            }

            if (newAccount.Category == Category.Debit)
            {
                ListOfDebit.Add((Debit)newAccount);
            }

            if (newAccount.Category == Category.Deposit)
            {
                ListOfDeposit.Add((Deposit)newAccount);
            }
        }

        public void GetMoneyFromAccount(int countMoney, ClientAccount accountName)
        {
            if (accountName.CountMoney < countMoney)
            {
                throw new BanksException.BanksException("Warning! You haven't enough money on your account!");
            }

            accountName.CountMoney -= countMoney;
        }

        public void PutMoneyOnAccount(int countMoney, ClientAccount accountName)
        {
            accountName.CountMoney += countMoney;
        }

        public void MoneyTransfer(decimal countMoney, ClientAccount fromWho, ClientAccount forWho)
        {
            IdOfOperation++;
            var operation = new Operations(countMoney, fromWho.UserNumber, forWho.UserNumber, IdOfOperation);
            ListOfOperations.Add(operation);

            if (fromWho.CountMoney < countMoney)
            {
                throw new BanksException.BanksException("Warning! You haven't enough money on your account!");
            }

            fromWho.CountMoney -= countMoney;
            forWho.CountMoney += countMoney;
        }

        public void LatestOperationCancel(string clientOperation)
        {
            if (clientOperation == null)
            {
                throw new BanksException.BanksException("Can't to find this operation");
            }

            var operation = new Operations();
            foreach (Operations operation1 in ListOfOperations)
            {
                if (clientOperation == operation.NumberOfOperation.ToString())
                {
                    operation = operation1;
                }
            }

            var fromWho = new ClientAccount();
            foreach (ClientAccount clientAccount1 in ListOfClientsAccounts)
            {
                if ((operation != null) && (clientAccount1.UserNumber == operation.FromWho))
                {
                    fromWho = clientAccount1;
                }
            }

            var forWho = new ClientAccount();
            foreach (ClientAccount clientAccount1 in ListOfClientsAccounts)
            {
                if ((operation != null) && (clientAccount1.UserNumber == operation.ForWho))
                {
                    forWho = clientAccount1;
                }
            }

            if (operation != null)
            {
                forWho.CountMoney -= operation.Money;
                fromWho.CountMoney += operation.Money;
                Operations.Remove(operation);
            }

            if ((fromWho == null) || (forWho == null))
            {
                throw new BanksException.BanksException("Please, check your entered data");
            }
        }

        public void CreateNewClient(Credit newClient)
        {
            throw new NotImplementedException();
        }
    }
}