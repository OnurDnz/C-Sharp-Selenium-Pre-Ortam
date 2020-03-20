using NUnit.Framework;
using SeleniumExtras.PageObjects;
using Simple.Pages;

namespace Simple
{
    [TestFixture]
    [CacheLookup]
    public class LoginPageTest : BaseTest
    {
        MainPage mainPage = new MainPage();

        [Test]
        public void Primary()
        {
            driver.Navigate().GoToUrl("https://www.google.com.tr/");
            mainPage.firstResult.SendKeys("Test");
            mainPage.secondResult.Click();
        }
        [Test]
        public void Secondery()
        {
            driver.Navigate().GoToUrl("https://www.google.com.tr/");
            mainPage.firstResult.SendKeys("Deneme");
            mainPage.secondResult.Click();
        }
    }
}
