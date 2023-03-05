using System;
using System.Linq;

namespace Restaurant
{
    public class CheckoutRestaurantSystem
    {
        public decimal CalculateTotal(Order order)
        {
            var starters = 0m;
            var mains = 0m;
            var drinks = 0m;

            foreach (Item item in order.items)
            {
                switch (item.poduct.type)
                {
                    case ItemType.Starter:
                    {
                        starters += item.quantity * PricesAndDiscounts.StarterPrice;
                        break;
                    }
                    case ItemType.Main:
                    {
                        mains += item.quantity * PricesAndDiscounts.MainPrice;
                        break;
                    }
                    case ItemType.Drink:
                    {
                        drinks += item.quantity * 
                            (string.IsNullOrEmpty(item.time) || TimeSpan.Parse(item.time) >= TimeSpan.Parse(PricesAndDiscounts.DiscountTime)
                                ? PricesAndDiscounts.DrinkPrice
                                : PricesAndDiscounts.DrinkPrice * (1 - PricesAndDiscounts.Discount));
                        break;
                    }
                }
            }
            var total = (starters + mains) * (1 + PricesAndDiscounts.ServiceCharge) + drinks;

            return total;
        }

        public string GenerateBill(Order order)
        {
            var startersQuantity = 0m;
            var mainsQuantity = 0m;
            var drinksQuantity = 0m;
            var discountDrinksQuantity = 0m;

            order.items.Where(x => x.poduct.type == ItemType.Starter).ToList().ForEach(l => startersQuantity += l.quantity);
            order.items.Where(x => x.poduct.type == ItemType.Main).ToList().ForEach(l => mainsQuantity += l.quantity);
            
            order.items.Where(x => x.poduct.type == ItemType.Drink)
                .Where(l => string.IsNullOrEmpty(l.time) || TimeSpan.Parse(l.time) >= TimeSpan.Parse(PricesAndDiscounts.DiscountTime))
                .ToList().ForEach(l => drinksQuantity += l.quantity);
            
            order.items.Where(x => x.poduct.type == ItemType.Drink)
                .Where(l => !string.IsNullOrEmpty(l.time) && TimeSpan.Parse(l.time) < TimeSpan.Parse(PricesAndDiscounts.DiscountTime))
                .ToList().ForEach(l => discountDrinksQuantity += l.quantity);

            var food = startersQuantity * PricesAndDiscounts.StarterPrice + mainsQuantity * PricesAndDiscounts.MainPrice;
            var drinks = drinksQuantity * PricesAndDiscounts.DrinkPrice + discountDrinksQuantity * PricesAndDiscounts.DrinkPrice * (1 - PricesAndDiscounts.Discount);
            var subtotal = food + drinks;
            var serviceCharge = food * PricesAndDiscounts.ServiceCharge;
            var total = subtotal + serviceCharge;

            string bill = $"Starters ({startersQuantity} * {PricesAndDiscounts.StarterPrice:C}): {startersQuantity * PricesAndDiscounts.StarterPrice:C}\n" +
                $"Mains ({mainsQuantity} * {PricesAndDiscounts.MainPrice:C}): {mainsQuantity * PricesAndDiscounts.MainPrice:C}\n" +
                $"Drinks ({drinksQuantity} * {PricesAndDiscounts.DrinkPrice:C}):\t{drinksQuantity * PricesAndDiscounts.DrinkPrice:C}\n\n" +
                $"DiscountedDrinks ({discountDrinksQuantity} * {(1 - PricesAndDiscounts.Discount) * PricesAndDiscounts.DrinkPrice:C}):\t{discountDrinksQuantity * (1 - PricesAndDiscounts.Discount) * PricesAndDiscounts.DrinkPrice:C}\n\n" +
                $"Subtotal: {subtotal:C}\n" +
                $"Service Charge ({PricesAndDiscounts.ServiceCharge:P}): {serviceCharge:C}\n" +
                $"Total: {total:C}";

            return bill;
        }
    }
}
