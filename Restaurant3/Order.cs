using System.Collections.Generic;

namespace Restaurant
{
    public class Order
    {
        public static int id;
        public List<Item> items;

        public Order() 
        {
            id++;
            items = new List<Item>();
        }

        public void Add(ItemType type, string title, int quantity, string dateTime = null) 
        {
            items.Add(new Item(new Product(type, title), quantity, dateTime));
        }

        public void Remove(ItemType type, string title, int quantity, string dateTime = null)
        {
            for (int i = 0; i < quantity; i++)
            {
                foreach (Item item in items)
                {
                    if (item.poduct.type == type)
                    {
                        item.quantity--;
                    }
                }
            }
        }
    }
}
