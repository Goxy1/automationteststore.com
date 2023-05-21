using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class CheckOutPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public CheckOutPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CheckOutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Lokatori
        By confirmOrderButtonField = By.Id("checkout_btn");
        By firstNameField = By.Id("guestFrm_firstname");
        By lastNameField = By.Id("guestFrm_lastname");
        By emailField = By.Id("guestFrm_email");
        By addressField = By.Id("guestFrm_address_1");
        By cityField = By.Id("guestFrm_city");
        By regionStateSelectField = By.Id("guestFrm_zone_id");
        By regionStateSelectOptionsField = By.XPath("//select[@id='guestFrm_zone_id']/option");
        By zipField = By.Id("guestFrm_postcode");
        By countrySelectField = By.Id("guestFrm_country_id");
        By countrySelectOptionsField = By.XPath("//select[@id='guestFrm_country_id']/option");
        By continueButtonField = By.XPath("//button[@title='Continue']");


        /// <summary>
        /// Metoda koja upisuje first name u polje
        /// </summary>
        /// <param name="firstName">First name</param>
        private void EnterFirstName(string firstName)
        {
            WriteTextToElement(firstNameField, firstName);
        }

        /// <summary>
        /// Metoda koja upisuje last name u polje
        /// </summary>
        /// <param name="lastName">Last name</param>
        private void EnterLastName(string lastName)
        {
            WriteTextToElement(lastNameField, lastName);
        }

        /// <summary>
        /// Metoda koja upisuje email u polje
        /// </summary>
        /// <param name="email">E-mail</param>
        private void EnterEmail(string email)
        {
            WriteTextToElement(emailField, email);
        }

        /// <summary>
        /// Metoda koja upisuje adresu u polje
        /// </summary>
        /// <param name="address">Address</param>
        private void EnterAddress(string address)
        {
            WriteTextToElement(addressField, address);
        }

        /// <summary>
        /// Metoda koja upisuje ime grada u polje
        /// </summary>
        /// <param name="city">City</param>
        private void EnterCity(string city)
        {
            WriteTextToElement(cityField, city);
        }

        /// <summary>
        /// Metoda koja bira random region iz option selecta 
        /// </summary>
        private void ChooseRandomRegion()
        {
            ClickRandomOptionFromSelect(regionStateSelectField, regionStateSelectOptionsField, 1);
        }

        /// <summary>
        /// Metoda koja upisuje zip u polje
        /// </summary>
        /// <param name="zipCode">Zip</param>
        private void EnterZipCode(string zipCode)
        {
            WriteTextToElement(zipField, zipCode);
        }

        /// <summary>
        /// Bira random country option iz selecta
        /// </summary>
        private void ChooseRandomCountry()
        {
            ClickRandomOptionFromSelect(countrySelectField, countrySelectOptionsField, 1);
        }

        /// <summary>
        /// Metoda koja vrsi klik na dugme
        /// </summary>
        private void ClickContinueButton()
        {
            ClickOnElement(continueButtonField);
        }


        /// <summary>
        /// Metoda koja klikce confirm order dugme
        /// </summary>
        public void ClickConfirmOrderButton()
        {
            ClickOnElement(confirmOrderButtonField);
        }

        /// <summary>
        /// Metoda koja vraca url trenutne stranice
        /// </summary>
        /// <returns>Url stranice</returns>
        public string GetSuccessUrl()
        {
            //thread sleep jer uhvati link od prosle stranice
            Thread.Sleep(500);
            return GetUrlLink();
        }

        /// <summary>
        /// Metoda koja popunjava formu i klikce na continue
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="email">E-mail</param>
        /// <param name="address">Address</param>
        /// <param name="city">City</param>
        /// <param name="zip">Zip</param>
        public void FillCheckoutForm(string firstName, string lastName, string email, string address, string city, string zip)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterAddress(address);
            EnterCity(city);
            ChooseRandomCountry();

            Thread.Sleep(1000);
            ChooseRandomRegion();
            
            Thread.Sleep(1000);
            EnterZipCode(zip);
            ClickContinueButton();
        }  
    }
}
