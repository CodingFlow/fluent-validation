namespace CodingFlow.FluentValidation;

public readonly record struct ValidationError
{
    public string Message { get; init; }

    public ValidationError(string message)
    {
        Message = message;
    }
}