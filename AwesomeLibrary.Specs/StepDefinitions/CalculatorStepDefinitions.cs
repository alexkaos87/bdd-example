namespace AwesomeLibrary.Specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly Calculator _calculator = new Calculator();
        private double _result;

        private Dictionary<string, Exception> _context = new Dictionary<string, Exception>();

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = _calculator.Substract();
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _result = _calculator.Multiply();
        }

        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch(Exception exception)
            {
                _context.Add("Exception_WhenTheTwoNumbersAreDivided", exception);
            }
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(double result)
        {
            _result.Should().Be(result);
        }

        [Then(@"the result should throw exception")]
        public void ThenTheResultShouldThrowException()
        {
            _context.Should().ContainKey("Exception_WhenTheTwoNumbersAreDivided");
            var exception = _context["Exception_WhenTheTwoNumbersAreDivided"];
            exception.Should().NotBeNull();
        }

    }
}