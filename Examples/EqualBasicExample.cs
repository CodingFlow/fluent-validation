using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class EqualBasicExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: EqualBasicExample
        RuleFor(input)
            .Equal(8)
            .Result();
        // end-snippet
    }
}