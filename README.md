# SauceDemo QA Automation Assignment

This repository contains a Selenium UI automation solution for https://www.saucedemo.com/ built with C#, Reqnroll, NUnit, and the Page Object Model pattern.

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
git clone <your-public-repository-url>
cd SauceDemo.Automation.Tests
dotnet restore SauceDemo.Automation.slnx
dotnet build SauceDemo.Automation.slnx
dotnet test SauceDemo.Automation.slnx
```

To run headless locally or in CI:

```powershell
$env:HEADLESS = "true"
dotnet test SauceDemo.Automation.slnx
```

## Implemented scenarios

1. Happy path - end-to-end purchase flow
2. Negative validation - checkout without required information
3. Navigation - return to products without losing cart selection

## Design notes

- All UI interactions are encapsulated in page object classes.
- Step definitions contain orchestration and assertions only.
- Each scenario starts from a clean browser session through Reqnroll hooks.
- ChromeDriver is managed through Selenium browser tooling and package dependencies.

## Scope decisions

The focus was limited to the three requested scenarios with emphasis on high business value and readability. Broader browser coverage, reporting, and advanced test data generation were intentionally left out to fit the assignment scope.
