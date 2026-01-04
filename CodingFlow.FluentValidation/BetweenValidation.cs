using System.Numerics;

namespace CodingFlow.FluentValidation;

public static class BetweenValidation
{

    extension<T>(FluentValidation<T> validation) where T : INumber<T>
    {
        public FluentValidation<T> Between(T minimum, T maximum)
        {
            BetweenValidate(validation, minimum, maximum);

            return validation;
        }
    }

    private static void BetweenValidate<T>(FluentValidation<T> validation, T minimum, T maximum)
        where T : INumber<T>
    {
        var isValid = minimum < validation.Input && validation.Input < maximum;

        if (!isValid)
        {
            validation.Result.IsValid = false;

            validation.Errors.Add(
                new ValidationError($"Value Object of type {typeof(T)} value '{validation.Input}' is not between {minimum} and {maximum}."));
        }
    }
}