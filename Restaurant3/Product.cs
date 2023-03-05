namespace Restaurant
{
    public class Product
    {
        private int Id { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }

        public Product(int id, ItemType type, string title)
        {
            Id = id;
            Title = title;
            Type = type;
        }
    }
}
