using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class MFPositive
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.hawaiianairlines.co.jp/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheMFPositiveTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            // Verify Page Title
            Assert.AreEqual("ハワイアン航空公式日本語サイト", driver.Title);
            // Verify manage/check-in link
            Assert.AreEqual("ご搭乗", driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[2]/a/span")));
            // Click manage/check-in link
            driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Click();
            Assert.AreEqual("チェックイン", driver.FindElement(By.LinkText("チェックイン")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.ng-scope > span")));
            driver.FindElement(By.LinkText("チェックイン")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("ウェブチェックイン" == driver.Title) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            Assert.AreEqual("ウェブチェックイン", driver.Title);
            Assert.IsTrue(IsElementPresent(By.Name("code_or_ticket")));
            driver.FindElement(By.Name("code_or_ticket")).Clear();
            driver.FindElement(By.Name("code_or_ticket")).SendKeys("1732142317055");
            Assert.IsTrue(IsElementPresent(By.Name("last_name")));
            driver.FindElement(By.Name("last_name")).Clear();
            driver.FindElement(By.Name("last_name")).SendKeys("known");
            Assert.IsTrue(IsElementPresent(By.Name("submit")));
            driver.FindElement(By.Name("submit")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("h1.welcome"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            Assert.AreEqual("Aloha! To begin your check-in, please provide the information below.", driver.FindElement(By.CssSelector("h1.welcome")).Text);
            // Continue Test Steps....
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
