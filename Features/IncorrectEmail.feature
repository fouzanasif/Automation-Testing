Feature: IncorrectEmail

A user enters an incorrect email or leaves the field empty

@incorrectEmail
Scenario: A user enters incorrect email
	Given A user goes to URL
	When user enters incorrect email
	Then prompt the user about incorrect or missing email
