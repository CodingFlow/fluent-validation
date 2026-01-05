using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class MaximumLengthValidatorTests
{
    [TestCase("short")]
    public void MaximumLength_Valid(string input)
    {
        var result = RuleFor(input)
            .MaximumLength(5)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase("kitten")]
    public void MaximumLength_Invalid(string input)
    {
        var result = RuleFor(input)
            .MaximumLength(5)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' has a length more than 5." }]
        });
    }
}
