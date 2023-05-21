using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class PurchaseItemTest:BaseTest
    {
        [Test]
        public void PurchaseItemWithUSD()
        {
            
            Pages.HomePage.ClickLoginOrRegisterLink();
            Pages.LogInPage.LoginUser(TestData.TestData.Login.username, TestData.TestData.Login.password);
            Pages.AccountPage.ClickHomeButton();
            Pages.HomePage.AddProductToCart();
            Pages.CartPage.ClickCheckoutButton();
            Pages.CheckOutPage.ClickConfirmOrderButton();

            //cuva url trenutne stranice
           // string url = Pages.CheckOutPage.GetSuccessUrl();
            //provera da li smo na dobroj stranici
          //  Assert.AreEqual(AppConstants.Constants.UrlLinks.purchaseItemSuccessLink, url);
        }
        [Test]
        public void PurchaseItemWithEUR()
        {
            //Menjamo valutu u euro
            Pages.HomePage.SetCurrencyToEuro();          
            Pages.HomePage.ClickLoginOrRegisterLink();        
            Pages.LogInPage.LoginUser(TestData.TestData.Login.username, TestData.TestData.Login.password);         
            Pages.AccountPage.ClickHomeButton();       
            Pages.HomePage.AddProductToCart();
            Pages.CartPage.ClickCheckoutButton();
            Pages.CheckOutPage.ClickConfirmOrderButton();

            //cuva url trenutne stranice
           // string url = Pages.CheckOutPage.GetSuccessUrl();
            //provera da li smo na dobroj stranici
           // Assert.AreEqual(AppConstants.Constants.UrlLinks.purchaseItemSuccessLink, url);
        }
        [Test]
        public void GuestPurchaseItemWithGBP()
        {
            //menja se valuta u GBP
            Pages.HomePage.SetCurrencyToPound();

            Pages.HomePage.AddProductToCart();
            Pages.CartPage.ClickCheckoutButton();
            Pages.AccountPage.CheckoutAsGuest();
            Pages.CheckOutPage.FillCheckoutForm(
                TestData.TestData.CheckOut.firstName,
                TestData.TestData.CheckOut.lastName,
                TestData.TestData.CheckOut.email,
                TestData.TestData.CheckOut.address,
                TestData.TestData.CheckOut.city,
                TestData.TestData.CheckOut.zip
            );

            Pages.CheckOutPage.ClickConfirmOrderButton();

            //cuva url trenutne stranice
            string url = Pages.CheckOutPage.GetSuccessUrl();
            //provera da li smo na dobroj stranici
            Assert.AreEqual(AppConstants.Constants.UrlLinks.purchaseItemSuccessLink, url);
        }
    }
}
