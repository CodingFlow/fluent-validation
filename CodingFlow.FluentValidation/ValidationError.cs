namespace CodingFlow.FluentValidation;

/// <summary>
/// Contains information on a validation error when validation fails.
/// </summary>
public readonly record struct ValidationError
{
    /// <summary>
    /// The error message of the validation error. This message can
    /// be customized by using
    /// <see cref="WithExtensions.WithMessage{T}(FluentValidation{T}, string)">WithMessage</see>.
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Creates the validation error with the given message.
    /// </summary>
    /// <param name="message"></param>
    public ValidationError(string message)
    {
        Message = message;
    }
}