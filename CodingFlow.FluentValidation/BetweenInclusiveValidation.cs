using System.Numerics;

namespace CodingFlow.FluentValidation;

public static class BetweenInclusiveValidation
{

    extension<T>(FluentValidation<T> validation) where T : INumber<T>
    {
        public FluentValidation<T> BetweenInclusive(T minimum, T maximum)
        {
            BetweenInclusiveValidate(validation, minimum, maximum);

            return validation;
        }
    }

    private static void BetweenInclusiveValidate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        var isValid = minimum <= validation.Input && validation.Input <= maximum;

        if (!isValid)
        {
            validation.Result.IsValid = false;

            validation.Errors.Add(
                new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not equal to or between {minimum} and {maximum}."));
        }
    }
}