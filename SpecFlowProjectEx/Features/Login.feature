	@Variant:Chrome
	@Variant:IE
Feature: Login
	In order to manage the hospital records
	As a portal user
	I would like to access OpenMr dashboard

#Background: 
  #  Given I have browser with OpenMr Page


Scenario Outline: Valid Credential
	Given I have browser with OpenMr Page
	When I enter username as '<username>'
	And  I enter password as '<password>'
	And  I select language as '<language>'
	And I click on Login
	Then I should get access to portal with title as 'OpenEMR'
	Examples: 
	| username  | password  | language         |
	| admin     | pass      | English (Indian) |
	| physician | physician | English (Indian) |



Scenario: InValid Credential
	Given I have browser with OpenMr Page
	When I enter username as 'admin'
	And  I enter password as 'pass123'
	And  I select language as 'English (Indian)'
	And I click on Login
	Then I should get error message as 'Invalid'