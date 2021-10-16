## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    349.52 ns |   1.862 ns |   1.742 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    387.04 ns |   3.512 ns |   3.114 ns |   1.11x slower |   0.01x |  0.5660 |   1,184 B |
|                         Linq |   100 |    334.20 ns |   0.990 ns |   0.827 ns |   1.05x faster |   0.00x |  0.2522 |     528 B |
|                   LinqFaster |   100 |    362.74 ns |   2.146 ns |   2.008 ns |   1.04x slower |   0.01x |  0.4358 |     912 B |
|                 LinqFasterer |   100 |    358.61 ns |   2.211 ns |   2.068 ns |   1.03x slower |   0.01x |  0.6232 |   1,304 B |
|                       LinqAF |   100 |    690.11 ns |   3.787 ns |   3.543 ns |   1.97x slower |   0.01x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 40,926.98 ns | 220.128 ns | 205.908 ns | 117.10x slower |   0.93x | 13.9771 |  29,360 B |
|                     SpanLinq |   100 |    355.90 ns |   1.360 ns |   1.272 ns |   1.02x slower |   0.01x |  0.2179 |     456 B |
|                      Streams |   100 |  1,556.45 ns |   6.177 ns |   5.778 ns |   4.45x slower |   0.03x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    281.94 ns |   1.353 ns |   1.266 ns |   1.24x faster |   0.01x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    155.20 ns |   0.621 ns |   0.550 ns |   2.25x faster |   0.01x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    270.04 ns |   1.582 ns |   1.480 ns |   1.29x faster |   0.01x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    143.85 ns |   0.613 ns |   0.511 ns |   2.43x faster |   0.02x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    106.65 ns |   0.554 ns |   0.491 ns |   3.28x faster |   0.02x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     71.31 ns |   0.574 ns |   0.479 ns |   4.90x faster |   0.04x |  0.2180 |     456 B |
