using System;

using Newtonsoft.Json;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Api;
using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class StockItem_Tests
    {
        private StockItem _stockItem;

        [Test]
        public void Constructor_WithValidJson_ReturnsValidStockItem()
        {
            _stockItem = JsonConvert.DeserializeObject<StockItem>(StockItemTestData.VALID_STOCK_ITEM_JSON);
            Assert.AreEqual(StockItemTestData.STOCK_ITEM_ID, _stockItem.StockItemId);
            Assert.AreEqual(StockItemGroupTestData.STOCK_ITEM_GROUP_ID, _stockItem.StockItemGroupId);
            Assert.AreEqual(ItemTestData.ITEM_ID, _stockItem.ItemId);
            Assert.AreEqual(ItemTestData.ITEM_NAME, _stockItem.Name);
            Assert.AreEqual(StockItemTestData.SHORT_NAME, _stockItem.ShortName);
            Assert.AreEqual(StockItemTestData.DATE_ADDED, _stockItem.DateAdded.ToString(ArtsApi.DATE_FORMAT));
            Assert.AreEqual(Convert.ToBoolean(StockItemTestData.IS_TRACKED), _stockItem.IsTracked);
        }

        [Test]
        public void Constructor_WithInvalidJson_ReturnsValidStockItem()
        {
            _stockItem = JsonConvert.DeserializeObject<StockItem>(StockItemTestData.INVALID_STOCK_ITEM_JSON);
            Assert.AreEqual(0, _stockItem.StockItemId);
            Assert.AreEqual(0, _stockItem.StockItemGroupId);
            Assert.AreEqual(0, _stockItem.ItemId);
            Assert.IsEmpty(_stockItem.Name);
            Assert.IsEmpty(_stockItem.ShortName);
            Assert.AreEqual(DateTime.MinValue, _stockItem.DateAdded);
            Assert.IsFalse(_stockItem.IsTracked);
        }

        [Test]
        public void Constructor_WithEmptyString_ReturnsNull()
        {
            _stockItem = JsonConvert.DeserializeObject<StockItem>(string.Empty);
            Assert.IsNull(_stockItem);
        }
    }
}
