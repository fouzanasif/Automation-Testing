using ASTProject.Pages;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class RightDateIssuesRequestStepDefinitions: SeleniumSetup
    {
        IssuesRequest issues = new IssuesRequest();

        [Given(@"User clicks on correct issue book (.*)")]
        public void GivenUserClicksOnCorrectIssueBook(int p0)
        {
            p0 = 3;
            issues.ClickIssue(p0);
        }

        [Given(@"User enters date within a month")]
        public void GivenUserEntersDateWithinAMonth()
        {
            string date = "05/21/2024";
            issues.EnterDate(date);
        }

        [When(@"User clicks Request Issue")]
        public void WhenUserClicksRequestIssue()
        {
            issues.ClickRequestIssue();
        }

        [Then(@"Validate If Issue is available in table")]
        public void ThenValidateIfIssueIsAvailableInTable()
        {
            Assert.AreEqual(true, issues.VerifyEntryInTable());
        }
    }
}
