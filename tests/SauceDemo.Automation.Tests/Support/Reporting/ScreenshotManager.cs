using OpenQA.Selenium;

namespace SauceDemo.Automation.Tests.Support.Reporting;

public static class ScreenshotManager
{
    private static string _screenshotDirectory = string.Empty;

    public static void Initialize(string screenshotDirectory)
    {
        _screenshotDirectory = screenshotDirectory;
        Directory.CreateDirectory(_screenshotDirectory);
    }

    public static string? CaptureFailureScreenshot(IWebDriver driver, string scenarioTitle)
    {
        if (driver is not ITakesScreenshot screenshotDriver)
        {
            return null;
        }

        var screenshotPath = Path.Combine(_screenshotDirectory, $"{SanitizeFileName(scenarioTitle)}-{DateTime.Now:yyyyMMddHHmmss}.png");
        screenshotDriver.GetScreenshot().SaveAsFile(screenshotPath);
        return screenshotPath;
    }

    private static string SanitizeFileName(string value)
    {
        foreach (var invalidChar in Path.GetInvalidFileNameChars())
        {
            value = value.Replace(invalidChar, '_');
        }

        return value;
    }
}
