## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 |    274.6 ns |   1.46 ns |   1.37 ns |       baseline |         | 0.0191 |      40 B |
|                     Linq |   100 |    360.5 ns |   1.52 ns |   1.35 ns |   1.31x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |   100 |    407.4 ns |   1.82 ns |   1.70 ns |   1.48x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |   100 | 40,693.5 ns | 258.27 ns | 241.59 ns | 148.18x slower |   1.22x | 9.7046 |  20,389 B |
|                  Streams |   100 |    839.0 ns |   2.40 ns |   2.24 ns |   3.06x slower |   0.02x | 0.1907 |     400 B |
|               StructLinq |   100 |    363.6 ns |   1.44 ns |   1.35 ns |   1.32x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |   100 |    282.4 ns |   1.17 ns |   1.10 ns |   1.03x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |   100 |    365.3 ns |   0.92 ns |   0.86 ns |   1.33x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    208.7 ns |   0.57 ns |   0.47 ns |   1.32x faster |   0.01x | 0.0191 |      40 B |
