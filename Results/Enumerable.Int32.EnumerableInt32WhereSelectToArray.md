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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    547.0 ns |   2.74 ns |   2.56 ns |      baseline |         |  0.7877 |   1,648 B |
|                     Linq |   100 |    794.4 ns |   4.28 ns |   4.00 ns |  1.45x slower |   0.01x |  0.6266 |   1,312 B |
|                   LinqAF |   100 |    899.4 ns |   4.92 ns |   4.11 ns |  1.64x slower |   0.01x |  0.7725 |   1,616 B |
|            LinqOptimizer |   100 | 53,461.5 ns | 272.57 ns | 254.97 ns | 97.73x slower |   0.72x | 15.3198 |  32,109 B |
|                  Streams |   100 |  1,602.2 ns |   6.15 ns |   5.75 ns |  2.93x slower |   0.02x |  1.0319 |   2,160 B |
|               StructLinq |   100 |    932.9 ns |   3.22 ns |   2.86 ns |  1.71x slower |   0.01x |  0.2632 |     552 B |
| StructLinq_ValueDelegate |   100 |    604.8 ns |   2.07 ns |   1.84 ns |  1.11x slower |   0.01x |  0.2213 |     464 B |
|                Hyperlinq |   100 |    936.2 ns |   2.54 ns |   2.37 ns |  1.71x slower |   0.01x |  0.2213 |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    640.0 ns |   2.76 ns |   2.59 ns |  1.17x slower |   0.01x |  0.2213 |     464 B |
