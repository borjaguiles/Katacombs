namespace Katacombs.Inventories
{
    public class Item
    {
        private readonly string _itemName;

        public Item(string itemName)
        {
            _itemName = itemName;
        }

        public string GetName()
        {
            return _itemName;
        }
    }
}