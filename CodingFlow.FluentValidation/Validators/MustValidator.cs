namespace CodingFlow.FluentValidation.Validators;

public static class MustValidator
{
    /// <summary>
    /// The predicate (aka <see cref="Must{T}(FluentValidation{T}, Func{T, bool})">Must</see>) validator allows you to provide your own validation logic by providing a delegate.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="predicate">The delagate with the custom validation logic.
    /// Return <c>true</c> to indicate validation passed, <c>false</c> if validation failed.</param>
    /// <returns></returns>
    public static FluentValidation<T> Must<T>(this FluentValidation<T> validation, Func<T, bool> predicate)
    {
        Validate(validation, predicate);

        return validation;
    }

    private static void Validate<T>(FluentValidation<T> validation, Func<T, bool> predicate)
    {
        validation.Internal.Validate(
            validation => predicate(validation.Internal.Input),
            new ValidationError($"Value '{validation.Internal.Input}' of type {typeof(T)} is not valid.")
        );
    }
}