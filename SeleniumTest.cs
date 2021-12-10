using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.Login_and_Job_Info;
using SeleniumTest.PageObjects;
using System.Threading;
namespace SeleniumText
{

    /// <instruction>
    /// There are 4 tests. You have to run them in this oreder:
    /// 1) Test1_addinigjob: This test opens site , send username and password. 
    /// Then it goes to job titles and adding new title.
    /// 2)Test2_4_checkingtitle: This test opens site , send username and password.
    /// Then it goes to job titles and opens(than closes) our title.It has to be used after. Test1 and Test3.
    /// 3)Test3_descrmodifying:This test opens site , send username and password. 
    /// Then it goes to job titles and opens our title ,edits description and save new title.
    /// 4)Test5_removatitle: This test opens site , send username and password. 
    /// Then it goes to job titles and deleting our title. 
    /// Or you can just run all tests)
    /// </instruction>

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
            var htmlReporter = new ExtentHtmlReporter(@"D:\3-rd course\Extent reports\TestReport.html");//name of file changed according to test
            extent.AttachReporter(htmlReporter);
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();
        }
        
        [Test]
        public void Test1_addinigjob()
        { // Entering user,password and clicking on login button:
            ExtentTest test = extent.CreateTest("Test1").Info("Test started");
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn(User1.username, User1.password)
                .Login()
                .GotoJobTitle();
            test.Log(Status.Info, "Successfully logged in and went to job title");
            //adding job 
            var Addbutton = driver.FindElement(By.XPath("//*[@id='btnAdd']"));
            Addbutton.Click();
            Thread.Sleep(2000);
            var JobTitle = driver.FindElement(By.XPath("//*[@id='jobTitle_jobTitle']"));
            JobTitle.SendKeys(job.title);
            Thread.Sleep(2000);

            var JobDescryption = driver.FindElement(By.XPath("//*[@id='jobTitle_jobDescription']"));
            JobDescryption.SendKeys(job.description);
            Thread.Sleep(2000);

            var JobNote = driver.FindElement(By.XPath("//*[@id='jobTitle_note']"));
            JobNote.SendKeys(job.note);
            Thread.Sleep(2000);

            var SaveButton = driver.FindElement(By.XPath("//*[@value='Save']"));
            SaveButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Title was created!Test1 Passed.");
        }
        [Test]
        public void Test2_4_checkingtitle()
        {
            ExtentTest test = extent.CreateTest("Test2").Info("Test started");
            // Entering user,password and clicking on login button:
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn(User1.username, User1.password)
                .Login()
                .GotoJobTitle();
            test.Log(Status.Info, "Successfully logged in and went to job title");
            //go to JobTitles
            var Goingtotitle = driver.FindElement(By.XPath(job.pathtotitle));
            if (Goingtotitle.Displayed)//if it is displayed, open title and check it
            {
                Goingtotitle.Click();
                Thread.Sleep(2000);//pause for seeing info of jobtitle 
                var CancelButton = driver.FindElement(By.XPath("//*[@id='btnCancel']"));
                CancelButton.Click();
                Thread.Sleep(2000);
            }
            test.Log(Status.Pass, "We can see our title!Test2 Passed.");
        }

        [Test]
        public void Test3_descrmodifying() 
        {
            ExtentTest test = extent.CreateTest("Test3").Info("Test started");
            //openeing site 
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn(User1.username, User1.password)
                .Login()
                .GotoJobTitle();
            test.Log(Status.Info, "Successfully logged in and went to job title");
            var Goingtotitle = driver.FindElement(By.XPath(job.pathtotitle));//going to our title
            Goingtotitle.Click();
            var EditButton = driver.FindElement(By.XPath("//*[@value='Edit']"));
            EditButton.Click();
            var JobDescryption = driver.FindElement(By.XPath("//*[@id='jobTitle_jobDescription']"));
            Thread.Sleep(2000);
            JobDescryption.Clear();
            Thread.Sleep(2000);
            JobDescryption.SendKeys(job.newdescryption);
            Thread.Sleep(2000);
            var SaveButton = driver.FindElement(By.XPath("//*[@value='Save']"));
            SaveButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Successfully changed description.To se changes run Test2 ! Test3 Passed.");
        }
        [Test]
        public void Test5_removatitle()
        {
            ExtentTest test = extent.CreateTest("Test5").Info("Test started");
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn(User1.username, User1.password)
                .Login()
                .GotoJobTitle();
            test.Log(Status.Info, "Successfully logged in and went to job title");
            var Goingtotitle = driver.FindElement(By.XPath(job.pathtotitle));
            string fullattributes = Goingtotitle.GetAttribute("href");//all checkboxbuttons has value, and also our going to title button has attribute href,that gives us this value from 82 element to the end of string 
            string value="";
            for (int i = 82; i < fullattributes.Length; i++) {
                value += fullattributes[i];
            }
            string Pathtocheckbox = "//input[@value = '" + value + "']";
            var CheckboxButton = driver.FindElement(By.XPath(Pathtocheckbox));
            CheckboxButton.Click();
            Thread.Sleep(2000);
            var DeleteButton = driver.FindElement(By.XPath("//*[@id='btnDelete']"));
            DeleteButton.Click();
            Thread.Sleep(2000);
            var Deleteapplying = driver.FindElement(By.XPath("//*[@id='dialogDeleteBtn']"));
            Deleteapplying.Click();
            Thread.Sleep(2000);//to see if our title is deleted
            test.Log(Status.Pass, "Title was deleted ! Test5 Passed.");
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
