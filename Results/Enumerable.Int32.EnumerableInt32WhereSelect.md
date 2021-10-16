## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    190.3 ns |   0.57 ns |   0.50 ns |       baseline |         |  0.0191 |      40 B |
|                     Linq |   100 |    713.9 ns |   2.88 ns |   2.55 ns |   3.75x slower |   0.02x |  0.0763 |     160 B |
|                   LinqAF |   100 |    559.6 ns |   2.72 ns |   2.12 ns |   2.94x slower |   0.01x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 52,765.9 ns | 267.94 ns | 250.63 ns | 277.24x slower |   1.40x | 14.9536 |  31,276 B |
|                  Streams |   100 |  1,786.3 ns |   6.19 ns |   5.17 ns |   9.39x slower |   0.03x |  0.3548 |     744 B |
|               StructLinq |   100 |    523.5 ns |   0.78 ns |   0.61 ns |   2.75x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate |   100 |    303.2 ns |   0.91 ns |   0.85 ns |   1.59x slower |   0.01x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    569.3 ns |   0.91 ns |   0.71 ns |   2.99x slower |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    379.1 ns |   2.57 ns |   2.28 ns |   1.99x slower |   0.01x |  0.0191 |      40 B |
