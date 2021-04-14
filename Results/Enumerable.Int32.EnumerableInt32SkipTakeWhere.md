## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5.068 μs | 0.0237 μs | 0.0210 μs |  1.00 |    0.00 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 15.466 μs | 0.1093 μs | 0.0969 μs |  3.05 |    0.03 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13.979 μs | 0.0447 μs | 0.0418 μs |  2.76 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 69.100 μs | 0.5815 μs | 0.4540 μs | 13.63 |    0.11 | 16.8457 |     - |     - |  35,265 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 27.192 μs | 0.2059 μs | 0.1826 μs |  5.37 |    0.04 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10.611 μs | 0.0398 μs | 0.0353 μs |  2.09 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.308 μs | 0.0491 μs | 0.0435 μs |  1.84 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10.898 μs | 0.0675 μs | 0.0632 μs |  2.15 |    0.02 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 | 10.184 μs | 0.0423 μs | 0.0353 μs |  2.01 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  3.435 μs | 0.0147 μs | 0.0123 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 10.002 μs | 0.0361 μs | 0.0301 μs |  2.91 |    0.01 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 11.566 μs | 0.1019 μs | 0.0851 μs |  3.37 |    0.03 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 61.726 μs | 1.0804 μs | 1.2861 μs | 18.04 |    0.47 | 16.6016 |     - |     - |  34,822 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 19.760 μs | 0.0655 μs | 0.0613 μs |  5.75 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.500 μs | 0.0399 μs | 0.0354 μs |  2.18 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.775 μs | 0.0291 μs | 0.0258 μs |  1.97 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  8.743 μs | 0.0399 μs | 0.0311 μs |  2.55 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.183 μs | 0.0182 μs | 0.0152 μs |  1.80 |    0.01 |  0.0153 |     - |     - |      40 B |
