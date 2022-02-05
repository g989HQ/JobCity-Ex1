using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ZeroWebApp_Ex1
{
    class ZeroWebAppTest
    {
        [TestFixture]

        public class ZeroWebbTests

        {
            [Test]
            public void NavigateAllTabs()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://zero.webappsecurity.com");
                driver.Manage().Window.Maximize();
                //Time added to follow up execution easier
                Thread.Sleep(5000);
                Activity.WaitForElementbyXpath(driver, "//a[contains(.,'Zero Bank')]");
                //Time added to follow up execution easier
                Thread.Sleep(5000);
                Activity.NavigateTabs(driver, "onlineBankingMenu", "//span[contains(.,'Account Summary')]");
                //Time added to follow up execution easier
                Thread.Sleep(5000);
                Activity.NavigateTabs(driver, "feedback", "//span[contains(.,'Frequently Asked Questions')]");
                Activity.WaitForElementbyXpath(driver, "//a[contains(.,'Zero Bank')]");
                Thread.Sleep(6000);

                Activity.ClickbuttonByXpath(driver, "//a[starts-with(.,'Zer')]");
              //  driver.Navigate().GoToUrl("http://zero.webappsecurity.com/index.html");
                Thread.Sleep(6000);
                Activity.WaitForElementbyXpath(driver, "//img[starts-with(@src,'/resources/img/main_carousel_1.jpg')]");
                Thread.Sleep(6000);
                driver.Quit();


            }

            [Test]
            public void SendFeedback()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://zero.webappsecurity.com");
                driver.Manage().Window.Maximize();
                //Time added to follow up execution easier
                Thread.Sleep(5000);
                Activity.WaitForElementbyXpath(driver, "//a[contains(.,'Zero Bank')]");             
                Activity.NavigateTabs(driver, "feedback", "//span[contains(.,'Frequently Asked Questions')]");
                Activity.WaitForElementbyXpath(driver, "//a[contains(.,'Zero Bank')]");
                Thread.Sleep(6000);
                Activity.SendKeysById(driver, "name", "Auto");
                Activity.SendKeysById(driver, "email", "Auto");
                Activity.SendKeysById(driver, "subject", "Auto");
                Activity.SendKeysById(driver, "comment", "Auto");
                Thread.Sleep(3000);
                Activity.ClickbuttonByName(driver, "submit");

                string feedbacksent = "Feedback\r\nThank you for your comments, Auto. They will be reviewed by our Customer Service staff and given the full attention that they deserve.";

                IWebElement element = driver.FindElement(By.XPath("//div[contains(@class,'offset3 span6')]"));

                var text = element.Text;

                if (feedbacksent == text)
                {
                    Assert.Fail("The feedback shouldn't be sent, the fields need to be validated.");
                }

                driver.Quit();


            }

            [TearDown]
            public void testClean()
            {

            }
        }
    }
}
