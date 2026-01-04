using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class BetweenExclusiveValidationTests
{
    [TestCase(5)]
    public void Between_Integer_Valid(int input)
    {
        var result = RuleFor(input)
            .BetweenExclusive(4, 6)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(5f)]
    public void Between_Float_Valid(float input)
    {
        var result = RuleFor(input)
            .BetweenExclusive(4f, 6f)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(4, 4, 6)]
    [TestCase(6, 4, 6)]
    [TestCase(-1, 4, 6)]
    public void Between_Integer_Invalid(int input, int minimum, int maximum)
    {
        var result = RuleFor(input)
            .BetweenExclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type System.Int32 is not between {minimum} and {maximum}."}
            ]
        });
    }

    [TestCase(4f, 4f, 6f)]
    [TestCase(6f, 4f, 6f)]
    [TestCase(-1f, 4f, 6f)]
    public void Between_Float_Invalid(float input, float minimum, float maximum)
    {
        var result = RuleFor(input)
            .BetweenExclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type System.Single is not between {minimum} and {maximum}."}
            ]
        });
    }
}
