using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class LogInPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public LogInPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public LogInPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Lokatori
        By registerContinueButton = By.XPath("//button[@title='Continue']");
        By loginNameInput = By.Id("loginFrm_loginname");
        By passwordInput = By.Id("loginFrm_password");
        By loginButton = By.XPath("//button[@title='Login']");
        By forgotYourPasswordLink = By.LinkText("Forgot your password?");
        By forgotYourLoginLink = By.LinkText("Forgot your login?");


        /// <summary>
        /// Metoda koja popunjava loginName polje
        /// </summary>
        /// <param name="loginName">Login name</param>
        private void EnterLoginName(string loginName)
        {
            WriteTextToElement(loginNameInput, loginName);
        }

        /// <summary>
        /// Metoda koja popunjava password polje
        /// </summary>
        /// <param name="password">Password</param>
        private void EnterPassword(string password)
        {
            WriteTextToElement(passwordInput, password);
        }

        /// <summary>
        /// Metoda koja klikce login button
        /// </summary>
        private void ClickLoginButton()
        {
            ClickOnElement(loginButton);
        }


        /// <summary>
        /// Metoda koja popunjava formu i klikce na button
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public void LoginUser(string username, string password)
        {
            EnterLoginName(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        /// <summary>
        /// Metoda koja vrsi klik na continue dugme kako bi se otvorila stranica za registraciju
        /// </summary>
        public void ClickOnRegisterContinueButton()
        {
            ClickOnElement(registerContinueButton);
        }

        /// <summary>
        /// Vraca url da bi proverili da li je otisao na dobru stranicu
        /// </summary>
        /// <returns>Url trenutne stranice</returns>
        public string ReturnLoginSuccessLink()
        {
            return GetUrlLink();
        }

        /// <summary>
        /// Metoda koja klikce na forgot your password 
        /// </summary>
        public void ClickForgotPasswordLink()
        {
            ClickOnElement(forgotYourPasswordLink);
        }

        /// <summary>
        /// Metoda koja klikce na forgot your login
        /// </summary>
        public void ClickForgotLoginLink()
        {
            ClickOnElement(forgotYourLoginLink);
        }
    }
}
