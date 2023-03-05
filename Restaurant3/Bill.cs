namespace Restaurant
{
    public class Bill
    {
        public decimal StartersQuantity { get; set; }
        public decimal MainsQuantity { get; set; }
        public decimal DrinksQuantity { get; set; }
        public decimal DiscountDrinksQuantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal Total { get; set; }

        public Bill(decimal startersQuantity, decimal mainsQuantity, decimal drinksQuantity, decimal discountDrinksQuantity, decimal subtotal, decimal serviceCharge, decimal total)
        {
            StartersQuantity = startersQuantity;
            MainsQuantity = mainsQuantity;
            DrinksQuantity = drinksQuantity;
            DiscountDrinksQuantity = discountDrinksQuantity;
            Subtotal = subtotal;
            ServiceCharge = serviceCharge;
            Total = total;
        }

        public override string ToString() 
        {
            return $"Starters ({StartersQuantity} * {PricesAndDiscounts.StarterPrice:C}): {StartersQuantity * PricesAndDiscounts.StarterPrice:C}\n" +
                $"Mains ({MainsQuantity} * {PricesAndDiscounts.MainPrice:C}): {MainsQuantity * PricesAndDiscounts.MainPrice:C}\n" +
                $"Drinks ({DrinksQuantity} * {PricesAndDiscounts.DrinkPrice:C}):\t{DrinksQuantity * PricesAndDiscounts.DrinkPrice:C}\n\n" +
                $"DiscountedDrinks ({DiscountDrinksQuantity} * {(1 - PricesAndDiscounts.Discount) * PricesAndDiscounts.DrinkPrice:C}):\t{DiscountDrinksQuantity * (1 - PricesAndDiscounts.Discount) * PricesAndDiscounts.DrinkPrice:C}\n\n" +
                $"Subtotal: {Subtotal:C}\n" +
                $"Service Charge ({PricesAndDiscounts.ServiceCharge:P}): {ServiceCharge:C}\n" +
                $"Total: {Total:C}";
        }
    }
}
