using Vogen;

namespace CodingFlow.FluentValidation.VogenExtensions;

public static class VogenValidations
{
    /// <summary>
    /// Creates the validation results for the validation chain and returns it
    /// Vogen pass or fail types.
    /// </summary>
    /// <typeparam name="R">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <returns>On validation success a <see cref="Validation.Ok"/> or if
    /// validation fails a <see cref="Validation.Invalid(string)"/>.</returns>
    public static Validation VogenResult<R>(this FluentValidation<R> validation)
    {
        validation.Result = validation.Result();

        return validation.Result.IsValid
            ? Validation.Ok
            : Validation.Invalid(validation.Result.Errors.First().Message);
    }
}
