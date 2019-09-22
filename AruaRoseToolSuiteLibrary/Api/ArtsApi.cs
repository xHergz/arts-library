/*
* PROJECT: ARTS Library
* PROGRAMMER: Justin
* FIRST VERSION: 22/09/2019
*/

using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using AruaRoseToolSuiteLibrary.Data;
using HergBot.Logging;
using HergBot.RestClient;
using HergBot.RestClient.Http;

namespace AruaRoseToolSuiteLibrary.Api
{
    /// <summary>
    /// Encapsulates the calls available from the ARTS API
    /// </summary>
    public class ArtsApi
    {
        private const string STOCK_ITEM_ENDPOINT = "stock-item";

        private const string STOCK_ENTRY_ENDPOINT = "stock-entry";

        private const string STOCK_ITEM_ID_KEY = "stockItemId";

        private const string ENTRY_DATE_KEY = "entryDate";

        private const string AVERAGE_PRICE_KEY = "averagePrice";

        private const string LOWEST_PRICE_KEY = "lowestPrice";

        private const string HIGHEST_PRICE_KEY = "highestPrice";

        private const string DATA_POINTS_KEY = "dataPoints";

        private const string STATUS_KEY = "status";

        private const string STOCK_ITEMS_KEY = "stockItems";

        private const int SUCCESS_STATUS = 0;

        private IRestClient _restClient;

        private ILogger _logger;

        private string _artsApiUrl;

        public static string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">The rest client to use for communicating with the API</param>
        /// <param name="logger">The logger</param>
        /// <param name="apiUrl">The root of the API url</param>
        public ArtsApi(IRestClient client, ILogger logger, string apiUrl)
        {
            _restClient = client;
            _logger = logger;
            _artsApiUrl = apiUrl;
        }

        /// <summary>
        /// Gets a list of all the stock items on the server
        /// </summary>
        /// <returns>List of StockItem objects</returns>
        public List<StockItem> GetAllStockItems()
        {
            string ALL_STOCK_ITEMS_URL = $"{_artsApiUrl}/{STOCK_ITEM_ENDPOINT}";

            HttpResponse allStockItemsResponse = _restClient.Get(ALL_STOCK_ITEMS_URL);
            _logger.LogInfo($"GET {allStockItemsResponse.RequestUrl}", "GetAllStockItems");
            _logger.LogInfo($"Status: {allStockItemsResponse.Status}", "GetAllStockItems");
            _logger.LogInfo($"Response: {allStockItemsResponse.Response}", "GetAllStockItems");
            if (!allStockItemsResponse.Success)
            {
                _logger.LogError("Get all stock items failed.", "GetAllStockItems");
                return null;
            }

            return ParseResultList<StockItem>(allStockItemsResponse.Response, STOCK_ITEMS_KEY);
        }

        /// <summary>
        /// Creates a stock entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>True if successful, false if not</returns>
        public bool CreateStockItemEntry(StockEntry entry)
        {
            string CREATE_STOCK_ENTRY_ENDPOINT = $"{_artsApiUrl}/{STOCK_ENTRY_ENDPOINT}";
            JsonBodyParameter body = new JsonBodyParameter();
            body.AddValue(STOCK_ITEM_ID_KEY, entry.StockItemId.ToString());
            body.AddValue(ENTRY_DATE_KEY, entry.EntryDate.ToString());
            body.AddValue(AVERAGE_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(LOWEST_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(HIGHEST_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(DATA_POINTS_KEY, entry.StockItemId.ToString());

            HttpResponse createStockEntryResponse = _restClient.Put(CREATE_STOCK_ENTRY_ENDPOINT, body);
            _logger.LogInfo($"PUT {createStockEntryResponse.RequestUrl}", "CreateStockItemEntry");
            _logger.LogInfo($"Body: {body.ToString()}");
            _logger.LogInfo($"Status: {createStockEntryResponse.Status}", "CreateStockItemEntry");
            _logger.LogInfo($"Response: {createStockEntryResponse.Response}", "CreateStockItemEntry");
            if (!createStockEntryResponse.Success)
            {
                _logger.LogInfo("Create stock item entry failed.", "CreateStockItemEntry");
                return false;
            }

            int? status = ParseStatusResult(createStockEntryResponse.Response);
            return status == SUCCESS_STATUS;
        }

        private JObject ParseJson(string json)
        {
            try
            {
                return JObject.Parse(json);
            }
            catch (JsonReaderException exception)
            {
                // Failed to parse the JSON, probably due to invalid JSON
                _logger.LogError("Failed to parse the JSON, probably due to invalid JSON.", "ParseJson");
                _logger.LogException(exception, "ParseJson");
                return null;
            }
        }

        private int? ParseStatus(JObject json)
        {
            if (json == null)
            {
                _logger.LogError("Invalid json object given.", "ParseStatus");
                return null;
            }

            if (!json.ContainsKey(STATUS_KEY))
            {
                _logger.LogError($"Status key '{STATUS_KEY}' not found.", "ParseStatus");
                return null;
            }

            int status = Convert.ToInt32(json[STATUS_KEY]);
            _logger.LogInfo($"Parsed a status of '{status}'.", "ParseStatus");
            if (status != SUCCESS_STATUS)
            {
                _logger.LogError($"Status returned was unsuccessful: '{status}'", "ParseResultList");
            }
            return status;
        }

        private int? ParseStatusResult(string resultJson)
        {
            JObject parsedJson = ParseJson(resultJson);
            return ParseStatus(parsedJson);
        }

        private List<T> ParseResultList<T>(string resultJson, string resultKey)
        {
            List<T> resultList = new List<T>();
            JObject parsedJson = ParseJson(resultJson);
            int? status = ParseStatus(parsedJson);

            if (!status.HasValue || status != SUCCESS_STATUS)
            {
                return null;
            }
            else if (!parsedJson.ContainsKey(resultKey))
            {
                _logger.LogError($"Result key '{resultKey}' not found.", "ParseResultList");
                return null;
            }

            
            IList<JToken> results = parsedJson[resultKey].Children().ToList();

            foreach (JToken result in results)
            {
                resultList.Add(result.ToObject<T>());
            }
            _logger.LogInfo($"Parsed {resultList.Count} results with key '{resultKey}'.", "ParseResultList");

            return resultList;
        }
    }
}
