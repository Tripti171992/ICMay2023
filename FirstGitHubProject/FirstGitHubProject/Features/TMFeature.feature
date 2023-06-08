Feature: TMFeature

As a TurnUp Portal admin, I would like to create , edit and delete time and material records so that I can manage 
employees time and materials successfully


Scenario: Create time and material record with valid details
	Given I logged into the TurnUp portal successfully
	When I navigate to the time and material page
	And I create new time and material record
	Then Then the record should be created successfully

	Scenario Outline: Edit existing time and material record with valid details
	Given I logged into the TurnUp portal successfully
	When I navigate to the time and material page
	And I edited '<Description>','<Code>' and '<Price>'on an existing time and material record
	Then The record should be editted successfully'<Description>','<Code>' and '<Price>'

	Examples:
	| Description  | Code     | Price |
	| Time         | Tripti   | $30.00    |
	| Material     | mouse    | $40.00    |
	| EditedRecord | Keyboard | $50.00    |