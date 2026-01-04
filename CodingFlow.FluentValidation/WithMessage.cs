namespace CodingFlow.FluentValidation;

public static class WithExtensions
{
    public static FluentValidation<T> WithMessage<T>(this FluentValidation<T> validation, string message)
    {
        validation.ChangeErrorMessage(message);

        return validation;
    }
}