using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class CheckoutInformationPage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By FirstNameInput = By.Id("first-name");
    private static readonly By LastNameInput = By.Id("last-name");
    private static readonly By PostalCodeInput = By.Id("postal-code");
    private static readonly By ContinueButton = By.Id("continue");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public string GetTitle()
    {
        return Wait.UntilVisible(Title).Text;
    }

    public void EnterInformation(string firstName, string lastName, string postalCode)
    {
        Wait.UntilVisible(FirstNameInput).SendKeys(firstName);
        Wait.UntilVisible(LastNameInput).SendKeys(lastName);
        Wait.UntilVisible(PostalCodeInput).SendKeys(postalCode);
    }

    public void Continue()
    {
        Wait.UntilClickable(ContinueButton).Click();
    }

    public string GetErrorMessage()
    {
        return Wait.UntilVisible(ErrorMessage).Text;
    }
}
