Feature: GetUser
In order to test if BankApi is taking users 
I want the EnterUser call to return Ok 
	
	
@mytag
Scenario: Validate Response Status
    When I make a Get request to "/User/GetUserData/1" 
    Then the response status code is "200"


