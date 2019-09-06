using System.Linq;

using Newtonsoft.Json;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class PriceInfo_Tests
    {
        private PriceInfo _priceInfo;

        [Test]
        public void Constructor_WithSuccessfulResponseJson_ReturnsValidInfo()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(TestData.ARUA_API_SUCCESS_RESPONSE);
            Assert.IsTrue(_priceInfo.Success);
            Assert.AreEqual(TestData.ITEM_ID, _priceInfo.ItemId);
            Assert.AreEqual(TestData.ITEM_NAME, _priceInfo.ItemName);
            Assert.IsTrue(_priceInfo.HighSellPrices.Any());
            Assert.IsTrue(_priceInfo.LowSellPrices.Any());
            Assert.IsTrue(_priceInfo.HighBuyPrices.Any());
            Assert.IsTrue(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(TestData.ONE_DAY_AVERAGE, _priceInfo.OneDayAverage);
            Assert.AreEqual(TestData.SEVEN_DAY_AVERAGE, _priceInfo.SevenDayAverage);
            Assert.IsEmpty(_priceInfo.Error);
        }

        [Test]
        public void Constructor_WithErrorResponseJson_ReturnsErrorInfo()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(TestData.ARUA_API_ERROR_RESPONSE);
            Assert.IsFalse(_priceInfo.Success);
            Assert.AreEqual(0, _priceInfo.ItemId);
            Assert.AreEqual(string.Empty, _priceInfo.ItemName);
            Assert.IsFalse(_priceInfo.HighSellPrices.Any());
            Assert.IsFalse(_priceInfo.LowSellPrices.Any());
            Assert.IsFalse(_priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(0, _priceInfo.OneDayAverage);
            Assert.AreEqual(0, _priceInfo.SevenDayAverage);
            Assert.AreEqual(TestData.ERROR, _priceInfo.Error);
        }

        [Test]
        public void Constructor_WithEmptyResponseJson_ReturnsEmptyInfo()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(TestData.ARUA_API_ERROR_RESPONSE);
            Assert.IsFalse(_priceInfo.Success);
            Assert.AreEqual(0, _priceInfo.ItemId);
            Assert.IsEmpty(_priceInfo.ItemName);
            Assert.IsFalse(_priceInfo.HighSellPrices.Any());
            Assert.IsFalse(_priceInfo.LowSellPrices.Any());
            Assert.IsFalse(_priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(0, _priceInfo.OneDayAverage);
            Assert.AreEqual(0, _priceInfo.SevenDayAverage);
            Assert.AreEqual(TestData.ERROR, _priceInfo.Error);
        }
    }
}
