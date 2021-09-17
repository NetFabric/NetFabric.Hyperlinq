## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    543.5 ns |   3.96 ns |   3.71 ns |      baseline |         |  0.7877 |   1,648 B |
|                     Linq |   100 |    888.2 ns |   4.22 ns |   3.74 ns |  1.64x slower |   0.01x |  0.6266 |   1,312 B |
|                   LinqAF |   100 |    892.1 ns |   4.86 ns |   4.31 ns |  1.64x slower |   0.02x |  0.7725 |   1,616 B |
|            LinqOptimizer |   100 | 52,040.9 ns | 282.56 ns | 264.31 ns | 95.76x slower |   0.70x | 15.3198 |  32,109 B |
|                  Streams |   100 |  1,560.0 ns |   8.52 ns |   7.97 ns |  2.87x slower |   0.02x |  1.0319 |   2,160 B |
|               StructLinq |   100 |    922.1 ns |   4.37 ns |   3.65 ns |  1.70x slower |   0.01x |  0.2632 |     552 B |
| StructLinq_ValueDelegate |   100 |    592.5 ns |   4.31 ns |   3.82 ns |  1.09x slower |   0.01x |  0.2213 |     464 B |
|                Hyperlinq |   100 |    942.6 ns |   5.36 ns |   4.75 ns |  1.74x slower |   0.01x |  0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    645.3 ns |   2.77 ns |   2.31 ns |  1.19x slower |   0.01x |  0.2213 |     464 B |
