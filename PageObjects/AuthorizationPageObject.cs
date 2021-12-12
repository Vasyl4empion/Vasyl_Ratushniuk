using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTest.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver driver;
        private readonly By _LoginButton = By.XPath("//input[@id='btnLogin']");
        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Gototitles Login(ExtentTest test) 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_LoginButton));
            driver.FindElement(_LoginButton).Click();
            test.Log(Status.Info, "Successfully logged in!");
            return new Gototitles(driver);
        }
    }
}
