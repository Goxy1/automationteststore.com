using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ForgotPasswordTest:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //klik na login or register link
            Pages.HomePage.ClickLoginOrRegisterLink();
            //klik na forgot your password link
            Pages.LogInPage.ClickForgotPasswordLink();
        }
        [Test]
        public void ForgotPassword()
        {
            //popunjava formu i klikce na continue
            Pages.ForgotPasswordPage.ForgotYourPassword(TestData.TestData.ForgotPassword.username, TestData.TestData.ForgotPassword.email);

            //cuva poruku za uporedjivanje
            //string message = Pages.ForgotPasswordPage.GetTextFromSuccessMessage();
            //assert da li se poruke podudaraju
            //Assert.AreEqual(AppConstants.Constants.Messages.forgottenPasswordSuccessMessage, message);
        }
    }
}
