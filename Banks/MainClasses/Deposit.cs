using System;

namespace Banks.MainClasses
{
    public class Deposit : ClientAccount
    {
        public Deposit(ClientInfo clientName, decimal balanceResidue, DateTime date)
            : base(clientName)
        {
            Category = Category.Deposit;
            BalanceResidue = balanceResidue;
        }

        public DateTime Date { get; set; }

        public decimal BalanceResidue { get; set; }

        public void Transactions()
        {
            MoneyForPay += CountMoney * (BalanceResidue / 100);
        }
    }
}