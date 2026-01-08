namespace CodingFlow.FluentValidation;

/// <summary>
/// The returned chained object for the fluent API.
/// </summary>
/// <typeparam name="T">Input type.</typeparam>
public record struct FluentValidation<T>
{
    internal ValidationResult Result { get; init; }

    internal List<ValidationError> Errors { get; init; } = [];

    internal T Input { get; private init; }

    private ValidationError LastError { get; set; }

    public FluentValidation(T input)
    {
        Result = new() { Errors = Errors };

        Input = input;
    }

    internal void Validate(Func<FluentValidation<T>, bool> validator, ValidationError error)
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

    internal void ChangeErrorMessage(string message)
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

    private void AddValid()
    {
        LastError = default;
    }

    private void AddError(ValidationError error)
    {
        Result.IsValid = false;
        LastError = error;
        Errors.Add(error);
    }
}
