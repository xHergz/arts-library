/*
* PROJECT: ARTS Library
* PROGRAMMER: Justin
* FIRST VERSION: 22/09/2019
*/

namespace AruaRoseToolSuiteLibrary.Data
{
    public class Item
    {
        public int ItemId { get; private set; }

        public string Name { get; private set; }

        public string IconFileName { get; private set; }

        public Item(int id, string name, string iconFile)
        {
            ItemId = id;
            Name = name;
            IconFileName = iconFile;
        }

        public override string ToString()
        {
            return $"Item: ItemId = {ItemId}, Name = '{Name}', IconFileName = '{IconFileName}'";
        }
    }
}
