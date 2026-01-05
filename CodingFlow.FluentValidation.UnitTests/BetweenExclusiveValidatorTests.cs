using System.Numerics;
using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class BetweenExclusiveValidatorTests
{
    private static readonly object[] BetweenExclusive_Valid_Cases = [
        new short[] { 5, 4, 6 },
        new ushort[] { 5, 4, 6 },
        new sbyte[] { 5, 4, 6 },
        new byte[] { 5, 4, 6 },
        new decimal[] { 5.5m, 5.4m, 5.6m },
    ];

    [TestCase(5, 4, 6)]
    [TestCase(5u, 4u, 6u)]
    [TestCase(5L, 4L, 6L)]
    [TestCase(5ul, 4ul, 6ul)]
    [TestCase(5.5f, 5.4f, 5.6f)]
    [TestCase(5.5d, 5.4d, 5.6d)]
    [TestCaseSource(nameof(BetweenExclusive_Valid_Cases))]
    public void BetweenExclusive_Valid<T>(T input, T minimum, T maximum)
        where T : INumber<T>
    {
        var result = RuleFor(input)
            .BetweenExclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    private static readonly object[] BetweenExclusive_Invalid_Cases = [
        new short[] { 4, 4, 6 },
        new short[] { 6, 4, 6 },

        new ushort[] { 4, 4, 6 },
        new ushort[] { 6, 4, 6 },

        new sbyte[] { 4, 4, 6 },
        new sbyte[] { 6, 4, 6 },

        new byte[] { 4, 4, 6 },
        new byte[] { 6, 4, 6 },

        new decimal[] { 5.4m, 5.4m, 5.6m },
        new decimal[] { 5.6m, 5.4m, 5.6m },
    ];

    [TestCase(4, 4, 6)] [TestCase(6, 4, 6)]
    [TestCase(4u, 4u, 6u)] [TestCase(6u, 4u, 6u)]
    [TestCase(4L, 4L, 6L)] [TestCase(6L, 4L, 6L)]
    [TestCase(4ul, 4ul, 6ul)] [TestCase(6ul, 4ul, 6ul)]
    [TestCase(5.4f, 5.4f, 5.6f)] [TestCase(5.6f, 5.4f, 5.6f)]
    [TestCase(5.4d, 5.4d, 5.6d)] [TestCase(5.6d, 5.4d, 5.6d)]
    [TestCaseSource(nameof(BetweenExclusive_Invalid_Cases))]
    public void BetweenExclusive_Invalid<T>(T input, T minimum, T maximum)
        where T : INumber<T>
    {
        var result = RuleFor(input)
            .BetweenExclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type {typeof(T)} is not between {minimum} and {maximum}."}
            ]
        });
    }
}
