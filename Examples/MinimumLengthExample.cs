using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class MinimumLengthExample
{
    public void Run()
    {
        var input = "some string";

        // begin-snippet: MinimumLengthExample
        RuleFor(input)
            .MinimumLength(5) // Must be at least 5 characters long.
            .Result();
        // end-snippet
    }
}