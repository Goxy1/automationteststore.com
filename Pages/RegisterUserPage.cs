using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class RegisterUserPage:BasePage
    {
        /// <summary>
        /// Kontstruktor bez parametra
        /// </summary>
        public RegisterUserPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrom
        /// </summary>
        /// <param name="webDriver">driver</param>
        public RegisterUserPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators

        By firstNameField = By.Id("AccountFrm_firstname");
        By lastNameField = By.Id("AccountFrm_lastname");
        By emailField = By.Id("AccountFrm_email");
        By addressField = By.Id("AccountFrm_address_1");
        By cityField = By.Id("AccountFrm_city");
        By regionStateDropdown = By.Id("AccountFrm_zone_id");
        By regionStateSelectOptions = By.XPath("//select[@id='AccountFrm_zone_id']/option");
        By zipField = By.Id("AccountFrm_postcode");
        By countryField = By.Id("AccountFrm_country_id");
        By countrySelectOptions = By.XPath("//select[@id='AccountFrm_country_id']/option");
        By loginNameField = By.Id("AccountFrm_loginname");
        By passwordField = By.Id("AccountFrm_password");
        By confirmPasswordField = By.Id("AccountFrm_confirm");
        By privacyPolicyField = By.Id("AccountFrm_agree");
        By registerContinueButton = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja upisuje firstName u polje
        /// </summary>
        /// <param name="firstName">First name</param>
        private void EnterFirstName(string firstName)
        {
            WriteTextToElement(firstNameField, firstName);
        }

        /// <summary>
        /// Metoda koja upisuje lastName u polje
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
        /// Metoda koja upisuje city u polje
        /// </summary>
        /// <param name="city">City</param>
        private void EnterCity(string city)
        {
            WriteTextToElement(cityField, city);
        }

        /// <summary>
        /// Bira random region option iz selecta
        /// </summary>
        private void ChooseRandomRegion()
        {
            ClickRandomOptionFromSelect(regionStateDropdown, regionStateSelectOptions, 1);
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
        /// Metoda koja bira random drzavu iz selecta 
        /// </summary>
        private void ChooseRandomCountry()
        {
            ClickRandomOptionFromSelect(countryField, countrySelectOptions, 1);
        }

        /// <summary>
        /// Metoda koja upisuje login username u polje 
        /// </summary>
        /// <param name="loginName">Login name</param>
        private void EnterLoginName(string loginName)
        {
            WriteTextToElement(loginNameField, loginName);
        }

        /// <summary>
        ///  Metoda koja upisuje password u polje 
        /// </summary>
        /// <param name="password">Password</param>
        private void EnterPassword(string password)
        {
            WriteTextToElement(passwordField, password);
        }

        /// <summary>
        /// Metoda koja upisuje potvrdjenu sifru u polje
        /// </summary>
        /// <param name="confirmPassword">Confirmed password</param>
        private void EnterConfirmedPassword(string confirmPassword)
        {
            WriteTextToElement(confirmPasswordField, confirmPassword);
        }

        /// <summary>
        /// Klik na odgovarajuci checkbox
        /// </summary>
        private void ClickPrivacyPolicyCheckBox()
        {
            ClickOnElement(privacyPolicyField);
        }

        /// <summary>
        /// Klik na continue dugme
        /// </summary>
        private void ClickContinueButton()
        {
            ClickOnElement(registerContinueButton);
        }


        /// <summary>
        /// Metoda koja popunjava celu formu
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="email">E-mail</param>
        /// <param name="address">Address</param>
        /// <param name="city">City</param>
        /// <param name="zip">Zip</param>
        /// <param name="loginName">Login name</param>
        /// <param name="password">Password</param>
        public void RegisterUser(string firstName, string lastName, string email, string address, string city, string zip, string loginName, string password)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterAddress(address);
            EnterCity(city);
            ChooseRandomCountry();
            Thread.Sleep(1000);
            ChooseRandomRegion();
     
           // Thread.Sleep(1000);
            EnterZipCode(zip);
            EnterLoginName(loginName);
            EnterPassword(password);
            EnterConfirmedPassword(password);
            ClickPrivacyPolicyCheckBox();
            ClickContinueButton();
        }

        public string ReturnRegisterSuccessUrl()
        {
            return getUrlLink();
        }

    }
}
