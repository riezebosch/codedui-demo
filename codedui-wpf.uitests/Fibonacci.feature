Feature: Fibonacci
	

@codedui
Scenario Outline: The n'th fibonacci number
	Given I have the application open
	And I have entered <input> in the WPF application
	When I press the big bad button
	Then the result should be <output> on the screen
Examples: 
| type       | input | output            |
| nul-invoer | 0     | 0                 |
| geldig     | 1     | 1                 |
| ongeldig   | -1    | Ongeldige invoer! |