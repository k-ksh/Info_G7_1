using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumProject.Helpers.Tables
{
    public class SimpleTable
    {
        private IWebDriver _driver;
        private By _tableHeaderLocators;
        private By _tableRowLocators;

        public List<IWebElement> HeadersElements => _driver.FindElements(_tableHeaderLocators).ToList();
        public List<string> HeadersNames => HeadersElements.Select(el => el.GetAttribute("textContent")).ToList();
        public List<IWebElement> RowsElement => _driver.FindElements(_tableRowLocators).ToList();

        public SimpleTable(IWebDriver driver, By tableHeaderLocators, By tableRowLocators)
        {
            _driver = driver;
            _tableHeaderLocators = tableHeaderLocators;
            _tableRowLocators = tableRowLocators;
        }

        //private int GetColumnIndexByName(string columnName)
        //{
        //    return HeadersNames.FindIndex(header => header == columnName);
        //}

        private List<IWebElement> GetColumnCells(IWebElement column)
        {
            return column.FindElements(By.CssSelector("tr")).ToList();
        }

        private List<IWebElement> GetRowCells(IWebElement row)
        {
            return row.FindElements(By.CssSelector("td")).ToList();
        }

        public IWebElement GetCellByColumnNumberAndRowNumber(int columnNumber, int rowNumber)
        {
            var cells = GetRowCells(RowsElement[rowNumber - 1]);

            if (columnNumber >= 1 && columnNumber <= cells.Count)
            {
                return cells[columnNumber - 1];
            }
            else
            {
        
                throw new ArgumentOutOfRangeException(nameof(columnNumber), "Column number is out of range.");
            }
        }


        public string GetTextInCell(int columnNumber, int rowNumber)
        {
            var cell = GetCellByColumnNumberAndRowNumber(columnNumber, rowNumber);
            return cell.GetAttribute("textContent");
        }

        public int GetRowCount()
        {

            var rowElements = RowsElement;

            return rowElements.Count;
        }
        public int GetColumnCount()
        {

            var columnElements = HeadersElements;

            return columnElements.Count;
        }

    }
}
