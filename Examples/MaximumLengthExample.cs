using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class MaximumLengthExample
{
    public void Run()
    {
        var input = "some string";

        // begin-snippet: MaximumLengthExample
        RuleFor(input)
            .MaximumLength(5) // Must be at most 5 characters long.
            .Result();
        // end-snippet
    }
}