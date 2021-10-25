## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   117.83 ns | 0.335 ns | 0.313 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    93.65 ns | 0.431 ns | 0.382 ns |  1.26x faster |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   843.88 ns | 2.508 ns | 2.095 ns |  7.16x slower |   0.03x | 0.0191 |      40 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   118.73 ns | 0.054 ns | 0.042 ns |  1.01x slower |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   113.20 ns | 0.745 ns | 0.697 ns |  1.04x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   308.07 ns | 1.911 ns | 1.694 ns |  2.61x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,379.28 ns | 7.290 ns | 6.462 ns | 11.70x slower |   0.07x | 0.0305 |      64 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   275.93 ns | 1.569 ns | 1.390 ns |  2.34x slower |   0.01x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    81.99 ns | 0.225 ns | 0.210 ns |  1.44x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    66.07 ns | 0.217 ns | 0.192 ns |  1.78x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    22.77 ns | 0.074 ns | 0.069 ns |  5.17x faster |   0.02x |      - |         - |
|                          |               |                                                                        |               |       |             |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   118.78 ns | 0.537 ns | 0.503 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    82.55 ns | 0.409 ns | 0.382 ns |  1.44x faster |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   274.45 ns | 1.375 ns | 1.286 ns |  2.31x slower |   0.01x | 0.0191 |      40 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   118.21 ns | 0.298 ns | 0.249 ns |  1.00x faster |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   111.29 ns | 0.821 ns | 0.728 ns |  1.07x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   309.25 ns | 1.146 ns | 1.016 ns |  2.60x slower |   0.01x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,350.23 ns | 6.248 ns | 5.539 ns | 11.37x slower |   0.07x | 0.0305 |      64 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   200.40 ns | 2.486 ns | 2.326 ns |  1.69x slower |   0.02x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    82.62 ns | 0.325 ns | 0.304 ns |  1.44x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    66.46 ns | 0.349 ns | 0.310 ns |  1.79x faster |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    21.53 ns | 0.244 ns | 0.204 ns |  5.52x faster |   0.05x |      - |         - |
|                          |               |                                                                        |               |       |             |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   113.19 ns | 0.358 ns | 0.317 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   293.81 ns | 1.293 ns | 1.210 ns |  2.59x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   679.25 ns | 4.065 ns | 3.803 ns |  6.00x slower |   0.04x | 0.0191 |      40 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    86.85 ns | 0.807 ns | 0.715 ns |  1.30x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   121.25 ns | 1.096 ns | 1.026 ns |  1.07x slower |   0.01x | 0.2027 |     424 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   543.48 ns | 2.556 ns | 2.266 ns |  4.80x slower |   0.02x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,461.05 ns | 8.549 ns | 7.996 ns | 12.91x slower |   0.08x | 0.0458 |      96 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   245.81 ns | 1.981 ns | 1.853 ns |  2.17x slower |   0.02x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    93.35 ns | 0.341 ns | 0.302 ns |  1.21x faster |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    91.87 ns | 0.220 ns | 0.184 ns |  1.23x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    45.93 ns | 0.216 ns | 0.191 ns |  2.46x faster |   0.01x |      - |         - |
