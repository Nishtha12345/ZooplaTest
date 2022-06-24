Feature: CheckResult

@Test1
Scenario: Verify that the text is displayed scenario
	Given User Passes the query parameter with text"this is some test input"
	When User creates a request URI
	Then Assert the response for the text"this is some test input"

	@Test2
Scenario: Verify chars in the text is successfully replaced with special chars
	Given Query Param with text"this is some test input" is replaced with "&add=input&fill_char=_"
	When User creates a request URI
	Then Assert the response for the replaced text"_____"

	@Test3
   Scenario: Verify text is replaced with words passed
	Given Query Param with text"this is some test input" is replaced with "&add=this, some&fill_text=Zoopla"
	When User creates a request URI
	Then Assert the response for the replaced text"Zoopla"

    @Test4
    Scenario: Verify error is generated with given query parameter
	Given Query Param with text"this is some test input" is replaced with "&fill_text=this is curiously long replacement text"
	When User creates a request URI
	Then Assert the response

	@Test5
   Scenario: Verify text is replaced with default *
	Given Query Param with text"this is some test input" is replaced with "&add=this, some&fill_text="
	When User creates a request URI
	Then Assert the response for the replaced text"**"