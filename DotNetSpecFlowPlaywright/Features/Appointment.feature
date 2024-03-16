Feature: Reserve Appointment


Scenario: Test user journey through a successful appointment
Given a user navigates to onboarding flow and reserve an appointment


Scenario: Test user journey by choosing other state option
Given a user navigates and choose other state to book an appointment

Scenario Outline: Test Privacy practices for different states
Given a user navigates to onboarding flow and checks privacy practice in <state>
Examples:
    | state |
    | california|
    | alabama   |

  
Scenario: Successful API test to get available time slots
Given a user sends request to  API