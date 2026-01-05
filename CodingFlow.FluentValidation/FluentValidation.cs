namespace CodingFlow.FluentValidation;

/// <summary>
/// The returned chained object for the fluent API.
/// </summary>
/// <typeparam name="T">Input type.</typeparam>
public class FluentValidation<T>
{
    public ValidationResult Result { get; set; }

    public List<ValidationError> Errors { get; init; } = [];

    /// <summary>
    /// Used internally by the library. Do not use this property
    /// unless you are building your own validator.
    /// </summary>
    public Internal<T> Internal { get; private set; }

    public FluentValidation(T input)
    {
        Result = new() { Errors = Errors };
        
        Internal = new Internal<T>(this)
        {
            Input = input
        };
    }
}
