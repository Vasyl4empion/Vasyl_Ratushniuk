using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver driver;
        private readonly By _UsernameInputButton = By.XPath("//input[@name='txtUsername']");
        private readonly By _PasswordInputButton = By.XPath("//input[@name='txtPassword']");
        private readonly By _AdminButton = By.XPath("//*[@id='menu_admin_viewAdminModule']/b");
        private readonly By _Drawdawn = By.CssSelector("#menu_admin_Job");
        private readonly By _JobTitleList = By.XPath("//*[@id='menu_admin_viewJobTitleList']");
        public MainMenuPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public AuthorizationPageObject SignIn(string username,string password) 
        {
            driver.FindElement(_UsernameInputButton).SendKeys(username);
            Thread.Sleep(2000);
            driver.FindElement(_PasswordInputButton).SendKeys(password);
            Thread.Sleep(2000);
            return new AuthorizationPageObject(driver);
        }
        public void GotoJobTitle()
        {
            driver.FindElement(_AdminButton).Click();
            Thread.Sleep(2000);
            driver.FindElement(_Drawdawn).Click();
            Thread.Sleep(2000);
            driver.FindElement(_Drawdawn).FindElement(_JobTitleList).Click();
            Thread.Sleep(2000);
        }
    }
}
