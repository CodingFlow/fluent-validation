using Vogen;

namespace CodingFlow.FluentValidation.VogenExtensions;

public static class VogenValidations
{
    public static Validation VogenResult<R>(this FluentValidation<R> validation)
    {
        validation.Result = validation.Result();

        return validation.Result.IsValid
            ? Validation.Ok
            : Validation.Invalid(validation.Result.Errors.First().Message);
    }
}
