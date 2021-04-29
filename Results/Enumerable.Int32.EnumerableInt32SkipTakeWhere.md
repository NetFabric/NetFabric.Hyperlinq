## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop | 1000 |   100 |  2.797 μs | 0.0096 μs | 0.0090 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |  3.646 μs | 0.0279 μs | 0.0261 μs |  1.30 |    0.01 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.490 μs | 0.0148 μs | 0.0131 μs |  1.25 |    0.00 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 53.548 μs | 0.3508 μs | 0.3110 μs | 19.15 |    0.13 | 15.9302 |     - |     - |  33,421 B |
|                  Streams | 1000 |   100 |  8.536 μs | 0.0805 μs | 0.0672 μs |  3.05 |    0.03 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.964 μs | 0.0365 μs | 0.0324 μs |  1.06 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.440 μs | 0.0102 μs | 0.0091 μs |  0.87 |    0.00 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  2.522 μs | 0.0127 μs | 0.0113 μs |  0.90 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.427 μs | 0.0134 μs | 0.0119 μs |  1.23 |    0.01 |  0.0191 |     - |     - |      40 B |
