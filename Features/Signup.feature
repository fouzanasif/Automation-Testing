Feature: Signup

User signs up and logs into his/her account

@signup
Scenario: User enters correct credentials to signup and then sign in to account
	Given User goes to signup URL
	And User enters name in correct format
	And User enters email in correct format
	And User enters password in correct format
	And User enters membership type
	And User enters subscription period
	And User presses signup
	And User enters login email
	And User enters login password
	When User clicks login
	Then User should have his/her name
