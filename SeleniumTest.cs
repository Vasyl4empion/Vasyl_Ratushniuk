using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.Login_and_Job_Info;
using SeleniumTest.PageObjects;
namespace SeleniumText
{
    public class Tests
    {
        ExtentReports extent = null;

        private IWebDriver driver;
        private readonly LoginInfo User1 = new LoginInfo();
        private readonly JobInfo job = new JobInfo();
        [SetUp]
        public void Setup()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"D:\3-rd course\Extent reports\TestReport.html");
            extent.AttachReporter(htmlReporter);
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Add_check_modify_delete_title() 
        {
            ExtentTest test = extent.CreateTest("Test https://opensource-demo.orangehrmlive.com/ on add,check,modify and delete job title").Info("Test started");
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn(User1.username, User1.password)
                .Login(test)
                .GoTotitle(test)
                .AddJob(test, job.title, job.description, job.note)
                .CheckJob(test, job.pathtotitle);
            mainMenu
                .Modify()
                .NewDescryption(test, job.pathtotitle, job.newdescryption)
                .CheckJob(test,job.pathtotitle);
            mainMenu
                .Removetitle()
                .DeleteJob(test, job.pathtotitle);
            test.Log(Status.Pass, "All tests passed!");
        }
  
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}