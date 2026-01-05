namespace CodingFlow.FluentValidation.Validators;

public static class MinimumLengthValidator
{
    /// <summary>
    /// Ensures the string has a length that is at least as long as a minimum.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="input">String to check length.</param>
    /// <param name="minimum">Minimum length of the string.</param>
    /// <returns></returns>
    public static FluentValidation<string> MinimumLength(this FluentValidation<string> validation, int minimum)
    {
        Validate(validation, minimum);

        return validation;
    }

    private static void Validate(FluentValidation<string> validation, int minimum)
    {
        validation.Internal.Validate(
            validation => validation.Internal.Input.Length >= minimum,
            new ValidationError($"Value '{validation.Internal.Input}' has a length less than {minimum}.")
        );
    }
}