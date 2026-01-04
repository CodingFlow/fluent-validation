# CodingFlow Fluent Validation

[![Nuget](https://img.shields.io/nuget/v/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/CodingFlow/options-bindings-generator/pull-request.yml)
[![Nuget](https://img.shields.io/nuget/dt/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/CodingFlow)](https://github.com/sponsors/CodingFlow)

Minimal, easy to use fluent validations API inspired by [FluentValidation](https://github.com/FluentValidation/FluentValidation).

When you need to validate any type, even primitives in an easy and direct way, this library fits the bill. FluentValidation by Jeremy Skinner requires creating a separate validator class to register validation rules, and then instantiating the validator class. This library on the other hand, let's you add validation directly.

# Usage

After installing the nuget package from Nuget.org, add this using statement to the file where you want to validate:

```csharp
using static CodingFlow.FluentValidation.Validations;
```

Then you can add validation like this:

```csharp
var input = 11;

var result = RuleFor(input)
    .Between(4, 6)
    .Result();

// Check results
bool isValid = result.IsValid;
var errors = result.Errors;
```

# Integrations

## Vogen

Extensions to integrate with Vogen validation methods.

To get started, install the Vogen extensions nuget package, `CodingFlow.FluentValidation.VogenExtensions`.

To get the final result of the fluent validation chain, call `VogenResult()` instead of `Result()`:

```csharp
[ValueObject]
public readonly partial struct Age
{
    public static Validation Validate(int value)
    {
        return RuleFor(value)
            .BetweenInclusive(0, 200)
            .VogenResult();
    }
}
```