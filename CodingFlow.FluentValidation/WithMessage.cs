namespace CodingFlow.FluentValidation;

public static class WithExtensions
{
    /// <summary>
    /// Changes the validator's failure error message with the provided <paramref name="message"/>.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation">Fluent validation API instance.</param>
    /// <param name="message">The custom error message to be set for the validator.</param>
    /// <returns></returns>
    public static FluentValidation<T> WithMessage<T>(this FluentValidation<T> validation, string message)
    {
        validation.Internal.ChangeErrorMessage(message);

        return validation;
    }
}