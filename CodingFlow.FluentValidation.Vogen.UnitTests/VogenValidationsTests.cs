using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.VogenExtensions.UnitTests;

public class VogenValidationsTests
{
    [TestCase(5f)]
    public void Between_Float_Valid<T>(T input)
    {
        var result = RuleFor(input)
            .Valid()
            .VogenResult();

        result.Should().BeEquivalentTo(Vogen.Validation.Ok);
    }

    [TestCase(4f)]
    [TestCase("test string")]
    public void Between_Float_Invalid<T>(T input)
    {
        var result = RuleFor(input)
            .Invalid()
            .VogenResult();

        result.Should().BeEquivalentTo(
            Vogen.Validation.Invalid(TestValidations.ErrorMessage));
    }
}
