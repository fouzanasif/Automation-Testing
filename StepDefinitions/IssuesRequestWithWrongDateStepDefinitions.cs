using ASTProject.Pages;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Order(2)]
    [Binding]
    
    public class IssuesRequestWithWrongDateStepDefinitions: SeleniumSetup
    {
        IssuesRequest issues = new IssuesRequest();

        [Given(@"User clicks on issue book (.*)")]
        public void GivenUserClicksOnIssueBook(int p0)
        {
            p0 = Int32.Parse(json["Book"].ToString());
            issues.ClickIssue(p0);
        }

        [When(@"User enters incorrect date")]
        public void WhenUserEntersIncorrectDate()
        {
            issues.EnterDate();
        }

        [Then(@"Generate prompt for Due Date < Current Date")]
        public void ThenGeneratePromptForDueDateCurrentDate()
        {
            Assert.AreEqual(true, issues.VerifyError());
            issues.GetDriverInstance().Navigate().GoToUrl(@$"{json["URL"]}/catalog/view");
        }
    }
}
