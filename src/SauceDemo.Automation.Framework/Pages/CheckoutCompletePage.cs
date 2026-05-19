using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class CheckoutCompletePage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By ConfirmationHeader = By.CssSelector("[data-test='complete-header']");

    public string GetTitle()
    {
        return Wait.UntilVisible(Title).Text;
    }

    public string GetConfirmationHeader()
    {
        return Wait.UntilVisible(ConfirmationHeader).Text;
    }
}
