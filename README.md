# SauceDemo QA Automation Framework

This repository contains a Selenium UI automation solution for https://www.saucedemo.com/ built with **C#**, **Reqnroll**, **NUnit**, and the **Page Object Model** pattern.

## Solution structure

- `src/SauceDemo.Automation.Framework` - reusable Selenium framework code, page objects, models, configuration, and driver setup
- `tests/SauceDemo.Automation.Tests` - Reqnroll feature files, step definitions, hooks, and scenario support classes
- `.github/workflows/ci.yml` - GitHub Actions pipeline for build and test execution

## Prerequisites

- .NET 10 SDK
- Google Chrome installed locally
- Windows, macOS, or Linux environment supported by Chrome and Selenium

## Clone and run

```powershell
git clone https://github.com/mmjuwel/saucedemo-automation-framework.git
cd SauceDemo.Automation.Tests
dotnet restore SauceDemo.Automation.slnx
dotnet build SauceDemo.Automation.slnx
dotnet test SauceDemo.Automation.slnx
```

## IDE Setup

### Visual Studio 2026
1. Open `SauceDemo.Automation.slnx`
2. Restore NuGet packages (automatic)
3. Run tests via **Test Explorer**

### To run headless locally or in CI:

```powershell
$env:HEADLESS = "true"
dotnet test SauceDemo.Automation.slnx
```

## Implemented scenarios

1. Happy path - end-to-end purchase flow
2. Negative validation - checkout without required information
3. Navigation - return to products without losing cart selection

## Design notes


-  **Page Object Model** - All UI interactions encapsulated in page classes
-  **Separation of Concerns** - Step definitions only orchestrate; pages handle actions
-  **BDD Scenarios** - Human-readable Gherkin specs in `.feature` files
-  **Clean Test Isolation** - Each scenario gets a fresh browser session
-  **Configuration-Driven** - No hardcoded URLs or credentials
-  **Environment Flexibility** - Switch between dev, test, prod configs via `TEST_ENV`



## Scope decisions

The focus was limited to the three requested scenarios with emphasis on high business value and readability. Broader browser coverage, reporting, and advanced test data generation were intentionally left out to fit the assignment scope.
