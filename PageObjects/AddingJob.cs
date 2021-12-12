using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest
{
    class AddingJob
    {
        private IWebDriver driver;
        private readonly By _Addbutton = By.XPath("//*[@id='btnAdd']");
        private readonly By _JobTitle = By.XPath("//*[@id='jobTitle_jobTitle']");
        private readonly By _JobDescryption = By.XPath("//*[@id='jobTitle_jobDescription']");
        private readonly By _JobNote = By.XPath("//*[@id='jobTitle_note']");
        private readonly By _SaveButton = By.XPath("//*[@value='Save']");
        public AddingJob(IWebDriver driver)
        {
            this.driver = driver;
        }
        public MainMenuPageObject AddJob(ExtentTest test,string title,string descryption,string note)
        {
            driver.FindElement(_Addbutton).Click();
            Thread.Sleep(2000);
            driver.FindElement(_JobTitle).SendKeys(title);
            Thread.Sleep(2000);
            driver.FindElement(_JobDescryption).SendKeys(descryption);
            Thread.Sleep(2000);
            driver.FindElement(_JobNote).SendKeys(note);
            Thread.Sleep(2000);
            driver.FindElement(_SaveButton).Click();
            Thread.Sleep(2000);
            test.Log(Status.Info, "Successfully added!");
            return new MainMenuPageObject(driver);
        }
    }
}
