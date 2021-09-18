## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    551.1 ns |   1.18 ns |   0.98 ns |      baseline |         |       - |         - |
|              ForeachLoop |   100 |    796.1 ns |   2.44 ns |   2.28 ns |  1.44x slower |   0.00x |       - |         - |
|                     Linq |   100 |  1,301.4 ns |   6.16 ns |   5.76 ns |  2.36x slower |   0.01x |  0.0877 |     184 B |
|               LinqFaster |   100 |  1,791.8 ns |   7.84 ns |   7.34 ns |  3.25x slower |   0.02x |  3.8605 |   8,088 B |
|             LinqFasterer |   100 |  1,788.3 ns |  29.34 ns |  27.45 ns |  3.24x slower |   0.05x |  4.7379 |   9,936 B |
|                   LinqAF |   100 |  1,377.4 ns |   4.92 ns |   4.37 ns |  2.50x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 54,768.1 ns | 506.13 ns | 473.43 ns | 99.42x slower |   0.79x | 73.1201 | 154,832 B |
|                 SpanLinq |   100 |    773.2 ns |   2.51 ns |   2.34 ns |  1.40x slower |   0.00x |       - |         - |
|                  Streams |   100 |  2,098.9 ns |   2.47 ns |   1.93 ns |  3.81x slower |   0.01x |  0.4044 |     848 B |
|               StructLinq |   100 |    651.2 ns |   1.65 ns |   1.54 ns |  1.18x slower |   0.00x |  0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |    577.5 ns |   1.96 ns |   1.74 ns |  1.05x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |  1,010.9 ns |   4.40 ns |   3.90 ns |  1.83x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    878.1 ns |   5.85 ns |   5.47 ns |  1.59x slower |   0.01x |       - |         - |
