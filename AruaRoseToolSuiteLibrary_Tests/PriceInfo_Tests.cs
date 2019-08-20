using System.Linq;

using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class PriceInfo_Tests
    {
        private const int TEST_ID = 12000088;

        private const string TEST_NAME = "Test Item";

        private const int TEST_ONE_DAY_AVERAGE = 10;

        private const int TEST_SEVEN_DAY_AVERAGE = 100;

        private const string TEST_ERROR = "Error!";

        private const int TEST_PRICE = 1000;

        private PriceInfo _priceInfo;

        [SetUp]
        public void SetUp()
        {
            _priceInfo = new PriceInfo(TEST_ID, TEST_NAME, TEST_ONE_DAY_AVERAGE, TEST_SEVEN_DAY_AVERAGE);
        }

        [Test]
        public void Constructor_WithAllProperties_ReturnsValidInfo()
        {
            Assert.IsTrue(_priceInfo.Success);
            Assert.AreEqual(TEST_ID, _priceInfo.ItemId);
            Assert.AreEqual(TEST_NAME, _priceInfo.ItemName);
            Assert.IsFalse(_priceInfo.HighSellPrices.Any());
            Assert.IsFalse(_priceInfo.LowSellPrices.Any());
            Assert.IsFalse(_priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(TEST_ONE_DAY_AVERAGE, _priceInfo.OneDayAverage);
            Assert.AreEqual(TEST_SEVEN_DAY_AVERAGE, _priceInfo.SevenDayAverage);
            Assert.AreEqual(string.Empty, _priceInfo.Error);
        }

        [Test]
        public void Constructor_WithError_ReturnsErrorInfo()
        {
            PriceInfo priceInfo = new PriceInfo(TEST_ERROR);
            Assert.IsFalse(priceInfo.Success);
            Assert.IsNull(priceInfo.ItemId);
            Assert.AreEqual(string.Empty, priceInfo.ItemName);
            Assert.IsFalse(priceInfo.HighSellPrices.Any());
            Assert.IsFalse(priceInfo.LowSellPrices.Any());
            Assert.IsFalse(priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(priceInfo.LowBuyPrices.Any());
            Assert.IsNull(priceInfo.OneDayAverage);
            Assert.IsNull(priceInfo.SevenDayAverage);
            Assert.AreEqual(TEST_ERROR, priceInfo.Error);
        }

        [Test]
        public void AddHighSellPrice_WithNumber_AddsItToList()
        {
            _priceInfo.AddHighSellPrice(TEST_PRICE);
            Assert.IsTrue(_priceInfo.HighSellPrices.Any());
            Assert.AreEqual(TEST_PRICE, _priceInfo.HighSellPrices.First());
        }

        [Test]
        public void AddLowSellPrice_WithNumber_AddsItToList()
        {
            _priceInfo.AddLowSellPrice(TEST_PRICE);
            Assert.IsTrue(_priceInfo.LowSellPrices.Any());
            Assert.AreEqual(TEST_PRICE, _priceInfo.LowSellPrices.First());
        }

        [Test]
        public void AddHighBuyPrice_WithNumber_AddsItToList()
        {
            _priceInfo.AddHighBuyPrice(TEST_PRICE);
            Assert.IsTrue(_priceInfo.HighBuyPrices.Any());
            Assert.AreEqual(TEST_PRICE, _priceInfo.HighBuyPrices.First());
        }

        [Test]
        public void AddLowBuyPrice_WithNumber_AddsItToList()
        {
            _priceInfo.AddLowBuyPrice(TEST_PRICE);
            Assert.IsTrue(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(TEST_PRICE, _priceInfo.LowBuyPrices.First());
        }
    }
}
