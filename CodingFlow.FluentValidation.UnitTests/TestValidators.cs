namespace CodingFlow.FluentValidation.UnitTests;

public static class TestValidators
{
    public const string ErrorMessage = "Test error.";

    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> Valid()
        {
            validation.Validate(
                () => true,
                new() { Message = ErrorMessage }
            );

            return validation;
        }

        public FluentValidation<T> Invalid()
        {
            validation.Validate(
                () => false,
                new() { Message = ErrorMessage }
            );

            return validation;
        }
    }
}