using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Api;
using HergBot.Logging;
using HergBot.RestClient;
using HergBot.RestClient.Http;
using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class ArtsApi_Tests
    {
        private Mock<IRestClient> _mockRestClient;

        private Mock<ILogger> _mockLogger;

        private ArtsApi _artsApi;

        [SetUp]
        public void SetUp()
        {
            _mockRestClient = new Mock<IRestClient>();
            _mockLogger = new Mock<ILogger>();
            _artsApi = new ArtsApi(_mockRestClient.Object, _mockLogger.Object);
            _mockLogger.Setup(x => x.LogInfo(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAllStockItems_WithResultsResponse_ReturnsList()
        {
            StockItem expectedStockItem = StockItemTestData.Generate();
            MockGetAllResponse(ArtsApiTestData.GET_ALL_STOCK_ITEMS_RESULTS_RESPONSE);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.AreEqual(1, stockItems.Count);
            Assert.AreEqual(expectedStockItem.StockItemId, stockItems[0].StockItemId);
            Assert.AreEqual(expectedStockItem.StockItemGroupId, stockItems[0].StockItemGroupId);
            Assert.AreEqual(expectedStockItem.ItemId, stockItems[0].ItemId);
            Assert.AreEqual(expectedStockItem.Name, stockItems[0].Name);
            Assert.AreEqual(expectedStockItem.ShortName, stockItems[0].ShortName);
            Assert.AreEqual(expectedStockItem.DateAdded, stockItems[0].DateAdded);
            Assert.AreEqual(expectedStockItem.IsTracked, stockItems[0].IsTracked);
        }

        [Test]
        public void GetAllStockItems_WithNoResultsResponse_ReturnsEmptyList()
        {
            MockGetAllResponse(ArtsApiTestData.GET_ALL_STOCK_ITEMS_NO_RESULTS_RESPONSE);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.AreEqual(0, stockItems.Count);
        }

        [Test]
        public void GetAllStockItems_WithErrorResponse_ReturnsNull()
        {
            MockGetAllResponse(ArtsApiTestData.GET_ALL_STOCK_ITEMS_ERROR_RESPONSE);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.IsNull(stockItems);
        }

        [Test]
        public void GetAllStockItems_WithInvalidResponse_ReturnsNull()
        {
            MockGetAllResponse(ArtsApiTestData.INVALID_RESPONSE);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.IsNull(stockItems);
        }

        [Test]
        public void GetAllStockItems_WithEmptyResponse_ReturnsNull()
        {
            MockGetAllResponse(string.Empty);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.IsNull(stockItems);
        }

        [Test]
        public void CreateStockEntry_WithSuccessfulResponse_ReturnsTrue()
        {
            StockEntry entry = StockEntryTestData.Generate();
            MockPutResponse(ArtsApiTestData.CREATE_STOCK_ENTRY_SUCCESSFUL_RESPONSE);
            bool success = _artsApi.CreateStockItemEntry(entry);
            Assert.IsTrue(success);
        }

        [Test]
        public void CreateStockEntry_WithUnsuccessfulResponse_ReturnsFalse()
        {
            StockEntry entry = StockEntryTestData.Generate();
            MockPutResponse(ArtsApiTestData.CREATE_STOCK_ENTRY_UNSUCCESSFUL_RESPONSE);
            bool success = _artsApi.CreateStockItemEntry(entry);
            Assert.IsFalse(success);
        }

        [Test]
        public void CreateStockEntry_WithInvalidResponse_ReturnsFalse()
        {
            StockEntry entry = StockEntryTestData.Generate();
            MockPutResponse(ArtsApiTestData.INVALID_RESPONSE);
            bool success = _artsApi.CreateStockItemEntry(entry);
            Assert.IsFalse(success);
        }

        [Test]
        public void CreateStockEntry_WithEmptyResponse_ReturnsFalse()
        {
            StockEntry entry = StockEntryTestData.Generate();
            MockPutResponse(string.Empty);
            bool success = _artsApi.CreateStockItemEntry(entry);
            Assert.IsFalse(success);
        }

        private void MockGetAllResponse(string response)
        {
            _mockRestClient.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(new HttpResponse("www.test.com", System.Net.HttpStatusCode.OK, response, HttpVerb.GET));
        }

        private void MockPutResponse(string response)
        {
            _mockRestClient.Setup(x => x.Put(It.IsAny<string>(), It.IsAny<JsonBodyParameter>()))
                .Returns(new HttpResponse("www.test.com", System.Net.HttpStatusCode.OK, response, HttpVerb.PUT));
        }
    }
}

