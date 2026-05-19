using OpenQA.Selenium;
using SauceDemo.Automation.Framework.Utilities;

namespace SauceDemo.Automation.Framework.Pages;

public abstract class BasePage(IWebDriver driver, TimeSpan timeout)
{
    protected IWebDriver Driver { get; } = driver;

    protected WaitHelper Wait { get; } = new WaitHelper(driver, timeout);
}
