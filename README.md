# CodingFlow Fluent Validation
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