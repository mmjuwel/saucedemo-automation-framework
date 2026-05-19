namespace SauceDemo.Automation.Framework.Configuration;

public sealed class TestConfiguration
{
    public required string BaseUrl { get; init; }

    public bool Headless { get; init; }

    public required TimeSpan DefaultTimeout { get; init; }
}
