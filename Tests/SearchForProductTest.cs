using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class SearchForProductTest:BaseTest
    {
        [Test]
        public void SearchProduct()
        {
            //Pozivamo metodu i izvrsava se search
            Pages.HomePage.SearchForProduct(TestData.TestData.SearchProduct.productName);

            //Asertujemo da vidimo da li je nadjen proizvod
            Assert.AreEqual(TestData.TestData.SearchProduct.productName, Pages.ProductPage.GetProductName());
        }
    }
}
