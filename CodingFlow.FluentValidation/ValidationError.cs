namespace CodingFlow.FluentValidation;

public record struct ValidationError
{
    public string Message { get; set; }

    public ValidationError(string message)
    {
        Message = message;
    }
}