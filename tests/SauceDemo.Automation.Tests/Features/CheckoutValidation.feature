Feature: Checkout Validation
  As a customer
  I want to see clear validation messages
  So that I can complete checkout successfully

  Scenario: Negative scenario - user submits invalid checkout information
	Given the user logs in with valid credentials
	When the user adds a backpack to the cart
	Then the user proceeds to cart
	Then the user proceeds to checkout
	When the user continues to checkout with the following details
	  | FirstName | LastName | PostalCode |
	  | Mansur    | Mahamud  |            |
	Then an error message "Error: Postal Code is required" is displayed
