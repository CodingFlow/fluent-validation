namespace CodingFlow.FluentValidation;

public static class Validations
{
    /// <summary>
    /// Initiates the validation chain for the given <paramref name="input"/>.
    /// </summary>
    /// <typeparam name="R">Input type.</typeparam>
    /// <param name="input">The value to be validated.</param>
    /// <returns>Fluent validation instance to allow for fluent chaining API.</returns>
    public static FluentValidation<R> RuleFor<R>(R input)
    {
        return new FluentValidation<R>(input);
    }

    /// <summary>
    /// Continues the validation chain for a different <paramref name="input"/> value.
    /// </summary>
    /// <typeparam name="R">Input type.</typeparam>
    /// <param name="validation">Fluent validation instance to allow for fluent chaining API.</param>
    /// <param name="input">The new input value to set validation rules for.</param>
    /// <returns>Fluent validation instance to allow for fluent chaining API.</returns>
    public static FluentValidation<R> RuleFor<R>(this FluentValidation<R> validation, R input)
    {
        var newValidation = new FluentValidation<R>(input)
        {
            Result = validation.Result,
            Errors = validation.Errors
        };

        return newValidation;
    }

    /// <summary>
    /// Ends the fluent validation chain and returns the result.
    /// </summary>
    /// <typeparam name="R">Input type.</typeparam>
    /// <param name="validation">Fluent validation instance to allow for fluent chaining API.</param>
    /// <returns>Validation result of the entire validation chain.</returns>
    public static ValidationResult Result<R>(this FluentValidation<R> validation)
    {
        validation.Result.Errors = validation.Errors;

        return validation.Result;
    }
}
