namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class ItemTestData
    {
        public static int ITEM_ID = 12000088;

        public static string ITEM_NAME = "Lisent (Au)";

        public static string ICON_FILE_NAME = "test_file.png";

        public static string ITEM_JSON = $@"{{
            ""itemId"": {ITEM_ID},
            ""name"": ""{ITEM_NAME}"",
            ""iconImageName"": ""{ICON_FILE_NAME}""
        }}";

        public static string INVALID_ITEM_JSON = @"{
            ""1"": 1,
            ""2"": ""eee"",
            ""3"": ""bbb""
        }";
    }
}
