using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
[TestFixture]
public class Valid Check-in
{
private ISelenium selenium;
private StringBuilder verificationErrors;

[SetUp]
public void SetupTest()
{
selenium = new DefaultSelenium("localhost", 4444, "*chrome", "https://www.hawaiianairlines.co.jp/");
selenium.Start();
verificationErrors = new StringBuilder();
}

[TearDown]
public void TeardownTest()
{
try
{
selenium.Stop();
}
catch (Exception)
{
// Ignore errors if unable to close the browser
}
Assert.AreEqual("", verificationErrors.ToString());
}

[Test]
public void TheValid Check-inTest()
{
			selenium.Open("/");
			selenium.Click("//div/ul/li[2]/a/span");
			selenium.Click("css=i.ha-icon.fontIcon40-checkIn");
			selenium.WaitForPageToLoad("30000");
			selenium.Type("name=code_or_ticket", "1732142317055");
			selenium.Type("name=last_name", "known");
			selenium.Click("name=submit");
			selenium.WaitForPageToLoad("30000");
}
}
}
