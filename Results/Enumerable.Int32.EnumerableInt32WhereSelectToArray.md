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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    549.8 ns |   4.07 ns |   3.81 ns |      baseline |         |  0.7877 |   1,648 B |
|                     Linq |   100 |    794.1 ns |   3.71 ns |   3.47 ns |  1.44x slower |   0.01x |  0.6266 |   1,312 B |
|                   LinqAF |   100 |    920.5 ns |   5.74 ns |   5.09 ns |  1.67x slower |   0.02x |  0.7725 |   1,616 B |
|            LinqOptimizer |   100 | 53,910.6 ns | 270.29 ns | 239.61 ns | 98.01x slower |   0.90x | 15.3198 |  32,109 B |
|                  Streams |   100 |  1,569.1 ns |   7.22 ns |   6.40 ns |  2.85x slower |   0.03x |  1.0319 |   2,160 B |
|               StructLinq |   100 |    937.8 ns |   3.78 ns |   3.53 ns |  1.71x slower |   0.01x |  0.2632 |     552 B |
| StructLinq_ValueDelegate |   100 |    592.1 ns |   3.74 ns |   3.31 ns |  1.08x slower |   0.01x |  0.2213 |     464 B |
|                Hyperlinq |   100 |    899.7 ns |   4.09 ns |   3.83 ns |  1.64x slower |   0.01x |  0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    645.3 ns |   3.26 ns |   2.89 ns |  1.17x slower |   0.01x |  0.2213 |     464 B |
