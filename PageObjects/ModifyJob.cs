using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTest.PageObjects;
using System;

namespace SeleniumTest
{
    class ModifyJob
    {
        private IWebDriver driver;
        private readonly By _EditButton = By.XPath("//*[@value='Edit']");
        private readonly By _JobDescr = By.XPath("//*[@id='jobTitle_jobDescription']");
        private readonly By _SaveButton = By.XPath("//*[@value='Save']");
        public ModifyJob(IWebDriver driver)
        {
            this.driver = driver;
        }
        public MainMenuPageObject NewDescryption(ExtentTest test, string path, string newdescryption)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path)));
            driver.FindElement(By.XPath(path)).Click();//going to our title
            wait.Until(ExpectedConditions.ElementToBeClickable(_EditButton));
            driver.FindElement(_EditButton).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_JobDescr));
            driver.FindElement(_JobDescr).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(_JobDescr));
            driver.FindElement(_JobDescr).SendKeys(newdescryption);
            wait.Until(ExpectedConditions.ElementToBeClickable(_SaveButton));
            driver.FindElement(_SaveButton).Click();
            test.Log(Status.Info, "Successfully changed description!");
            return new MainMenuPageObject(driver);
        }
    }
}
