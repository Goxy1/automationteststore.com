using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class ProductPage:BasePage
    {
        /// <summary>
        /// Podrazumevani konstruktor
        /// </summary>
        public ProductPage()
        {
            driver = null;
        }
        /// <summary>
        /// Parametrizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ProductPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        //Lokatori
        By addToCartButtonField = By.XPath("//a[contains(., 'Add to Cart')]");
        By productNameField = By.XPath("//h1");


        /// <summary>
        /// Metoda koja klikce na add to cart dugme
        /// </summary>
        public void ClickAddToCartButton()
        {
            ClickOnElement(addToCartButtonField);
        }

        /// <summary>
        /// Metoda koja vraca naziv nadjenog proizvoda
        /// </summary>
        /// <returns>Naziv proizvoda</returns>
        public string GetProductName()
        {
            return ReadTextFromElement(productNameField);
        }
    }
}
