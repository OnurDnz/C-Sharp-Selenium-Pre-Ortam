using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Simple.Utilities;

namespace Simple
{
    public class BaseTest : BrowserFactory
    {
        internal ExcelTool Excel { get; set; }

        string xlFilePath = @"C:\Users\onurd\source\repos\Simple\Simple\TestData.xlsx";

        [SetUp]
        public void SetUp()
        {
            InitBrowser("Firefox");
            WaitClass.Driver = driver;
            driver.Manage().Window.Maximize();
            Excel = new ExcelTool(xlFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenshot.Take(driver);
            driver.Quit();
            //WriteTestStatus();
        }

        public void WriteTestStatus()
        {
            if (TestContext.CurrentContext.Result.FailCount == 0)
            {
                FindUntillToNullCell(2, Status.Passed);
            }
            else
            {
                FindUntillToNullCell(2, Status.Failed);
            }

        }

        public void FindUntillToNullCell(int colNum, Status status)
        {
            bool flag = true;
            while (flag)
            {
                if (Excel.GetCellData("DataSet", 5, colNum) == null)
                {
                    Excel.SetCellData("DataSet", "TestName", colNum, $"{TestContext.CurrentContext.Test.MethodName}");
                    if (status == Status.Passed)
                    {
                        Excel.SetCellData("DataSet", "Result", colNum, status.ToString());
                        Excel.FillPassed("E" + colNum, "E" + colNum);
                    }
                    else
                    {
                        Excel.SetCellData("DataSet", "Result", colNum, status.ToString());
                        Excel.FillFailed("E" + colNum, "E" + colNum);
                    }
                    flag = false;
                }
                colNum++;
            }
        }
        public enum Status
        {
            Passed,
            Failed
        }
    }
}
