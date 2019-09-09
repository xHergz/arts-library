using Newtonsoft.Json;

using AruaRoseToolSuiteLibrary.Data;
using HergBot.RestClient;
using HergBot.RestClient.Http;

namespace AruaRoseToolSuiteLibrary.Api
{
    public class AruaApi
    {
        private const string ARUA_API_URL = "https://www.aruarose.com/api/";

        private const string API_KEY_KEY = "key";

        private const string TYPE_KEY = "type";

        private const string DATA_KEY = "data";

        private const string ITEM_TYPE = "item";

        private IRestClient _restClient;

        private string _aruaApiKey;

        public AruaApi(IRestClient client, string apiKey)
        {
            // The Arua api doesn't use auth headers, it uses query args
            _restClient = client;
            _aruaApiKey = apiKey;
        }

        public PriceInfo GetItemPriceInfo(StockItem item)
        {
            QueryParameter itemPriceQuery = ConstructApiQuery(_aruaApiKey, ITEM_TYPE, item.ItemId.ToString());
            HttpResponse itemPriceResponse = null;

            itemPriceResponse = _restClient.Get(ARUA_API_URL, itemPriceQuery);
            if (!itemPriceResponse.Success)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PriceInfo>(itemPriceResponse.Response);
        }

        private QueryParameter ConstructApiQuery(string key, string type, string data)
        {
            QueryParameter query = new QueryParameter();
            query.AddValue(API_KEY_KEY, key);
            query.AddValue(TYPE_KEY, type);
            query.AddValue(DATA_KEY, data);
            return query;
        }
    }
}
