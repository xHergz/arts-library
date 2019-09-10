using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class ArtsApiTestData
    {
        public static string GET_ALL_STOCK_ITEMS_RESULTS_RESPONSE = $@"{{
            ""status"": 0,
            ""stockItems"": [
                {StockItemTestData.VALID_STOCK_ITEM_JSON}
            ]
        }}";

        public static string GET_ALL_STOCK_ITEMS_NO_RESULTS_RESPONSE = $@"{{
            ""status"": 0,
            ""stockItems"": []
        }}";

        public static string GET_ALL_STOCK_ITEMS_ERROR_RESPONSE = $@"{{
            ""status"": 1,
            ""stockItems"": null
        }}";

        public static string GET_STOCK_ETRY_HISTORY_NO_RESULTS_RESPONSE = $@"{{
            ""status"": 0,
            ""stockItemEntryHistory"": []
        }}";

        public static string CREATE_STOCK_ENTRY_SUCCESSFUL_RESPONSE = $@"{{
            ""status"": 0
        }}";

        public static string CREATE_STOCK_ENTRY_UNSUCCESSFUL_RESPONSE = $@"{{
            ""status"": 1020
        }}";

        public static string INVALID_RESPONSE = $@"{{
            ""blah"": ""blah""
        }}";
    }
}
