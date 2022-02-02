@Patient
Feature: Patient
	In order to add/delete/edit the patient records
	As a admin
	I want to get access to portal


@addpatient
Scenario: Add Pateint record
Given I have browser with OpenMr Page
	When I enter username as 'admin'
	And  I enter password as 'pass'
	And  I select language as 'English (Indian)'
	And I click on Login
	And I click on Patient/client
	And I click on Patient
	And I click on add new patient
	And I fill the form
	| firstname | middlename | lastname | dob | gender |
	| Johns      | Kr         |wicks     | 2022-01-12 | male   |
	And I click on create new patient
	And I click on confirm create new patient
	And I store alert text and handle it
	And I handle happy birthday pop up if any
	Then I should verify the stored alert text as 'New Due'
	Then I should verify the patient details as 'Medical Record Dashboard- John wick'

