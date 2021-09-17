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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     93.43 ns |   0.296 ns |   0.277 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    125.70 ns |   0.237 ns |   0.185 ns |   1.35x slower |   0.00x |       - |         - |
|                     Linq |   100 |    666.61 ns |   3.505 ns |   3.279 ns |   7.13x slower |   0.04x |  0.0343 |      72 B |
|               LinqFaster |   100 |    475.62 ns |   1.277 ns |   1.066 ns |   5.09x slower |   0.02x |  0.3090 |     648 B |
|             LinqFasterer |   100 |    445.15 ns |   2.035 ns |   1.903 ns |   4.76x slower |   0.03x |  0.3328 |     696 B |
|                   LinqAF |   100 |    448.33 ns |   5.346 ns |   4.739 ns |   4.80x slower |   0.05x |       - |         - |
|            LinqOptimizer |   100 | 45,750.54 ns | 265.963 ns | 248.782 ns | 489.67x slower |   2.82x | 13.6719 |  28,650 B |
|                 SpanLinq |   100 |    279.90 ns |   1.031 ns |   0.964 ns |   3.00x slower |   0.02x |       - |         - |
|                  Streams |   100 |  1,144.54 ns |   7.096 ns |   6.290 ns |  12.25x slower |   0.09x |  0.2899 |     608 B |
|               StructLinq |   100 |    369.97 ns |   5.867 ns |   5.201 ns |   3.96x slower |   0.05x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    182.58 ns |   0.354 ns |   0.296 ns |   1.95x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |    307.03 ns |   5.124 ns |   4.542 ns |   3.29x slower |   0.05x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    220.37 ns |   0.540 ns |   0.505 ns |   2.36x slower |   0.01x |       - |         - |
