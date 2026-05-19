using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Automation.Framework.Configuration;

namespace SauceDemo.Automation.Framework.Drivers;

public static class WebDriverFactory
{
    public static IWebDriver Create(TestConfiguration configuration)
    {
        var options = new ChromeOptions();

        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);
        options.AddArgument("--disable-notifications");
        options.AddArgument("--start-maximized");
        options.AddArgument("--no-sandbox");

        // Disable password manager popup
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        // Disable password leak detection popup
        options.AddUserProfilePreference("profile.password_manager_leak_detection",false);

        
        //options.AddArgument("--incognito");


        if (configuration.Headless)
        {
            options.AddArgument("--headless=new");
        }

        return new ChromeDriver(options);
    }
}
