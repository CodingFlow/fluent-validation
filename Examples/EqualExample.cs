using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class EqualExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: EqualExample
        RuleFor(input)
            .Equal(8)
            .Result();
        // end-snippet
    }
}