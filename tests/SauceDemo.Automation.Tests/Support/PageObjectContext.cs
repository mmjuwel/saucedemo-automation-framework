using Microsoft.Extensions.Configuration;
using SauceDemo.Automation.Framework.Configuration;
using SauceDemo.Automation.Framework.Drivers;
using SauceDemo.Automation.Framework.Pages;

namespace SauceDemo.Automation.Tests.Support;

public sealed class PageObjectContext : IDisposable
{
    public PageObjectContext()
    {
        //To support multiple environment through appsettings.{environment}.json files, we read the environment name from the TEST_ENV environment variable.
        var environmentName = Environment.GetEnvironmentVariable("TEST_ENV")?.Trim().ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(environmentName))
        {
            environmentName = "test";
        }

        var appConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .Build();

        var settings = appConfiguration.GetSection("TestSettings").Get<TestSettings>() ?? new TestSettings();


        var headlessFromEnv = Environment.GetEnvironmentVariable("HEADLESS");
        var headless = settings.Headless;

        if (bool.TryParse(headlessFromEnv, out var parsedHeadless))
        {
            headless = parsedHeadless;
        }

        // used TestConfiguration to pass the settings to the page objects, so we don't have to pass multiple parameters to the page object constructors.
        Configuration = new TestConfiguration
        {
            BaseUrl = settings.BaseUrl,
            Headless = headless,
            DefaultTimeout = TimeSpan.FromSeconds(settings.DefaultTimeout)
        };

        Credentials = settings.Credentials;
        Session = new BrowserSession(Configuration);
        LoginPage = new LoginPage(Session.Driver, Configuration.DefaultTimeout);
        ProductPage = new ProductPage(Session.Driver, Configuration.DefaultTimeout);
        CartPage = new CartPage(Session.Driver, Configuration.DefaultTimeout);
        CheckoutInformationPage = new CheckoutInformationPage(Session.Driver, Configuration.DefaultTimeout);
        CheckoutOverviewPage = new CheckoutOverviewPage(Session.Driver, Configuration.DefaultTimeout);
        CheckoutCompletePage = new CheckoutCompletePage(Session.Driver, Configuration.DefaultTimeout);
    }

    public TestConfiguration Configuration { get; }

    public CredentialSettings? Credentials { get; }

    public BrowserSession Session { get; }

    public LoginPage LoginPage { get; }

    public ProductPage ProductPage { get; }

    public CartPage CartPage { get; }

    public CheckoutInformationPage CheckoutInformationPage { get; }

    public CheckoutOverviewPage CheckoutOverviewPage { get; }

    public CheckoutCompletePage CheckoutCompletePage { get; }

    public void Dispose()
    {
        Session.Dispose();
    }
}
