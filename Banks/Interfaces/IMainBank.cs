using Banks.MainClasses;

namespace Banks.Interfaces
{
    public interface IMainBank
    {
        public void AddTypeOfAccount(MainBank bank, ClientInfo newClient, Category type);
        public void CreateNewClient(ClientInfo newClient);
        public void CreateNewAccount(ClientAccount newAccount);
        public void GetMoneyFromAccount(int countMoney, ClientAccount accountName);
        public void PutMoneyOnAccount(int countMoney, ClientAccount accountName);
        public void MoneyTransfer(decimal countMoney, ClientAccount fromWho, ClientAccount forWho);
        public void LatestOperationCancel(string clientOperation);
    }
}