using OpenQA.Selenium;

namespace SauceDemo.Automation.Framework.Pages;

public sealed class LoginPage(IWebDriver driver, TimeSpan timeout) : BasePage(driver, timeout)
{
    private static readonly By UsernameInput = By.Id("user-name");
    private static readonly By PasswordInput = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public void Open(string baseUrl)
    {
        Driver.Navigate().GoToUrl(baseUrl);
    }


    public void Login(string username, string password)
    {
        Wait.UntilVisible(UsernameInput).SendKeys(username);
        Wait.UntilVisible(PasswordInput).SendKeys(password);
        Wait.UntilClickable(LoginButton).Click();
    }

    public string GetErrorMessage()
    {
        return Wait.UntilVisible(ErrorMessage).Text;
    }
}
