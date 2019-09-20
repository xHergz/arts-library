using System;

using AruaRoseToolSuiteLibrary.Data;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class StockItemTestData
    {
        public static int STOCK_ITEM_ID = 1;

        public static string SHORT_NAME = "AU";

        public static string DATE_ADDED = "2019-01-01 00:00:00";

        public static int IS_TRACKED = 1;

        public static string VALID_STOCK_ITEM_JSON = $@"{{
            ""stockItemId"": {STOCK_ITEM_ID},
            ""stockItemGroupId"": {StockItemGroupTestData.STOCK_ITEM_GROUP_ID},
            ""itemId"": {ItemTestData.ITEM_ID},
            ""name"": ""{ItemTestData.ITEM_NAME}"",
            ""shortName"": ""{SHORT_NAME}"",
            ""dateAdded"": ""{DATE_ADDED}"",
            ""isTracked"": {IS_TRACKED}
        }}";

        public static string INVALID_STOCK_ITEM_JSON = $@"{{
            ""blah"": ""blah"",
        }}";

        public static StockItem Generate()
        {
            return new StockItem(
                STOCK_ITEM_ID,
                StockItemGroupTestData.STOCK_ITEM_GROUP_ID,
                ItemTestData.ITEM_ID,
                ItemTestData.ITEM_NAME,
                SHORT_NAME,
                DateTime.Parse(DATE_ADDED),
                Convert.ToBoolean(IS_TRACKED)
            );
        }
    }
}
