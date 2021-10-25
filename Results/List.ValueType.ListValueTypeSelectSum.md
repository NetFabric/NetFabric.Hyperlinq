## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   151.70 ns |  0.800 ns |  0.710 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   367.89 ns |  3.190 ns |  2.984 ns |  2.42x slower |   0.03x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,045.16 ns |  7.831 ns |  6.942 ns |  6.89x slower |   0.04x | 0.0458 |      96 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   381.50 ns |  0.790 ns |  0.700 ns |  2.51x slower |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   684.61 ns |  5.801 ns |  5.427 ns |  4.51x slower |   0.04x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,030.09 ns | 14.444 ns | 13.511 ns |  6.79x slower |   0.10x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,518.18 ns |  6.066 ns |  5.674 ns | 10.01x slower |   0.06x | 0.0572 |     120 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   890.82 ns |  5.233 ns |  4.639 ns |  5.87x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   225.26 ns |  0.982 ns |  0.871 ns |  1.48x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    92.80 ns |  0.289 ns |  0.270 ns |  1.63x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   525.67 ns |  7.679 ns |  6.807 ns |  3.47x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   286.47 ns |  0.409 ns |  0.342 ns |  1.89x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,304.73 ns | 13.739 ns | 12.180 ns |  8.60x slower |   0.08x | 0.5836 |   1,224 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   153.53 ns |  0.354 ns |  0.296 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   402.88 ns |  2.815 ns |  2.351 ns |  2.62x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   717.18 ns |  2.069 ns |  1.935 ns |  4.67x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   416.54 ns |  0.924 ns |  0.819 ns |  2.71x slower |   0.01x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   702.38 ns |  6.710 ns |  5.603 ns |  4.57x slower |   0.04x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   986.61 ns |  2.801 ns |  2.483 ns |  6.43x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,424.99 ns |  7.220 ns |  6.401 ns |  9.28x slower |   0.03x | 0.0572 |     120 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   825.90 ns |  5.156 ns |  4.571 ns |  5.38x slower |   0.04x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   244.07 ns |  1.270 ns |  1.188 ns |  1.59x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    95.56 ns |  0.201 ns |  0.178 ns |  1.61x faster |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   533.47 ns |  1.212 ns |  1.012 ns |  3.47x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   283.85 ns |  1.370 ns |  1.215 ns |  1.85x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   901.82 ns |  8.932 ns |  7.458 ns |  5.87x slower |   0.05x | 0.5846 |   1,224 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   217.47 ns |  0.945 ns |  0.789 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   475.84 ns |  1.786 ns |  1.670 ns |  2.19x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,029.64 ns |  2.741 ns |  2.289 ns |  4.73x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   387.10 ns |  0.586 ns |  0.489 ns |  1.78x slower |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   689.89 ns |  8.518 ns |  7.551 ns |  3.18x slower |   0.04x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,806.94 ns | 31.172 ns | 27.633 ns |  8.29x slower |   0.13x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,623.82 ns | 28.354 ns | 44.972 ns |  7.56x slower |   0.26x | 0.0725 |     152 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   895.92 ns |  9.486 ns |  8.873 ns |  4.12x slower |   0.05x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   229.29 ns |  2.581 ns |  2.015 ns |  1.05x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   101.33 ns |  0.288 ns |  0.270 ns |  2.15x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   626.94 ns |  7.857 ns |  6.134 ns |  2.88x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   312.21 ns |  1.478 ns |  1.311 ns |  1.44x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,356.37 ns |  7.386 ns |  6.909 ns |  6.24x slower |   0.03x | 0.5836 |   1,224 B |
