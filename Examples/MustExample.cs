using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class MustExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: MustExample
        RuleFor(input)
            .Must(input => input == 7)
            .Result();
        // end-snippet
    }
}