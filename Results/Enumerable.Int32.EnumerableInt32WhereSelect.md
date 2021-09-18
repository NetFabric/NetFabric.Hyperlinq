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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    190.0 ns |   0.84 ns |   0.79 ns |       baseline |         |  0.0191 |      40 B |
|                     Linq |   100 |    751.9 ns |   4.03 ns |   3.77 ns |   3.96x slower |   0.02x |  0.0763 |     160 B |
|                   LinqAF |   100 |    577.2 ns |   0.57 ns |   0.44 ns |   3.04x slower |   0.01x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 52,140.9 ns | 284.04 ns | 251.79 ns | 274.35x slower |   1.62x | 14.9536 |  31,276 B |
|                  Streams |   100 |  1,826.2 ns |   7.69 ns |   7.19 ns |   9.61x slower |   0.06x |  0.3548 |     744 B |
|               StructLinq |   100 |    535.7 ns |   3.26 ns |   2.89 ns |   2.82x slower |   0.02x |  0.0458 |      96 B |
| StructLinq_ValueDelegate |   100 |    381.3 ns |   1.68 ns |   1.49 ns |   2.01x slower |   0.01x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    566.4 ns |   4.53 ns |   4.23 ns |   2.98x slower |   0.03x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    377.2 ns |   1.33 ns |   1.25 ns |   1.98x slower |   0.01x |  0.0191 |      40 B |
