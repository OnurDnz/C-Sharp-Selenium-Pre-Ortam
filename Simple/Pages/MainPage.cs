using OpenQA.Selenium;
using Simple.Utilities;

namespace Simple.Pages
{
    public class MainPage
    {
        public IWebElement firstResult => WaitClass.WaitUntillFind(By.Name("q"));
        public IWebElement secondResult => WaitClass.WaitUntillFind(By.Name("btnK"));
    }
}
