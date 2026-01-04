namespace CodingFlow.FluentValidation;

public class FluentValidation<T>
{
    public T Input { get; set; }
    public ValidationResult Result { get; set; }

    public List<ValidationError> Errors { get; init; } = [];

    public ValidationError LastError { get; private set; }

    public FluentValidation(T input)
    {
        Input = input;
        Result = new() { Errors = Errors };
    }

    public void AddValid()
    {
        LastError = default;
    }

    public void AddError(ValidationError error)
    {
        Result.IsValid = false;
        LastError = error;
        Errors.Add(error);
    }

    public void Validate(Func<FluentValidation<T>, bool> validator, ValidationError error)
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
            Errors.RemoveAt(Errors.Count - 1);
            Errors.Add(LastError with
            {
                Message = message
            });
        }
    }
}
