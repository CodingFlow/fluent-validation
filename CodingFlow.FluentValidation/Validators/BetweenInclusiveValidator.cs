using System.Numerics;

namespace CodingFlow.FluentValidation.Validators;

public static class BetweenInclusiveValidator
{
    public static FluentValidation<T> BetweenInclusive<T>(this FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        Validate(validation, minimum, maximum);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        validation.Validate(
            () => minimum <= validation.Input && validation.Input <= maximum,
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not equal to or between {minimum} and {maximum}.")
        );
    }
}