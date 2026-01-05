using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class BetweenInclusiveExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: BetweenInclusiveExample
        RuleFor(input)
            .BetweenInclusive(6, 14)
            .Result();
        // end-snippet
    }
}