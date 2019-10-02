using Moq;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Api;
using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;
using HergBot.Logging;
using HergBot.RestClient;
using HergBot.RestClient.Http;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class AruaApi_Tests
    {
        private const string TEST_URL = "www.test.com/api/";

        private const string TEST_KEY = "test_key";

        private Mock<IRestClient> _mockRestClient;

        private Mock<ILogger> _mockLogger;

        private AruaApi _aruaApi;

        private StockItem _testItem;

        [SetUp]
        public void SetUp()
        {
            _mockRestClient = new Mock<IRestClient>();
            _mockLogger = new Mock<ILogger>();
            _aruaApi = new AruaApi(_mockRestClient.Object, _mockLogger.Object, TEST_URL, TEST_KEY);
            _testItem = StockItemTestData.Generate();
        }

        [Test]
        public void GetItemPriceInfo_WithSuccessfulResponse_ReturnsInfo()
        {
            PriceInfo expected = PriceInfoTestData.GenerateSuccesfulInfo();
            MockResponse(PriceInfoTestData.SUCCESS_PRICE_INFO_JSON);
            PriceInfo info = _aruaApi.GetItemPriceInfo(_testItem);
            Assert.AreEqual(expected.Success, info.Success);
            Assert.AreEqual(expected.Error, info.Error);
            Assert.AreEqual(expected.ItemId, info.ItemId);
            Assert.AreEqual(expected.ItemName, info.ItemName);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.OneDayAverage, info.OneDayAverage);
            Assert.AreEqual(expected.SevenDayAverage, info.SevenDayAverage);
        }

        [Test]
        public void GetItemPriceInfo_WithErrorResponse_ReturnsError()
        {
            PriceInfo expected = PriceInfoTestData.GenerateErrorInfo();
            MockResponse(PriceInfoTestData.ERROR_PRICE_INFO_JSON);
            PriceInfo info = _aruaApi.GetItemPriceInfo(_testItem);
            Assert.AreEqual(expected.Success, info.Success);
            Assert.AreEqual(expected.Error, info.Error);
            Assert.AreEqual(expected.ItemId, info.ItemId);
            Assert.AreEqual(expected.ItemName, info.ItemName);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.OneDayAverage, info.OneDayAverage);
            Assert.AreEqual(expected.SevenDayAverage, info.SevenDayAverage);
        }

        [Test]
        public void GetItemPriceInfo_WithInvalidResponse_ReturnsNull()
        {
            PriceInfo expected = PriceInfoTestData.GenerateInvalidInfo();
            MockResponse(PriceInfoTestData.INVALID_PRICE_INFO_JSON);
            PriceInfo info = _aruaApi.GetItemPriceInfo(_testItem);
            Assert.AreEqual(expected.Success, info.Success);
            Assert.AreEqual(expected.Error, info.Error);
            Assert.AreEqual(expected.ItemId, info.ItemId);
            Assert.AreEqual(expected.ItemName, info.ItemName);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.HighSellPrices, info.HighSellPrices);
            Assert.AreEqual(expected.LowSellPrices, info.LowSellPrices);
            Assert.AreEqual(expected.OneDayAverage, info.OneDayAverage);
            Assert.AreEqual(expected.SevenDayAverage, info.SevenDayAverage);
        }

        [Test]
        public void GetItemPriceInfo_WithEmptyResponse_ReturnsNull()
        {
            MockResponse(string.Empty);
            PriceInfo info = _aruaApi.GetItemPriceInfo(_testItem);
            Assert.IsNull(info);
        }

        private void MockResponse(string response)
        {
            _mockRestClient.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<QueryParameter>()))
                .Returns(new HttpResponse("www.test.com", System.Net.HttpStatusCode.OK, response, HttpVerb.GET));
        }
    }
}
