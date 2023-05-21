using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class RegisterPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public RegisterPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public RegisterPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Lokatori
        By firstNameField = By.Id("AccountFrm_firstname");
        By lastNameField = By.Id("AccountFrm_lastname");
        By emailField = By.Id("AccountFrm_email");
        By addressField = By.Id("AccountFrm_address_1");
        By cityField = By.Id("AccountFrm_city");
        By regionStateSelectField = By.Id("AccountFrm_zone_id");
        By regionStateSelectOptionsField = By.XPath("//select[@id='AccountFrm_zone_id']/option");
        By zipField = By.Id("AccountFrm_postcode");
        By countrySelectField = By.Id("AccountFrm_country_id");
        By countrySelectOptionsField = By.XPath("//select[@id='AccountFrm_country_id']/option");
        By loginNameField = By.Id("AccountFrm_loginname");
        By passwordField = By.Id("AccountFrm_password");
        By confirmPasswordField = By.Id("AccountFrm_confirm");
        By privacyPolicyCheckBoxField = By.Id("AccountFrm_agree");
        By registerContinueButtonField = By.XPath("//button[@title='Continue']");


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
        /// Metoda koja upisuje email u odgovarajuci polje
        /// </summary>
        /// <param name="email">E-mail</param>
        private void EnterEmail(string email)
        {
            WriteTextToElement(emailField, email);
        }

        /// <summary>
        /// Metoda koja upisuje adresu u odgovarajuce polje
        /// </summary>
        /// <param name="address">Address</param>
        private void EnterAddress(string address)
        {
            WriteTextToElement(addressField, address);
        }

        /// <summary>
        /// MEtoda koja upisuje grad u odgovarajuce polje
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
        /// Metoda koja upisuje zipCode u odgovarajuce polje
        /// </summary>
        /// <param name="zipCode">Zip</param>
        private void EnterZipCode(string zipCode)
        {
            WriteTextToElement(zipField, zipCode);
        }

        /// <summary>
        /// Metoda koja bira random country option iz selecta 
        /// </summary>
        private void ChooseRandomCountry()
        {
            ClickRandomOptionFromSelect(countrySelectField, countrySelectOptionsField, 1);
        }

        /// <summary>
        /// Metoda koja upisuje login name u odgovarajuce polje
        /// </summary>
        /// <param name="loginName">Login name</param>
        private void EnterLoginName(string loginName)
        {
            WriteTextToElement(loginNameField, loginName);
        }

        /// <summary>
        /// Metoda koja upisuje password u odgovarajcue polje
        /// </summary>
        /// <param name="password">Password</param>
        private void EnterPassword(string password)
        {
            WriteTextToElement(passwordField, password);
        }

        /// <summary>
        /// Metoda koja upisuje confirmed password u odgovarajuce polje
        /// </summary>
        /// <param name="confirmPassword">Confirmed password</param>
        private void EnterConfirmedPassword(string confirmPassword)
        {
            WriteTextToElement(confirmPasswordField, confirmPassword);
        }

        /// <summary>
        /// Metoda koja klikce checkBox
        /// </summary>
        private void ClickPrivacyPolicyCheckBox()
        {
            ClickOnElement(privacyPolicyCheckBoxField);
        }

        /// <summary>
        /// Metoda koja klikce na continue dugme
        /// </summary>
        private void ClickContinueButton()
        {
            ClickOnElement(registerContinueButtonField);
        }


        /// <summary>
        /// Metoda koja popunjava formu,zatim klikce na checkbox pa na dugme continue
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
            Thread.Sleep(1000);
            EnterZipCode(zip);
            EnterLoginName(loginName);
            EnterPassword(password);
            EnterConfirmedPassword(password);
            ClickPrivacyPolicyCheckBox();
            ClickContinueButton();
        }

        /// <summary>
        /// Metoda koja vraca url link
        /// </summary>
        /// <returns>url link</returns>
        public string ReturnRegisterSuccessUrl()
        {
            return GetUrlLink();
        }
    }
}
