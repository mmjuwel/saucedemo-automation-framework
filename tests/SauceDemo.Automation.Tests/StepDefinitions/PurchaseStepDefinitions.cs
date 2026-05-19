using Reqnroll;
using SauceDemo.Automation.Tests.Support;

namespace SauceDemo.Automation.Tests.StepDefinitions;

[Binding]
public sealed class PurchaseStepDefinitions(PageObjectContext pages)
{
    private readonly PageObjectContext _pages = pages;

    [Given("the user logs in with valid credentials")]
    public void GivenTheUserLogsInWithValidCredentials()
    {
        _pages.LoginPage.Login(_pages.Credentials.User, _pages.Credentials.Password);
        Assert.That(_pages.ProductPage.GetTitle(), Is.EqualTo("Products"));
    }

    [Given("the user adds a backpack to the cart")]
    [When("the user adds a backpack to the cart")]
    public void WhenTheUserAddsABackpackToTheCart()
    {
        _pages.ProductPage.AddBackpackToCart();
    }

    [Then("the cart badge should show {int} item")]
    [Then("the cart badge should show {int} items")]
    public void ThenTheCartBadgeShouldShowItems(int expectedCount)
    {
        Assert.That(_pages.ProductPage.GetCartItemCount(), Is.EqualTo(expectedCount));
    }

    [When("the user proceeds to cart")]
    [Then("the user proceeds to cart")]
    public void WhenTheUserProceedsToCart()
    {
        _pages.ProductPage.OpenCart();
        Assert.That(_pages.CartPage.GetTitle(), Is.EqualTo("Your Cart"));
    }

    [Then("the cart should contain {int} item")]
    [Then("the cart should contain {int} items")]
    public void ThenTheCartShouldContainItems(int expectedCount)
    {
        Assert.That(_pages.CartPage.GetItemCount(), Is.EqualTo(expectedCount));
    }

    [Then("the cart should display {string}")]
    public void ThenTheCartShouldDisplay(string expectedItemName)
    {
        var itemNames = _pages.CartPage.GetItemNames();
        Assert.That(itemNames, Does.Contain(expectedItemName));
    }

    [Then("the user proceeds to checkout")]
    public void ThenTheUserProceedsToCheckout()
    {
        _pages.CartPage.Checkout();
        Assert.That(_pages.CheckoutInformationPage.GetTitle(), Is.EqualTo("Checkout: Your Information"));
    }

    [When("the user continues to checkout with the following details")]
    public void WhenTheUserContinuesToCheckoutWithTheFollowingDetails(DataTable data)
    {
        var row = data.Rows[0];
        var firstName = row["FirstName"];
        var lastName = row["LastName"];
        var postalCode = row["PostalCode"];
        _pages.CheckoutInformationPage.EnterInformation(firstName, lastName, postalCode);
        _pages.CheckoutInformationPage.Continue();
    }

    [Then("the checkout overview should load with the correct item")]
    public void ThenTheCheckoutOverviewShouldDisplayTheCorrectItem()
    {
        var itemNames = _pages.CheckoutOverviewPage.GetItemNames();
        Assert.That(_pages.CheckoutOverviewPage.GetTitle(), Is.EqualTo("Checkout: Overview"));
        Assert.That(itemNames, Does.Contain("Sauce Labs Backpack"));
    }

    [Then("the checkout overview should display the correct total")]
    public void ThenTheCheckoutOverviewShouldDisplayTheCorrectTotal()
    {
        var subtotal = _pages.CheckoutOverviewPage.GetSubtotal();
        var tax = _pages.CheckoutOverviewPage.GetTax();
        var total = _pages.CheckoutOverviewPage.GetTotal();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(subtotal, Is.GreaterThan(0), "Subtotal should be greater than 0");
            Assert.That(tax, Is.GreaterThan(0), "Tax should be greater than 0");
            Assert.That(total, Is.EqualTo(subtotal + tax), "Total should equal subtotal + tax");
        }
    }

    [When("the user completes the order")]
    public void WhenTheUserCompletesTheOrder()
    {
        _pages.CheckoutOverviewPage.Finish();
    }

    [Then("the order confirmation should be displayed")]
    public void ThenTheOrderConfirmationShouldBeDisplayed()
    {
        Assert.That(_pages.CheckoutCompletePage.GetTitle(), Is.EqualTo("Checkout: Complete!"));
    }

    [Then("the confirmation message should be {string}")]
    public void ThenTheConfirmationMessageShouldBe(string expectedMessage)
    {
        Assert.That(_pages.CheckoutCompletePage.GetConfirmationHeader(), Is.EqualTo(expectedMessage));
    }
}
