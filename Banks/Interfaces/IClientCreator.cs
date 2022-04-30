using System.Data.Common;

namespace Banks.Interfaces
{
    public interface IClientCreator
    {
        public void ClientName(string name);
        public void ClientSurname(string surname);
        public void ClientAddress(string address);
        public void ClientPassportData(string data);
        public void ClientUsername(string username);
        public void ClientId(int id);
    }
}