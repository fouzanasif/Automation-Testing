using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class IncorrectEmailStepDefinitions
    {
        Login login = new Login();
        [Given(@"A user goes to URL")]
        public void GivenAUserGoesToURL()
        {
            login.GetDriverInstance();
            login.OpenBrowser();
        }

        [When(@"user enters incorrect email")]
        public void WhenUserEntersIncorrectEmail()
        {
            Thread.Sleep(1000);
            login.EnterEmail("dhwejdg");
        }

        [Then(@"prompt the user about incorrect or missing email")]
        public void ThenPromptTheUserAboutIncorrectOrMissingEmail()
        {
            Assert.AreEqual(true, login.InvalidEmail());
            Thread.Sleep(1000);
        }
    }
}
