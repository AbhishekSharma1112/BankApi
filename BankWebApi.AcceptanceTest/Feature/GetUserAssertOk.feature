Feature: GetUserAssertOk
I want request user from bank api 
Give result Ok


@mytag
Scenario: Validate GetUser Request
	When I perfom get request for  user with id "{id}"
	Then response status is '200'