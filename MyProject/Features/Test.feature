Feature: VismaTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Check mandatory fields, email fields and blog links
	When User navigate to Home Page
	And User click on Apply button
	Then User navigates to Application Page
	And User clicks on Submit button
	And User clicks on Submit button
	And User can see all input fields 'highlighted' as mandatory with 'Šis lauks ir obligāts.' message
	And User can see checkbox 'highlighted' as mandatory
	And User clicks on Term of Use Checkbox
	And User clicks on Submit button
	And User can see checkbox 'not highlighted' as mandatory
	And User fills all mandatory fields
	| ItemList     | Value        |
	| Name         | Test         |
	| Surname      | Automation   |
	| Company Name | Visma Labs   |
	| Phone        | +37127666456 |
	| E-mail       | igataullin00 |
	And User clicks on Submit button
	And User 'can' see 'Ievadiet derîgu epasta adresi.' e-mail error
	And User fills all mandatory fields
	| ItemList | Value                  |
	| E-mail   | igataullin00@gmail.com |
	And User clicks on Term of Use Checkbox
	#Perfroming again to click on 'Term of Use Checkbox' to not to proceed future process of application submitting
	And User clicks on Submit button
	And User 'cannot' see 'Ievadiet derîgu epasta adresi.' e-mail error
	And User can see all input fields 'not highlighted' as mandatory with '' message
	And User returns back to the home page
	Then click on blog '<link>' at the main page
	Examples: 
	| link                 |
	| visma school         |
	| accounting documents |
	| average earnings     |

Scenario: Check that page changes location (url and language) when switching to another country 
	When User navigate to Home Page
	Then User changes country to Romania
	And User can see that web-link and language had been changed according to country 

Scenario Outline: Check Social Media Links
	When User navigate to Home Page
	And User clicks on '<link>' links and check '<title>'
	
	Examples: 
	| link     | title             |
	| facebook | VISMA.lv          |
	| LinkedIn | Visma Latvia      |
	| Blog     | Visma Blog Latvia |




	
	
