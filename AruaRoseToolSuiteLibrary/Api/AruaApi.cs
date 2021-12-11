/*
* PROJECT: ARTS Library
* PROGRAMMER: Justin
* FIRST VERSION: 22/09/2019
*/

using Newtonsoft.Json;

using AruaRoseToolSuiteLibrary.Data;
using HergBot.Logging;
using HergBot.RestClient;
using HergBot.RestClient.Http;

namespace AruaRoseToolSuiteLibrary.Api
{
    /// <summary>
    /// Encapsulates the calls available from the AruaROSE API
    /// </summary>
    public class AruaApi
    {
        private const string API_KEY_KEY = "key";

        private const string TYPE_KEY = "type";

        private const string DATA_KEY = "data";

        private const string ITEM_TYPE = "item";

        private IRestClient _restClient;

        private ILogger _logger;

        private string _aruaApiUrl;

        private string _aruaApiKey;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">The rest client to use for communicating with the API</param>
        /// <param name="logger">The logger</param>
        /// <param name="apiKey">Key to access the API</param>
        public AruaApi(IRestClient client, ILogger logger, string apiUrl, string apiKey)
        {
            // The Arua api doesn't use auth headers, it uses query args
            _restClient = client;
            _logger = logger;
            _aruaApiUrl = apiUrl;
            _aruaApiKey = apiKey;
        }

        /// <summary>
        /// Gets a summary of an items current price information from Duke
        /// </summary>
        /// <param name="item">The item to get info for</param>
        /// <returns>An object containing the price information</returns>
        public PriceInfo GetItemPriceInfo(StockItem item)
        {
            QueryParameter itemPriceQuery = ConstructApiQuery(_aruaApiKey, ITEM_TYPE, item.ItemId.ToString());

            HttpResponse itemPriceResponse = _restClient.Get(_aruaApiUrl, itemPriceQuery);
            _logger.LogInfo($"GET {itemPriceResponse.RequestUrl}", "GetItemPriceInfo");
            _logger.LogInfo($"Status: {itemPriceResponse.Status}", "GetItemPriceInfo");
            _logger.LogInfo($"Response: {itemPriceResponse.Response}", "GetItemPriceInfo");
            if (!itemPriceResponse.Success)
            {
                _logger.LogError("Get item price info failed.", "GetItemPriceInfo");
                return null;
            }

            return JsonConvert.DeserializeObject<PriceInfo>(itemPriceResponse.Response);
        }

        public void GetArmoryPriceInfo(StockItem item)
        {
            string armoryUrl = $"https:";
            HttpResponse itemPriceResponse = _restClient.Get(_aruaApiUrl, itemPriceQuery);
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
