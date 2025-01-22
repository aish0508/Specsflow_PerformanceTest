Feature: ChangePassword

I Would Like To Change Password.

@tag1
Scenario: 01 Check the Empty Scenario In Change Password
	Given User Login into Mars Url and navigate to user tab
	When User Directly Click on Save Button
	Then  '<Message>' should be displayed 

	Examples:
	| Message                                   |
	| Please fill all the details before Submit |

       

	Scenario Outline: 04 Check by writing Wrong Current Password
	Given User Login into Mars Url and navigate to user tab
	When User write wrong  Current password and Same inputs in New Password, Confirm Password with '<id>' and Click on Save Button
	Then  Password Failed Verification'<id>' should be displayed

	Examples: 
	| id |
	| 2  |

	Scenario Outline: 03 Check by writing wrong new password and confirm password
	Given User Login into Mars Url and navigate to user tab
	When User write Correct Current Password and different inputs in  New Password, Confirm Password with '<id>'and Click on Save Button
	Then Password should not match'<id>' should be displayed 

	Examples: 
	| id |
	| 3  |

	Scenario Outline: 02 Change the new password
	Given User Login into Mars Url and navigate to user tab
	When User clicks Change Password and updates the new password with '<id>'
	Then New Password updated with '<id>' successfully

	Examples: 
      | id |
      | 1  |





