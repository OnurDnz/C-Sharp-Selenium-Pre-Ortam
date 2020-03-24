using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using SeleniumHelperLibrary;
using Simple.Utilities;
using System;

namespace Simple
{
    public class BaseTest : BrowserFactory
    {
        string xlFilePath = @"C:\Users\onurd\source\repos\Simple\Simple\TestData.xlsx";
        protected ExtentReportsHelper extent;

        [SetUp]
        public void SetUp()
        {
            InitBrowser("Firefox");
            WaitClass.Driver = driver;
            driver.Manage().Window.Maximize();
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ExcelTool.ExcelFilePath = xlFilePath;
        }

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        TakeScreenshot.Take(driver);
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        TakeScreenshot.Take(driver);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                driver.Quit();
            }
        }


        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                extent.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
