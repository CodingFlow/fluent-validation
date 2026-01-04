using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class EqualValidatorTests
{
    [TestCase(5)]
    public void Equal_Valid(int input)
    {
        var result = RuleFor(input)
            .Equal(5)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(5f, 20f)]
    [TestCase("some string", "another string")]
    public void EqualInvalid<T>(T input, T otherInput)
    {
        var result = RuleFor(input)
            .Equal(otherInput)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' of type {typeof(T)} is not equal to {otherInput}." }]
        });
    }
}
