using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AutomationFramework.Utils
{
    public class CommonMethods
    {
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
        /// Metoda koja pravi random prvi deo mejla a ostatak se povezuje sa its.edu.rs
        /// </summary>
        /// <param name="baseMail">Osnovni deo email-a</param>
        /// <returns>Random email</returns>
        public static string GenerateRandomEmail(string baseMail)
        {
            Random random = new Random();
            return baseMail + random.Next(1000, 9999) + "@its.edu.rs";
        }
    }
}
