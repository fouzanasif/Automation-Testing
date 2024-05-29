Feature: ZZZZ-PayFineWithLesserThan0Value

In this feature, we'll check functionality for what if user enters dues < 0

@finepayment
Scenario: User has penalty to pay for overdue books
	Given User visits Fine Management Page
	And User Checks Penalty
	And User presses Pay penalty if it exists
	And User enters dues to pay within range
	When User presses Submit Dues
	Then Check if penalty left was expected
