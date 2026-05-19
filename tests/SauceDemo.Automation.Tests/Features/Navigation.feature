Feature: Navigation
  As a customer
  I want to move back to a previous step
  So that I do not lose my cart selection

  Scenario: Navigation - user returns to shopping without losing cart selection
	Given the user logs in with valid credentials
	And the user adds a backpack to the cart
	When the user navigates to the cart from the products page
	Then the user navigates back to the products page from the cart
	Then the cart should still contain the selected item
