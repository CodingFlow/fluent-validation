using System.Numerics;

namespace CodingFlow.FluentValidation;

public static class BetweenExclusiveValidation
{

    extension<T>(FluentValidation<T> validation) where T : INumber<T>
    {
        public FluentValidation<T> BetweenExclusive(T minimum, T maximum)
        {
            Validate(validation, minimum, maximum);

            return validation;
        }
    }

    private static void Validate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        validation.Validate(
            () => minimum < validation.Input && validation.Input < maximum,
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not between {minimum} and {maximum}.")
        );
    }
}