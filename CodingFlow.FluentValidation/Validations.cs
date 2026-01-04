namespace CodingFlow.FluentValidation;

public static class Validations
{
    public static FluentValidation<R> RuleFor<R>(R input)
    {
        return new FluentValidation<R>(input);
    }

    extension<R>(FluentValidation<R> validation)
    {
        public FluentValidation<R> RuleFor(R input)
        {
            var newValidation = new FluentValidation<R>(input)
            {
                Result = validation.Result
            };

            return newValidation;
        }

        public ValidationResult Result()
        {
            validation.Result.Errors = validation.Errors;

            return validation.Result;
        }
    }
}
