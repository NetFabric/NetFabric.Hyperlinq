## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     74.63 ns |   0.479 ns |   0.448 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    710.20 ns |   3.120 ns |   2.605 ns |   9.52 |    0.06 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    841.26 ns |   5.720 ns |   5.071 ns |  11.27 |    0.09 |  0.6533 |     - |     - |   1,368 B |
|             LinqFasterer | 1000 |   100 |    741.86 ns |   9.377 ns |   8.772 ns |   9.94 |    0.13 |  2.5311 |     - |     - |   5,304 B |
|                   LinqAF | 1000 |   100 |  5,318.64 ns |  25.318 ns |  19.767 ns |  71.30 |    0.59 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 52,705.77 ns | 392.746 ns | 367.375 ns | 706.26 |    6.94 | 15.3809 |     - |     - |  32,274 B |
|                  Streams | 1000 |   100 |  7,051.77 ns |  83.870 ns |  70.035 ns |  94.51 |    0.97 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    289.45 ns |   3.997 ns |   3.543 ns |   3.88 |    0.05 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    179.35 ns |   0.681 ns |   0.637 ns |   2.40 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    251.11 ns |   1.486 ns |   1.390 ns |   3.36 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    221.24 ns |   0.379 ns |   0.317 ns |   2.97 |    0.02 |       - |     - |     - |         - |
