namespace CodingFlow.FluentValidation.VogenExtensions.UnitTests;

public static class TestValidations
{
    public const string ErrorMessage = "Test error.";

    extension<T>(FluentValidation<T> validation)
    {
        public FluentValidation<T> Valid()
        {
            return validation;
        }

        public FluentValidation<T> Invalid()
        {
            validation.Result.IsValid = false;
            validation.Errors.Add(new() { Message = ErrorMessage });

            return validation;
        }
    }
}