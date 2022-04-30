namespace Banks.MainClasses
{
    public class ClientAccount
    {
        public ClientAccount(ClientInfo clientName)
        {
            NameOfClient = clientName;
            clientName.PersonalSystem = this;
        }

        public ClientAccount()
        {
            throw new System.NotImplementedException();
        }

        public static ClientInfo NameOfClient { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public string UserNumber { get; set; }
        public decimal CountMoney { get; set; }
        public Category Category { get; set; }
        public decimal MoneyForPay { get; set; }
    }
}