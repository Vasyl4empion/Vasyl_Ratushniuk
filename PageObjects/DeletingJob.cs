using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTest.PageObjects;
using System;
using NUnit.Framework;

namespace SeleniumTest
{
    class DeletingJob
    {
        private IWebDriver driver;
        private readonly By _DeleteButton = By.XPath("//*[@id='btnDelete']");
        private readonly By _ApplyDelete = By.XPath("//*[@id='dialogDeleteBtn']");
        public DeletingJob(IWebDriver driver)
        {
            this.driver = driver;
        }
        public MainMenuPageObject DeleteJob(ExtentTest test, string path)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string hrefattribute = driver.FindElement(By.XPath(path)).GetAttribute("href");
            string value = "";
            for (int i = 82; i < hrefattribute.Length; i++)
            {
                value += hrefattribute[i];
            }
            string Pathtocheckbox = "//input[@value = '" + value + "']";
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Pathtocheckbox)));
            driver.FindElement(By.XPath(Pathtocheckbox)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_DeleteButton));
            driver.FindElement(_DeleteButton).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_ApplyDelete));
            driver.FindElement(_ApplyDelete).Click();
            var FindElement = driver.FindElements(By.XPath(path));
            Assert.AreEqual(0, FindElement.Count);//if we have 0 elements - it does not exist on page
            test.Log(Status.Info, "Title deleted");
            return new MainMenuPageObject(driver);
        }
    }
}
