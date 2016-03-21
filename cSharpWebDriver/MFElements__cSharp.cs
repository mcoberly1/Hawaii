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
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div/ul/li[2]/a/span | ]]
            Assert.AreEqual("ご搭乗", driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[2]/a/span")));
            // Click manage/check-in link
            driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=チェックイン | ]]
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
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=img[alt="Hawaiian Airlines"] | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Hawaiian Airlines\"]")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("img[alt=\"Hawaiian Airlines\"]")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=ヘルプ | ]]
            Assert.AreEqual("ヘルプ", driver.FindElement(By.LinkText("ヘルプ")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ヘルプ")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=ご利用規約 | ]]
            Assert.AreEqual("ご利用規約", driver.FindElement(By.LinkText("ご利用規約")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ご利用規約")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=お問い合わせ | ]]
            Assert.AreEqual("お問い合わせ", driver.FindElement(By.LinkText("お問い合わせ")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("お問い合わせ")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.ha-icon.fontIcon16-search | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.ha-icon.fontIcon16-search")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=サイト内検索 | ]]
            Assert.AreEqual("サイト内検索", driver.FindElement(By.CssSelector("span.label")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("サイト内検索")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--japan | ]]
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.icon-flag-26--japan")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--japan")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=a.region.link > span.label | ]]
            Assert.AreEqual("JPY", driver.FindElement(By.CssSelector("a.region.link > span.label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.region.link > span.label")));
            driver.FindElement(By.LinkText("JPY")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--usa | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--usa")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=United States (USD) | ]]
            Assert.AreEqual("United States (USD)", driver.FindElement(By.LinkText("United States (USD)")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=a.region.flag-link > i.icon-flag-26--japan | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.region.flag-link > i.icon-flag-26--japan")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[2]/a/span | ]]
            Assert.AreEqual("日本 (JPY)", driver.FindElement(By.XPath("//li[2]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--southkorea | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--southkorea")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[3]/a/span | ]]
            Assert.AreEqual("한국어 (KRW)", driver.FindElement(By.XPath("//li[3]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--australia | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--australia")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[4]/a/span | ]]
            Assert.AreEqual("Australia (AUD)", driver.FindElement(By.XPath("//li[4]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--newzealand | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--newzealand")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[6]/ul/li[5]/a/span | ]]
            Assert.AreEqual("New Zealand (NZD)", driver.FindElement(By.XPath("//li[6]/ul/li[5]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--china | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--china")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[6]/ul/li[6]/a/span | ]]
            Assert.AreEqual("中国 (CNY)", driver.FindElement(By.XPath("//li[6]/ul/li[6]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.icon-flag-26--taiwan | ]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.icon-flag-26--taiwan")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[7]/a/span | ]]
            Assert.AreEqual("台灣 (NT$)", driver.FindElement(By.XPath("//li[7]/a/span")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=a.region.link > span.label | ]]
            driver.FindElement(By.LinkText("JPY")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div/ul/li[1]/a/span | ]]
            Assert.AreEqual("ご予約", driver.FindElement(By.CssSelector("span.ha-nav.nav-li-inner-title")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.ha-nav.nav-li-inner-title")));
            // Verify manage/check-in link
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div/ul/li[2]/a/span | ]]
            Assert.AreEqual("ご搭乗", driver.FindElement(By.XPath("//div/ul/li[2]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[2]/a/span")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div/ul/li[3]/a/span | ]]
            Assert.AreEqual("ハワイアン航空について", driver.FindElement(By.XPath("//div/ul/li[3]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div/ul/li[3]/a/span")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div/ul/li[4]/a/span | ]]
            Assert.AreEqual("ハワイガイド", driver.FindElement(By.XPath("//div/ul/li[4]/a/span")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ハワイガイド")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=span.nav-li--account-title | ]]
            Assert.AreEqual("HawaiianMiles会員ログイン", driver.FindElement(By.CssSelector("span.nav-li--account-title")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.nav-li--account-title")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=ログイン | ]]
            Assert.AreEqual("ログイン", driver.FindElement(By.LinkText("ログイン")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("ログイン")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=新規入会 | ]]
            Assert.AreEqual("新規入会", driver.FindElement(By.LinkText("新規入会")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("新規入会")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=em | ]]
            Assert.AreEqual("ウェブチェックイン", driver.Title);
            Assert.IsTrue(IsElementPresent(By.CssSelector("em")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //header | ]]
            Assert.AreEqual("ウェブチェックイン", driver.FindElement(By.XPath("//header")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=p | ]]
            Assert.AreEqual("ご出発24時間～90分前までウェブチェックインが可能です。チェックインの際に座席指定や座席変更、手荷物料金のお支払いもできます。", driver.FindElement(By.CssSelector("p")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=code_or_ticket | ]]
            Assert.IsTrue(IsElementPresent(By.Name("code_or_ticket")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=last_name | ]]
            Assert.IsTrue(IsElementPresent(By.Name("last_name")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=submit | ]]
            Assert.IsTrue(IsElementPresent(By.Name("submit")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=予約番号、またはチケット番号をお忘れですか？ | ]]
            Assert.AreEqual("予約番号、またはチケット番号をお忘れですか？", driver.FindElement(By.LinkText("予約番号、またはチケット番号をお忘れですか？")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("予約番号、またはチケット番号をお忘れですか？")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=small | ]]
            Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("small")).Text, "^exact:[\\s\\S]*お電話にて仮予約して保持された場合、ウェブサイトでの本予約は受け付けておりません。 予約センターまでお電話の上、ご予約を確定してください。$"));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=予約センターまでお電話の上、ご予約を確定してください。 | ]]
            Assert.AreEqual("予約センターまでお電話の上、ご予約を確定してください。", driver.FindElement(By.LinkText("予約センターまでお電話の上、ご予約を確定してください。")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("予約センターまでお電話の上、ご予約を確定してください。")));
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=i.ha-icon.fontIcon20-circleUp | ]]
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.ha-icon.fontIcon20-circleUp")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=トップに戻る | ]]
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
