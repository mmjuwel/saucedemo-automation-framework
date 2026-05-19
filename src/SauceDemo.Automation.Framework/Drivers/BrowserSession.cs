using OpenQA.Selenium;
using SauceDemo.Automation.Framework.Configuration;

namespace SauceDemo.Automation.Framework.Drivers;

public sealed class BrowserSession : IDisposable
{
    public BrowserSession(TestConfiguration configuration)
    {
        Configuration = configuration;
        Driver = WebDriverFactory.Create(configuration);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
    }

    public TestConfiguration Configuration { get; }

    public IWebDriver Driver { get; }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
