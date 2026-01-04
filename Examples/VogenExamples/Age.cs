using CodingFlow.FluentValidation.Validators;
using CodingFlow.FluentValidation.VogenExtensions;
using Vogen;
using static CodingFlow.FluentValidation.Validations;

namespace Examples;

[ValueObject]
public readonly partial struct Age
{
    public static Validation Validate(int value)
    {
        return RuleFor(value)
            .BetweenInclusive(0, 200)
            .VogenResult();
    }
}