using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class MinimumLengthValidatorTests
{
    [TestCase("short")]
    [TestCase("long string")]
    public void MinimumLength_Valid(string input)
    {
        var result = RuleFor(input)
            .MinimumLength(5)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase("four")]
    public void MinimumLength_Invalid(string input)
    {
        var result = RuleFor(input)
            .MinimumLength(5)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' has a length less than 5." }]
        });
    }
}
