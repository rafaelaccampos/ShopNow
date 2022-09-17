namespace ShopNow
{
    public class Item
    {
        public Item(string description, decimal price, int count)
        {
            Description = description;
            Price = price;
            Count = count;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Count { get; private set; }
    }
}
