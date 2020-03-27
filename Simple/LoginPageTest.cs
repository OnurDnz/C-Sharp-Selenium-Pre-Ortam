using NUnit.Framework;
using SeleniumExtras.PageObjects;
using Simple.Pages;
using Simple.Utilities;

namespace Simple
{
    [TestFixture]
    [CacheLookup]
    public class LoginPageTest : BaseTest
    {
        //MainPage mainPage = new MainPage();

        [Test]
        public void Primary()
        {
            driver.Navigate().GoToUrl("https://www.google.com.tr/");
            MainPage.firstResult.SendKeys("Test");
            MainPage.secondResult.Click();
        }
        [Test]
        public void Secondery()
        {
            driver.Navigate().GoToUrl("https://www.google.com.tr/");
            MainPage.firstResult.SendKeys("Deneme");
            MainPage.secondResult.Click();
        }
    }
}
