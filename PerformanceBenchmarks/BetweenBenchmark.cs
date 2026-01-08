namespace PerformanceBenchmarks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using CodingFlow.FluentValidation.Validators;
using static CodingFlow.FluentValidation.Validations;

// begin-snippet: PerformanceBenchmarkBetweenInclusive
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
public class BetweenBenchmark
{
    private readonly int input = 5;

    private readonly IntegerValidator validator = new();

    [Benchmark]
    public bool CodingFlow()
    {
        return RuleFor(input)
            .BetweenInclusive(1, 7)
            .Result()
            .IsValid;
    }

    [Benchmark]
    public bool FluentValidation()
    {
        return validator.Validate(input)
            .IsValid;
    }
}
// end-snippet