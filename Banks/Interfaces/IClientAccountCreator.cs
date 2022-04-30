using Banks.MainClasses;

namespace Banks.Interfaces
{
    public interface IClientAccountCreator
    {
        public void NameOfClient(ClientInfo clientName);
        public void Login(string login);
        public void Password(string password);
        public void Category(string type);

        public void UserNumber(string number);
    }
}