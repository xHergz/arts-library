using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AruaRoseToolSuiteLibrary.Data;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class StockEntryTestData
    {
        public static DateTime ENTRY_DATE = DateTime.Now;

        public static int AVERAGE_PRICE = (int)PriceInfoTestData.LOW_SELL_PRICES.Average();

        public static int LOWEST_PRICE = PriceInfoTestData.LOW_SELL_PRICES.Min();

        public static int HIGHEST_PRICE = PriceInfoTestData.LOW_SELL_PRICES.Max();

        public static int DATA_POINTS = PriceInfoTestData.LOW_SELL_PRICES.Count;

        public static StockEntry Generate()
        {
            return new StockEntry(
                StockItemTestData.STOCK_ITEM_ID,
                ENTRY_DATE,
                AVERAGE_PRICE,
                HIGHEST_PRICE,
                LOWEST_PRICE,
                DATA_POINTS
            );
        }
    }
}
