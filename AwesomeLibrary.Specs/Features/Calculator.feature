Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](AwesomeLibrary.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Scenario: Add two numbers
    Given the first number is <FirstNumber>
    And the second number is <SecondNumber>
    When the two numbers are added
    Then the result should be <AddResult>

Examples: 
    | FirstNumber | SecondNumber | AddResult |
    | 50          | 70           | 120       |
    | 70          | 50           | 120       |
    | 50          | 50           | 100       |
    | 70          | 70           | 140       |

Scenario: Subtract two numbers
    Given the first number is 120
    And the second number is 70
    When the two numbers are subtracted
    Then the result should be 50
    
Scenario: Multiply two numbers
    Given the first number is 10
    And the second number is 7
    When the two numbers are multiplied
    Then the result should be 70
    
Scenario: Divide two numbers
    Given the first number is 10
    And the second number is 1
    When the two numbers are divided
    Then the result should be 10
    
Scenario: Divide for 0
    Given the first number is 10
    And the second number is 0
    When the two numbers are divided
    Then the result should throw exception