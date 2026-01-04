namespace CodingFlow.FluentValidation.Validators;

public static class EqualValidator
{
    public static FluentValidation<T> Equal<T>(this FluentValidation<T> validation, T input)
    {
        Validate(validation, input);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, T input)
    {
        validation.Validate(
            () => validation.Input.Equals(input),
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not equal to {input}.")
        );
    }
}