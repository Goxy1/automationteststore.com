using OpenQA.Selenium;
namespace AutomationFramework.Pages
{
    public class ForgotLoginPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public ForgotLoginPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ForgotLoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By lastNameField = By.Id("forgottenFrm_lastname");
        By emailField = By.Id("forgottenFrm_email");
        By continueButtonField = By.XPath("//button[@title='Continue']");
        By successMsgField = By.XPath("//div[@class='alert alert-success']");


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
        /// <param name="email">Email</param>
        private void EnterEmail(string email)
        {
            WriteTextToElement(emailField, email);
        }

        /// <summary>
        /// Metoda koja klikce na continue button
        /// </summary>
        private void ClickContinueButton()
        {
            ClickOnElement(continueButtonField);
        }


        /// <summary>
        /// Metoda koja popunjava formu i klikce na dugme continue
        /// </summary>
        /// <param name="lastName">Last name</param>
        /// <param name="email">Email</param>
        public void ForgotYourLogin(string lastName, string email)
        {
            EnterLastName(lastName);
            EnterEmail(email);
            ClickContinueButton();
        }

        /// <summary>
        /// Metoda koja izvlaci tekst iz poruke da bi ga asertovala
        /// </summary>
        /// <returns>Tekst iz success poruke</returns>
        public string GetTextFromSuccessMessage()
        {
            return ReadTextFromElement(successMsgField);
        }
    }
}
