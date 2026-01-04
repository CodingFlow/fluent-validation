using CodingFlow.FluentValidation.Validators;
// begin-snippet: StandardUsing
using static CodingFlow.FluentValidation.Validations;
// end-snippet

namespace Examples;

internal class BasicExample
{
    public void Run()
    {
        // begin-snippet: BasicExample
        var input = 11;

        var result = RuleFor(input)
            .BetweenInclusive(4, 6)
            .Result();

        // Check results
        bool isValid = result.IsValid;
        var errors = result.Errors;
        // end-snippet
    }
}