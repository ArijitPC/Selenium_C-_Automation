
# Grants Finder Page Testing

## Introduction

The aim of this project is to test the Grants Finder page. The script filters grants by four different categories: **Business**, **Individual**, **Local Government**, and **Not-For-Profit**. It then validates if the returned results are correct. For testing purposes, filtering by **Local Government** has been deliberately made unsuccessful to demonstrate screenshot capture upon test failure.

## Installation

### Prerequisites

- **Visual Studio**: Install Visual Studio on your development machine. If you're using a Mac, note that some extensions like SpecFlow are not supported in Visual Studio for Mac. Instead, you will need to use Visual Studio Code.

### NuGet Packages

Ensure the following NuGet packages are installed:

- **Selenium WebDriver 4.24**
- **Selenium Support**
- **Selenium Chrome Driver**
- **DotNetSeleniumWaitHelper**
- **DotNetSeleniumExtraxPageObjects**
- **DotNetSeleniumExtraxPageObjectsCore**
- **ExtentReports**
- **SpecFlow Extension** (Note: This is not available on Visual Studio for Mac. Use Visual Studio Code instead.)

## Building the Project

1. After installing the necessary packages, write your scripts.
2. Build the project using Visual Studio.

## Test Framework

This project uses the **Page Object Model (POM)** along with the **NUnit** framework. The **Category** tag has been utilized to isolate different test scenarios for regression and smoke testing.

## Running Tests

You can run the tests either from the IDE's Tests window by double-clicking on the test item or by using the CLI.

### Running All Tests

```sh
dotnet test
```

### Running Smoke Tests Only

```sh
dotnet test --filter "Category = smoke"
```

### Running Regression Tests Only

```sh
dotnet test --filter "Category = regression"
```

## Reports

Upon test completion, HTML reports can be viewed under the **Reports** directory. Screenshots for failed tests will be automatically added to the report.

## Issues Faced

1. **Unable to Save Screenshots on Mac:** 
   - Issue: Screenshots could not be saved to the local directory due to privacy restrictions on MacBook.
   - Solution: Ensure that the folder has write access enabled to allow saving screenshots.

2. **SpecFlow Not Supported by Visual Studio on Mac:** 
   - Issue: SpecFlow is not supported by Visual Studio on MacBook.
   - Workaround: Install and use Visual Studio Code instead of Visual Studio to work with SpecFlow. 
   
## Improvements

1. **SpecFlow Integration**: The framework can be uplifted to a Behavior Driven Development (BDD) framework similar to Cucumber in Java by integrating SpecFlow. Note that SpecFlow is not supported by Visual Studio for Mac. As a workaround, Visual Studio Code needs to be installed along with other required libraries.
   
2. **Parallel Test Execution**: Enable parallel test execution by implementing `[Parallelizable(ParallelScope.Fixtures)]`.

3. **Data-Driven Testing**: Enable data-driven testing by reading test data from an external file (e.g., an Excel file) using the `CsvHelper` NuGet package.


