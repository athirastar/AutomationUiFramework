Feature: Login functionality

Background:
  Given user is on login page
@owner:athira
Scenario Outline: Verify login with different credentials
    When user logs in with "<username>" and "<password>"
    Then user should see "Login" text
    When user click on Login button
    And login should show the status with "<expectedText>"

Examples:
    | username   | password         | result  |expectedText
    | athira     | Interview@998    | success |account
    | wronguser  | wrongpass        | failure |login
    