## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |   100 |    589.3 ns |   0.94 ns |   0.74 ns |      baseline |         |  0.0458 |      96 B |
|                   LinqAF |   100 |    398.6 ns |   1.74 ns |   1.63 ns |  1.48x faster |   0.01x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 45,457.1 ns | 254.02 ns | 237.61 ns | 77.16x slower |   0.45x | 13.8550 |  29,091 B |
|                  Streams |   100 |  1,513.2 ns |   4.24 ns |   3.54 ns |  2.57x slower |   0.01x |  0.2823 |     592 B |
|               StructLinq |   100 |    450.2 ns |   1.55 ns |   1.45 ns |  1.31x faster |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    286.1 ns |   1.94 ns |   1.62 ns |  2.06x faster |   0.01x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    425.8 ns |   1.78 ns |   1.58 ns |  1.38x faster |   0.01x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    342.1 ns |   1.12 ns |   1.05 ns |  1.72x faster |   0.01x |  0.0191 |      40 B |
