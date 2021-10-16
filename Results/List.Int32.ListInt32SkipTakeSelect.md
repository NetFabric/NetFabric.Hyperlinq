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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     79.90 ns |   0.317 ns |   0.281 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    465.96 ns |   0.809 ns |   0.675 ns |   5.83x slower |   0.02x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    843.80 ns |   2.898 ns |   2.569 ns |  10.56x slower |   0.05x |  0.6542 |   1,368 B |
|             LinqFasterer | 1000 |   100 |    812.22 ns |  16.229 ns |  21.102 ns |  10.17x slower |   0.27x |  2.5311 |   5,304 B |
|                   LinqAF | 1000 |   100 |  3,112.27 ns |   8.021 ns |   7.503 ns |  38.96x slower |   0.09x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 57,043.56 ns | 242.001 ns | 202.082 ns | 714.25x slower |   3.88x | 15.3809 |  32,273 B |
|                 SpanLinq | 1000 |   100 |    305.77 ns |   0.536 ns |   0.502 ns |   3.83x slower |   0.02x |       - |         - |
|                  Streams | 1000 |   100 |  7,230.13 ns |  14.993 ns |  14.024 ns |  90.49x slower |   0.39x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    277.25 ns |   1.008 ns |   0.943 ns |   3.47x slower |   0.02x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    178.34 ns |   0.319 ns |   0.299 ns |   2.23x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    248.43 ns |   0.514 ns |   0.481 ns |   3.11x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    218.87 ns |   0.344 ns |   0.322 ns |   2.74x slower |   0.01x |       - |         - |
