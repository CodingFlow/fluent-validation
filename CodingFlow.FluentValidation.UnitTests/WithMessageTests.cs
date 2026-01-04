using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class WithMessageTests
{
    [TestCase(5)]
    public void WithMessage_Valid(int input)
    {
        var result = RuleFor(input)
            .Valid().WithMessage("my message")
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    [TestCase(5f)]
    public void WithMessage_Invalid(float input)
    {
        var result = RuleFor(input)
            .Invalid().WithMessage("my message")
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = "my message" }]
        });
    }
}
