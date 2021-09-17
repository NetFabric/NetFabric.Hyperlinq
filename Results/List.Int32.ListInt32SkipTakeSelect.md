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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     78.93 ns |   0.086 ns |   0.067 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    467.49 ns |   2.022 ns |   1.891 ns |   5.92x slower |   0.02x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    818.68 ns |   3.078 ns |   2.729 ns |  10.37x slower |   0.04x |  0.6542 |   1,368 B |
|             LinqFasterer | 1000 |   100 |    894.60 ns |  17.726 ns |  20.413 ns |  11.28x slower |   0.27x |  2.5311 |   5,304 B |
|                   LinqAF | 1000 |   100 |  3,109.83 ns |  10.369 ns |   9.699 ns |  39.39x slower |   0.14x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 58,098.00 ns | 265.573 ns | 248.417 ns | 736.16x slower |   3.19x | 15.3809 |  32,273 B |
|                 SpanLinq | 1000 |   100 |    277.82 ns |   0.366 ns |   0.286 ns |   3.52x slower |   0.00x |       - |         - |
|                  Streams | 1000 |   100 |  7,212.63 ns |  22.378 ns |  20.932 ns |  91.39x slower |   0.24x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    252.92 ns |   1.435 ns |   1.342 ns |   3.21x slower |   0.02x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    178.31 ns |   0.554 ns |   0.491 ns |   2.26x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    272.38 ns |   0.963 ns |   0.854 ns |   3.45x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    222.11 ns |   0.450 ns |   0.421 ns |   2.81x slower |   0.01x |       - |         - |
