using Banks.MainClasses;

namespace Banks.Interfaces
{
    public abstract class IConsoleInterface
    {
        public abstract string Interactions();
        public abstract void CreateNewAccount(MainBank bank, ClientInfo newClient);
        public abstract void ShowBalance(ClientAccount name);
        public abstract void PutMoneyOnAccount(MainBank bank, ClientAccount name);
        public abstract void GetMoneyFromAccount(MainBank bank, ClientAccount name);
        public abstract void MoneyTransfer(MainBank bank, ClientAccount clientAccount, ClientAccount forWho);
        public abstract string AddName();
        public abstract string AddSurname();
        public abstract string AddAddress();
        public abstract string AddUsername();
    }
}