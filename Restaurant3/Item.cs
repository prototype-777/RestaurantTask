using System;

namespace Restaurant
{
    /// <summary>
    /// Represent info about quantity, time and the product that orederd.
    /// e.g. 3 Beers that oredered at 18:50
    /// </summary>
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
