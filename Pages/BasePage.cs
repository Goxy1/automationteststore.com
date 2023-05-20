using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
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
    }
    
}
