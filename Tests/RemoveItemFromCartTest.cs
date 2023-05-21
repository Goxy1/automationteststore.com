using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RemoveItemFromCartTest:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //Prvo se desava klik na add to cart pa na cart dugme
            Pages.HomePage.AddProductToCart();
        }
        [Test]
        public void RemoveItemFromCart()
        {
            //klik na remove from cart dugme
            Pages.CartPage.ClickRemoveFromCartButton();

            //U varijablu smestamo broj proizvoda u korpi
            string numOfItems = Pages.CartPage.GetNumberOfItemsInCart();
            //Provera da li ima nula proizvoda u korpi
            Assert.AreEqual("0", numOfItems);
        }
    }
}
