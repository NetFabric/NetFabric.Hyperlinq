## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 |    245.7 ns |   0.42 ns |   0.35 ns |       baseline |         | 0.0191 |      40 B |
|                     Linq |   100 |    273.3 ns |   1.08 ns |   0.96 ns |   1.11x slower |   0.00x | 0.0191 |      40 B |
|                   LinqAF |   100 |    313.1 ns |   1.79 ns |   1.59 ns |   1.27x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |   100 | 27,472.8 ns | 120.75 ns | 107.04 ns | 111.76x slower |   0.35x | 8.2397 |  17,274 B |
|                  Streams |   100 |    336.0 ns |   2.25 ns |   2.00 ns |   1.37x slower |   0.01x | 0.1183 |     248 B |
|               StructLinq |   100 |    286.7 ns |   0.31 ns |   0.24 ns |   1.17x slower |   0.00x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    275.4 ns |   0.90 ns |   0.80 ns |   1.12x slower |   0.00x | 0.0191 |      40 B |
|                Hyperlinq |   100 |    247.1 ns |   0.74 ns |   0.62 ns |   1.01x slower |   0.00x | 0.0191 |      40 B |
