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
        private readonly Product _salad = new Product(1, ItemType.Starter, "Salad");
        private readonly Product _porkSteak = new Product(2, ItemType.Main, "Pork steak");
        private readonly Product _redWine = new Product(3, ItemType.Drink, "Red wine");

        [Given(@"a group of (\d+) people")]
        public void GivenAGroupOfPeople(int numberOfPeople)
        {
            //does nothing according to current business logic
        }

        [Given(@"they order (\d+) starters, (\d+) mains, and (\d+) drinks")]
        public void GivenTheyOrderStartersMainsAndDrinks(int numberOfStarters, int numberOfMains, int numberOfDrinks)
        {
            _order.Add(1, _salad, numberOfStarters);
            _order.Add(2, _porkSteak, numberOfMains);
            _order.Add(3, _redWine, numberOfDrinks);
        }

        [Given(@"they order (\d+) starters, (\d+) mains and (\d+) drinks at (.*)")]
        public void GivenTheyOrderStartersMainsAndDrinksBefore(int numberOfStarters, int numberOfMains, int numberOfDrinks, string timeOrdered)
        {
            _order.Add(4, _salad, numberOfStarters, TimeSpan.Parse(timeOrdered));
            _order.Add(5, _porkSteak, numberOfMains, TimeSpan.Parse(timeOrdered));
            _order.Add(6, _redWine, numberOfDrinks, TimeSpan.Parse(timeOrdered));
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

        [Then(@"a bill is generated correctly: service charge (.*) and total (.*)")]
        public void ThenGenerateBill(string expectedServiceCharge, string expectedTotal)
        {
            var bill = new CheckoutRestaurantSystem().GenerateBill(_order);
            bill.ServiceCharge.Should().Be(decimal.Parse(expectedServiceCharge));
            bill.Total.Should().Be(decimal.Parse(expectedTotal));

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
            _order.Add(7, _salad, numberOfStarters, TimeSpan.Parse(timeOrdered));
            _order.Add(8, _porkSteak, numberOfMains, TimeSpan.Parse(timeOrdered));
            _order.Add(9, _redWine, numberOfDrinks, TimeSpan.Parse(timeOrdered));
        }
    }
}
