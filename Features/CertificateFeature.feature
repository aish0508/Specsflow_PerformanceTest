Feature: CertificateFeature

As a user, 
I would like to add and delete certificate
so that people seeking for certificate can look at it	

@tag1
Scenario Outline: 01 - Add and then delete certificate in the certificate list
	Given User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
	And Delete all certifications in the certifications list
	When User add new certification '<certificationId>' and should be added succesfully
	Then User deletes Certification '<certificationId>' and should be deleted successfully

	Examples: 
	| loginId | certificationId |
	| 1       | 1               |
	| 1       | 2               |

	Scenario Outline: 02 - Add an existing certificate in the certificate list
	Given User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
	And Delete all certifications in the certifications list
	And User has Certification '<certificationId>' in the certificate list
	When User tries to add certificate '<certificationId>' again
	Then The certificate '<certificationId>' should not be added again

	Examples: 
	| loginId | certificationId |
	| 1       | 1               |

	Scenario Outline: 03 - Add an empty certification in the certifications list
  Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
   When User tries to add empty certification '<certificationId>' in the certifications list
   Then The certification '<certificationId>' should not allow empty certification

Examples: 
        | loginId | certificationId |
        | 1       | 1               |

Scenario Outline: 04 - Add special characters in the certification
  Given  User logged into Mars URL with login details '<loginId>' and navigates to Certifications tab
    And  Delete all certifications in the certifications list
   When User tries to add special characters in the certification '<certificationId>'
   Then The certification '<certificationId>' should not allow special characters

Examples: 
        | loginId | certificationId |
        | 1       | 1               |

