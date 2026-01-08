namespace CodingFlow.FluentValidation.Validators;

public static class MaximumLengthValidator
{
    /// <summary>
    /// Ensures the string has a length that is at most a maximum.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="input">String to check length.</param>
    /// <param name="maximum">Maximum length of the string.</param>
    /// <returns></returns>
    public static FluentValidation<string> MaximumLength(this FluentValidation<string> validation, int maximum)
    {
        Validate(validation, maximum);

        return validation;
    }

    private static void Validate(FluentValidation<string> validation, int maximum)
    {
        validation.Validate(
            validatin => validatin.Input.Length <= maximum,
            new ValidationError($"Value '{validation.Input}' has a length more than {maximum}.")
        );
    }
}