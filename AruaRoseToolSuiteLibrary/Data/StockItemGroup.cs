/*
* PROJECT: ARTS Library
* PROGRAMMER: Justin
* FIRST VERSION: 22/09/2019
*/

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

        public override string ToString()
        {
            return $"StockitemGroup: StockItemGroupId = {StockItemGroupId}, GroupName = {GroupName}";
        }
    }
}
