using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class IsGuidBasicExample
{
    public void Run()
    {
        var input = "some string";

        // begin-snippet: IsGuidBasicExample
        RuleFor(input)
            .IsGuid()
            .Result();
        // end-snippet
    }
}