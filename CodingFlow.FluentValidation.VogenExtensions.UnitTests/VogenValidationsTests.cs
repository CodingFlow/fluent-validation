using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.VogenExtensions.UnitTests;

public class VogenValidationsTests
{
    [TestCase(5f)]
    public void Between_Float_Valid<T>(T input)
    {
        var result = RuleFor(input)
            .Must(_ => true)
            .VogenResult();

        result.Should().BeEquivalentTo(Vogen.Validation.Ok);
    }

    private const string ErrorMessage = "Test error.";

    [TestCase(4f)]
    [TestCase("test string")]
    public void Between_Float_Invalid<T>(T input)
    {
        var result = RuleFor(input)
            .Must(_ => false).WithMessage(ErrorMessage)
            .VogenResult();

        result.Should().BeEquivalentTo(Vogen.Validation.Invalid(ErrorMessage));
    }
}
