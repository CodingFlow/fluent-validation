namespace CodingFlow.FluentValidation;

internal class Internal<T>(FluentValidation<T> validation)
{
    public required T Input { get; set; }

    private ValidationError LastError { get; set; }

    public void Validate(Func<Internal<T>, bool> validator, ValidationError error)
    {
        if (validator(this))
        {
            AddValid();
        }
        else
        {
            AddError(error);
        }
    }

    public void ChangeErrorMessage(string message)
    {
        if (LastError != default)
        {
            validation.Errors.RemoveAt(validation.Errors.Count - 1);
            validation.Errors.Add(LastError with
            {
                Message = message
            });
        }
    }

    private void AddValid()
    {
        LastError = default;
    }

    private void AddError(ValidationError error)
    {
        validation.Result.IsValid = false;
        LastError = error;
        validation.Errors.Add(error);
    }
}