// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using PerformanceBenchmarks;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<BetweenBenchmark>();