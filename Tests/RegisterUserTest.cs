using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RegisterUserTest:BaseTest
    {
        //Pozivamo funkciju preko CommonMethods-a da izvuce random username
        string username = CommonMethods.GenerateRandomUsername(TestData.TestData.Register.username);

        string email = CommonMethods.GenerateRandomEmail(TestData.TestData.Register.email);

        [SetUp]
        public void Setup()
        {
            //Pozivamo metodu iz HomePage-a da klikne na log in ili register link
            Pages.HomePage.ClickLoginOrRegisterLink();
            //Klik na continue dugme kod registracije
            Pages.LogInPage.ClickOnRegisterContinueButton();
        }

        [Test]
        public void Register()
        {
            //Popunjavanje cele forme i klik na continue dugme
            Pages.RegisterUserPage.RegisterUser(
                TestData.TestData.Register.firstName,
                TestData.TestData.Register.lastName,
                email,
                TestData.TestData.Register.address,
                TestData.TestData.Register.city,
                TestData.TestData.Register.zip,
                username,
                TestData.TestData.Register.password
            );

            //U varijablu url pamtimo trenutni link kako bi ga kasnije asertovali-proverili sa odgovarajucim
            string url = Pages.RegisterUserPage.ReturnRegisterSuccessUrl();
            //Proveravamo zabelezeni url link sa ispravnim linkom
            Assert.AreEqual(AppConstants.Constants.UrlLinks.registrationSuccessLink, url);
        }
    }
}
