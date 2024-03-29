﻿using System;

using Newtonsoft.Json;
using NUnit.Framework;

using AruaRoseToolSuiteLibrary.Api;
using AruaRoseToolSuiteLibrary.Data;
using AruaRoseToolSuiteLibrary_Tests.Data;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class StockEntry_Tests
    {
        private StockEntry _stockEntry;

        [Test]
        public void JsonConstructor_WithValidJsonWithAverageChange_ReturnsValidStockEntry()
        {
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.VALID_STOCK_ENTRY_WITH_AVERAGE_CHANGE_JSON);
            Assert.AreEqual(StockEntryTestData.STOCK_ENTRY_ID, _stockEntry.StockEntryId);
            Assert.AreEqual(StockItemTestData.STOCK_ITEM_ID, _stockEntry.StockItemId);
            Assert.AreEqual(StockEntryTestData.ENTRY_DATE, _stockEntry.EntryDate.ToString(ArtsApi.DATE_FORMAT));
            Assert.AreEqual(StockEntryTestData.AVERAGE_PRICE, _stockEntry.AveragePrice);
            Assert.AreEqual(StockEntryTestData.HIGHEST_PRICE, _stockEntry.HighestPrice);
            Assert.AreEqual(StockEntryTestData.LOWEST_PRICE, _stockEntry.LowestPrice);
            Assert.AreEqual(StockEntryTestData.DATA_POINTS, _stockEntry.DataPoints);
            Assert.AreEqual(StockEntryTestData.AVERAGE_CHANGE_FROM_PREVIOUS_DAY, _stockEntry.AverageChangeFromPreviousDay);
        }

        [Test]
        public void JsonConstructor_WithValidJsonWithoutAverageChange_ReturnsValidStockEntry()
        {
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.VALID_STOCK_ENTRY_WITHOUT_AVERAGE_CHANGE_JSON);
            Assert.AreEqual(StockEntryTestData.STOCK_ENTRY_ID, _stockEntry.StockEntryId);
            Assert.AreEqual(StockItemTestData.STOCK_ITEM_ID, _stockEntry.StockItemId);
            Assert.AreEqual(StockEntryTestData.ENTRY_DATE, _stockEntry.EntryDate.ToString(ArtsApi.DATE_FORMAT));
            Assert.AreEqual(StockEntryTestData.AVERAGE_PRICE, _stockEntry.AveragePrice);
            Assert.AreEqual(StockEntryTestData.HIGHEST_PRICE, _stockEntry.HighestPrice);
            Assert.AreEqual(StockEntryTestData.LOWEST_PRICE, _stockEntry.LowestPrice);
            Assert.AreEqual(StockEntryTestData.DATA_POINTS, _stockEntry.DataPoints);
            Assert.IsNull(_stockEntry.AverageChangeFromPreviousDay);
        }

        [Test]
        public void JsonConstructor_WithInvalidJson_ReturnsValidStockEntry()
        {
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.INVALID_STOCK_ENTRY_JSON);
            Assert.AreEqual(0, _stockEntry.StockEntryId);
            Assert.AreEqual(0, _stockEntry.StockItemId);
            Assert.AreEqual(DateTime.MinValue, _stockEntry.EntryDate);
            Assert.AreEqual(0, _stockEntry.AveragePrice);
            Assert.AreEqual(0, _stockEntry.HighestPrice);
            Assert.AreEqual(0, _stockEntry.LowestPrice);
            Assert.AreEqual(0, _stockEntry.DataPoints);
            Assert.IsNull(_stockEntry.AverageChangeFromPreviousDay);
        }

        [Test]
        public void JsonConstructor_WithEmptyString_ReturnsNull()
        {
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(string.Empty);
            Assert.IsNull(_stockEntry);
        }

        [Test]
        public void ToString_WithAverageChange_ReturnsFormattedString()
        {
            string expected = $"StockEntry: StockEntryId = {StockEntryTestData.STOCK_ENTRY_ID}, StockItemId = {StockItemTestData.STOCK_ITEM_ID}, "
                + $"EntryDate = {StockEntryTestData.ENTRY_DATE}, AveragePrice = {StockEntryTestData.AVERAGE_PRICE}, HighestPrice = "
                + $"{StockEntryTestData.HIGHEST_PRICE}, LowestPrice = {StockEntryTestData.LOWEST_PRICE}, DataPoints = {StockEntryTestData.DATA_POINTS}, "
                + $"AvergaeChangeFromPreviousDay = {StockEntryTestData.AVERAGE_CHANGE_FROM_PREVIOUS_DAY}";
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.VALID_STOCK_ENTRY_WITH_AVERAGE_CHANGE_JSON);
            Assert.AreEqual(expected, _stockEntry.ToString());
        }

        [Test]
        public void ToString_WithoutAverageChange_ReturnsFormattedString()
        {
            string expected = $"StockEntry: StockEntryId = {StockEntryTestData.STOCK_ENTRY_ID}, StockItemId = {StockItemTestData.STOCK_ITEM_ID}, "
                + $"EntryDate = {StockEntryTestData.ENTRY_DATE}, AveragePrice = {StockEntryTestData.AVERAGE_PRICE}, HighestPrice = "
                + $"{StockEntryTestData.HIGHEST_PRICE}, LowestPrice = {StockEntryTestData.LOWEST_PRICE}, DataPoints = {StockEntryTestData.DATA_POINTS}, "
                + $"AvergaeChangeFromPreviousDay = null";
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.VALID_STOCK_ENTRY_WITHOUT_AVERAGE_CHANGE_JSON);
            Assert.AreEqual(expected, _stockEntry.ToString());
        }

        [Test]
        public void ToString_WithAnInvalidStockEntry_ReturnsFormattedString()
        {
            string expected = $"StockEntry: StockEntryId = 0, StockItemId = 0, EntryDate = {DateTime.MinValue.ToString(ArtsApi.DATE_FORMAT)}, "
                + $"AveragePrice = 0, HighestPrice = 0, LowestPrice = 0, DataPoints = 0, AvergaeChangeFromPreviousDay = null";
            _stockEntry = JsonConvert.DeserializeObject<StockEntry>(StockEntryTestData.INVALID_STOCK_ENTRY_JSON);
            Assert.AreEqual(expected, _stockEntry.ToString());
        }
    }
}
