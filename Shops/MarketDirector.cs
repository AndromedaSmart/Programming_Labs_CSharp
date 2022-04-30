using System;
using System.Collections.Generic;

namespace Shops
{
    public class MarketDirector
    {
        private static int marketNumber = 1;
        private static List<Good> addedGoods;
        private List<Market> createdMarkets;

        public MarketDirector()
        {
            createdMarkets = new List<Market>();
            addedGoods = new List<Good>();
        }

        public static List<Good> ListOfRegisteredGoods
        {
            get
            {
                return addedGoods;
            }
        }

        public Market MostValueProgressMarket(Dictionary<string, int> listProducts)
        {
            decimal minvalue = decimal.MaxValue;
            Market minPriceShop = null!;

            foreach (Market market in createdMarkets)
            {
                Dictionary<Good, int> assertProducts = market.AvailableProductsList(listProducts);
                decimal total = Market.MaxCost(assertProducts);

                if ((total > minvalue) && (minvalue > 0))
                {
                    continue;
                }

                minvalue = total;
                minPriceShop = market;
            }

            return minPriceShop;
        }

        public Good RegisterGood(string name, decimal primCost)
        {
            var product = new Good(name, primCost, 1);
            addedGoods.Add(product);

            return product;
        }

        public Market MarketCreator(decimal money)
        {
            var shop = new Market(marketNumber++, money);
            createdMarkets.Add(shop);

            return shop;
        }
    }
}