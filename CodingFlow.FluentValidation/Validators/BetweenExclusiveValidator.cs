using System.Numerics;

namespace CodingFlow.FluentValidation.Validators;

public static class BetweenExclusiveValidator
{
    /// <summary>
    /// Ensures a number of any type (int, float, double, etc.)
    /// is greater than a minimum and less than a maximum.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="minimum">Minimum number of the validation range.</param>
    /// <param name="maximum">Maximum number of the validation range.</param>
    /// <returns></returns>
    public static FluentValidation<T> BetweenExclusive<T>(this FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        Validate(validation, minimum, maximum);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        validation.Internal.Validate(
            @internal => minimum < @internal.Input && @internal.Input < maximum,
            new ValidationError($"Value '{validation.Internal.Input}' of type {typeof(T)} is not between {minimum} and {maximum}.")
        );
    }
}