using TechTalk.SpecFlow;
using FluentAssertions;
using Restaurant;
using System;

namespace Automation.Steps
{
    [Binding]
    public sealed class RestaurantCheckoutStepDefinitions
    {
        private readonly Order _order = new Order(1);
        private float _total;
        private string _bill;

        private Product salad = new Product(1, ItemType.Starter, "Salad");
        private Product porkSteak = new Product(2, ItemType.Main, "Pork steak");
        private Product redWine = new Product(3, ItemType.Drink, "Red wine");

        [Given(@"a group of (\d+) people")]
        public void GivenAGroupOfPeople(int numberOfPeople)
        {
            //  _order.NumberOfPeople = numberOfPeople;
        }

        [Given(@"they order (\d+) starters, (\d+) mains, and (\d+) drinks")]
        public void GivenTheyOrderStartersMainsAndDrinks(int numberOfStarters, int numberOfMains, int numberOfDrinks)
        {
            _order.Add(1, salad, numberOfStarters);
            _order.Add(2, porkSteak, numberOfMains);
            _order.Add(3, redWine, numberOfDrinks);
        }

        [Given(@"they order (\d+) starters, (\d+) mains and (\d+) drinks at (.*)")]
        public void GivenTheyOrderStartersMainsAndDrinksBefore(int numberOfStarters, int numberOfMains, int numberOfDrinks, string timeOrdered)
        {
            _order.Add(4, salad, numberOfStarters, TimeSpan.Parse(timeOrdered));
            _order.Add(5, porkSteak, numberOfMains, TimeSpan.Parse(timeOrdered));
            _order.Add(6, redWine, numberOfDrinks, TimeSpan.Parse(timeOrdered));
        }

        [When(@"order is sent to the endpoint")]
        public void WhenTheOrderIsSentToCheckoutSystem()
        {
            //here sgould be logic that send something to endpoint
        }

        [Then(@"total is calculated correctly (.*)")]
        public void ThenCalculateTotal(string expectedTotal)
        {
            var total = new CheckoutRestaurantSystem().CalculateTotal(_order);
            total.Should().Be(decimal.Parse(expectedTotal));
        }

        [Then(@"a bill is generated correctly")]
        public void ThenGenerateBill()
        {
            _bill = new CheckoutRestaurantSystem().GenerateBill(_order);
        }

        [Then(@"person\(s\) cancels order of (\d+) starters, (\d+) mains and (\d+) drinks")]
        public void ThenPersonCancelsTheirOrder(int numberOfStarters, int numberOfMains, int numberOfDrinks)
        {
            _order.Remove(1, numberOfStarters);
            _order.Remove(2, numberOfMains);
            _order.Remove(3, numberOfDrinks);
        }

        [Then(@"more people join the group and order (\d+) starters, (\d+) mains and (\d+) drinks at (.*)")]
        public void ThenMorePeopleJoinAndMakeOrder(int numberOfStarters, int numberOfMains, int numberOfDrinks, string timeOrdered)
        {
            _order.Add(7, salad, numberOfStarters, TimeSpan.Parse(timeOrdered));
            _order.Add(8, porkSteak, numberOfMains, TimeSpan.Parse(timeOrdered));
            _order.Add(9, redWine, numberOfDrinks, TimeSpan.Parse(timeOrdered));
        }
    }
}
