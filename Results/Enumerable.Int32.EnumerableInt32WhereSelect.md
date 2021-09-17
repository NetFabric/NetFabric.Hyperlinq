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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    189.2 ns |   0.60 ns |   0.56 ns |       baseline |         |  0.0191 |      40 B |
|                     Linq |   100 |    748.2 ns |   3.29 ns |   2.75 ns |   3.95x slower |   0.01x |  0.0763 |     160 B |
|                   LinqAF |   100 |    496.0 ns |   0.68 ns |   0.57 ns |   2.62x slower |   0.01x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 50,892.1 ns | 342.03 ns | 319.93 ns | 268.93x slower |   1.11x | 14.9536 |  31,276 B |
|                  Streams |   100 |  1,839.4 ns |  29.05 ns |  27.17 ns |   9.72x slower |   0.13x |  0.3548 |     744 B |
|               StructLinq |   100 |    532.4 ns |   0.49 ns |   0.38 ns |   2.81x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate |   100 |    380.4 ns |   1.51 ns |   1.34 ns |   2.01x slower |   0.01x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    563.3 ns |   0.83 ns |   0.65 ns |   2.98x slower |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    376.3 ns |   1.31 ns |   1.22 ns |   1.99x slower |   0.01x |  0.0191 |      40 B |
