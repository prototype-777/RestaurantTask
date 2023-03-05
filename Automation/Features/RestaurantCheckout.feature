Feature: RestaurantCheckout

Link to a feature: [Restaurant3](Automation/Features/RestaurantCheckout.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Calculate total bill for a group of 4 people
	Given a group of 4 people
	And they order 4 starters, 4 mains, and 4 drinks
	When order is sent to the endpoint
	Then total is calculated correctly 58.40
	And a bill is generated correctly: service charge 4.4 and total 58.40 

Scenario: Calculate total bill for a group of 4 people with updated order
	Given a group of 2 people
	And they order 1 starters, 2 mains and 2 drinks at 18:00
	When order is sent to the endpoint
	Then total is calculated correctly 23.3
	And a bill is generated correctly: service charge 1.8 and total 23.3 
	And more people join the group and order 0 starters, 2 mains and 2 drinks at 20:00
	When order is sent to the endpoint
	Then total is calculated correctly 43.70
	And a bill is generated correctly: service charge 3.2 and total 43.70

Scenario: Update order and calculate total bill for a group of 4 people
	Given a group of 4 people
	And they order 4 starters, 4 mains, and 4 drinks
	When order is sent to the endpoint
	Then total is calculated correctly 58.40
	And a bill is generated correctly: service charge 4.40 and total 58.40 
	And person(s) cancels order of 1 starters, 1 mains and 1 drinks
	When order is sent to the endpoint
	Then total is calculated correctly 43.80
	And a bill is generated correctly: service charge 3.30 and total 43.80
