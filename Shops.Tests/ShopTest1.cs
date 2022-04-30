using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shops;

namespace Shops.Tests
{
    [TestFixture]
    public class MarketDirectorTest
    {
        private MarketDirector _shopManager = new MarketDirector();
        
        private Good good1 = new Good("Молоко", 10, 10);
        private Good good2 = new Good("Творог", 20, 50);
        private Good good3 = new Good("Мясо", 30, 50);

        private Market market1 = new Market(1, 50000);
        private Market market2 = new Market(2, 1000000);
        private Market market3 = new Market(3, 10000000);
        
    }
}