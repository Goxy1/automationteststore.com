using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class HomePage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public HomePage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Lokatori
        By loginOrRegisterLink = By.LinkText("Login or register");
        By contactUsLink = By.LinkText("Contact Us");
        By addToCartButton = By.XPath("//a[@data-id='88']");
        By addToCartButton1 = By.XPath("//a[@data-id='66']");
        By cartButton = By.XPath("//ul[@class='nav topcart pull-left']/li[@class='dropdown hover']/a");
        By productLink = By.XPath("//a[@title='ck one Summer 3.4 oz']");
        By currencyDropdown = By.XPath("//ul[@class='nav language pull-left']/li[@class='dropdown hover']");
        By currencyEuro = By.XPath("//li/a[contains(., '€ Euro')]");
        By currencyPound = By.XPath("//li/a[contains(., '£ Pound Sterling')]");
        By searchField = By.Id("filter_keyword");
        By searchButtonField = By.XPath("//i[@class='fa fa-search']");


        /// <summary>
        /// Metoda koja klikce na currency dropdown menu 
        /// </summary>
        private void ClickCurrencyDropdownMenu()
        {
            ClickOnElement(currencyDropdown);
        }

        /// <summary>
        /// Metoda koja klikce na euro currency
        /// </summary>
        private void ClickCurrencyEuro()
        {
            ClickOnElement(currencyEuro);
        }

        /// <summary>
        /// Metoda koja klikce na pound currency
        /// </summary>
        private void ClickCurrencyPound()
        {
            ClickOnElement(currencyPound);
        }

        /// <summary>
        /// Metoda koja upisuje naziv proizvoda u searchBox
        /// </summary>
        /// <param name="searchText">searchText</param>
        private void EnterInSearchBox(string searchText)
        {
            WriteTextToElement(searchField, searchText);
        }

        /// <summary>
        /// Metoda koja klikce dugme search 
        /// </summary>
        private void ClickSearchButton()
        {
            ClickOnElement(searchButtonField);
        }


        /// <summary>
        /// Metoda koja klikne na add to cart dugme za odredjeni proizvod 
        /// </summary>
        public void ClickOnAddToCartButton()
        {
            ClickOnElement(addToCartButton);
        }

        /// <summary>
        /// Metoda koja klikce na cart dugme kako bi nas prebacila na cart stranicu 
        /// </summary>
        public void ClickCartButton()
        {
            ClickOnElement(cartButton);
        }

        /// <summary>
        /// Metoda koja klikne prvo na add to cart pa nakon toga klikce na ulazak u cart 
        /// </summary>
        public void AddProductToCart()
        {
            ClickOnAddToCartButton();
            ClickCartButton();
        }

        /// <summary>
        /// Metoda koja vrsi klik na login or register link
        /// </summary>
        public void ClickLoginOrRegisterLink()
        {
            ClickOnElement(loginOrRegisterLink);
        }

        /// <summary>
        /// Metoda koja klikce na contact us u futeru 
        /// </summary>
        public void ClickContactUsLink()
        {
            ClickOnElement(contactUsLink);
        }

        /// <summary>
        /// Metoda koja klikce na naziv proizvoda
        /// </summary>
        public void ClickOnProductLink()
        {
            ClickOnElement(productLink);
        }

        /// <summary>
        /// Metoda koja postavlja valutu na evro 
        /// </summary>
        public void SetCurrencyToEuro()
        {
            ClickCurrencyDropdownMenu();
            ClickCurrencyEuro();
        }

        /// <summary>
        /// Metoda koja postavlja valutu na pound
        /// </summary>
        public void SetCurrencyToPound()
        {
            ClickCurrencyDropdownMenu();
            ClickCurrencyPound();
        }

        /// <summary>
        /// Metoda koja dodaje dva proizvoda u korpu 
        /// </summary>
        public void AddTwoItemsToCart()
        {
            ClickOnAddToCartButton();
            ClickOnElement(addToCartButton1);
        }

        /// <summary>
        /// Metoda koja kuca naziv proizvoda u search boxu pa klikce button za pretragu 
        /// </summary>
        /// <param name="productName">productName</param>
        public void SearchForProduct(string productName)
        {
            EnterInSearchBox(productName);
            ClickSearchButton();
        }
    }
}
