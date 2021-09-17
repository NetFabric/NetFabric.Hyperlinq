## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                  ForLoop |   100 |    330.4 ns |   2.31 ns |   2.16 ns |       baseline |         |  0.3095 |     648 B |
|              ForeachLoop |   100 |    323.4 ns |   1.55 ns |   1.37 ns |   1.02x faster |   0.01x |  0.3095 |     648 B |
|                     Linq |   100 |    594.8 ns |   3.70 ns |   3.28 ns |   1.80x slower |   0.02x |  0.3824 |     800 B |
|               LinqFaster |   100 |    544.8 ns |   4.20 ns |   3.51 ns |   1.65x slower |   0.02x |  0.4396 |     920 B |
|             LinqFasterer |   100 |    496.5 ns |   3.01 ns |   2.66 ns |   1.50x slower |   0.01x |  0.5617 |   1,176 B |
|                   LinqAF |   100 |    710.8 ns |   2.63 ns |   2.46 ns |   2.15x slower |   0.02x |  0.3090 |     648 B |
|            LinqOptimizer |   100 | 53,307.6 ns | 287.70 ns | 269.12 ns | 161.34x slower |   1.22x | 15.1978 |  31,844 B |
|                 SpanLinq |   100 |    536.7 ns |   5.10 ns |   4.77 ns |   1.62x slower |   0.02x |  0.3090 |     648 B |
|                  Streams |   100 |  1,363.6 ns |   7.18 ns |   6.71 ns |   4.13x slower |   0.04x |  0.5684 |   1,192 B |
|               StructLinq |   100 |    579.7 ns |   1.33 ns |   1.11 ns |   1.75x slower |   0.01x |  0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |    338.3 ns |   1.53 ns |   1.28 ns |   1.02x slower |   0.01x |  0.1297 |     272 B |
|                Hyperlinq |   100 |    613.5 ns |   3.54 ns |   3.32 ns |   1.86x slower |   0.02x |  0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    389.7 ns |   2.70 ns |   2.39 ns |   1.18x slower |   0.01x |  0.1297 |     272 B |
