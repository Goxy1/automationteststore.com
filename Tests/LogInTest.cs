using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class LogInTest:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //Pozivamo metodu da klikne na login ili register link(ceo button tj link ima ime login or register)
            Pages.HomePage.ClickLoginOrRegisterLink();
        }

        [Test]
        public void Login()
        {
            //Metoda koja popunjava forme i klikce dugme submit 
            Pages.LogInPage.LoginUser(TestData.TestData.Login.username, TestData.TestData.Login.password);

            //U varijablu url ubacujemo trenutni link kako bi ga kasnije uporedili - assertovali 
            string url = Pages.LogInPage.ReturnLoginSuccessLink();
            //Proverava da li smo dospeli na odgovarajucu stranicu
            Assert.AreEqual(AppConstants.Constants.UrlLinks.loginSuccessLink, url);
        }
    }
}
