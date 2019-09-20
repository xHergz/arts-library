using System;
using System.Linq;

using AruaRoseToolSuiteLibrary.Data;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class StockEntryTestData
    {
        public static int STOCK_ENTRY_ID = 1;

        public static string ENTRY_DATE = "2019-01-01 00:00:00";

        public static decimal AVERAGE_PRICE = (decimal)PriceInfoTestData.LOW_SELL_PRICES.Average();

        public static int LOWEST_PRICE = PriceInfoTestData.LOW_SELL_PRICES.Min();

        public static int HIGHEST_PRICE = PriceInfoTestData.LOW_SELL_PRICES.Max();

        public static int DATA_POINTS = PriceInfoTestData.LOW_SELL_PRICES.Count;

        public static decimal AVERAGE_CHANGE_FROM_PREVIOUS_DAY = 7.14M;

        public static string VALID_STOCK_ENTRY_WITH_AVERAGE_CHANGE_JSON = $@"{{
            ""stockEntryId"": {STOCK_ENTRY_ID},
            ""stockItemId"": {StockItemTestData.STOCK_ITEM_ID},
            ""entryDate"": ""{ENTRY_DATE}"",
            ""averagePrice"": {AVERAGE_PRICE},
            ""lowestPrice"": {LOWEST_PRICE},
            ""highestPrice"": {HIGHEST_PRICE},
            ""dataPoints"": {DATA_POINTS},
            ""averageChangeFromPreviousDay"": {AVERAGE_CHANGE_FROM_PREVIOUS_DAY}
        }}";

        public static string VALID_STOCK_ENTRY_WITHOUT_AVERAGE_CHANGE_JSON = $@"{{
            ""stockEntryId"": {STOCK_ENTRY_ID},
            ""stockItemId"": {StockItemTestData.STOCK_ITEM_ID},
            ""entryDate"": ""{ENTRY_DATE}"",
            ""averagePrice"": {AVERAGE_PRICE},
            ""lowestPrice"": {LOWEST_PRICE},
            ""highestPrice"": {HIGHEST_PRICE},
            ""dataPoints"": {DATA_POINTS},
            ""averageChangeFromPreviousDay"": null
        }}";

        public static string INVALID_STOCK_ENTRY_JSON = $@"{{
            ""blah"": ""blah""
        }}";

        public static StockEntry Generate()
        {
            return new StockEntry(
                StockItemTestData.STOCK_ITEM_ID,
                DateTime.Parse(ENTRY_DATE),
                AVERAGE_PRICE,
                HIGHEST_PRICE,
                LOWEST_PRICE,
                DATA_POINTS
            );
        }
    }
}
