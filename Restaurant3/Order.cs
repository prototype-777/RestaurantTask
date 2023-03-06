using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{
    /// <summary>
    /// Hold all data about certain order.
    /// </summary>
    public class Order
    {
        private int Id { get; set; }
        public List<Item> Items { get; set; }

        public Order(int id) 
        {
            Id = id;
            Items = new List<Item>();
        }

        /// <summary>
        /// Use to add order for certain product(kind of dish/drink). 
        /// </summary>
        /// <param name="id">Integer</param>
        /// <param name="prod">Link on certain product</param>
        /// <param name="quantity">How many dish/drink(s) were ordered</param>
        /// <param name="dateTime">When we got order</param>
        public void Add(int id, Product prod, int quantity, TimeSpan? dateTime = null) 
        {
            Items.Add(new Item(id, prod, quantity, dateTime));
        }

        /// <summary>
        /// Use to decrease quantity of ordered products.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="quantity">Number of products that you want to decrease/remove</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when Id cant be found.
        /// </exception>
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
