using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        public MainMenuPageObject Login() 
        {
            driver.FindElement(_LoginButton).Click();
            Thread.Sleep(2000);
            return new MainMenuPageObject(driver);
        }
    }
}
