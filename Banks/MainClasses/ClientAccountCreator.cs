using System.Collections.Generic;
using Banks.Interfaces;

namespace Banks.MainClasses
{
    public class ClientAccountCreator : IClientAccountCreator
    {
        private List<ClientAccount> listOfAccounts = new List<ClientAccount>();

        public void ClientAccount()
        {
            Reset();
        }

        public void NameOfClient(ClientInfo clientName)
        {
            if (clientName != null)
            {
                MainClasses.ClientAccount.NameOfClient = clientName;
            }
            else
            {
                throw new BanksException.BanksException("Enter the correct name, please");
            }
        }

        public void Login(string login)
        {
            if (login != null)
            {
                MainClasses.ClientAccount.Login = login;
            }
            else
            {
                throw new BanksException.BanksException("Every our client must to have login");
            }
        }

        public void Password(string password)
        {
            if (password != null)
            {
                MainClasses.ClientAccount.Password = password;
            }
            else
            {
                throw new BanksException.BanksException("Every our client must to have password");
            }
        }

        public List<ClientAccount> GetClientAccount()
        {
            List<ClientAccount> obj = listOfAccounts;
            Reset();
            return obj;
        }

        public void Category(string type)
        {
            if (type != null)
            {
                if (!string.IsNullOrEmpty(type = "Debit"))
                {
                   type = MainClasses.Category.Debit.ToString();
                }

                if (!string.IsNullOrEmpty(type = "Credit"))
                {
                    type = MainClasses.Category.Credit.ToString();
                }

                if (!string.IsNullOrEmpty(type = "Deposit"))
                {
                    type = MainClasses.Category.Credit.ToString();
                }
            }
            else
            {
                throw new BanksException.BanksException("Choose one of the types of your account");
            }
        }

        public void UserNumber(string number) // necessary for transfer money from one acc to another
        {
            if (number == null)
            {
                throw new BanksException.BanksException("Please, enter your number of user");
            }
        }

        private void Reset()
        {
            listOfAccounts = new List<ClientAccount>();
        }
    }
}