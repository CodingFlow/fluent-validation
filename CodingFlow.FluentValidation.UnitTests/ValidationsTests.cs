using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class ValidationsTests
{
    [TestCase(5)]
    [TestCase("test string")]
    public void RuleFor_Chained_Valid<T>(T input)
    {
        var result = 
            RuleFor(input)
                .Valid()
            .RuleFor(input)
                .Valid()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(5)]
    [TestCase("test string")]
    public void RuleFor_Chained_Invalid_First<T>(T input)
    {
        var result =
            RuleFor(input)
                .Invalid()
            .RuleFor(input)
                .Valid()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = TestValidators.ErrorMessage }]
        });
    }

    [TestCase(5)]
    [TestCase("test string")]
    public void RuleFor_Chained_Invalid_Second<T>(T input)
    {
        var result =
            RuleFor(input)
                .Valid()
            .RuleFor(input)
                .Invalid()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = TestValidators.ErrorMessage }]
        });
    }
}
