namespace CodingFlow.FluentValidation;

/// <summary>
/// The returned chained object for the fluent API.
/// </summary>
/// <typeparam name="T">Input type.</typeparam>
public class FluentValidation<T>
{
    public ValidationResult Result { get; init; }

    public List<ValidationError> Errors { get; init; } = [];

    internal Internal<T> Internal { get; private init; }

    public FluentValidation(T input)
    {
        Result = new() { Errors = Errors };
        
        Internal = new Internal<T>(this)
        {
            Input = input
        };
    }
}
