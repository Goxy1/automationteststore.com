using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.Utils
{
    public class CommonMethods
    {
        public static WebDriverWait? wait;


        /// <summary>
        /// Metoda koja ceka vidljivost elementa
        /// </summary>
        private static void WaitElementVisibility(IWebDriver driver, By element)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }

        /// <summary>
        /// Metoda koja kreira jedinstvenog korisnika, kreirajuci random broj
        /// kao sufix na "Random User" string
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomUsername(string randomName)
        {
            Random random = new Random();
            int randomNumber = random.Next(20, 9999);
            string username = randomName + randomNumber;
            return username;
        }

        /// <summary>
        /// Metoda koja ce kliknuti bilo koju opciju iz selecta
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="selectElement">Select</param>
        /// <param name="optionsElement">Options</param>
        /// <param name="skip">Koliko clanova sa pocetka se preskace</param>
        public static void ClickRandomOption(IWebDriver driver, By selectElement, By optionsElement, int skip = 0)
        {
            List<string> options = GetAllOptions(driver, optionsElement);

            SelectElement select = new SelectElement(driver.FindElement(selectElement));

            select.SelectByText(GetRandomItemFromList(options, skip));
        }


        /// <summary>
        /// Metoda koja vraca random string iz liste
        /// </summary>
        /// <param name="list">Lista</param>
        /// <param name="skip">Koliko clanova sa pocetka se preskace</param>
        /// <returns>Random string iz liste</returns>
        public static string GetRandomItemFromList(List<string> list, int skip = 0)
        {
            Random random = new Random();
            return list[random.Next(skip, list.Count - 1)];
        }

        /// <summary>
        /// Vraca tekst iz svih option elemenata iz nekog selecta
        /// </summary>
        /// <param name="driver">driver</param>
        /// <returns></returns>
        private static List<string> GetAllOptions(IWebDriver driver, By element)
        {
            List<string> options = new List<string>();

            try
            {
                ReadOnlyCollection<IWebElement> allOptions = driver.FindElements(element);

                foreach (IWebElement option in allOptions)
                {
                    options.Add(option.Text);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return options;
        }


        /// <summary>
        /// Metoda koja vraca url stranice
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static string UrlLink(IWebDriver driver)
        {
            return driver.Url;
        }

        /// <summary>
        /// Metoda koja cisti tekst iz elementa
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        public static void ClearText(IWebDriver driver, By element)
        {
            WaitElementVisibility(driver, element);
            driver.FindElement(element).Clear();
        }

        /// <summary>
        /// Metoda koja pravi random prvi deo mejla a ostatak se povezuje sa its.edu.rs
        /// </summary>
        /// <param name="baseMail">Osnovni deo email-a</param>
        /// <returns>Random email</returns>
        public static string GenerateRandomEmail(string baseMail)
        {
            Random random = new Random();
            return baseMail + random.Next(1000, 9999) + "@its.edu.rs";
        }

        public static string GetAnyValueFromLastTableRow(IWebDriver driver, By tableRows, int indexOfColumnReturned = 0)
        {
            try
            {
                // svi redovi
                ReadOnlyCollection<IWebElement> rows = driver.FindElements(tableRows);

                if (rows.Count > 0)
                {
                    // poslednji red
                    IWebElement lastRow = rows[^1];
                    // kolona iz poslednjeg reda
                    ReadOnlyCollection<IWebElement> columns = lastRow.FindElements(By.TagName("td"));

                    if (indexOfColumnReturned >= 0 && indexOfColumnReturned < columns.Count)
                    {
                        return columns[indexOfColumnReturned].Text;
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
        }


        /// <summary>
        /// Metoda koja sklanja prvi karakter iz stringa i prebacuje ga u broj tipa float
        /// </summary>
        /// <param name="element">Element iz kog se vadi tekst</param>
        /// <returns>Realan broj bez $, €, £ i sl.</returns>
        public static float RemoveFirstCharacterFromStringAndConvertToFloat(IWebDriver driver, By element)
        {
            string totalPriceFromElementText = ReadText(driver, element);

            return float.Parse(totalPriceFromElementText.Remove(0, 1));
        }


        /// <summary>
        /// Metoda koja cita tekst iz elementa
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        /// <returns></returns>
        public static string ReadText(IWebDriver driver, By element)
        {
            WaitElementVisibility(driver, element);
            return driver.FindElement(element).Text;
        }


        /// <summary>
        /// Sabira vrednosti iz kolona u tabeli
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="tableRows">Redovi iz tabele</param>
        /// <param name="numberOfRowsToSkip">Broj koliko redova da se preskoči od početka</param>
        /// <param name="indexOfColumnsToSum">Broj kolone koja se sabira</param>
        /// <returns>Zbir vrednosti iz kolone</returns>
        public static float SumColumnValues(IWebDriver driver, By tableRows, int numberOfRowsToSkip, int indexOfColumnsToSum)
        {
            float sum = 0;

            try
            {
                ReadOnlyCollection<IWebElement> rows = driver.FindElements(tableRows);

                for (int i = numberOfRowsToSkip; i < rows.Count; i++)
                {
                    IWebElement column = rows[i].FindElements(By.TagName("td"))[indexOfColumnsToSum];
                
                    sum += float.Parse(column.Text.TrimStart('$'));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sum;
        }

    }
}
