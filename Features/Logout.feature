Feature: Logout

This feature logs user out of his/her current session and empties browser storage

@logout
Scenario: A user logs out of his/her session
	Given A user clicks on profile dropdown
	When The user clicks Logout
	Then Log the user out of the session
