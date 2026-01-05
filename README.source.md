# CodingFlow Fluent Validation

[![Nuget](https://img.shields.io/nuget/v/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/CodingFlow/options-bindings-generator/pull-request.yml)
[![Nuget](https://img.shields.io/nuget/dt/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/CodingFlow)](https://github.com/sponsors/CodingFlow)

Minimal, easy to use fluent validations API inspired by [FluentValidation](https://github.com/FluentValidation/FluentValidation).

When you need to validate any type, even primitives in an easy and direct way, this library fits the bill. FluentValidation by Jeremy Skinner requires creating a separate validator class to register validation rules, and then instantiating the validator class. This library on the other hand, let's you add validation directly.

# Usage

After installing the nuget package from Nuget.org, add this using statement to the file where you want to validate:

snippet: StandardUsing

Then you can add validation like this:

snippet: BasicExample

# Validators

There are several built-in validators available out-of-the-box. You can also provide your own validation logic via the [predicate validator](#predicate-validator) (aka `Must`).

## NotEmpty Validator

Ensures the value is not `null` for reference types or a default value for value types. For strings, ensures it is not `null`, an empty string, or only whitespace.

snippet: NotEmptyBasicExample

## BetweenInclusive Validator

Ensures a number of any type (`int`, `float`, `double`, etc.) is greater than a minimum and less than a maximum.

snippet: BetweenInclusiveBasicExample

## BetweenExclusive Validator

Ensures a number of any type (`int`, `float`, `double`, etc.) is greater than or equal to a minimum and less than or equal to a maximum.

snippet: BetweenExclusiveBasicExample

## Equal Validator

Ensures the input is considered equal to the provided value. For reference types it checks if the two references are to the same instance (reference equality). For value types, it checks it the types and values are the same (value equality).

snippet: EqualBasicExample

## Regular Expression Validator

Aka `Matches`, ensure the string passes a regular expression test.

snippet: MatchesBasicExample

## Predicate Validator

The predicate (aka `Must`) validator allows you to provide your own validation logic by providing a delegate.

snippet: MustBasicExample

## IsGuid Validator

Ensures the string can be parsed into a valid GUID.

snippet: IsGuidBasicExample

# Customizing

## Custom Error Messages

The `WithMessage` method can be used to change the validation error message for a validator.

snippet: WithMessageBasicExample

# Integrations

## Vogen

Extensions to integrate with [Vogen](https://github.com/SteveDunn/Vogen) validation methods.

To get started, install the [Vogen extensions](https://www.nuget.org/packages/CodingFlow.FluentValidation.VogenExtensions) nuget package, `CodingFlow.FluentValidation.VogenExtensions`.

To get the final result of the fluent validation chain, call `VogenResult()` instead of `Result()`:

snippet: VogenExample