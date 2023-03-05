using System;

namespace Restaurant
{
    public class Item
    {
        public int Id { get; }
        public Product Poduct { get; set; }
        public int Quantity { get; set; }
        public TimeSpan? Time { get; set; }

        public Item(int id, Product poduct, int quantity, TimeSpan? time) 
        {
            Id = id;
            Poduct = poduct;
            Quantity = quantity;
            Time = time;
        }
    }
}
