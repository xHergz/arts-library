namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class TestData
    {
        public static int ITEM_ID = 12000088;

        public static string ITEM_NAME = "Lisent (Au)";

        public static int ONE_DAY_AVERAGE = 12899144;

        public static int SEVEN_DAY_AVERAGE = 13480910;

        public static string ERROR = "invalid_item";

        public static string ARUA_API_SUCCESS_RESPONSE = $@"{{
            ""success"":true,
            ""item"":""{ITEM_ID}"",
            ""name"":""{ITEM_NAME}"",
            ""market_sell_prices_high"":[
                ""30000000"",
                ""30000000"",
                ""30000000"",
                ""30000000"",
                ""28500000"",
                ""20899000"",
                ""20000000"",
                ""20000000"",
                ""18000000"",
                ""18000000""
            ],
            ""market_sell_prices_low"":[
                ""12500000"",
                ""12500000"",
                ""12999999"",
                ""13000000"",
                ""13000000"",
                ""13000000"",
                ""13099999"",
                ""13188888"",
                ""13200000"",
                ""13400000""
            ],
            ""market_buy_prices_high"":[
                ""12100000"",
                ""12000000"",
                ""12000000"",
                ""12000000"",
                ""11912000"",
                ""11588888"",
                ""11500000"",
                ""10000000"",
                ""1844"",
                ""1""
            ],
            ""market_buy_prices_low"":[
                ""1"",
                ""1844"",
                ""10000000"",
                ""11500000"",
                ""11588888"",
                ""11912000"",
                ""12000000"",
                ""12000000"",
                ""12000000"",
                ""12100000""
            ],
            ""average_1day"":""{ONE_DAY_AVERAGE}"",
            ""average_7day"":""{SEVEN_DAY_AVERAGE}""
        }}";

        public static string ARUA_API_ERROR_RESPONSE = $@"{{
            ""success"":false,
            ""error"":""{ERROR}""
        }}";

        public static string ARUA_API_EMPTY_RESPONSE = string.Empty;
    }
}
