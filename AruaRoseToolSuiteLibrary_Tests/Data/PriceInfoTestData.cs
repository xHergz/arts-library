using System.Collections.Generic;

using AruaRoseToolSuiteLibrary.Data;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class PriceInfoTestData
    {
        public static List<int> HIGH_SELL_PRICES = new List<int>()
        {
            30000000,
            30000000,
            30000000,
            30000000,
            28500000,
            20899000,
            20000000,
            20000000,
            18000000,
            18000000
        };

        public static List<int> LOW_SELL_PRICES = new List<int>()
        {
            12500000,
            12500000,
            12999999,
            13000000,
            13000000,
            13000000,
            13099999,
            13188888,
            13200000,
            13400000
        };

        public static List<int> HIGH_BUY_PRICES = new List<int>()
        {
            12100000,
            12000000,
            12000000,
            12000000,
            11912000,
            11588888,
            11500000,
            10000000,
            1844,
            1
        };

        public static List<int> LOW_BUY_PRICES = new List<int>()
        {
            1,
            1844,
            10000000,
            11500000,
            11588888,
            11912000,
            12000000,
            12000000,
            12000000,
            12100000
        };

        public static int ONE_DAY_AVERAGE = 12899144;

        public static int SEVEN_DAY_AVERAGE = 13480910;

        public static string ERROR = "invalid_item";

        public static string SUCCESS_PRICE_INFO_JSON = $@"{{
            ""success"":true,
            ""item"":""{ItemTestData.ITEM_ID}"",
            ""name"":""{ItemTestData.ITEM_NAME}"",
            ""market_sell_prices_high"":[
                {string.Join(", ", HIGH_SELL_PRICES)}
            ],
            ""market_sell_prices_low"":[
                {string.Join(", ", LOW_SELL_PRICES)}
            ],
            ""market_buy_prices_high"":[
                {string.Join(", ", HIGH_BUY_PRICES)}
            ],
            ""market_buy_prices_low"":[
                {string.Join(", ", LOW_BUY_PRICES)}
            ],
            ""average_1day"":""{ONE_DAY_AVERAGE}"",
            ""average_7day"":""{SEVEN_DAY_AVERAGE}""
        }}";

        public static string ERROR_PRICE_INFO_JSON = $@"{{
            ""success"":false,
            ""error"":""{ERROR}""
        }}";

        public static string INVALID_PRICE_INFO_JSON = $@"{{
            ""blah"": ""blah"",
        }}";

        public static PriceInfo GenerateSuccesfulInfo()
        {
            return new PriceInfo(
                true,
                string.Empty,
                ItemTestData.ITEM_ID,
                ItemTestData.ITEM_NAME,
                HIGH_SELL_PRICES,
                LOW_SELL_PRICES,
                HIGH_BUY_PRICES,
                LOW_BUY_PRICES,
                ONE_DAY_AVERAGE,
                SEVEN_DAY_AVERAGE
            );
        }

        public static PriceInfo GenerateErrorInfo()
        {
            return new PriceInfo(
                false,
                ERROR,
                0,
                string.Empty,
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                0,
                0
            );
        }

        public static PriceInfo GenerateInvalidInfo()
        {
            return new PriceInfo(
                false,
                string.Empty,
                0,
                string.Empty,
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                0,
                0
            );
        }
    }
}
