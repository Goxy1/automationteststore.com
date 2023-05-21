using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class AccountPage : BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public AccountPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Lokatori
        By homeButtonField = By.XPath("//ul[@class='nav-pills categorymenu']/li/a[contains(., 'Home')]");
        By guestCheckoutRadioField = By.Id("accountFrm_accountguest");
        By continueButtonField = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja klikce na guest checkout rb
        /// </summary>
        private void ClickGuestCheckoutRadioButton()
        {
            ClickOnElement(guestCheckoutRadioField);
        }

        /// <summary>
        /// Metoda koja klikce na continue button 
        /// </summary>
        private void ClickContinue()
        {
            ClickOnElement(continueButtonField);
        }


        /// <summary>
        /// Klik na home button
        /// </summary>
        public void ClickHomeButton()
        {
            ClickOnElement(homeButtonField);
        }

        /// <summary>
        /// Klik na guest checkout radio button pa na continue button
        /// </summary>
        public void CheckoutAsGuest()
        {
            ClickGuestCheckoutRadioButton();
            ClickContinue();
        }
    }
}
