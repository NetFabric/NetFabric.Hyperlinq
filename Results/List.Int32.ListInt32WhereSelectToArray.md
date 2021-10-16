## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop |   100 |    350.6 ns |   1.83 ns |   1.62 ns |       baseline |         |  0.4244 |     888 B |
|              ForeachLoop |   100 |    338.0 ns |   1.69 ns |   1.50 ns |   1.04x faster |   0.01x |  0.4244 |     888 B |
|                     Linq |   100 |    599.0 ns |   3.13 ns |   2.93 ns |   1.71x slower |   0.01x |  0.4015 |     840 B |
|               LinqFaster |   100 |    513.8 ns |   4.56 ns |   3.56 ns |   1.47x slower |   0.01x |  0.4244 |     888 B |
|             LinqFasterer |   100 |    454.2 ns |   3.04 ns |   2.84 ns |   1.29x slower |   0.01x |  0.4320 |     904 B |
|                   LinqAF |   100 |    681.3 ns |   2.69 ns |   2.52 ns |   1.94x slower |   0.01x |  0.4091 |     856 B |
|            LinqOptimizer |   100 | 53,669.5 ns | 217.83 ns | 193.10 ns | 153.10x slower |   0.78x | 15.0757 |  31,571 B |
|                 SpanLinq |   100 |    603.8 ns |   2.63 ns |   2.46 ns |   1.72x slower |   0.01x |  0.4244 |     888 B |
|                  Streams |   100 |  1,049.2 ns |   5.34 ns |   4.99 ns |   2.99x slower |   0.02x |  0.6695 |   1,400 B |
|               StructLinq |   100 |    627.5 ns |   3.38 ns |   3.17 ns |   1.79x slower |   0.01x |  0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |    326.7 ns |   1.79 ns |   1.67 ns |   1.07x faster |   0.01x |  0.1144 |     240 B |
|                Hyperlinq |   100 |    602.9 ns |   1.71 ns |   1.60 ns |   1.72x slower |   0.01x |  0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    371.9 ns |   1.17 ns |   0.98 ns |   1.06x slower |   0.01x |  0.1144 |     240 B |
