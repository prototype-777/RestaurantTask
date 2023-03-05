using System;

namespace Restaurant
{
    public class PricesAndDiscounts
    {
        public const decimal StarterPrice = 4.00m;
        public const decimal MainPrice = 7.00m;
        public const decimal DrinkPrice = 2.50m;
        public const decimal ServiceCharge = 0.10m;
        public const decimal Discount = 0.3m;
        public static readonly TimeSpan DiscountTime = TimeSpan.Parse("19:00:00");
    }
}
