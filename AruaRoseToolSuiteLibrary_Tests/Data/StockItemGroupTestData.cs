namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class StockItemGroupTestData
    {
        public static int STOCK_ITEM_GROUP_ID = 1;

        public static string GROUP_NAME = "Test";

        public static string VALID_STOCK_ITEM_GROUP_JSON = $@"{{
            ""stockItemGroupId"": {STOCK_ITEM_GROUP_ID},
            ""groupName"": {GROUP_NAME},
        }}";

        public static string INVALID_STOCK_ITEM_GROUP_JSON = $@"{{
            ""blah"": ""blah"",
        }}";
    }
}
