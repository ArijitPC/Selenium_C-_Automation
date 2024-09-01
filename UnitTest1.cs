using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
using System.Reflection;
using Test1.Pages;
using NUnit.Framework.Interfaces;
using static Test1.Pages.GrantsFinder;
using System.Reactive;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;



namespace Test1;

public class Tests
{
    IWebDriver driver;
    ExtentReports extentReports;
    ExtentTest extentTest;



    private void SetupExtentReports()
    {
    
        extentReports = new ExtentReports();
        DateTime now = DateTime.Now;
        string dateTimeString = now.ToString("yyyy-MM-dd HH:mm:ss");
        var spark = new ExtentSparkReporter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Reports",dateTimeString + "_Report.html"));
        extentReports.AttachReporter(spark);
        extentReports.CreateTest("Grants Finder Test Results");
        extentTest= extentReports.CreateTest("SearchTest");
      
       
    }
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        SetupExtentReports();
       
    }

    

    [Test]
    [Category("smoke")]
    public void TestBusiness()
    {

            //Load URL
            driver.Navigate().GoToUrl("https://www.nsw.gov.au/grants-and-funding");
            GrantsFinder grantsfinder = new GrantsFinder(driver);
            grantsfinder.verifyBannerText("Grants and funding");
            grantsfinder.selectBusiness();
            grantsfinder.clickApply();
            grantsfinder.verifySearchResults("Business");
            extentTest.Log(Status.Pass, "Filter by business category is successful");
            
    }


   
    [Test]
    [Category("smoke")]
    public void TestIndividual()
    {
        //Load URL
        driver.Navigate().GoToUrl("https://www.nsw.gov.au/grants-and-funding");
        GrantsFinder grantsfinder = new GrantsFinder(driver);
        grantsfinder.selectIndividual();
        grantsfinder.clickApply();
        grantsfinder.verifySearchResults("Individual");
        extentTest.Log(Status.Pass, "Filter by Individual category is successful");

    }


    [Test]
    [Category("regression")]
    public void TestLocalGovernment()
    {
        //Load URL
        driver.Navigate().GoToUrl("https://www.nsw.gov.au/grants-and-funding");
        GrantsFinder grantsfinder = new GrantsFinder(driver);
        grantsfinder.selectLocalGovernment();
        grantsfinder.clickApply();
        grantsfinder.verifySearchResults("Fail");// Failing this test to capture screenshot
        extentTest.Log(Status.Pass, "Filter by Local Government category is successful");
    }


    [Test]
    [Category("regression")]
    public void TestNotForProfit()
    {
        //Load URL
        driver.Navigate().GoToUrl("https://www.nsw.gov.au/grants-and-funding");
        GrantsFinder grantsfinder = new GrantsFinder(driver);

        grantsfinder.verifyBannerText("Grants and funding");
        grantsfinder.selectNotForProfit();
        grantsfinder.clickApply();
        grantsfinder.verifySearchResults("Not-for-profit");
        extentTest.Log(Status.Pass, "Filter by NOT for Profit category is successful");

    }




    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
           
            TakeScreenshot("GrantsFinder");
            
        }

        driver.Quit();
        extentReports.Flush();
    }
    public void TakeScreenshot(string screenshotname)
    {
        Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
        DateTime now = DateTime.Now;
        string dateTimeString = now.ToString("yyyy-MM-dd HH:mm:ss");
        string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Screenshots", screenshotname + "_" + dateTimeString + ".png");
        image.SaveAsFile(relativePath);
        extentTest.AddScreenCaptureFromPath(relativePath);
        extentTest.Log(Status.Fail, "Grants Filter failed search");

    }
   

}
