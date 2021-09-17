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
|                  ForLoop |   100 |    348.7 ns |   1.64 ns |   1.45 ns |       baseline |         |  0.4244 |     888 B |
|              ForeachLoop |   100 |    332.2 ns |   1.38 ns |   1.22 ns |   1.05x faster |   0.01x |  0.4244 |     888 B |
|                     Linq |   100 |    582.7 ns |   1.12 ns |   0.88 ns |   1.67x slower |   0.01x |  0.4015 |     840 B |
|               LinqFaster |   100 |    506.9 ns |  10.16 ns |   9.98 ns |   1.46x slower |   0.03x |  0.4244 |     888 B |
|             LinqFasterer |   100 |    450.8 ns |   2.22 ns |   2.07 ns |   1.29x slower |   0.01x |  0.4320 |     904 B |
|                   LinqAF |   100 |    674.0 ns |   2.67 ns |   2.49 ns |   1.93x slower |   0.01x |  0.4091 |     856 B |
|            LinqOptimizer |   100 | 54,027.7 ns | 251.55 ns | 222.99 ns | 154.96x slower |   1.02x | 15.0757 |  31,571 B |
|                 SpanLinq |   100 |    595.6 ns |   4.28 ns |   3.80 ns |   1.71x slower |   0.01x |  0.4244 |     888 B |
|                  Streams |   100 |  1,023.1 ns |   4.33 ns |   3.84 ns |   2.93x slower |   0.02x |  0.6695 |   1,400 B |
|               StructLinq |   100 |    570.3 ns |   1.51 ns |   1.18 ns |   1.64x slower |   0.01x |  0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |    316.9 ns |   1.57 ns |   1.39 ns |   1.10x faster |   0.01x |  0.1144 |     240 B |
|                Hyperlinq |   100 |    611.3 ns |   2.63 ns |   2.46 ns |   1.75x slower |   0.01x |  0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    402.1 ns |   1.76 ns |   1.56 ns |   1.15x slower |   0.01x |  0.1144 |     240 B |
