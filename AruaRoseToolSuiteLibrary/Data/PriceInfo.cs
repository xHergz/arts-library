using System;
using System.Collections.Generic;
using System.Text;

namespace AruaRoseToolSuiteLibrary.Data
{
    public class PriceInfo
    {
        private List<int> _highSellPrices;

        private List<int> _lowSellPrices;

        private List<int> _highBuyPrices;

        private List<int> _lowBuyPrices;

        public bool Success { get; private set; }

        public int? ItemId { get; private set; }

        public string ItemName { get; private set; }

        public IEnumerable<int> HighSellPrices { get { return _highSellPrices; } }

        public IEnumerable<int> LowSellPrices { get { return _lowSellPrices; } }

        public IEnumerable<int> HighBuyPrices { get { return _highSellPrices; } }

        public IEnumerable<int> LowBuyPrices { get { return _lowBuyPrices; } }

        public int? AverageOneDay { get; private set; }

        public int? AverageSevenDay { get; private set; }

        public string Error { get; private set; }

        public PriceInfo(string error)
        {
            Success = false;
            ItemId = null;
            ItemName = string.Empty;
            _highSellPrices = new List<int>();
            _lowSellPrices = new List<int>();
            _highBuyPrices = new List<int>();
            _lowSellPrices = new List<int>();
            AverageOneDay = null;
            AverageSevenDay = null;
            Error = error;
        }

        public PriceInfo(int itemId, string itemName, int averageOneDay, int averageSevenDay)
        {
            Success = false;
            ItemId = itemId;
            ItemName = itemName;
            _highSellPrices = new List<int>();
            _lowSellPrices = new List<int>();
            _highBuyPrices = new List<int>();
            _lowSellPrices = new List<int>();
            AverageOneDay = null;
            AverageSevenDay = null;
            Error = string.Empty;
        }
    }
}
