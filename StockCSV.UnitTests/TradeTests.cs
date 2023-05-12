namespace StockCSV.UnitTests
{
    [TestFixture]
    public class TradeTests
    {
        [SetUp]
        public void Setup()
        {
            // Holding
            // Trade of type sell some holdings
            // Trade of type sell all holdings
            // Trade of type buy new holding
            // Trade of type buy add to existing holdings
        }
        
        [Test]
        public void Sell_WhenCalled_ReturnTotalProfitLoss()
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