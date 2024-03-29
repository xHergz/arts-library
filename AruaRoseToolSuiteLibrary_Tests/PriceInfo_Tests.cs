﻿using System.Linq;

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
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.SUCCESS_PRICE_INFO_JSON);
            Assert.IsTrue(_priceInfo.Success);
            Assert.AreEqual(ItemTestData.ITEM_ID, _priceInfo.ItemId);
            Assert.AreEqual(ItemTestData.ITEM_NAME, _priceInfo.ItemName);
            Assert.AreEqual(PriceInfoTestData.HIGH_SELL_PRICES, _priceInfo.HighSellPrices);
            Assert.AreEqual(PriceInfoTestData.LOW_SELL_PRICES, _priceInfo.LowSellPrices);
            Assert.AreEqual(PriceInfoTestData.HIGH_BUY_PRICES, _priceInfo.HighBuyPrices);
            Assert.AreEqual(PriceInfoTestData.LOW_BUY_PRICES, _priceInfo.LowBuyPrices);
            Assert.AreEqual(PriceInfoTestData.ONE_DAY_AVERAGE, _priceInfo.OneDayAverage);
            Assert.AreEqual(PriceInfoTestData.SEVEN_DAY_AVERAGE, _priceInfo.SevenDayAverage);
            Assert.IsEmpty(_priceInfo.Error);
        }

        [Test]
        public void Constructor_WithErrorResponseJson_ReturnsErrorInfo()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.ERROR_PRICE_INFO_JSON);
            Assert.IsFalse(_priceInfo.Success);
            Assert.AreEqual(0, _priceInfo.ItemId);
            Assert.AreEqual(string.Empty, _priceInfo.ItemName);
            Assert.IsFalse(_priceInfo.HighSellPrices.Any());
            Assert.IsFalse(_priceInfo.LowSellPrices.Any());
            Assert.IsFalse(_priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(0, _priceInfo.OneDayAverage);
            Assert.AreEqual(0, _priceInfo.SevenDayAverage);
            Assert.AreEqual(PriceInfoTestData.ERROR, _priceInfo.Error);
        }

        [Test]
        public void Constructor_WithInvalidResponseJson_ReturnsDefaultInfo()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.INVALID_PRICE_INFO_JSON);
            Assert.IsFalse(_priceInfo.Success);
            Assert.AreEqual(0, _priceInfo.ItemId);
            Assert.IsEmpty(_priceInfo.ItemName);
            Assert.IsFalse(_priceInfo.HighSellPrices.Any());
            Assert.IsFalse(_priceInfo.LowSellPrices.Any());
            Assert.IsFalse(_priceInfo.HighBuyPrices.Any());
            Assert.IsFalse(_priceInfo.LowBuyPrices.Any());
            Assert.AreEqual(0, _priceInfo.OneDayAverage);
            Assert.AreEqual(0, _priceInfo.SevenDayAverage);
            Assert.IsEmpty(_priceInfo.Error);
        }

        [Test]
        public void Constructor_WithEmptyString_ReturnsNull()
        {
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(string.Empty);
            Assert.IsNull(_priceInfo);
        }

        [Test]
        public void ToString_WithSuccesPriceInfo_ReturnsFormattedString()
        {
            string expected = $"PriceInfo: Success = True, Error = '', ItemId = {ItemTestData.ITEM_ID}, ItemName = '{ItemTestData.ITEM_NAME}', "
                + $"HighSellPrices({PriceInfoTestData.HIGH_SELL_PRICES.Count}) = [{string.Join(", ", PriceInfoTestData.HIGH_SELL_PRICES)}], "
                + $"LowSellPrices({PriceInfoTestData.LOW_SELL_PRICES.Count}) = [{string.Join(", ", PriceInfoTestData.LOW_SELL_PRICES)}], "
                + $"HighBuyPrices({PriceInfoTestData.HIGH_BUY_PRICES.Count}) = [{string.Join(", ", PriceInfoTestData.HIGH_BUY_PRICES)}], "
                + $"LowBuyPrices({PriceInfoTestData.LOW_BUY_PRICES.Count}) = [{string.Join(", ", PriceInfoTestData.LOW_BUY_PRICES)}], "
                + $"OneDayAverage = {PriceInfoTestData.ONE_DAY_AVERAGE}, SevenDayAverage = {PriceInfoTestData.SEVEN_DAY_AVERAGE}";
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.SUCCESS_PRICE_INFO_JSON);
            Assert.AreEqual(expected, _priceInfo.ToString());
        }

        [Test]
        public void ToString_WithErrorPriceInfo_ReturnsFormattedString()
        {
            string expected = $"PriceInfo: Success = False, Error = '{PriceInfoTestData.ERROR}', ItemId = 0, ItemName = '', "
                + $"HighSellPrices(0) = [], LowSellPrices(0) = [], HighBuyPrices(0) = [], LowBuyPrices(0) = [], "
                + $"OneDayAverage = 0, SevenDayAverage = 0";
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.ERROR_PRICE_INFO_JSON);
            Assert.AreEqual(expected, _priceInfo.ToString());
        }

        [Test]
        public void ToString_WithInvalidPriceInfo_ReturnsFormattedString()
        {
            string expected = $"PriceInfo: Success = False, Error = '', ItemId = 0, ItemName = '', "
                + $"HighSellPrices(0) = [], LowSellPrices(0) = [], HighBuyPrices(0) = [], LowBuyPrices(0) = [], "
                + $"OneDayAverage = 0, SevenDayAverage = 0";
            _priceInfo = JsonConvert.DeserializeObject<PriceInfo>(PriceInfoTestData.INVALID_PRICE_INFO_JSON);
            Assert.AreEqual(expected, _priceInfo.ToString());
        }
    }
}
