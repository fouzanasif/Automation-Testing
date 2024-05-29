Feature: ZZZ-CancelOrReturnBook

In this feature, testing of user being able to cancel or return his/her book will be done

@cancelOrReturnBook
Scenario: A user can cancel or return their book
	Given A user has Pending Approval, Approved, Overdue, or Reserved statusCodes
	When A user presses Cancel/Return
	Then The status is updated accordingly
