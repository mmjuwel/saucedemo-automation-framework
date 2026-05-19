using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class CartPage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By CheckoutButton = By.Id("checkout");
    private static readonly By ContinueShoppingButton = By.Id("continue-shopping");
    private static readonly By CartItems = By.CssSelector("[data-test='inventory-item']");
    private static readonly By ItemNames = By.CssSelector("[data-test='inventory-item-name']");

    public string GetTitle()
    {
        return Wait.UntilVisible(Title).Text;
    }

    public int GetItemCount()
    {
        return Driver.FindElements(CartItems).Count;
    }

    public List<string> GetItemNames()
    {
        return Driver.FindElements(ItemNames).Select(e => e.Text).ToList();
    }

    public void Checkout()
    {
        Wait.UntilClickable(CheckoutButton).Click();
    }

    public void ContinueShopping()
    {
        Wait.UntilClickable(ContinueShoppingButton).Click();
    }
}
