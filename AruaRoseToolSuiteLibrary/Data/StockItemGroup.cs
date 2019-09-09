using Newtonsoft.Json;

namespace AruaRoseToolSuiteLibrary.Data
{
    public class StockItemGroup
    {
        public int StockItemGroupId { get; private set; }

        public string GroupName { get; private set; }

        [JsonConstructor]
        public StockItemGroup(int stockItemGroupId, string groupName)
        {
            StockItemGroupId = stockItemGroupId;
            GroupName = groupName;
        }
    }
}
