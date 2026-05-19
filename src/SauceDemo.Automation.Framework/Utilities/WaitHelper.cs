using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Automation.Framework.Utilities;

public sealed class WaitHelper(IWebDriver driver, TimeSpan timeout)
{
    private readonly WebDriverWait _wait = new(driver, timeout);


    public IWebElement UntilVisible(By locator)
    {
        return _wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed ? element : null;
        })!;
    }

    public IWebElement UntilClickable(By locator)
    {
        return _wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        })!;
    }
}
