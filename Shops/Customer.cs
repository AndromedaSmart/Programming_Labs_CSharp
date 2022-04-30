namespace Shops
{
    public class Customer
    {
        public Customer(decimal money)
        {
            Money = money;
        }

        public decimal Money { get; set; }
    }
}