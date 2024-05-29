using ASTProject.Pages;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ASTProject.StepDefinitions
{
    [Binding]
    public class PayFineStepDefinitions
    {
        FineManagement page = new FineManagement();
        bool hasFine = false;
        int duesAdded = 0;
        int duesPending = 0;
        [Given(@"User visits Fine Management Page")]
        public void GivenUserVisitsFineManagementPage()
        {
            Thread.Sleep(1000);
            page.VisitFineManagement();
        }

        [Given(@"User Checks Penalty")]
        public void GivenUserChecksPenalty()
        {
            hasFine = !page.CheckFine();
        }

        [Given(@"User presses Pay penalty if it exists")]
        public void GivenUserPressesPayPenaltyIfItExists()
        {
            if(hasFine)
            {
                page.PayFineButtonClick();
            }
        }

        [Given(@"User enters dues to pay within range")]
        public void GivenUserEntersDuesToPayWithinRange()
        {
            if (hasFine)
            {
                duesAdded = page.AddDues();
            }
        }

        [When(@"User presses Submit Dues")]
        public void WhenUserPressesSubmitDues()
        {
            if (hasFine)
            {
                duesPending = page.TotalDues();
                page.SubmitDues();
            }
        }

        [Then(@"Check if penalty left was expected")]
        public void ThenCheckIfPenaltyLeftWasExpected()
        {
            Assert.AreEqual(true, page.VerifyPenalty(duesPending, duesAdded));
        }
    }
}
