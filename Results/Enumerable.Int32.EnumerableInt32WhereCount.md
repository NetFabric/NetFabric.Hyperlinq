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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 |    274.6 ns |   0.44 ns |   0.34 ns |       baseline |         | 0.0191 |      40 B |
|                     Linq |   100 |    360.5 ns |   1.60 ns |   1.49 ns |   1.31x slower |   0.01x | 0.0191 |      40 B |
|                   LinqAF |   100 |    406.1 ns |   1.82 ns |   1.70 ns |   1.48x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |   100 | 40,806.7 ns | 238.96 ns | 211.83 ns | 148.65x slower |   0.84x | 9.7046 |  20,389 B |
|                  Streams |   100 |    856.2 ns |   5.13 ns |   4.80 ns |   3.12x slower |   0.01x | 0.1907 |     400 B |
|               StructLinq |   100 |    363.7 ns |   1.89 ns |   1.77 ns |   1.32x slower |   0.01x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |   100 |    283.1 ns |   1.74 ns |   1.45 ns |   1.03x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |   100 |    366.3 ns |   1.71 ns |   1.51 ns |   1.33x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    210.6 ns |   0.82 ns |   0.77 ns |   1.30x faster |   0.01x | 0.0191 |      40 B |
