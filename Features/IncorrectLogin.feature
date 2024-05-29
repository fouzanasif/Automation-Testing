Feature: IncorrectLogin

A user enters an incorrect email or leaves the field empty

@incorrectEmail
Scenario: A user enters incorrect account credentials
	Given A user enters an email
	And A user enters an incorrect password
	When A User presses login
	Then Prompt Invalid Email or Password
