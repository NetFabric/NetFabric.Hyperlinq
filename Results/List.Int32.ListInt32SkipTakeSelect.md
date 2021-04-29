## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     74.18 ns |   0.376 ns |   0.352 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  3,721.76 ns |  23.900 ns |  21.187 ns |  50.17 |    0.29 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |    727.65 ns |  10.109 ns |   8.961 ns |   9.81 |    0.14 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    789.73 ns |   3.758 ns |   3.331 ns |  10.65 |    0.07 |  0.6533 |     - |     - |   1,368 B |
|                   LinqAF | 1000 |   100 |  5,221.59 ns |  37.794 ns |  33.503 ns |  70.39 |    0.58 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 63,519.03 ns | 768.916 ns | 642.079 ns | 856.39 |   10.55 | 15.3809 |     - |     - |  32,273 B |
|                  Streams | 1000 |   100 |  7,338.75 ns |  37.313 ns |  33.077 ns |  98.93 |    0.68 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    233.56 ns |   0.967 ns |   0.857 ns |   3.15 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    164.58 ns |   0.557 ns |   0.521 ns |   2.22 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    209.74 ns |   0.666 ns |   0.623 ns |   2.83 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    202.71 ns |   1.360 ns |   1.136 ns |   2.73 |    0.02 |       - |     - |     - |         - |
