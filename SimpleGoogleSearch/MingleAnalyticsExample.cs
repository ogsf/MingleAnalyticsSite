using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    [TestFixture] //this tells Nunit that this is a test class
    public class MingleAnalyticsExample
    {
        private IWebDriver driver; //creates the IWebDriver we will use to create the specific browser driver

        private String baseURL;

        [SetUp] //tells Nunit to run this code before each [Test] method
        //TODO Move Setup and Teardown to a 'hooks' class
        public void SetupTest()
        {
            //driver = new FirefoxDriver(); //creates the Firefox driver – you can also create IE, Chrome, Safari etc
            //driver = new ChromeDriver(@"C:\Users\Kevin\Downloads\chromedriver_win32"); // This is now working
            driver = new InternetExplorerDriver(@"C:\Users\Kevin\Downloads\IEDriverServer_x64_2.47.0"); // This is now working
            baseURL = "http://mingleanalytics.com"; ; //sets the baseURL string to the URL we want to start at!
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 10)); //10 second timeout
        }
        
        [TearDown] //tells Nunit to run this method after each [Test]
        public void TeardownTest()
        {
            driver.Quit(); //quits the driver after each test
        }

        [Test] //Nunit knows this is a test method and will run the code against the browser
        public void NavigationMenuTest()
        {
            //Navigate
            driver.Navigate().GoToUrl(baseURL + "/"); //goes to the baseURL with / appended on it

            //TODO Setup PageObject classes to define elements in one place
            //TODO Replace the var list with an array of elements defined in a PageObject class
            System.Console.WriteLine("Page title is: " + driver.Title);
            var menuHome = driver.FindElement(By.XPath("//a[.='Home']")); //Locate menu item
            var menuAbout = driver.FindElement(By.XPath("//a[.='About']")); //Locate menu item
            var menuPI = driver.FindElement(By.XPath("//a[.='Practice Improvement']")); //Locate menu item
            var menuEHR = driver.FindElement(By.XPath("//a[.='EHR Solutions']")); //Locate menu item
            var menuQI = driver.FindElement(By.XPath("//a[.='Quality Incentives']")); //Locate menu item
            var menuContact = driver.FindElement(By.XPath("//a[.='Contact']")); //Locate menu item

            //Assertions
            //TODO Call elements from an array, and iterate through the asserts.
            Assert.AreEqual(true, menuHome.Displayed);
            Assert.AreEqual(true, menuAbout.Displayed);
            Assert.AreEqual(true, menuPI.Displayed);
            Assert.AreEqual(true, menuEHR.Displayed);
            Assert.AreEqual(true, menuQI.Displayed);
            Assert.AreEqual(true, menuContact.Displayed);
            //Two ways to acheive tha same thing
            //TODO Educate yourself on the difference
            Assert.That(driver.Title, Is.EqualTo("Quality is not enough | Mingle Analytics"));
            Assert.AreEqual("Quality is not enough | Mingle Analytics", driver.Title);//Nunit assertion to check title is correct
        }

        [Test]
        public void ContactMenuTest()
        {
            //Navigate
            driver.Navigate().GoToUrl(baseURL + "/"); //goes to the baseURL with / appended on it

            var menuContact = driver.FindElement(By.CssSelector("a[href = '/contact']"));

            menuContact.Click();

            var callUsText = driver.FindElement(By.XPath("//p[contains(., 'Call us toll free')]"));

            System.Console.WriteLine("Call us text is: " + callUsText);
            //Assert.Contains("Call us toll free 1-866-359-4458 9:00 AM to 5:00 PM Eastern Time", callUsText);
        }

    }
}
