/*
* PROJECT: ARTS Library
* PROGRAMMER: Justin
* FIRST VERSION: 22/09/2019
*/

using System.Collections.Generic;

using Newtonsoft.Json;

namespace AruaRoseToolSuiteLibrary.Data
{
    public class PriceInfo
    {
        private List<int> _highSellPrices;

        private List<int> _lowSellPrices;

        private List<int> _highBuyPrices;

        private List<int> _lowBuyPrices;

        public bool Success { get; private set; }

        public int ItemId { get; private set; }

        public string ItemName { get; private set; }

        public IEnumerable<int> HighSellPrices { get { return _highSellPrices; } }

        public IEnumerable<int> LowSellPrices { get { return _lowSellPrices; } }

        public IEnumerable<int> HighBuyPrices { get { return _highBuyPrices; } }

        public IEnumerable<int> LowBuyPrices { get { return _lowBuyPrices; } }

        public int OneDayAverage { get; private set; }

        public int SevenDayAverage { get; private set; }

        public string Error { get; private set; }

        [JsonConstructor]
        public PriceInfo(bool success, string error, int item, string name, List<int> market_sell_prices_high, List<int> market_sell_prices_low,
            List<int> market_buy_prices_high, List<int> market_buy_prices_low, int average_1day, int average_7day)
        {
            Success = success;
            Error = error ?? string.Empty;
            ItemId = item;
            ItemName = name ?? string.Empty;
            _highSellPrices = market_sell_prices_high ?? new List<int>();
            _lowSellPrices = market_sell_prices_low ?? new List<int>();
            _highBuyPrices = market_buy_prices_high ?? new List<int>();
            _lowBuyPrices = market_buy_prices_low ?? new List<int>();
            OneDayAverage = average_1day;
            SevenDayAverage = average_7day;
        }

        public override string ToString()
        {
            return $"PriceInfo: Success = {Success}, Error = '{Error}', ItemId = {ItemId}, ItemName = '{ItemName}', HighSellPrices({_highSellPrices.Count}) = "
                + $"[{string.Join(", ", _highSellPrices)}], LowSellPrices({_lowSellPrices.Count}) = [{string.Join(", ", _lowSellPrices)}], "
                + $"HighBuyPrices({_highBuyPrices.Count}) = [{string.Join(", ", _highBuyPrices)}], LowBuyPrices({_lowBuyPrices.Count}) = "
                + $"[{string.Join(", ", _lowBuyPrices)}], OneDayAverage = {OneDayAverage}, SevenDayAverage = {SevenDayAverage}";
        }
    }
}
