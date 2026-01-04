using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class MustValidationTests
{
    [TestCase(5)]
    public void Must_Valid(int input)
    {
        var result = RuleFor(input)
            .Must(value => true)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(5f)]
    public void Must_Invalid(float input)
    {
        var result = RuleFor(input)
            .Must(value => false)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' of type System.Single is not valid." }]
        });
    }
}
