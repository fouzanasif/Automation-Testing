Feature: ZZZZ-PayFine

This feature defines on how the fine is paid by a user

@finepayment
Scenario: User has penalty to pay for overdue books
	Given User visits Fine Management Page again
	And User Checks Penalty again
	And User presses Pay penalty if it exists again
	And User enters dues lesser than 0
	When User presses Submit Dues again
	Then prompt the user about lesser than 0 values
