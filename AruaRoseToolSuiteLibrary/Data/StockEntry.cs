using System;

using Newtonsoft.Json;

namespace AruaRoseToolSuiteLibrary.Data
{
    public class StockEntry
    {
        public int? StockEntryId { get; private set; }

        public int StockItemId { get; private set; }

        public DateTime EntryDate { get; private set; }

        public decimal AveragePrice { get; private set; }

        public decimal HighestPrice { get; private set; }

        public decimal LowestPrice { get; private set; }

        public int DataPoints { get; private set; }

        public StockEntry(int stockItemId, DateTime entryDate, decimal averagePrice, decimal highestPrice,
            decimal lowestPrice, int dataPoints)
        {
            StockEntryId = null;
            StockItemId = stockItemId;
            EntryDate = entryDate;
            AveragePrice = averagePrice;
            HighestPrice = highestPrice;
            LowestPrice = lowestPrice;
            DataPoints = dataPoints;
        }

        [JsonConstructor]
        public StockEntry(int stockEntryId, int stockItemId, DateTime entryDate, decimal averagePrice,
            decimal highestPrice, decimal lowestPrice, int dataPoints)
        {
            StockEntryId = stockEntryId;
            StockItemId = stockItemId;
            EntryDate = entryDate;
            AveragePrice = averagePrice;
            HighestPrice = highestPrice;
            LowestPrice = lowestPrice;
            DataPoints = dataPoints;
        }
    }
}
