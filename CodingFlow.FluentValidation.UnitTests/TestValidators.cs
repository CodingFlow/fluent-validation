namespace CodingFlow.FluentValidation.UnitTests;

public static class TestValidators
{
    public const string ErrorMessage = "Test error.";

    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> Valid()
        {
            validation.Internal.Validate(
                _ => true,
                new() { Message = ErrorMessage }
            );

            return validation;
        }

        public FluentValidation<T> Invalid()
        {
            validation.Internal.Validate(
                _ => false,
                new() { Message = ErrorMessage }
            );

            return validation;
        }
    }
}