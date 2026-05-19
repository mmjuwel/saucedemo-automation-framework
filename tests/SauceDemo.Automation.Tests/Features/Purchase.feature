Feature: Purchase
  As a customer
  I want to complete a End-to-End purchase process
  So that I can buy products successfully.

  Scenario: Happy path — user completes an End-to-End purchase
	Given the user logs in with valid credentials
	When the user adds a backpack to the cart
	Then the cart badge should show 1 item
	When the user proceeds to cart
	Then the cart should contain 1 item
	And the cart should display "Sauce Labs Backpack"
	Then the user proceeds to checkout
	When the user continues to checkout with the following details
		| FirstName  | LastName  | PostalCode |
		| Mansur     | Mahamud   | 1230       |
	Then the checkout overview should load with the correct item
	When the user completes the order
	Then the order confirmation should be displayed
	And the confirmation message should be "Thank you for your order!"
