using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{
    public class Order
    {
        private int Id { get; set; }
        public List<Item> Items { get; set; }

        public Order(int id) 
        {
            Id = id;
            Items = new List<Item>();
        }

        public void Add(int id, Product prod, int quantity, TimeSpan? dateTime = null) 
        {
            Items.Add(new Item(id, prod, quantity, dateTime));
        }

        public void Remove(int id, int quantity)
        {
            var itemToUpdate = Items.Where(x => x.Id == id).FirstOrDefault();
            
            if (itemToUpdate == null) 
            {
                throw new ArgumentNullException(id.ToString());
            }
            
            itemToUpdate.Quantity -= quantity;
            
            if (itemToUpdate.Quantity < 1) 
            {
                Items.Remove(itemToUpdate);
            }
        }
    }
}
