using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using xl = Microsoft.Office.Interop.Excel;

namespace Simple
{
    class ExcelTool
    {
        //Bu sınıf static yapılacak

        Application xlApp = null;
        Workbooks workbooks = null;
        Workbook workbook = null;
        Range range;
        Hashtable sheets;
        public string xlFilePath;
        public ExcelTool Eat { get; set; }

        public ExcelTool(string xlFilePath)
        {
            this.xlFilePath = xlFilePath;
        }

        public void OpenExcel()
        {
            xlApp = new Application();
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Open(xlFilePath);
            sheets = new Hashtable();
            int count = 1;
            // Storing worksheet names in Hashtable.
            foreach (Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }
        public void FillPassed(object cell1, object cell2)
        {
            OpenExcel();
            range = xlApp.get_Range(cell1, cell2);
            range.Interior.Color = xl.XlRgbColor.rgbLightGreen;
            workbook.Save();
            CloseExcel();
        }
        public void FillFailed(object cell1, object cell2)
        {
            OpenExcel();
            range = xlApp.get_Range(cell1, cell2);
            range.Interior.Color = xl.XlRgbColor.rgbRed;
            workbook.Save();
            CloseExcel();
        }
        public void CloseExcel()
        {
            workbook.Close(false, xlFilePath, null); // Close the connection to workbook
            Marshal.FinalReleaseComObject(workbook); // Release unmanaged object references.
            workbook = null;

            workbooks.Close();
            Marshal.FinalReleaseComObject(workbooks);
            workbooks = null;

            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;
        }
        public string GetCellData(string sheetName, int colNumber, int rowNumber)
        {
            OpenExcel();

            string value = string.Empty;
            int sheetValue = 0;

            if (sheets.ContainsValue(sheetName))
            {
                foreach (DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(sheetName))
                    {
                        sheetValue = (int)sheet.Key;
                    }
                }
                Worksheet worksheet = null;
                worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                Range range = worksheet.UsedRange;

                value = Convert.ToString((range.Cells[rowNumber, colNumber] as Range).Value2);
                Marshal.FinalReleaseComObject(worksheet);
                worksheet = null;
            }
            CloseExcel();
            return value;
        }
        public bool SetCellData(string sheetName, string colName, int rowNumber, string value)
        {
            OpenExcel();

            int sheetValue = 0;
            int colNumber = 0;

            try
            {
                if (sheets.ContainsValue(sheetName))
                {
                    foreach (DictionaryEntry sheet in sheets)
                    {
                        if (sheet.Value.Equals(sheetName))
                        {
                            sheetValue = (int)sheet.Key;
                        }
                    }

                    xl.Worksheet worksheet = null;
                    worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                    xl.Range range = worksheet.UsedRange;

                    for (int i = 1; i <= range.Columns.Count; i++)
                    {
                        string colNameValue = Convert.ToString((range.Cells[1, i] as xl.Range).Value2);
                        if (colNameValue.ToLower() == colName.ToLower())
                        {
                            colNumber = i;
                            break;
                        }
                    }

                    range.Cells[rowNumber, colNumber] = value;
                    workbook.Save();
                    Marshal.FinalReleaseComObject(worksheet);
                    worksheet = null;

                    CloseExcel();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public List<string> GetAll(int sheetİndex)
        {
            int rCnt, cCnt, rw = 0, cl = 0;
            List<string> cellDataList = new List<string>();

            OpenExcel();
            Worksheet worksheet = workbook.Worksheets.get_Item(sheetİndex);
            range = worksheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;

            for (rCnt = 1; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    if (range.Cells[rCnt, cCnt].Value2 != null)
                    {
                        cellDataList.Add(range.Cells[rCnt, cCnt].Value2.ToString());
                    }
                }
            }

            CloseExcel();
            return cellDataList;
        }

        public List<string> GetMultipleCells(int sheetİndex, string startCell, string endCell)
        {
            List<string> cellDataList = new List<string>();

            OpenExcel();
            Worksheet worksheet = workbook.Worksheets.get_Item(sheetİndex);

            range = worksheet.UsedRange;
            Range multipleCells = xlApp.get_Range(startCell, endCell);
            foreach (var item in multipleCells.Value2)
            {
                if (item != null)
                {
                    cellDataList.Add(item);
                }
            }
            CloseExcel();
            return cellDataList;
        }
    }
}
