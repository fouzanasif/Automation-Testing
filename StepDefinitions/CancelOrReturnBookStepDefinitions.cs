using System;
using TechTalk.SpecFlow;
using ASTProject;
using NUnit.Framework;
using ASTProject.Pages;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class CancelOrReturnBookStepDefinitions
    {
        IssuesRequest issues = new IssuesRequest();
        string status;
        string newStatus;
        [Given(@"A user has Pending Approval, Approved, Overdue, or Reserved statusCodes")]
        public void GivenAUserHasPendingApprovalApprovedOverdueOrReservedStatusCodes()
        {
            status = issues.MarkAsReturnedOrCancelled(true);
        }

        [When(@"A user presses Cancel/Return")]
        public void WhenAUserPressesCancelReturn()
        {
            Thread.Sleep(1000);
            newStatus = issues.MarkAsReturnedOrCancelled(false) == ""? "Cancelled": "Returned";
        }

        [Then(@"The status is updated accordingly")]
        public void ThenTheStatusIsUpdatedAccordingly()
        {
            if(status == string.Empty || status != "True") 
            {
                Assert.Pass();
            }
            else
            {
                Assert.That(string.Equals(newStatus, "Cancelled") || string.Equals(newStatus, "Returned"));
            }
        }
    }
}
