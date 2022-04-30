using Banks.Interfaces;

namespace Banks.MainClasses
{
    public class Director
    {
        private IClientCreator builder;

        public IClientCreator Builder
        {
            set => builder = value;
        }

        public void MakeNewClient(string name, string surname, string address, string username, string data, int id)
        {
            builder.ClientName(name);
            builder.ClientSurname(surname);
            builder.ClientAddress(address);
            builder.ClientUsername(username);
            builder.ClientPassportData(data);
            builder.ClientId(id);
        }
    }
}