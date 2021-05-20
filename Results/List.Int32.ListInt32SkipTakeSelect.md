## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     76.61 ns |   0.602 ns |   0.533 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    763.70 ns |   7.440 ns |   6.596 ns |   9.97x slower |   0.11x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    888.64 ns |   6.367 ns |   5.645 ns |  11.60x slower |   0.14x |  0.6523 |     - |     - |   1,368 B |
|             LinqFasterer | 1000 |   100 |    759.85 ns |  10.435 ns |   9.760 ns |   9.91x slower |   0.14x |  2.5311 |     - |     - |   5,304 B |
|                   LinqAF | 1000 |   100 |  6,258.21 ns |  61.481 ns |  54.501 ns |  81.69x slower |   0.72x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 55,967.06 ns | 473.374 ns | 803.825 ns | 731.01x slower |   9.86x | 15.3809 |     - |     - |  32,273 B |
|                 SpanLinq | 1000 |   100 |    231.42 ns |   1.279 ns |   1.134 ns |   3.02x slower |   0.02x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  7,423.73 ns | 105.707 ns |  93.706 ns |  96.91x slower |   1.47x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    238.16 ns |   4.829 ns |   7.079 ns |   3.18x slower |   0.09x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    183.25 ns |   0.804 ns |   0.671 ns |   2.39x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    233.57 ns |   1.211 ns |   1.133 ns |   3.05x slower |   0.03x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    229.68 ns |   2.411 ns |   2.255 ns |   3.00x slower |   0.03x |       - |     - |     - |         - |
