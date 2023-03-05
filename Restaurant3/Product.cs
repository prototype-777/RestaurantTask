namespace Restaurant
{
    public class Product
    {
        public static int id;
        public string title;
        public ItemType type;

        public Product(ItemType type, string title) 
        {
            id++;
            this.type = type;
            this.title = title;
        }
    }
}
