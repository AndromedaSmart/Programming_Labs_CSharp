using Banks.Interfaces;

namespace Banks.MainClasses
{
    public class ClientCreator : IClientCreator
    {
        private ClientInfo newClient = new ClientInfo();

        public void ClientInfo()
        {
            Reset();
        }

        public void ClientName(string name)
        {
            if (name != null)
            {
                MainClasses.ClientInfo.Name = name;
            }
            else
            {
                throw new BanksException.BanksException("At-first, please, you should add your name.");
            }
        }

        public void ClientSurname(string surname)
        {
            if (surname != null)
            {
                newClient.Surname = surname;
            }
            else
            {
                throw new BanksException.BanksException("It's recommends, add your surname.");
            }
        }

        public void ClientAddress(string address)
        {
            if (address != null)
            {
                newClient.Address = address;
            }
            else
            {
                address = null;
            }
        }

        public void ClientPassportData(string data)
        {
            if (data != null)
            {
                newClient.PassportData = data;
            }
            else
            {
                data = null;
            }
        }

        public void ClientUsername(string username)
        {
            if (username != null)
            {
                newClient.Username = username;
            }
            else
            {
                throw new BanksException.BanksException("Sorry, but you need to enter your username");
            }
        }

        public void ClientId(int id)
        {
            if (id > 0)
            {
                newClient.CliendId = id;
            }
            else
            {
                throw new BanksException.BanksException("Please, enter your unique ID");
            }
        }

        public ClientInfo GetClient()
        {
            ClientInfo obj = newClient;
            Reset();
            return obj;
        }

        private void Reset()
        {
            newClient = new ClientInfo();
        }
    }
}