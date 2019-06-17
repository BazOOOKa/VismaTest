Feature: EmergenTest

Scenario: Check User cannot choose Reward without authorization into the system
	When User navigate to EurOffice Home Page
	And User clicks on Euroffice Rewards
	Then User cannnot choose the rewards without signing into the system

Scenario: Check email field 
	When User navigate to EurOffice Home Page
	And Click On Registration Button
	Then User fills mandatory fields on Registration Page
	| ItemList          | Value        |
	| UserName          | Ildar        |
	| User LastName     | Gataullin    |
	| User EmailAddress | igataullin00 |
	| User Password     | blablabla123 |
	And User can see wrong email notification