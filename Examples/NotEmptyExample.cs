using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class NotEmptyExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: NotEmptyExample
        RuleFor(input)
            .NotEmpty()
            .Result();
        // end-snippet
    }
}