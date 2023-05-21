using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class ForgotPasswordPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public ForgotPasswordPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ForgotPasswordPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By loginNameField = By.Id("forgottenFrm_loginname");
        By emailField = By.Id("forgottenFrm_email");
        By continueButtonField = By.XPath("//button[@title='Continue']");
        By successMsgField = By.XPath("//div[@class='alert alert-success']");


        /// <summary>
        /// Metoda koja upisuje login name u polje
        /// </summary>
        /// <param name="loginName">Login name</param>
        private void EnterLoginName(string loginName)
        {
            WriteTextToElement(loginNameField, loginName);
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
        /// Metoda koja klikce na continue dugme
        /// </summary>
        private void ClickContinueButton()
        {
            ClickOnElement(continueButtonField);
        }


        /// <summary>
        /// Metoda koja popunjava formu i klikce na dugme continue
        /// </summary>
        /// <param name="loginName">Login name</param>
        /// <param name="email">Email</param>
        public void ForgotYourPassword(string loginName, string email)
        {
            EnterLoginName(loginName);
            EnterEmail(email);
            ClickContinueButton();
        }

        /// <summary>
        /// Metoda koja izvlaci tekst iz poruke da bi se kasnije asertovala
        /// </summary>
        /// <returns>Tekst iz success poruke</returns>
        public string GetTextFromSuccessMessage()
        {
            return ReadTextFromElement(successMsgField);
        }
    }
}
