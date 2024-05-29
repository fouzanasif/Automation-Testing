using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {
        Login login = new Login();

        [Given(@"A user clicks on profile dropdown")]
        public void GivenAUserClicksOnProfileDropdown()
        {
            Thread.Sleep(1000);
            login.LogoutDropdown();
        }

        [When(@"The user clicks Logout")]
        public void WhenTheUserClicksLogout()
        {
            login.Logout();
        }

        [Then(@"Log the user out of the session")]
        public void ThenLogTheUserOutOfTheSession()
        {
            Assert.AreEqual(true, login.LogoutVerification());
        }
    }
}
