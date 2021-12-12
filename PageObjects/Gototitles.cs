using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest
{
    class Gototitles
    {
        private IWebDriver driver;
        private readonly By _AdminButton = By.XPath("//*[@id='menu_admin_viewAdminModule']/b");
        private readonly By _Drawdawn = By.CssSelector("#menu_admin_Job");
        private readonly By _JobTitleList = By.XPath("//*[@id='menu_admin_viewJobTitleList']");
        public Gototitles(IWebDriver driver)
        {
            this.driver = driver;
        }
        public AddingJob GoTotitle(ExtentTest test)
        {
            driver.FindElement(_AdminButton).Click();
            Thread.Sleep(2000);
            driver.FindElement(_Drawdawn).Click();
            Thread.Sleep(2000);
            driver.FindElement(_Drawdawn).FindElement(_JobTitleList).Click();
            Thread.Sleep(2000);
            test.Log(Status.Info, "Successfully went to jobtitles!");
            return new AddingJob(driver);
        }
    }
}
