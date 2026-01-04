namespace CodingFlow.FluentValidation.Validators;

public static class MustValidation
{
    public static FluentValidation<T> Must<T>(this FluentValidation<T> validation, Func<T, bool> predicate)
    {
        Validate(validation, predicate);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, Func<T, bool> predicate)
    {
        validation.Validate(
            () => predicate(validation.Input),
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not valid.")
        );
    }
}