namespace CodingFlow.FluentValidation.Validators;

public static class NotEmptyValidator
{
    /// <summary>
    /// Ensures the value is not <c>null</c> for reference types or a default value for value types. For strings,
    /// ensures it is not <c>null</c>, an empty string, or only whitespace.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <returns></returns>
    public static FluentValidation<T> NotEmpty<T>(this FluentValidation<T> validation)
    {
        Validate(validation);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation)
    {
        validation.Validate(
            validation =>
            {
                if (typeof(T) == typeof(string))
                {
                    return !string.IsNullOrWhiteSpace(validation.Input as string);
                }

                return !EqualityComparer<T>.Default.Equals(validation.Input, default);
            },
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is empty.")
        );
    }
}