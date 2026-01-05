using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class GuidValidatorTests
{
    [TestCase("019b87ad-c2c0-7a74-af4f-5fd1d80235be")]
    [TestCase("019b87adc2c07a74af4f5fd1d80235be")]
    public void Guid_Valid(string input)
    {
        var result = RuleFor(input)
            .IsGuid()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase("100000000-0000-0000-0000-000000000000")]
    [TestCase("0z000000-0000-0000-0000-000000000000")]
    public void Guid_Invalid(string input)
    {
        var result = RuleFor(input)
            .IsGuid()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' is not a valid GUID." }]
        });
    }
}
