namespace CodingFlow.FluentValidation.Validators;

public static class IsGuidValidator
{
    /// <summary>
    /// Ensures the string can be parsed into a valid GUID.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="input">Value to compare against.</param>
    /// <returns></returns>
    public static FluentValidation<string> IsGuid(this FluentValidation<string> validation)
    {
        Validate(validation);

        return validation;
    }

    private static void Validate(FluentValidation<string> validation)
    {
        validation.Internal.Validate(
            @internal => Guid.TryParse(@internal.Input, out var value),
            new ValidationError($"Value '{validation.Internal.Input}' is not a valid GUID.")
        );
    }
}