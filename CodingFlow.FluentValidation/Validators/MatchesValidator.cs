using System.Text.RegularExpressions;

namespace CodingFlow.FluentValidation.Validators;

public static class MatchesValidator
{
    /// <summary>
    /// Ensures the string matches a given regular expression.
    /// </summary>
    /// <typeparam name="T">Input type.</typeparam>
    /// <param name="validation"></param>
    /// <param name="input">Value to compare against.</param>
    /// <param name="regex">Regular expression to validate the input against.</param>
    /// <returns></returns>
    public static FluentValidation<string> Matches(this FluentValidation<string> validation, string regex)
    {
        Validate(validation, regex);

        return validation;
    }

    private static void Validate(FluentValidation<string> validation, string regex)
    {
        validation.Internal.Validate(
            @internal => Regex.IsMatch(@internal.Input, regex),
            new ValidationError($"Value '{validation.Internal.Input}' does not match the pattern.")
        );
    }
}