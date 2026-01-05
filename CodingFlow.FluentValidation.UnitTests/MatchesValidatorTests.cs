using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class MatchesValidatorTests
{
    [TestCase("has a cat in the string")]
    public void Matches_Valid(string input)
    {
        var result = RuleFor(input)
            .Matches("cat")
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase("only kitten here")]
    public void Matches_Invalid(string input)
    {
        var result = RuleFor(input)
            .Matches("cat")
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' does not match the pattern." }]
        });
    }
}
