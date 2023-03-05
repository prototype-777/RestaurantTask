using TechTalk.SpecFlow;
using FluentAssertions;
using Restaurant;

namespace Automation.Steps
{
    [Binding]
    public sealed class RestaurantCheckoutStepDefinitions
    {
        private readonly Order _order = new Order();
        private float _total;
        private string _bill;

        [Given(@"a group of (\d+) people")]
        public void GivenAGroupOfPeople(int numberOfPeople)
        {
            //  _order.NumberOfPeople = numberOfPeople;
        }

        [Given(@"they order (\d+) starters, (\d+) mains, and (\d+) drinks")]
        public void GivenTheyOrderStartersMainsAndDrinks(int numberOfStarters, int numberOfMains, int numberOfDrinks)
        {
            _order.Add(ItemType.Starter, "Salad", numberOfStarters);
            _order.Add(ItemType.Main, "Pork steak", numberOfMains);
            _order.Add(ItemType.Drink, "Red wine", numberOfDrinks);
        }

        [Given(@"they order (\d+) starters, (\d+) mains and (\d+) drinks at (.*)")]
        public void GivenTheyOrderStartersMainsAndDrinksBefore(int numberOfStarters, int numberOfMains, int numberOfDrinks, string timeOrdered)
        {
            _order.Add(ItemType.Starter, "Salad", numberOfStarters, timeOrdered);
            _order.Add(ItemType.Main, "Pork steak", numberOfMains, timeOrdered);
            _order.Add(ItemType.Drink, "Red wine", numberOfDrinks, timeOrdered);
        }

        [When(@"the order is sent to the endpoint")]
        public void WhenTheOrderIsSentToCheckoutSystem()
        {
            //nothing here
        }

        [Then(@"the total is calculated correctly (.*)")]
        public void WhenCalculateTotal(string expectedTotal)
        {
            var total = new CheckoutRestaurantSystem().CalculateTotal(_order);
            total.Should().Be(decimal.Parse(expectedTotal));
        }

        [Then(@"a bill is generated correctly")]
        public void ThenGenerateBill()
        {
            _bill = new CheckoutRestaurantSystem().GenerateBill(_order);

        }

        //[When(@"(\d+) more people join at (.*) and order (\d+) mains and (\d+) drinks")]
        public void WhenMorePeopleJoinAndOrderMainsAndDrinks(int numberOfPeople, string timeOrdered, int numberOfMains, int numberOfDrinks)
        {
            //  _order.NumberOfPeople += numberOfPeople;
           // _order.mains += numberOfMains;
           // _order.drinks += numberOfDrinks;
           // _order.time_ordered = timeOrdered;
        }

        [Then(@"person\(s\) cancels order of (\d+) starters, (\d+) mains and (\d+) drinks")]
        public void ThenPersonCancelsTheirOrder(int numberOfStarters, int numberOfMains, int numberOfDrinks)
        {
            _order.Remove(ItemType.Starter, "Salad", numberOfStarters);
            _order.Remove(ItemType.Main, "Pork steak", numberOfMains);
            _order.Remove(ItemType.Drink, "Red wine", numberOfDrinks);
        }

        [Then(@"more people join the group and order (\d+) starters, (\d+) mains and (\d+) drinks at (.*)")]
        public void ThenPersonsOrderAdditionalDrinksAfter(int numberOfStarters, int numberOfMains, int numberOfDrinks, string timeOrdered)
        {
            _order.Add(ItemType.Starter, "Salad", numberOfStarters, timeOrdered);
            _order.Add(ItemType.Main, "Pork steak", numberOfMains, timeOrdered);
            _order.Add(ItemType.Drink, "Red wine", numberOfDrinks, timeOrdered);
        }

    }
}
