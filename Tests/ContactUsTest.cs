using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ContactUsTest:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //klik na contact us link u footeru
            Pages.HomePage.ClickContactUsLink();
        }
        [Test]
        //Metoda koja popunjava formu i klikce na dugme submit
        public void ContactUs()
        {
          
            Pages.ContactUsPage.SendMessage(
                TestData.TestData.ContactUs.firstName,
                TestData.TestData.ContactUs.email,
                TestData.TestData.ContactUs.message
            );

            //Cuva se trenutni link za assert
            string url = Pages.ContactUsPage.GetSuccessUrlLink();
            //Uporedjivanje da li smo na dobroj stranici
            Assert.AreEqual(AppConstants.Constants.UrlLinks.contactUsSuccessLink, url);
        }
    }
}
