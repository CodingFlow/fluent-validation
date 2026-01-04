namespace CodingFlow.FluentValidation.VogenExtensions;

public static class VogenValidations
{
    extension<R>(FluentValidation<R> validation)
    {
        public Vogen.Validation VogenResult()
        {
            validation.Result = validation.Result();

            return validation.Result.IsValid
                ? Vogen.Validation.Ok
                : Vogen.Validation.Invalid(validation.Result.Errors.First().Message);
        }
    }
}
