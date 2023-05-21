using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class BasePage
    {
        // Driver
        public IWebDriver? driver;
        public WebDriverWait wait;


        /// <summary>
        /// Metoda koja ceka vidljivost elementa
        /// </summary>
        private void WaitElementVisibility(By elementBy)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementBy));
        }

        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        public void ClickOnElement(By element)
        {
            WaitElementVisibility(element);
            driver.FindElement(element).Click();
        }

        /// <summary>
        /// Metoda koja poziva common metodu ClearText da izbrise tekst iz nekog drugog elementa
        /// </summary>
        /// <param name="element">Element</param>
        protected void ClearTextFromElement(By element)
        {
            CommonMethods.ClearText(driver, element);
        }

        /// <summary>
        /// Vraca vrednost iz jedne kolone iz poslednje reda u tabeli
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="tableRows">By element koju u sebi sadrzi i table i tr tagove</param>
        /// <param name="indexOfColumnReturned">
        /// </param>
        /// <returns>Vrednost iz kolone</returns>
        public static string GetAnyValueFromLastTableRow(IWebDriver driver, By tableRows, int indexOfColumnReturned = 0)
        {
            string columnValue = string.Empty;

            try
            {
                // svi redovi
                ReadOnlyCollection<IWebElement> rows = driver.FindElements(tableRows);

                if (rows.Count > 0)
                {
                    // poslednji red
                    IWebElement lastRow = rows[rows.Count - 1];
                    // kolone iz poslednjeg reda
                    ReadOnlyCollection<IWebElement> columns = lastRow.FindElements(By.XPath("./td"));

                    if (indexOfColumnReturned >= 0 && indexOfColumnReturned < columns.Count)
                    {
                        columnValue = columns[indexOfColumnReturned].Text;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Invalid column index.");
                    }
                }
                else
                {
                    throw new NoSuchElementException("No table rows found.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return columnValue;
        }



        /// <summary>
        /// Poziva common metodu GetAnyValueFromLastTableRow koja vraca vrednost iz kolone iz poslednje reda prosledjene tabele
        /// </summary>
        /// <param name="tableRows">By element koji u sebi ima i table i sve tr tagove</param>
        /// <param name="columnReturned">
        ///     Koja kolona se vraca iz tabele (default 0):
        ///     0 - prva;
        ///     1 - druga;
        ///     itd.
        /// </param>
        /// <returns></returns>
        protected string GetValueFromLastTableRow(By tableRows, int columnReturned = 0)
        {
            return CommonMethods.GetAnyValueFromLastTableRow(driver, tableRows, columnReturned);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u polje
        /// </summary>
        public void WriteTextToElement(By element, string text)
        {
            WaitElementVisibility(element);
            driver.FindElement(element).SendKeys(text);
        }

        /// <summary>
        /// Metoda koja cita text iz elementa
        /// </summary>
        public string ReadTextFromElement(By element)
        {
            WaitElementVisibility(element);
            return driver.FindElement(element).Text;
        }

        /// <summary>
        /// Metoda koja cita text iz alert box-a
        /// </summary>
        public string ReadTextFromAlertBox()
        {
            Thread.Sleep(1000);
            return driver.SwitchTo().Alert().Text;
        }

        protected void ClickRandomOptionFromSelect(By selectElement, By optionsElement, int skip = 0)
        {
            CommonMethods.ClickRandomOption(driver, selectElement, optionsElement, skip);
        }

        /// <summary>
        /// Uzimamo url link sa trenutne stranice
        /// </summary>
        /// <returns></returns>
        protected string getUrlLink()
        {
            return CommonMethods.UrlLink(driver);
        }

        /// <summary>
        /// Vraca link sa trenutne stranice
        /// </summary>
        /// <returns>Url link sa trenutne stranice</returns>
        protected string GetUrlLink()
        {
            return CommonMethods.UrlLink(driver);
        }

        /// <summary>
        /// Metoda koja poziva RemoveFirstCharacterFromStringAndConvertToFloat iz common methodsa.Metoda uzima string i prebacuje ga u float
        /// </summary>
        /// <param name="priceElement">Element ciji je tekst neka cena</param>
        /// <returns>Realan broj bez $, €, £ i sl.</returns>
        protected float GetFloatFromPriceText(By priceElement)
        {
            return CommonMethods.RemoveFirstCharacterFromStringAndConvertToFloat(driver, priceElement);
        }


        /// <summary>
        /// Metoda koja poziva SumColumnValues da skloni prvi karakter iz stringa i onda da sabere ostale brojeve koji su ostali
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="tableRows">Redovi iz tabele</param>
        /// <param name="numberOfRowsToSkip">Broj koliko redova da se preskoci od pocetka (default je 0)</param>
        /// <param name="indexOfColumnsToSum">Broj kolone koja se sabira (default 1 zbog html-a jer index krece od 1)</param>
        /// <returns>Zbir vrednosti iz kolone</returns>
        protected float GetSumOfColumnValues(By tableRows, int numberOfRowsToSkip = 0, int indexOfColumnsToSum = 1)
        {
            return CommonMethods.SumColumnValues(driver, tableRows, numberOfRowsToSkip, indexOfColumnsToSum);
        }
    }

}
