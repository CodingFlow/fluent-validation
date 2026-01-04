using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.VogenExtensions.UnitTests;

public class VogenValidationsTests
{
    [TestCase(5f)]
    public void Between_Float_Valid(float input)
    {
        var result = RuleFor(input)
            .Between(4f, 6f)
            .VogenResult();

        result.Should().BeEquivalentTo(Vogen.Validation.Ok);
    }

    [TestCase(4f, 4f, 6f)]
    [TestCase(6f, 4f, 6f)]
    [TestCase(-1f, 4f, 6f)]
    public void Between_Float_Invalid(float input, float minimum, float maximum)
    {
        var result = RuleFor(input)
            .Between(minimum, maximum)
            .VogenResult();

        result.Should().BeEquivalentTo(
            Vogen.Validation.Invalid($"Value '{input}' of type System.Single is not between {minimum} and {maximum}."));
    }
}
