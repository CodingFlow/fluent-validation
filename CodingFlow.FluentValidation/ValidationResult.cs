namespace CodingFlow.FluentValidation;

public record ValidationResult
{
    public bool IsValid { get; set; } = true;
    public IEnumerable<ValidationError> Errors { get; set; }
}