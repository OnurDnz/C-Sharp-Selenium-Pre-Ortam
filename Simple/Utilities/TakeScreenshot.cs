using NUnit.Framework;
using OpenQA.Selenium;

namespace Simple.Utilities
{
    public static class TakeScreenshot
    {
        public static void Take(IWebDriver driver)
        {
            var path = @"C:\Users\onurd\source\repos\Simple\Simple\Screenshots\" + TestContext.CurrentContext.Test.MethodName.Trim() + ".Jpeg";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
        }

        public static void Take(IWebDriver driver, string SSName)
        {
            var path = @"C:\Users\onurd\source\repos\Simple\Simple\Screenshots\" + SSName.Trim() + ".Jpeg";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
        }
    }
}
