## AggressiveInliningBenchmarks

### Source
[AggressiveInliningBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AggressiveInliningBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|             Method | Count |     Mean |   Error |  StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |------ |---------:|--------:|--------:|------:|------:|------:|------:|----------:|
|           Baseline |  1000 | 544.3 ns | 0.85 ns | 0.67 ns |  1.00 |     - |     - |     - |         - |
| AggressiveInlining |  1000 | 544.4 ns | 1.39 ns | 1.23 ns |  1.00 |     - |     - |     - |         - |
