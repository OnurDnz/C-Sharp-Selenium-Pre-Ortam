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

        public static IWebElement WaitUntilFind(By elementLocatorType)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(
                   typeof(NotFoundException),
                   typeof(NoSuchElementException),
                   typeof(ElementNotVisibleException),
                   typeof(StaleElementReferenceException),
                   typeof(ElementNotInteractableException)
                );
                var foundElement = wait.Until(x => x.FindElement(elementLocatorType));
                wait.Until(ExpectedConditions.ElementToBeClickable(foundElement));
                return foundElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Wait until find function
        /// </summary>
        /// <param name="elementLocatorType">Extension parameter</param>
        /// <param name="locator">Search for element location type</param>
        /// <param name="timeoutInSeconds">Variable is wait value of the function that wait until find element</param>
        /// <returns></returns>
        public static IWebElement WaitUntilFind(this IWebElement elementLocatorType, By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(
                   typeof(NotFoundException),
                   typeof(NoSuchElementException),
                   typeof(ElementNotVisibleException),
                   typeof(StaleElementReferenceException),
                   typeof(ElementNotInteractableException)
                );
                var foundElement = wait.Until(x => x.FindElement(locator));
                wait.Until(ExpectedConditions.ElementToBeClickable(foundElement));
                return foundElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }
    }
}
