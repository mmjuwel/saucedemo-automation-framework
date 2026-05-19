using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class ProductPage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By ShoppingCartBadge = By.CssSelector("[data-test='shopping-cart-badge']");
    private static readonly By ShoppingCartLink = By.CssSelector("[data-test='shopping-cart-link']");
    private static readonly By BackPackAddToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By BikeLightAddToCartButton = By.Id("add-to-cart-sauce-labs-bike-light");

    public string GetTitle()
    {
        return Wait.UntilVisible(Title).Text;
    }

    public void AddBackpackToCart()
    {
        Wait.UntilClickable(BackPackAddToCartButton).Click();
    }

    public void AddBikeLightToCart()
    {
        Wait.UntilClickable(BikeLightAddToCartButton).Click();
    }

    public int GetCartItemCount()
    {
        var badges = Driver.FindElements(ShoppingCartBadge);
        return badges.Count == 0 ? 0 : int.Parse(badges[0].Text);
    }

    public void OpenCart()
    {
        Wait.UntilClickable(ShoppingCartLink).Click();
    }
}
