using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class CheckoutOverviewPage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By FinishButton = By.Id("finish");
    private static readonly By ItemNames = By.CssSelector("[data-test='inventory-item-name']");
    private static readonly By SubtotalLabel = By.CssSelector("[data-test='subtotal-label']");
    private static readonly By TaxLabel = By.CssSelector("[data-test='tax-label']");
    private static readonly By TotalLabel = By.CssSelector("[data-test='total-label']");

    public string GetTitle()
    {
        return Wait.UntilVisible(Title).Text;
    }

    public List<string> GetItemNames()
    {
        return Driver.FindElements(ItemNames).Select(e => e.Text).ToList();
    }

    public decimal GetSubtotal()
    {
        var text = Wait.UntilVisible(SubtotalLabel).Text;
        var amount = text.Replace("Item total: $", "").Trim();
        return decimal.Parse(amount);
    }

    public decimal GetTax()
    {
        var text = Wait.UntilVisible(TaxLabel).Text;
        var amount = text.Replace("Tax: $", "").Trim();
        return decimal.Parse(amount);
    }

    public decimal GetTotal()
    {
        var text = Wait.UntilVisible(TotalLabel).Text;
        var amount = text.Replace("Total: $", "").Trim();
        return decimal.Parse(amount);
    }

    public void Finish()
    {
        Wait.UntilClickable(FinishButton).Click();
    }
}
