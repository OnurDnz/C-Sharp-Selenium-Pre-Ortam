using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Simple.Utilities;

namespace Simple.Pages
{
    [CacheLookup]
    public static class MainPage
    {
        public static IWebElement firstResult => WaitClass.WaitUntilFind(By.Name("q"));
        public static IWebElement secondResult => WaitClass.WaitUntilFind(By.Name("btnK"));
    }
}
