using System;

namespace Shops
{
    public class Good
    {
        public Good(string name, decimal price, int count)
        {
            Name = name;
            Total = price;
            Count = count;
        }

        public Good()
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Total { get; set; }
    }
}