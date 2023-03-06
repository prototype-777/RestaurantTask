namespace Restaurant
{
    /// <summary>
    /// Represents kinds of dish/drinks that could be serve.
    /// e.g. "Red dry wine", "Jack Daniels" that both has type Drinks.
    /// </summary>
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
