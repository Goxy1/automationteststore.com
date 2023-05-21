using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
