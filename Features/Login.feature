Feature: Login

Validating if Login for User works

@login
Scenario: User logging into the LMS
	Given User goes to URL
	And User enters correct email
	And User enters correct password
	When User presses login
	Then User should see Catalog
