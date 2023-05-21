using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class CartPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public CartPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CartPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Lokatori
        By cartTableRowsField = By.XPath("//div[@class='container-fluid cart-info product-list']/table[@class='table table-striped table-bordered']/tbody/tr");
        By removeFromCartButtonField = By.XPath("//td[@class='align_center']/a/i");
        By numberOfItemsSpanField = By.XPath("//a[@class='dropdown-toggle']/span[@class='label label-orange font14']");
        By checkoutButtonField = By.Id("cart_checkout1");
       
        //Quantity radi samo kada ima vise istih
        By quantityField = By.XPath("//td[@class='align_center']/div/input");
        By updateButtonField = By.Id("cart_update");
        By totalPriceSpanField = By.XPath("//a[@class='dropdown-toggle']/span[@class='cart_total']");
        By removeFirstItemFromCartButtonField = By.XPath("//tr[2]/td[@class='align_center']/a/i");



        public void UpdateItemQuantity(string currentItemCount)
        {
            int itemCount = int.Parse(currentItemCount);
            if (itemCount == 0)
                return;

            ClearTextFromElement(quantityField);
            WriteTextToElement(quantityField, (itemCount - 1).ToString());
            ClickOnElement(updateButtonField);
        }

        /// <summary>
        /// Vraca vrednost iz, u ovom slucaju, druge kolone iz tabele
        /// </summary>
        /// <returns>Naziv poslednjeg proizvoda u cart tabeli</returns>
        public string GetLastProductName()
        {
            return GetValueFromLastTableRow(cartTableRowsField, 1);
        }

        /// <summary>
        /// Metoda koja klikce remove from card
        /// </summary>
        public void ClickRemoveFromCartButton()
        {
            ClickOnElement(removeFromCartButtonField);
        }

        /// <summary>
        /// Metoda koja vraca broj proizvod 
        /// </summary>
        /// <returns>Broj proizvoda u korpi</returns>
        public string GetNumberOfItemsInCart()
        {
            return ReadTextFromElement(numberOfItemsSpanField);
        }

        /// <summary>
        /// Metoda koja klikce na checkout dugme
        /// </summary>
        public void ClickCheckoutButton()
        {
            ClickOnElement(checkoutButtonField);
        }

        /// <summary>
        /// Vraca ukupnu cenu sa sajta kao realni broj
        /// </summary>
        /// <returns>Ukupna cena korpe</returns>
        public float GetActualTotalPrice()
        {
            return GetFloatFromPriceText(totalPriceSpanField);
        }

        /// <summary>
        /// Sabira cene iz tabele i vraca je
        /// </summary>
        /// <returns>Zbir cena proizvoda</returns>
        public float GetExpectedTotalPrice()
        {
            return GetSumOfColumnValues(cartTableRowsField, 1, 6);
        }

        /// <summary>
        /// Brise iskljucivo samo prvi proizvod iz korpe
        /// </summary>
        public void RemoveFirstItemFromCart()
        {
            ClickOnElement(removeFirstItemFromCartButtonField);
        }
    }
}
