using ASTProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class WrongDateIssuesRequestStepDefinitions: SeleniumSetup
    {
        IssuesRequest issues = new IssuesRequest();
        [Given(@"User clicks on another issue book (.*)")]
        public void GivenUserClicksOnAnotherIssueBook(int p0)
        {
            p0 = 2;
            issues.ClickIssue(p0);
        }

        [When(@"User enters date greater than a month")]
        public void WhenUserEntersDateGreaterThanAMonth()
        {
            string date = "07/21/2024";
            issues.EnterDate(date);
        }

        [Then(@"Generate prompt for Due Date > (.*) month from today")]
        public void ThenGeneratePromptForDueDateMonthFromToday(int p0)
        {
            Assert.AreEqual(true, issues.VerifyGreaterThanMonthError());
            issues.GetDriverInstance().Navigate().GoToUrl(@$"{json["URL"]}/catalog/view");
        }
    }
}
