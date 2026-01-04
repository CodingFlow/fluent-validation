using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class NotEmptyBasicExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: NotEmptyBasicExample
        RuleFor(input)
            .NotEmpty()
            .Result();
        // end-snippet
    }
}