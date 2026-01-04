using System.Numerics;

namespace CodingFlow.FluentValidation;

public static class BetweenExclusiveValidation
{

    extension<T>(FluentValidation<T> validation) where T : INumber<T>
    {
        public FluentValidation<T> BetweenExclusive(T minimum, T maximum)
        {
            BetweenExclusiveValidate(validation, minimum, maximum);

            return validation;
        }
    }

    private static void BetweenExclusiveValidate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        var isValid = minimum < validation.Input && validation.Input < maximum;

        if (!isValid)
        {
            validation.Result.IsValid = false;

            validation.Errors.Add(
                new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not between {minimum} and {maximum}."));
        }
    }
}