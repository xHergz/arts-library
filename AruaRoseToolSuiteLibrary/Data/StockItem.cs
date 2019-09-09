using System;

using Newtonsoft.Json;

namespace AruaRoseToolSuiteLibrary.Data
{
    public class StockItem
    {
        public int StockItemId { get; private set; }

        public int StockItemGroupId { get; private set; }

        public int ItemId { get; private set; }

        public string Name { get; private set; }

        public string ShortName { get; private set; }

        public DateTime DateAdded { get; private set; }

        public bool IsTracked { get; private set; }

        [JsonConstructor]
        public StockItem(int stockItemId, int stockItemGroupId, int itemId, string name, string shortName,
            DateTime dateAdded, bool isTracked)
        {
            StockItemId = stockItemId;
            StockItemGroupId = stockItemGroupId;
            ItemId = itemId;
            Name = name ?? string.Empty;
            ShortName = shortName ?? string.Empty;
            DateAdded = dateAdded;
            IsTracked = isTracked;
        }
    }
}
