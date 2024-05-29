using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Order(0)]
    [Binding]
    
    public class LoginStepDefinitions
    {
        Login page = new Login();

        [Given(@"User goes to URL")]
        public void GivenUserGoesToURL()
        {
            
        }

        [Given(@"User enters correct email")]
        public void GivenUserEntersCorrectEmail()
        {
            page.EnterEmail();
        }

        [Given(@"User enters correct password")]
        public void GivenUserEntersCorrectPassword()
        {
            page.EnterPassword();
        }

        [When(@"User presses login")]
        public void WhenUserPressesLogin()
        {
            page.ClickLogin();
        }

        [Then(@"User should see Catalog")]
        public void ThenUserShouldSeeCatalog()
        {
            Assert.AreEqual(true, page.VerifyLogin());
            Thread.Sleep(1000);
        }
    }
}
