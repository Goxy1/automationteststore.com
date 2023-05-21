using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class AddItemToCartTest:BaseTest
    {
        [Test]
        public void AddItemToCartFromHomePage()
        {
            //klik na add to cart pa na cart dugme
            Pages.HomePage.AddProductToCart();

            //cuva naziv dodatog proizvoda
            string addedProductName = Pages.CartPage.GetLastProductName();
            //proverava da li se proizvodi podudaraju
            Assert.AreEqual(TestData.TestData.AddToCart.productName, addedProductName);
        }
        [Test]
        public void AddItemToCartFromProductPage()
        {
            //klik na naziv proizvoda
            Pages.HomePage.ClickOnProductLink();
            //klik na add to cart dugme
            Pages.ProductPage.ClickAddToCartButton();

            //cuva naziv dodatog proizvoda
            string addedProductName = Pages.CartPage.GetLastProductName();
            //proverava da li se proizvodi podudaraju
            Assert.AreEqual(TestData.TestData.AddToCart.productName, addedProductName);
        }
    }
}
