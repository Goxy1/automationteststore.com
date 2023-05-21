using OpenQA.Selenium;
namespace AutomationFramework.Pages
{
    public class ContactUsPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public ContactUsPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ContactUsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Lokatori
        By firstNameField = By.Id("ContactUsFrm_first_name");
        By emailField = By.Id("ContactUsFrm_email");
        By enquiryField = By.Id("ContactUsFrm_enquiry");
        By submitButtonField = By.XPath("//button[@title='Submit']");


        /// <summary>
        /// Metoda koja unosi first name u polje
        /// </summary>
        /// <param name="firstName">First name</param>
        private void EnterFirstName(string firstName)
        {
            WriteTextToElement(firstNameField, firstName);
        }

        /// <summary>
        ///  Metoda koja unosi email u polje
        /// </summary>
        /// <param name="email">Email</param>
        private void EnterEmail(string email)
        {
            WriteTextToElement(emailField, email);
        }

        /// <summary>
        /// metoda koja unosi poruku
        /// </summary>
        /// <param name="enquiry">Poruka</param>
        private void EnterEnquiry(string enquiry)
        {
            WriteTextToElement(enquiryField, enquiry);
        }

        /// <summary>
        /// Metoda koja klikce na dugme
        /// </summary>
        private void ClickSubmitButton()
        {
            ClickOnElement(submitButtonField);
        }

        /// <summary>
        /// Vraca link trenutne stranice
        /// </summary>
        /// <returns></returns>
        public string GetSuccessUrlLink()
        {
            return GetUrlLink();
        }

        /// <summary>
        /// Metoda koja popunjava formu i klikce na dugme
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="email">Email</param>
        /// <param name="enquiry">Poruka</param>
        public void SendMessage(string firstName, string email, string enquiry)
        {
            EnterFirstName(firstName);
            EnterEmail(email);
            EnterEnquiry(enquiry);
            ClickSubmitButton();
        }

      
    }
}
