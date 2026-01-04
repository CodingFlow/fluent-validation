namespace CodingFlow.FluentValidation;

public static class Validations
{
    public static FluentValidation<R> RuleFor<R>(R input)
    {
        return new FluentValidation<R>(input);
    }

    public static FluentValidation<R> RuleFor<R>(this FluentValidation<R> validation, R input)
    {
        var newValidation = new FluentValidation<R>(input)
        {
            Result = validation.Result,
            Errors = validation.Errors
        };

        return newValidation;
    }

    public static ValidationResult Result<R>(this FluentValidation<R> validation)
    {
        validation.Result.Errors = validation.Errors;

        return validation.Result;
    }
}
