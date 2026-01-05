namespace CodingFlow.FluentValidation;

public class Internal<T>(FluentValidation<T> validation)
{
    public required T Input { get; set; }

    public ValidationError LastError { get; private set; }

    public void AddValid()
    {
        LastError = default;
    }

    public void AddError(ValidationError error)
    {
        validation.Result.IsValid = false;
        LastError = error;
        validation.Errors.Add(error);
    }

    public void Validate(Func<FluentValidation<T>, bool> validator, ValidationError error)
    {
        if (validator(validation))
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
}