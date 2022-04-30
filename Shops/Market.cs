using System.Collections.Generic;
using System.Linq;
using Shops.Tools;

namespace Shops
{
    public class Market
    {
        private readonly List<Good> availableGoods;
        private readonly int defaultUnit = 10;

        public Market(int number, decimal money)
        {
            MarketNumber = number;
            MoneyCount = money;
            availableGoods = new List<Good>();
        }

        private int MarketNumber { get; set; }

        private decimal MoneyCount { get; set; }

        public static decimal MaxCost(Dictionary<Good, int> availableGoods)
        {
            return availableGoods.Sum(count => count.Value);
        }

        public void Delivery(Good good)
        {
            foreach (Good good1 in availableGoods)
            {
                if (good1.Name == good.Name)
                {
                    good = good1;
                }

                good.Count += good.Count;
                good.Total *= defaultUnit;
            }

            MoneyCount -= good.Count * good.Total;
        }

        public Dictionary<Good, int> AvailableProductsList(Dictionary<string, int> list)
        {
            var assertAvailableGoods = new Dictionary<Good, int>();

            foreach ((string number, int count) in list)
            {
                var good = new Good();

                foreach (Good good1 in availableGoods)
                {
                    if (number == good.Name)
                    {
                        good = good1;
                    }

                    if ((good != null) && (count > good.Count))
                    {
                        throw new ShopsException("Not found!");
                    }

                    if (good == null)
                    {
                        throw new ShopsException("Not found!");
                    }
                }

                assertAvailableGoods.Add(good, count);
            }

            return assertAvailableGoods;
        }

        public void SaleGoods(Dictionary<string, int> list, Customer name)
        {
            Dictionary<Good, int> assertGoodsList = AvailableProductsList(list);
            decimal totalCost = MaxCost(assertGoodsList);

            if (totalCost > name.Money)
            {
                throw new ShopsException("Not enough money!");
            }

            foreach ((Good number, int count) in assertGoodsList)
            {
                var good = new Good();

                foreach (Good good1 in availableGoods)
                {
                    if ((good != null) && (good.Name == number.Name))
                    {
                        good = good1;
                    }

                    if (good != null)
                    {
                        good.Count -= count;
                    }
                }
            }

            MoneyCount += totalCost;
            name.Money -= totalCost;
        }

        public Good ShowInformationAboutProduct(string goodNumber)
        {
            foreach (Good good in availableGoods)
            {
                if (goodNumber == good.Name)
                {
                    return good;
                }
                else
                {
                    throw new ShopsException("Not found!");
                }
            }

            return null;
        }

        public void ProductTotalPrice(string goodNumber, decimal newTotal)
        {
            foreach (Good good in availableGoods)
            {
                if (goodNumber == good.Name)
                {
                    good.Total = newTotal;
                }
                else
                {
                    throw new ShopsException("Not found!");
                }
            }
        }
    }
}