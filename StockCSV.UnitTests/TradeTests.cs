using StockCSV.Data;

namespace StockCSV.UnitTests
{
    [TestFixture]
    public class TradeTests
    {
        [SetUp]
        public void Setup()
        {
            
            // Holding
            var holding = new Holding { Id = 1, Code = "AGY", Units = 10, AVGPrice = 1, PurchaseDate = DateTime.Now };
            // Trade of type sell some holdings
            var sellSome = new Trade { Code = "AGY", Units = 4, Price = 2, TradeType = "Sell", GST = 0, Brokerage = 1};
            // Trade of type sell all holdings.
            var sellAll = new Trade { Code = "AGY", Units = 10, Price = 2, TradeType = "Sell", GST = 0, Brokerage = 1 };
            // Trade of type buy new holding
            var buyNew = new Trade { Code = "AGY", Units = 10, Price = 2, TradeType = "Buy", GST = 0, Brokerage = 1, PurchaseDate = DateTime.Now };
            // Trade of type buy add to existing holdings
            var buyExisting = new Trade { Code = "AGY", Units = 10, Price = 2, TradeType = "Buy", GST = 0, Brokerage = 1, PurchaseDate = DateTime.Now };
            var records = new List<Trade>
        }

        [Test]
        public void TaxCalculator_WhenCalled_ReturnTotalProfitLoss()
        {
            Assert.Pass();
        }

        [Test]
        public void Sell_AllStockSold_RemoveHolding()
        {
            Assert.Pass();
        }

        [Test]
        public void Sell_StockSold_UpdateHoldingUnits()
        {
            Assert.Pass();
        }

        [Test]
        public void Buy_NewStockPurchased_NewHoldingCreated()
        {
            Assert.Pass();
        }

        [Test]
        public void Buy_StockPurchased_UpdateHoldingUnits()
        {
            Assert.Pass();
        }

        [Test]
        public void Buy_StockPurchased_UpdatePurchaseDate()
        {
            Assert.Pass();
        }
    }

}