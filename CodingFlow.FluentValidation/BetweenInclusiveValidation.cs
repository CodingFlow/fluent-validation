using System.Numerics;

namespace CodingFlow.FluentValidation;

public static class BetweenInclusiveValidation
{
    extension<T>(FluentValidation<T> validation) where T : INumber<T>
    {
        public FluentValidation<T> BetweenInclusive(T minimum, T maximum)
        {
            Validate(validation, minimum, maximum);

            return validation;
        }
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