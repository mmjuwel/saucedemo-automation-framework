using Reqnroll;
using SauceDemo.Automation.Tests.Support;

namespace SauceDemo.Automation.Tests.StepDefinitions;

[Binding]
public sealed class CheckoutValidationStepDefinitions(PageObjectContext pages)
{
    private readonly PageObjectContext _pages = pages;

    [Then("an error message {string} is displayed")]
    public void ThenAnErrorMessageIsDisplayed(string expectedMessage)
    {
        Assert.That(_pages.CheckoutInformationPage.GetErrorMessage(), Is.EqualTo(expectedMessage));
    }
}
