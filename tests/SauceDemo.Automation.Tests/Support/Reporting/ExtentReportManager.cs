using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Support.Reporting;

public static class ExtentReportManager
{
    private static readonly object ReportLock = new();
    private static ExtentReports? _extent;
    private static string _reportDirectory = string.Empty;

    public static void Initialize()
    {
        var reportsRootDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Reports");
        _reportDirectory = Path.Combine(reportsRootDirectory, "Extent");
        var screenshotDirectory = Path.Combine(_reportDirectory, "Screenshots");

        Directory.CreateDirectory(_reportDirectory);
        ScreenshotManager.Initialize(screenshotDirectory);

        var spark = new ExtentSparkReporter(Path.Combine(_reportDirectory, "ExtentReport.html"));

        _extent = new ExtentReports();
        _extent.AttachReporter(spark);
        _extent.AddSystemInfo("Product", "SauceDemo");
        _extent.AddSystemInfo("Environment", Environment.GetEnvironmentVariable("TEST_ENV") ?? "test");
        _extent.AddSystemInfo("Framework", "Reqnroll + NUnit + Selenium");
    }

    public static ExtentTest? StartScenario(string scenarioTitle)
    {
        lock (ReportLock)
        {
            return _extent?.CreateTest(scenarioTitle);
        }
    }

    public static void CompleteScenario(ExtentTest? scenarioTest, string scenarioTitle, Exception? testError, IWebDriver driver)
    {
        if (scenarioTest is null)
        {
            return;
        }

        if (testError is null)
        {
            scenarioTest.Pass("Scenario passed");
            return;
        }

        scenarioTest.Fail(testError.Message);

        var screenshotPath = ScreenshotManager.CaptureFailureScreenshot(driver, scenarioTitle);
        if (screenshotPath is not null)
        {
            scenarioTest.AddScreenCaptureFromPath(screenshotPath);
        }
    }

    public static void Flush()
    {
        lock (ReportLock)
        {
            _extent?.Flush();
        }
    }


}
