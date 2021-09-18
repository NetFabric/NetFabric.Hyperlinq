## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     93.25 ns |   0.222 ns |   0.197 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    126.31 ns |   0.545 ns |   0.510 ns |   1.35x slower |   0.01x |       - |         - |
|                     Linq |   100 |    669.66 ns |   3.604 ns |   3.371 ns |   7.18x slower |   0.04x |  0.0343 |      72 B |
|               LinqFaster |   100 |    464.75 ns |   2.453 ns |   2.049 ns |   4.98x slower |   0.02x |  0.3095 |     648 B |
|             LinqFasterer |   100 |    422.68 ns |   1.257 ns |   1.176 ns |   4.53x slower |   0.02x |  0.3328 |     696 B |
|                   LinqAF |   100 |    477.67 ns |   3.187 ns |   2.981 ns |   5.13x slower |   0.03x |       - |         - |
|            LinqOptimizer |   100 | 46,145.82 ns | 295.035 ns | 275.976 ns | 494.97x slower |   3.34x | 13.6719 |  28,651 B |
|                 SpanLinq |   100 |    347.87 ns |   0.511 ns |   0.453 ns |   3.73x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,158.07 ns |   4.386 ns |   4.103 ns |  12.41x slower |   0.05x |  0.2899 |     608 B |
|               StructLinq |   100 |    373.82 ns |   3.091 ns |   2.740 ns |   4.01x slower |   0.03x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    183.30 ns |   0.656 ns |   0.548 ns |   1.97x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    330.72 ns |   4.420 ns |   4.135 ns |   3.54x slower |   0.04x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    219.51 ns |   0.302 ns |   0.252 ns |   2.35x slower |   0.01x |       - |         - |
