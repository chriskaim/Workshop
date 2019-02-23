using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System;

namespace SeleniumTests
{
    class Selenium
    {
        IWebDriver driver;

        [SetUp]
        public void Intialize()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void LoginExistingData()
        {
            driver.Url = "https://pl.wikipedia.org/w/index.php?title=Specjalna:Zaloguj&returnto=Wikipedia%3AStrona+g%C5%82%C3%B3wna";
            IWebElement username = driver.FindElement(By.XPath("//input[contains(@id, 'wpName1')]"));
            IWebElement password = driver.FindElement(By.XPath("//input[contains(@id, 'wpPassword1')]"));

            username.Clear();
            username.SendKeys("Existing user");

            password.Clear();
            password.SendKeys("Existing password");

            driver.FindElement(By.Id("wpLoginAttempt")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("SeleniumTests"));
        }

        [Test]
        public void LoginFakeData()
        {
            driver.Url = "https://pl.wikipedia.org/w/index.php?title=Specjalna:Zaloguj&returnto=Wikipedia%3AStrona+g%C5%82%C3%B3wna";
            IWebElement username = driver.FindElement(By.XPath("//input[contains(@id, 'wpName1')]"));
            IWebElement password = driver.FindElement(By.XPath("//input[contains(@id, 'wpPassword1')]"));

            username.Clear();
            username.SendKeys("Fake user");

            password.Clear();
            password.SendKeys("Fake password");

            driver.FindElement(By.Id("wpLoginAttempt")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsFalse(body.Text.Contains("SeleniumTests"));
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
