namespace Banks.MainClasses
{
    public class ClientInfo
    {
        public static string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PassportData { get; set; }
        public string Username { get; set; }
        public int CliendId { get; set; }

        public ClientAccount PersonalSystem { get; set; }
    }
}