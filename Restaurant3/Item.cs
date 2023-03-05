namespace Restaurant
{
    public class Item
    {
        public static int id;
        public Product poduct;
        public int quantity;
        public string time;

        public Item(Product poduct, int quantity, string time) 
        {
            id++;
            this.poduct = poduct;
            this.quantity = quantity;
            this.time = time;
        }
    }
}
