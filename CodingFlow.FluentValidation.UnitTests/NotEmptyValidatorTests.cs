using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class NotEmptyValidatorTests
{
    private static readonly object[] NotEmpty_Valid_Cases = [
        new Guid("019b87ad-c2c0-7a74-af4f-5fd1d80235be")
    ];

    [TestCase(5)]
    [TestCase("z")]
    [TestCaseSource(nameof(NotEmpty_Valid_Cases))]
    public void NotEmpty_Valid<T>(T input)
    {
        var result = RuleFor(input)
            .NotEmpty()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    private static readonly object[] NotEmpty_Invalid_Cases = [
        Guid.Empty,
    ];

    [TestCase(0)]
    [TestCase("")]
    [TestCaseSource(nameof(NotEmpty_Invalid_Cases))]
    public void NotEmpty_Invalid<T>(T input)
    {
        var result = RuleFor(input)
            .NotEmpty()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' of type {typeof(T)} is empty." }]
        });
    }

    [Test]
    public void NotEmpty_Object_Invalid()
    {
        TestRecord? input = null;

        var result = RuleFor(input)
            .NotEmpty()
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [new() { Message = $"Value '{input}' of type {typeof(TestRecord)} is empty." }]
        });
    }

    private record TestRecord(string Name);
}
