namespace CodingFlow.FluentValidation;

/// <summary>
/// Contains the results of the validation.
/// </summary>
public record ValidationResult
{
    /// <summary>
    /// Indicates if the validation succeeded or failed.
    /// <c>true</c> indicates success. <c>false</c> indicate failure.
    /// Check <see cref="Errors"/> for the errors.
    /// </summary>
    public bool IsValid { get; set; } = true;

    /// <summary>
    /// Collection of validation errors if the validation failed.
    /// This collection will be empty if the validation succeeded.
    /// </summary>
    public required IEnumerable<ValidationError> Errors { get; set; }
}