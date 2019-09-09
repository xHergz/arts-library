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
    }
}
