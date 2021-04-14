## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  7.602 μs | 0.0349 μs | 0.0326 μs |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7.033 μs | 0.0353 μs | 0.0313 μs |  0.93 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 54.314 μs | 0.3855 μs | 0.7427 μs |  7.16 |    0.15 | 14.7705 |     - |     - |  31,142 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15.588 μs | 0.1056 μs | 0.0882 μs |  2.05 |    0.01 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  6.506 μs | 0.0429 μs | 0.0380 μs |  0.86 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.441 μs | 0.0295 μs | 0.0261 μs |  0.72 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  6.677 μs | 0.1302 μs | 0.1447 μs |  0.88 |    0.02 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.064 μs | 0.0278 μs | 0.0217 μs |  0.67 |    0.00 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |           |           |           |       |         |         |       |       |           |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  4.531 μs | 0.0146 μs | 0.0130 μs |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4.539 μs | 0.0231 μs | 0.0193 μs |  1.00 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 49.115 μs | 0.3771 μs | 0.5409 μs | 10.84 |    0.13 | 14.6484 |     - |     - |  30,699 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11.087 μs | 0.0410 μs | 0.0342 μs |  2.45 |    0.01 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3.681 μs | 0.0130 μs | 0.0109 μs |  0.81 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.675 μs | 0.0140 μs | 0.0124 μs |  0.59 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4.257 μs | 0.0255 μs | 0.0238 μs |  0.94 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.942 μs | 0.0104 μs | 0.0092 μs |  0.65 |    0.00 |  0.0191 |     - |     - |      40 B |
