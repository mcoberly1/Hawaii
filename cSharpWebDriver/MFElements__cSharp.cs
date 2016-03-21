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
    public class MFElements
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
        public void TheMFElementsTest()
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
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("img[alt=\"Hawaiian Airlines\"]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Hawaiian Airlines\"]")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("img[alt=\"Hawaiian Airlines\"]")).Text);
            Assert.AreEqual("ヘルプ", driver.FindElement(By.LinkText("ヘルプ")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ヘルプ")));
            Assert.AreEqual("ご利用規約", driver.FindElement(By.LinkText("ご利用規約")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ご利用規約")));
            Assert.AreEqual("お問い合わせ", driver.FindElement(By.LinkText("お問い合わせ")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("お問い合わせ")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.ha-icon.fontIcon16-search")));
            Assert.AreEqual("サイト内検索", driver.FindElement(By.CssSelector("span.label")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("サイト内検索")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.icon-flag-26--japan")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--japan")));
            Assert.AreEqual("JPY", driver.FindElement(By.CssSelector("a.region.link > span.label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.region.link > span.label")));
            driver.FindElement(By.LinkText("JPY")).Click();
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--usa")));
            Assert.AreEqual("United States (USD)", driver.FindElement(By.LinkText("United States (USD)")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.region.flag-link > i.icon-flag-26--japan")));
            Assert.AreEqual("日本 (JPY)", driver.FindElement(By.XPath("//li[2]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--southkorea")));
            Assert.AreEqual("한국어 (KRW)", driver.FindElement(By.XPath("//li[3]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--australia")));
            Assert.AreEqual("Australia (AUD)", driver.FindElement(By.XPath("//li[4]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--newzealand")));
            Assert.AreEqual("New Zealand (NZD)", driver.FindElement(By.XPath("//li[6]/ul/li[5]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--china")));
            Assert.AreEqual("中国 (CNY)", driver.FindElement(By.XPath("//li[6]/ul/li[6]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--taiwan")));
            Assert.AreEqual("台灣 (NT$)", driver.FindElement(By.XPath("//li[7]/a/span")).Text);
            driver.FindElement(By.LinkText("JPY")).Click();
            Assert.AreEqual("ご予約", driver.FindElement(By.CssSelector("span.ha-nav.nav-li-inner-title")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.ha-nav.nav-li-inner-title")));
            // Verify manage/check-in link
            Assert.AreEqual("ご搭乗", driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[2]/a/span")));
            Assert.AreEqual("ハワイアン航空について", driver.FindElement(By.XPath("//div/ul/li[3]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[3]/a/span")));
            Assert.AreEqual("ハワイガイド", driver.FindElement(By.XPath("//div/ul/li[4]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ハワイガイド")));
            Assert.AreEqual("HawaiianMiles会員ログイン", driver.FindElement(By.CssSelector("span.nav-li--account-title")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.nav-li--account-title")));
            Assert.AreEqual("ログイン", driver.FindElement(By.LinkText("ログイン")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ログイン")));
            Assert.AreEqual("新規入会", driver.FindElement(By.LinkText("新規入会")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("新規入会")));
            Assert.AreEqual("ウェブチェックイン", driver.Title);
            Assert.IsTrue(IsElementPresent(By.CssSelector("em")));
            Assert.AreEqual("ウェブチェックイン", driver.FindElement(By.XPath("//header")).Text);
            Assert.AreEqual("ご出発24時間～90分前までウェブチェックインが可能です。チェックインの際に座席指定や座席変更、手荷物料金のお支払いもできます。", driver.FindElement(By.CssSelector("p")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("code_or_ticket")));
            Assert.IsTrue(IsElementPresent(By.Name("last_name")));
            Assert.IsTrue(IsElementPresent(By.Name("submit")));
            Assert.AreEqual("予約番号、またはチケット番号をお忘れですか？", driver.FindElement(By.LinkText("予約番号、またはチケット番号をお忘れですか？")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("予約番号、またはチケット番号をお忘れですか？")));
            Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("small")).Text, "^exact:[\\s\\S]*お電話にて仮予約して保持された場合、ウェブサイトでの本予約は受け付けておりません。 予約センターまでお電話の上、ご予約を確定してください。$"));
            Assert.AreEqual("予約センターまでお電話の上、ご予約を確定してください。", driver.FindElement(By.LinkText("予約センターまでお電話の上、ご予約を確定してください。")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("予約センターまでお電話の上、ご予約を確定してください。")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.ha-icon.fontIcon20-circleUp")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("トップに戻る")));
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
