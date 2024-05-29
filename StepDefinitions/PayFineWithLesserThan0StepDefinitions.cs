using System;
using TechTalk.SpecFlow;
using ASTProject.Pages;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class PayFineWithLesserThan0StepDefinitions
    {
        FineManagement page = new FineManagement();
        bool hasFine = false;
        int duesAdded = 0;
        [Given(@"User visits Fine Management Page again")]
        public void GivenUserVisitsFineManagementPageAgain()
        {
            Thread.Sleep(1000);
            page.VisitFineManagement();
        }

        [Given(@"User Checks Penalty again")]
        public void GivenUserChecksPenaltyAgain()
        {
            hasFine = !page.CheckFine();
        }

        [Given(@"User presses Pay penalty if it exists again")]
        public void GivenUserPressesPayPenaltyIfItExistsAgain()
        {
            if (hasFine)
            {
                page.PayFineButtonClick();
            }
        }

        [Given(@"User enters dues lesser than (.*)")]
        public void GivenUserEntersDuesLesserThan(int p0)
        {
            if (hasFine)
            {
                page.AddDues(0);
            }
        }

        [When(@"User presses Submit Dues again")]
        public void WhenUserPressesSubmitDuesAgain()
        {
            page.SubmitDues();
        }

        [Then(@"prompt the user about lesser than (.*) values")]
        public void ThenPromptTheUserAboutLesserThanValues(int p0)
        {
            Assert.AreEqual(true, page.VerifyError());
        }
    }
}
