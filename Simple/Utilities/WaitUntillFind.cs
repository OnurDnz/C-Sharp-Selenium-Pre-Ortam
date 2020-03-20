using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace Simple.Utilities
{
    public static class WaitClass
    {
        public static IWebDriver Driver { get; set; }

        public static IWebElement WaitUntillFind(By locator, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(
                   typeof(NotFoundException),
                   typeof(NoSuchElementException),
                   typeof(ElementNotVisibleException),
                   typeof(StaleElementReferenceException),
                   typeof(ElementNotInteractableException)
                );
                var result = wait.Until(x => x.FindElement(locator));
                wait.Until(ExpectedConditions.ElementToBeClickable(result));
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }
        public static IWebElement WaitUntillFind(this IWebElement element, By locator, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(
                   typeof(NotFoundException),
                   typeof(NoSuchElementException),
                   typeof(ElementNotVisibleException),
                   typeof(StaleElementReferenceException),
                   typeof(ElementNotInteractableException)
                );
                var a = wait.Until(x => x.FindElement(locator));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
                return a;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }
    }
}
