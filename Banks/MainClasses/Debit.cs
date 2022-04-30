namespace Banks.MainClasses
{
    public class Debit : ClientAccount
    {
        public Debit(ClientInfo clientName, decimal balanceResidue)
            : base(clientName)
        {
            Category = Category.Debit;
            BalanceResidue = balanceResidue;
        }

        public decimal BalanceResidue { get; set; }

        public void Transactions()
        {
            MoneyForPay += CountMoney * (BalanceResidue / 100);
        }
    }
}