using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class ValidateCartPriceTest:BaseTest
    {
        [Test]
        public void ValidateCartPrice()
        {
            
            Pages.HomePage.AddTwoItemsToCart();
            Pages.HomePage.ClickCartButton();

            //cena koja pise na sajtu i cena koja je dobijena sabiranjem cena proizvoda
            float actualTotalPrice = Pages.CartPage.GetActualTotalPrice();
            //ocekivana cena
            float expectedTotalPrice = Pages.CartPage.GetExpectedTotalPrice();
            //Proveravamo da li su iste cene
            Assert.AreEqual(expectedTotalPrice, actualTotalPrice);

            //brisemo prvi proizvod iz korpe
            Pages.CartPage.RemoveFirstItemFromCart();
            //cena koja pise na sajtu i cena koja je dobijena sabiranjem cena proizvoda
            float newActualTotalPrice = Pages.CartPage.GetActualTotalPrice();
            //nova cena koju ocekujemo
            float newExpectedTotalPrice = Pages.CartPage.GetExpectedTotalPrice();
            //Proveravamo da li su cene iste
            Assert.AreEqual(newExpectedTotalPrice, newActualTotalPrice);
        }
    }
}
