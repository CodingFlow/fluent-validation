using FluentValidation;

namespace PerformanceBenchmarks;

internal class IntegerValidator : AbstractValidator<int>
{
    public IntegerValidator()
    {
        RuleFor(x => x).InclusiveBetween(1, 7);
    }
}
