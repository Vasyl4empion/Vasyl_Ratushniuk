using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using NUnit.Framework;

namespace SeleniumTest.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver driver;
        private readonly By _UsernameInputButton = By.XPath("//input[@name='txtUsername']");
        private readonly By _PasswordInputButton = By.XPath("//input[@name='txtPassword']");
        private readonly By _CancelButton = By.XPath("//*[@id='btnCancel']");
        public MainMenuPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public AuthorizationPageObject SignIn(string username,string password) 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_UsernameInputButton));
            driver.FindElement(_UsernameInputButton).SendKeys(username);
            wait.Until(ExpectedConditions.ElementToBeClickable(_PasswordInputButton));
            driver.FindElement(_PasswordInputButton).SendKeys(password);
            return new AuthorizationPageObject(driver);
        }
        public void CheckJob(ExtentTest test,string path)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.IsTrue(driver.FindElement(By.XPath(path)).Displayed);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path)));
            driver.FindElement(By.XPath(path)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_CancelButton));
            driver.FindElement(_CancelButton).Click();
            test.Log(Status.Info, "We can see our title!");
            
        }
        public ModifyJob Modify() 
        { return new ModifyJob(driver); }
        public DeletingJob Removetitle()
        { return new DeletingJob(driver); }
    }
}
