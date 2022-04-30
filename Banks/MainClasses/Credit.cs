namespace Banks.MainClasses
{
    public class Credit : ClientAccount
    {
        public Credit(ClientInfo clientName, decimal monthlyPayments, decimal maxCountOfCreditation, decimal countMoney)
            : base(clientName)
        {
            Category = Category.Credit;
            MonthlyPayments = monthlyPayments;
            MaxCountOfCreditation = maxCountOfCreditation;
            CountMoney = countMoney;
        }

        public Credit(ClientInfo clientName, decimal mainBankCreditRate, decimal maxCountOfCreditation)
        {
            throw new System.NotImplementedException();
        }

        public decimal MaxCountOfCreditation { get; set; }
        public decimal MonthlyPayments { get; set; }

        public void Transactions()
        {
            if (MaxCountOfCreditation > CountMoney)
            {
                MoneyForPay -= MonthlyPayments;
            }
        }
    }
}