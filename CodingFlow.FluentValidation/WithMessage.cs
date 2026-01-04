namespace CodingFlow.FluentValidation;

public static class WithExtensions
{
    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> WithMessage(string message)
        {
            validation.ChangeErrorMessage(message);

            return validation;
        }
    }
}