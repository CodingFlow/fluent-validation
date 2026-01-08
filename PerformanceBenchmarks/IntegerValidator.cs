using FluentValidation;

namespace PerformanceBenchmarks;

// begin-snippet: IntegerValidator
internal class IntegerValidator : AbstractValidator<int>
{
    public IntegerValidator()
    {
        RuleFor(x => x).InclusiveBetween(1, 7);
    }
}
// end-snippet