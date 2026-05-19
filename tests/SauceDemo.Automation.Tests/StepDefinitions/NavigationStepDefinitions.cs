using Reqnroll;
using SauceDemo.Automation.Tests.Support;

namespace SauceDemo.Automation.Tests.StepDefinitions;

[Binding]
public sealed class NavigationStepDefinitions(PageObjectContext pages)
{
    private readonly PageObjectContext _pages = pages;


    [When("the user navigates to the cart from the products page")]
    public void WhenTheUserNavigatesToTheCartFromTheProductsPage()
    {
        _pages.ProductPage.OpenCart();
        Assert.That(_pages.CartPage.GetTitle(), Is.EqualTo("Your Cart"));
    }


    [Then("the user navigates back to the products page from the cart")]
    public void WhenTheUserNavigatesBackToTheProductsPageFromTheCart()
    {
        _pages.CartPage.ContinueShopping();
        Assert.That(_pages.ProductPage.GetTitle(), Is.EqualTo("Products"));
    }


    [Then("the cart should still contain the selected item")]
    public void ThenTheCartShouldStillContainTheSelectedItem()
    {
        Assert.That(_pages.ProductPage.GetCartItemCount(), Is.EqualTo(1));
    }
}
