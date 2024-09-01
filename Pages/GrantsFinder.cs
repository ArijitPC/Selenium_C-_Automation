using System;
using System.Reflection;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Support.UI;


namespace Test1.Pages
{
	public class GrantsFinder
	{

        private readonly IWebDriver driver;

        public GrantsFinder(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement elementBanner => driver.FindElement(By.XPath("//div[@class='nsw-hero-banner__content']/h1"));
        IWebElement checkbox_business => driver.FindElement(By.XPath("//label[@class='nsw-form__checkbox-label'][@for='audience-business']"));
        IWebElement checkbox_individual => driver.FindElement(By.XPath("//label[@class='nsw-form__checkbox-label'][@for='audience-individual']"));
        IWebElement checkbox_localgovernment => driver.FindElement(By.XPath("//label[@class='nsw-form__checkbox-label'][@for='audience-local-government']"));
        IWebElement checkbox_notforprofit => driver.FindElement(By.XPath("//label[@class='nsw-form__checkbox-label'][@for='audience-not-for-profit']"));
        IWebElement button_apply => driver.FindElement(By.XPath("//div[@class='nsw-filters__accept']/button[@type='submit']"));
        IList<IWebElement> listOfGrants => driver.FindElements(By.XPath("//div[@class='grant-list-detail__audience']/strong"));

        public void verifyBannerText(string expectedString)
        {
            Assert.That(elementBanner.Text, Is.EqualTo(expectedString));
        }

        public void selectBusiness()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", checkbox_business);

        }
        public void selectIndividual()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", checkbox_individual);

        }
        public void selectLocalGovernment()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", checkbox_localgovernment);

        }
        public void selectNotForProfit()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", checkbox_notforprofit);

        }
        public void clickApply()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", button_apply);
        }



        public void verifySearchResults(string expectedSearchSubstring)
        {
           
            foreach (IWebElement keywordList in listOfGrants)
            {

               // string elementText = keywordList.Text;
                Assert.IsTrue(keywordList.Text.Contains(expectedSearchSubstring), $"The text '{keywordList.Text}' does not contain the expected substring '{expectedSearchSubstring}'.");
            }

        }

        


    }
}

