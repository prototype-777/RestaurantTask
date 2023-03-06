using System.Linq;

namespace Restaurant
{
    public class CheckoutRestaurantSystem
    {
        /// <summary>
        /// Calculate total anount of certain order.
        /// </summary>
        /// <param name="order">Order type</param>
        /// <returns>decimal type</returns>
        public decimal CalculateTotal(Order order)
        {
            var starters = 0m;
            var mains = 0m;
            var drinks = 0m;

            foreach (Item item in order.Items)
            {
                switch (item.Poduct.Type)
                {
                    case ItemType.Starter:
                    {
                        starters += item.Quantity * PricesAndDiscounts.StarterPrice;
                        break;
                    }
                    case ItemType.Main:
                    {
                        mains += item.Quantity * PricesAndDiscounts.MainPrice;
                        break;
                    }
                    case ItemType.Drink:
                    {
                        drinks += item.Quantity * (!item.Time.HasValue || item.Time >= PricesAndDiscounts.DiscountTime
                                ? PricesAndDiscounts.DrinkPrice
                                : PricesAndDiscounts.DrinkPrice * (1 - PricesAndDiscounts.Discount));
                        break;
                    }
                }
            }
            var total = (starters + mains) * (1 + PricesAndDiscounts.ServiceCharge) + drinks;

            return total;
        }

        /// <summary>
        /// Generate detailed information aboud certain order.
        /// Contain: Quantity, Service Charge, Drink discount, Subtotal and Total. 
        /// </summary>
        /// <param name="order">Order type</param>
        /// <returns>Bill type</returns>
        public Bill GenerateBill(Order order)
        {
            var startersQuantity = 0m;
            var mainsQuantity = 0m;
            var drinksQuantity = 0m;
            var discountDrinksQuantity = 0m;

            order.Items
                .Where(x => x.Poduct.Type == ItemType.Starter)
                .ToList()
                .ForEach(l => startersQuantity += l.Quantity);

            order.Items
                .Where(x => x.Poduct.Type == ItemType.Main)
                .ToList()
                .ForEach(l => mainsQuantity += l.Quantity);

            order.Items
                .Where(x => x.Poduct.Type == ItemType.Drink)
                .ToList()
                .ForEach(l =>
                {
                    if (l.Time.HasValue && l.Time < PricesAndDiscounts.DiscountTime)
                    {
                        discountDrinksQuantity += l.Quantity;
                    }
                    else if (!l.Time.HasValue || l.Time >= PricesAndDiscounts.DiscountTime)
                    {
                        drinksQuantity += l.Quantity;
                    }
                });

            var food = startersQuantity * PricesAndDiscounts.StarterPrice + mainsQuantity * PricesAndDiscounts.MainPrice;
            var drinks = drinksQuantity * PricesAndDiscounts.DrinkPrice + discountDrinksQuantity * PricesAndDiscounts.DrinkPrice * (1 - PricesAndDiscounts.Discount);
            var subtotal = food + drinks;
            var serviceCharge = food * PricesAndDiscounts.ServiceCharge;
            var total = subtotal + serviceCharge;

            return new Bill(startersQuantity,
                mainsQuantity,
                drinksQuantity,
                discountDrinksQuantity,
                subtotal,
                serviceCharge,
                total);
        }
    }
}
