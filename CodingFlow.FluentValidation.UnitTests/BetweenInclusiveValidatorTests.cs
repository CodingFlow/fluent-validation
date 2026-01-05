using System.ComponentModel.DataAnnotations;
using System.Numerics;
using CodingFlow.FluentValidation.Validators;
using FluentAssertions;
using static CodingFlow.FluentValidation.Validations;

namespace CodingFlow.FluentValidation.UnitTests;

public class BetweenInclusiveValidatorTests
{
    private static readonly object[] BetweenInclusive_Valid_Cases = [
        new short[] { 5, 4, 6 },
        new short[] { 4, 4, 6 },
        new short[] { 6, 4, 6 },

        new ushort[] { 5, 4, 6 },
        new ushort[] { 4, 4, 6 },
        new ushort[] { 6, 4, 6 },

        new sbyte[] { 5, 4, 6 },
        new sbyte[] { 4, 4, 6 },
        new sbyte[] { 6, 4, 6 },

        new byte[] { 5, 4, 6 },
        new byte[] { 4, 4, 6 },
        new byte[] { 6, 4, 6 },

        new decimal[] { 5.5m, 5.4m, 5.6m },
        new decimal[] { 5.4m, 5.4m, 5.6m },
        new decimal[] { 5.6m, 5.4m, 5.6m },
    ];

    [TestCase(5, 4, 6)] [TestCase(4, 4, 6)] [TestCase(6, 4, 6)]
    [TestCase(5u, 4u, 6u)] [TestCase(4u, 4u, 6u)] [TestCase(6u, 4u, 6u)]
    [TestCase(5L, 4L, 6L)] [TestCase(4L, 4L, 6L)] [TestCase(6L, 4L, 6L)]
    [TestCase(5ul, 4ul, 6ul)] [TestCase(4ul, 4ul, 6ul)] [TestCase(6ul, 4ul, 6ul)]
    [TestCase(5.5f, 5.4f, 5.6f)] [TestCase(5.4f, 5.4f, 5.6f)] [TestCase(5.6f, 5.4f, 5.6f)]
    [TestCase(5.5d, 5.4d, 5.6d)] [TestCase(5.4d, 5.4d, 5.6d)] [TestCase(5.6d, 5.4d, 5.6d)]
    [TestCaseSource(nameof(BetweenInclusive_Valid_Cases))]
    public void BetweenInclusive_Valid<T>(T input, T minimum, T maximum)
        where T : INumber<T>
    {
        var result = RuleFor(input)
            .BetweenInclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = true,
            Errors = []
        });
    }

    private static readonly object[] BetweenInclusive_Invalid_Cases = [
        new short[] { 3, 4, 6 },
        new short[] { 7, 4, 6 },

        new ushort[] { 3, 4, 6 },
        new ushort[] { 7, 4, 6 },

        new sbyte[] { 3, 4, 6 },
        new sbyte[] { 7, 4, 6 },

        new byte[] { 3, 4, 6 },
        new byte[] { 7, 4, 6 },

        new decimal[] { 5.39m, 5.4m, 5.6m },
        new decimal[] { 5.61m, 5.4m, 5.6m },
    ];

    [TestCase(3, 4, 6)] [TestCase(7, 4, 6)]
    [TestCase(3u, 4u, 6u)] [TestCase(7u, 4u, 6u)]
    [TestCase(3L, 4L, 6L)] [TestCase(7L, 4L, 6L)]
    [TestCase(3ul, 4ul, 6ul)] [TestCase(7ul, 4ul, 6ul)]
    [TestCase(5.39f, 5.4f, 5.6f)] [TestCase(5.61f, 5.4f, 5.6f)]
    [TestCase(5.39d, 5.4d, 5.6d)] [TestCase(5.61d, 5.4d, 5.6d)]
    [TestCaseSource(nameof(BetweenInclusive_Invalid_Cases))]
    public void BetweenInclusive_Invalid<T>(T input, T minimum, T maximum)
        where T : INumber<T>
    {
        var result = RuleFor(input)
            .BetweenInclusive(minimum, maximum)
            .Result();

        result.Should().BeEquivalentTo(new ValidationResult
        {
            IsValid = false,
            Errors = [
                new() { Message = $"Value '{input}' of type {typeof(T)} is not equal to or between {minimum} and {maximum}."}
            ]
        });
    }
}
