namespace CodingFlow.FluentValidation.Validators;

public static class NotEmptyValidator
{
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