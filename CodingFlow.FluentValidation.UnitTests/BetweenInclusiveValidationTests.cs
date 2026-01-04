using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class BetweenInclusiveValidationTests
{
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    public void BetweenInclusive_Integer_Valid(int input)
    {
        var result = RuleFor(input)
            .BetweenInclusive(4, 6)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(4f)]
    [TestCase(5f)]
    [TestCase(6f)]
    public void BetweenInclusive_Float_Valid(float input)
    {
        var result = RuleFor(input)
            .BetweenInclusive(4f, 6f)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(3, 4, 6)]
    [TestCase(7, 4, 6)]
    [TestCase(-1, 4, 6)]
    public void BetweenInclusive_Integer_Invalid(int input, int minimum, int maximum)
    {
        var result = RuleFor(input)
            .BetweenInclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type System.Int32 is not equal to or between {minimum} and {maximum}."}
            ]
        });
    }

    [TestCase(3f, 4f, 6f)]
    [TestCase(7f, 4f, 6f)]
    [TestCase(-1f, 4f, 6f)]
    public void BetweenInclusive_Float_Invalid(float input, float minimum, float maximum)
    {
        var result = RuleFor(input)
            .BetweenInclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type System.Single is not equal to or between {minimum} and {maximum}."}
            ]
        });
    }
}
