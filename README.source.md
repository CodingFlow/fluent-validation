# CodingFlow Fluent Validation

[![Nuget](https://img.shields.io/nuget/v/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/CodingFlow/fluent-validation/pull-request.yml)
[![Nuget](https://img.shields.io/nuget/dt/CodingFlow.FluentValidation)](https://www.nuget.org/packages/CodingFlow.FluentValidation)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/CodingFlow)](https://github.com/sponsors/CodingFlow)

Minimal, easy to use fluent validations API inspired by [FluentValidation](https://github.com/FluentValidation/FluentValidation).

When you need to validate any type, even primitives in an easy and direct way, this library fits the bill. FluentValidation by Jeremy Skinner requires creating a separate validator class to register validation rules, and then instantiating the validator class. This library on the other hand, let's you add validation directly. This library is also ~ 25% faster performance-wise (See [performance benchmark](#performance-benchmark-comparison-with-fluentvalidation)).

# Usage

After installing the nuget package from Nuget.org, add this using statement to the file where you want to validate:

snippet: StandardUsing

Then you can add validation like this:

snippet: BasicExample

# Validators

There are several built-in validators available out-of-the-box. You can also provide your own validation logic via the [predicate validator](#predicate-validator) (aka `Must`).

## NotEmpty Validator

Ensures the value is not `null` for reference types or a default value for value types. For strings, ensures it is not `null`, an empty string, or only whitespace.

snippet: NotEmptyExample

## BetweenInclusive Validator

Ensures a number of any type (`int`, `float`, `double`, etc.) is greater than or equal to a minimum and less than or equal to a maximum.

snippet: BetweenInclusiveExample

## BetweenExclusive Validator

Ensures a number of any type (`int`, `float`, `double`, etc.) is greater than a minimum and less than a maximum.

snippet: BetweenExclusiveExample

## Equal Validator

Ensures the input is considered equal to the provided value. For reference types it checks if the two references are to the same instance (reference equality). For value types, it checks it the types and values are the same (value equality).

snippet: EqualExample

## MinimumLength Validator

Ensures the string has a minimum length.

snippet: MinimumLengthExample

## MaximumLength Validator

Ensures the string has a maximum length.

snippet: MaximumLengthExample

## Regular Expression Validator

Aka `Matches`, ensure the string passes a regular expression test.

snippet: MatchesExample

## Predicate Validator

The predicate (aka `Must`) validator allows you to provide your own validation logic by providing a delegate.

snippet: MustExample

## IsGuid Validator

Ensures the string can be parsed into a valid GUID.

snippet: IsGuidExample

# Customizing

## Custom Error Messages

The `WithMessage` method can be used to change the validation error message for a validator.

snippet: WithMessageExample

# Integrations

## Vogen

Extensions to integrate with [Vogen](https://github.com/SteveDunn/Vogen) validation methods.

To get started, install the [Vogen extensions](https://www.nuget.org/packages/CodingFlow.FluentValidation.VogenExtensions) nuget package, `CodingFlow.FluentValidation.VogenExtensions`.

To get the final result of the fluent validation chain, call `VogenResult()` instead of `Result()`:

snippet: VogenExample

# Performance Benchmark Comparison with FluentValidation

Benchmark of inclusive between validator shows this library is ~ 25% faster
than FluentValidation.

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
Intel Core Ultra 5 245KF 4.20GHz, 1 CPU, 14 logical and 14 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 9.0  : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3
```

| Method           | Job       | Runtime   | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------- |---------- |---------- |---------:|---------:|---------:|-------:|-------:|----------:|
| CodingFlow       | .NET 10.0 | .NET 10.0 | 34.58 ns | 0.154 ns | 0.144 ns | 0.0249 |      - |     312 B |
| FluentValidation | .NET 10.0 | .NET 10.0 | 46.73 ns | 0.527 ns | 0.493 ns | 0.0471 | 0.0001 |     592 B |
| CodingFlow       | .NET 8.0  | .NET 8.0  | 42.22 ns | 0.418 ns | 0.391 ns | 0.0249 |      - |     312 B |
| FluentValidation | .NET 8.0  | .NET 8.0  | 52.87 ns | 0.390 ns | 0.365 ns | 0.0471 | 0.0001 |     592 B |
| CodingFlow       | .NET 9.0  | .NET 9.0  | 35.42 ns | 0.211 ns | 0.187 ns | 0.0249 |      - |     312 B |
| FluentValidation | .NET 9.0  | .NET 9.0  | 48.73 ns | 0.175 ns | 0.164 ns | 0.0471 | 0.0001 |     592 B |

Benchmark code:

snippet: PerformanceBenchmarkBetweenInclusive

FluentValidation validator:

snippet: IntegerValidator