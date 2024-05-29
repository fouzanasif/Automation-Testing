using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class IncorrectLoginStepDefinitions
    {
        Login login = new Login();
        string alertText;

        [Given(@"A user enters an email")]
        public void GivenAUserEntersAnEmail()
        {
            login.EnterEmail("sbdfh@sfsg.com");
        }

        [Given(@"A user enters an incorrect password")]
        public void GivenAUserEntersAnIncorrectPassword()
        {
            login.EnterPassword();
        }

        [When(@"A User presses login")]
        public void WhenAUserPressesLogin()
        {
            login.ClickLogin();
        }

        [Then(@"Prompt Invalid Email or Password")]
        public void ThenPromptInvalidEmailOrPassword()
        {
            var driver = login.GetDriverInstance();
            Thread.Sleep(1000);
            IAlert alert = driver.SwitchTo().Alert();
            alertText = alert.Text;
            alert.Accept();
            Assert.AreEqual("Invalid email or password", alertText.Trim());
            login.CleanLogin();
            
        }
    }
}
