using NUnit.Framework;
using System.Threading.Tasks;

namespace StockInfoGrabber
{
    [TestFixture]
    class AlphaVantageAPITests
    {

        AlphaVantageAPIClient client;

        [SetUp]
        public void Setup()
        {
            client = new AlphaVantageAPIClient();
        }

        [Test]
        public async Task Get_AmdStockPrice_NotNull()
        {
            var stockdata = await client.GetLatestStockData("AMD");

            Assert.IsNotNull(stockdata);
        }


        [Test]
        public async Task Get_AmdStockPrice_StockPrice_and_AMD_NotNull()
        {
            var stockdata = await client.GetLatestStockData("AMD");


            Assert.IsTrue(stockdata.Item2.Symbol == "AMD");
            Assert.IsNotNull(stockdata.Item1.High);

        }


    }
}
