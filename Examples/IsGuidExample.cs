using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class IsGuidExample
{
    public void Run()
    {
        var input = "some string";

        // begin-snippet: IsGuidExample
        RuleFor(input)
            .IsGuid()
            .Result();
        // end-snippet
    }
}