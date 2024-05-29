using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Order(1)]
    [Binding]
    
    public class SignupStepDefinitions : SeleniumSetup
    {
        Login login;
        Signup signup;
        int sleepTime = 1000;

        [Given(@"User goes to signup URL")]
        public void GivenUserGoesToSignupURL()
        {
            login = new Login(json["Signup"]);
            login.GetDriverInstance();
            login.OpenBrowser();

            Thread.Sleep(sleepTime);
            login.ClickSignup();

            
        }

        [Given(@"User enters name in correct format")]
        public void GivenUserEntersNameInCorrectFormat()
        {
            signup = new Signup();
            signup.AddName();
        }

        [Given(@"User enters email in correct format")]
        public void GivenUserEntersEmailInCorrectFormat()
        {
            signup.AddEmail();
        }

        [Given(@"User enters password in correct format")]
        public void GivenUserEntersPasswordInCorrectFormat()
        {
            signup.AddPassword();
        }

        [Given(@"User enters membership type")]
        public void GivenUserEntersMembershipType()
        {
            signup.AddMembership();
        }

        [Given(@"User enters subscription period")]
        public void GivenUserEntersSubscriptionPeriod()
        {
            signup.AddSubPeriod();
        }

        [Given(@"User presses signup")]
        public void GivenUserPressesSignup()
        {
            signup.ClickSignup();
        }

        [Given(@"User enters login email")]
        public void GivenUserEntersLoginEmail()
        {
            login.EnterEmail();
        }

        [Given(@"User enters login password")]
        public void GivenUserEntersLoginPassword()
        {
            login.EnterPassword();
        }

        [When(@"User clicks login")]
        public void WhenUserClicksLogin()
        {
            login.ClickLogin();
        }

        [Then(@"User should have his/her name")]
        public void ThenUserShouldHaveHisHerName()
        {
            Assert.AreEqual(true, signup.VerifySignup());
            Thread.Sleep(sleepTime);
        }
    }
}
