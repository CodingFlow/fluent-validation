using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class MustBasicExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: MustBasicExample
        RuleFor(input)
            .Must(input => input == 7)
            .Result();
        // end-snippet
    }
}