using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class MatchesExample
{
    public void Run()
    {
        var input = "some string";

        // begin-snippet: MatchesExample
        RuleFor(input)
            .Matches("cat")
            .Result();
        // end-snippet
    }
}