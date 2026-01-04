namespace CodingFlow.FluentValidation;

public class FluentValidation<T>
{
    public T Input { get; set; }
    public ValidationResult Result { get; set; }

    public List<ValidationError> Errors { get; set; } = [];

    public FluentValidation(T input)
    {
        Input = input;
        Result = new() { Errors = Errors };
    }
}
