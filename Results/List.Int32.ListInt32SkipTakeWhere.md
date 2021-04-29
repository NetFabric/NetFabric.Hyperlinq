## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    121.0 ns |   1.40 ns |   1.31 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    765.1 ns |   5.14 ns |   4.56 ns |   6.33 |    0.08 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    860.1 ns |   8.36 ns |   7.41 ns |   7.12 |    0.10 |  0.7458 |     - |     - |   1,560 B |
|             LinqFasterer | 1000 |   100 |    795.6 ns |   9.91 ns |   9.27 ns |   6.58 |    0.11 |  2.4424 |     - |     - |   5,112 B |
|                   LinqAF | 1000 |   100 |  6,585.8 ns |  46.08 ns |  38.48 ns |  54.47 |    0.73 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 56,702.5 ns | 268.09 ns | 237.65 ns | 469.10 |    4.49 | 15.6860 |     - |     - |  32,884 B |
|                  Streams | 1000 |   100 |  7,376.7 ns |  20.03 ns |  17.76 ns |  61.03 |    0.72 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    337.4 ns |   5.03 ns |   4.46 ns |   2.79 |    0.04 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    171.8 ns |   1.66 ns |   1.55 ns |   1.42 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    339.7 ns |   6.24 ns |   5.21 ns |   2.81 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    223.5 ns |   0.77 ns |   0.72 ns |   1.85 |    0.02 |       - |     - |     - |         - |
