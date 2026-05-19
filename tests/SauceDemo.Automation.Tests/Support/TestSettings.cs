namespace SauceDemo.Automation.Tests.Support;

public sealed class TestSettings
{
    public string BaseUrl { get; init; } = "https://www.saucedemo.com/";

    public bool Headless { get; init; } = true;

    public int DefaultTimeout { get; init; } = 30;

    public CredentialSettings? Credentials { get; init; }   
}
    
public sealed class CredentialSettings
{
    public required string User { get; init; }
    
    public required string Password { get; init; } 
}
