namespace CodingFlow.FluentValidation;

public static class MustValidation
{
    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> Must(Func<T, bool> predicate)
        {
            MustValidate<T>(validation, predicate);

            return validation;
        }
    }

    private static void MustValidate<T>(FluentValidation<T> validation, Func<T, bool> predicate)
    {
        var isValid = predicate(validation.Input);

        if (!isValid)
        {
            validation.Result.IsValid = false;

            validation.Errors.Add(
                new ValidationError($"Value '{validation.Input}' of type {typeof(T)} is not valid."));
        }
    }
}