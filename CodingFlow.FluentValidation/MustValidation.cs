namespace CodingFlow.FluentValidation;

public static class MustValidation
{
    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> Must(Func<T, bool> predicate)
        {
            Validate(validation, predicate);

            return validation;
        }
    }

    private static void Validate<T>(FluentValidation<T> validation, Func<T, bool> predicate)
    {
        validation.Validate(
            () => predicate(validation.Input),
            new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not valid.")
        );
    }
}