using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class BetweenExclusiveExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: BetweenExclusiveExample
        RuleFor(input)
            .BetweenExclusive(6, 14)
            .Result();
        // end-snippet
    }
}