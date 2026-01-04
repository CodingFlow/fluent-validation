using CodingFlow.FluentValidation;
using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

internal class WithMessageBasicExample
{
    public void Run()
    {
        var input = 11;

        // begin-snippet: WithMessageBasicExample
        RuleFor(input)
            .Equal(8).WithMessage("The two numbers are not equal.")
        .Result();
        // end-snippet
    }
}