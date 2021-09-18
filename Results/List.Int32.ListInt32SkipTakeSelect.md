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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                  ForLoop | 1000 |   100 |     79.36 ns |   0.258 ns |   0.242 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    469.98 ns |   1.652 ns |   1.546 ns |   5.92x slower |   0.02x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    831.53 ns |  15.316 ns |  15.728 ns |  10.49x slower |   0.20x |  0.6542 |   1,368 B |
|             LinqFasterer | 1000 |   100 |    768.33 ns |   5.263 ns |   4.109 ns |   9.68x slower |   0.06x |  2.5311 |   5,304 B |
|                   LinqAF | 1000 |   100 |  3,121.70 ns |   8.935 ns |   8.358 ns |  39.34x slower |   0.19x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 57,634.78 ns | 207.071 ns | 183.563 ns | 726.22x slower |   2.46x | 15.3809 |  32,273 B |
|                 SpanLinq | 1000 |   100 |    279.19 ns |   1.202 ns |   1.124 ns |   3.52x slower |   0.02x |       - |         - |
|                  Streams | 1000 |   100 |  7,227.30 ns |  23.787 ns |  21.086 ns |  91.07x slower |   0.39x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    253.87 ns |   0.324 ns |   0.253 ns |   3.20x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    178.51 ns |   0.272 ns |   0.254 ns |   2.25x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    270.86 ns |   0.517 ns |   0.404 ns |   3.41x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    217.09 ns |   0.265 ns |   0.248 ns |   2.74x slower |   0.01x |       - |         - |
