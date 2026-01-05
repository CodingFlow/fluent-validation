namespace CodingFlow.FluentValidation.Validators;

public static class EqualValidator
{
    /// <summary>
    /// Ensures the input is considered equal to the provided value.
    /// For reference types it checks if the two references are to the same instance (reference equality).
    /// For value types, it checks it the types and values are the same (value equality).
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="input">Value to compare against.</param>
    /// <returns></returns>
    public static FluentValidation<T> Equal<T>(this FluentValidation<T> validation, T input)
    {
        Validate(validation, input);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, T input)
    {
        validation.Validate(
            validation => validation.Input.Equals(input),
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not equal to {input}.")
        );
    }
}