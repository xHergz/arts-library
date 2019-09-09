using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AruaRoseToolSuiteLibrary.Data;
using HergBot.RestClient;
using HergBot.RestClient.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AruaRoseToolSuiteLibrary.Api
{
    public class ArtsApi
    {
        private const string ARTS_API_URL = "https://api.aruarosetoolsuite.localhost";

        private const string STOCK_ITEM_ENDPOINT = "stock-item";

        private const string STOCK_ENTRY_ENDPOINT = "stock-entry";

        private const string STOCK_ITEM_ID_KEY = "stockItemId";

        private const string ENTRY_DATE_KEY = "entryDate";

        private const string AVERAGE_PRICE_KEY = "averagePrice";

        private const string LOWEST_PRICE_KEY = "lowestPrice";

        private const string HIGHEST_PRICE_KEY = "highestPrice";

        private const string DATA_POINTS_KEY = "dataPoints";

        private const string STATUS_KEY = "status";

        private const string STOCK_ITEM_KEY = "stockItem";

        private const string STOCK_ITEMS_KEY = "stockItems";

        private const int SUCCESS_STATUS = 0;

        private IRestClient _restClient;

        public static string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public ArtsApi(IRestClient client)
        {
            _restClient = client;
        }

        public List<StockItem> GetAllStockItems()
        {
            string ALL_STOCK_ITEMS_URL = $"{ARTS_API_URL}/{STOCK_ITEM_ENDPOINT}";

            HttpResponse allStockItemsResponse = _restClient.Get(ALL_STOCK_ITEMS_URL);
            if (!allStockItemsResponse.Success)
            {
                return null;
            }

            return ParseResultList<StockItem>(allStockItemsResponse.Response, STOCK_ITEMS_KEY);
        }

        public bool CreateStockItemEntry(StockEntry entry)
        {
            string CREATE_STOCK_ENTRY_ENDPOINT = $"{ARTS_API_URL}/{STOCK_ENTRY_ENDPOINT}";
            JsonBodyParameter body = new JsonBodyParameter();
            body.AddValue(STOCK_ITEM_ID_KEY, entry.StockItemId.ToString());
            body.AddValue(ENTRY_DATE_KEY, entry.EntryDate.ToString());
            body.AddValue(AVERAGE_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(LOWEST_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(HIGHEST_PRICE_KEY, entry.StockItemId.ToString());
            body.AddValue(DATA_POINTS_KEY, entry.StockItemId.ToString());

            HttpResponse createStockEntryResponse = _restClient.Put(CREATE_STOCK_ENTRY_ENDPOINT, body);
            if (!createStockEntryResponse.Success)
            {
                return false;
            }

            int? status = ParseStatusResult(createStockEntryResponse.Response);
            return status == SUCCESS_STATUS;
        }

        private int? ParseStatusResult(string resultJson)
        {
            JObject parsedJson = null;

            try
            {
                parsedJson = JObject.Parse(resultJson);
            }
            catch (JsonReaderException exception)
            {
                // Failed to parse the JSON, probably due to invalid JSON
                return null;
            }

            if (!parsedJson.ContainsKey(STATUS_KEY))
            {
                return null;
            }

            return Convert.ToInt32(parsedJson[STATUS_KEY]);
        }

        private List<T> ParseResultList<T>(string resultJson, string resultKey)
        {
            List<T> resultList = new List<T>();
            JObject parsedJson = null;

            try
            {
                parsedJson = JObject.Parse(resultJson);
            }
            catch(JsonReaderException exception)
            {
                // Failed to parse the JSON, probably due to invalid JSON
                return null;
            }
            
            if (!parsedJson.ContainsKey(STATUS_KEY))
            {
                return null;
            }
            else if (!parsedJson.ContainsKey(STOCK_ITEMS_KEY))
            {
                return null;
            }

            int status = Convert.ToInt32(parsedJson[STATUS_KEY]);
            IList<JToken> results = parsedJson[resultKey].Children().ToList();

            if (status != SUCCESS_STATUS)
            {
                return null;
            }

            foreach (JToken result in results)
            {
                resultList.Add(result.ToObject<T>());
            }

            return resultList;
        }
    }
}
