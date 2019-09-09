using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Api;
using HergBot.RestClient;
using HergBot.RestClient.Http;
using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class ArtsApi_Tests
    {
        private Mock<IRestClient> _mockRestClient;

        private ArtsApi _artsApi;

        [SetUp]
        public void SetUp()
        {
            _mockRestClient = new Mock<IRestClient>();
            _artsApi = new ArtsApi(_mockRestClient.Object);
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
        public void GetAllStockItems_WithEmptyResponse_ReturnsNull()
        {
            MockGetAllResponse(string.Empty);
            List<StockItem> stockItems = _artsApi.GetAllStockItems();
            Assert.IsNull(stockItems);
        }

        private void MockGetAllResponse(string response)
        {
            _mockRestClient.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(new HttpResponse("www.test.com", System.Net.HttpStatusCode.OK, response, HttpVerb.GET));
        }
    }
}

