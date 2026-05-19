using AventStack.ExtentReports;
using Reqnroll;
using SauceDemo.Automation.Tests.Support;
using SauceDemo.Automation.Tests.Support.Reporting;

namespace SauceDemo.Automation.Tests.Hooks;

[Binding]
public sealed class TestHooks(PageObjectContext pageObjectContext, ScenarioContext scenarioContext)
{
    private readonly PageObjectContext _pageObjectContext = pageObjectContext;
    private readonly ScenarioContext _scenarioContext = scenarioContext;
    private ExtentTest? _scenarioTest;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ExtentReportManager.Initialize();
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _scenarioTest = ExtentReportManager.StartScenario(_scenarioContext.ScenarioInfo.Title);
        _pageObjectContext.LoginPage.Open(_pageObjectContext.Configuration.BaseUrl);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        ExtentReportManager.CompleteScenario(_scenarioTest,
                                             _scenarioContext.ScenarioInfo.Title,
                                             _scenarioContext.TestError,
                                             _pageObjectContext.Session.Driver);

        _pageObjectContext.Dispose();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ExtentReportManager.Flush();
    }
}
