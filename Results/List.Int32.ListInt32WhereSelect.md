## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    76.67 ns |  0.417 ns |  0.390 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   132.81 ns |  0.442 ns |  0.392 ns |  1.73x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   925.01 ns |  5.466 ns |  4.845 ns | 12.06x slower |   0.08x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   598.68 ns |  4.576 ns |  4.280 ns |  7.81x slower |   0.06x | 0.3090 |     648 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   783.62 ns |  5.270 ns |  4.929 ns | 10.22x slower |   0.09x | 0.4473 |     936 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,058.00 ns |  6.283 ns |  5.246 ns | 13.79x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,700.53 ns | 31.182 ns | 29.167 ns | 35.22x slower |   0.44x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,928.65 ns |  9.983 ns |  8.850 ns | 25.16x slower |   0.21x | 0.3624 |     760 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   355.61 ns |  0.850 ns |  0.664 ns |  4.64x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   196.53 ns |  0.510 ns |  0.452 ns |  2.56x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   360.46 ns |  1.412 ns |  1.251 ns |  4.70x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   228.71 ns |  0.681 ns |  0.568 ns |  2.98x slower |   0.02x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   611.31 ns |  5.155 ns |  4.305 ns |  7.97x slower |   0.07x | 0.3090 |     648 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    78.93 ns |  0.651 ns |  0.609 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    87.62 ns |  0.465 ns |  0.435 ns |  1.11x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   490.33 ns |  2.798 ns |  2.617 ns |  6.21x slower |   0.06x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   526.86 ns |  3.318 ns |  2.941 ns |  6.67x slower |   0.06x | 0.3090 |     648 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   560.22 ns |  3.962 ns |  3.706 ns |  7.10x slower |   0.07x | 0.4473 |     936 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   438.30 ns |  1.786 ns |  1.583 ns |  5.55x slower |   0.05x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,532.39 ns | 27.121 ns | 25.369 ns | 32.09x slower |   0.41x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,413.31 ns |  7.546 ns |  6.689 ns | 17.90x slower |   0.12x | 0.3624 |     760 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   359.90 ns |  3.843 ns |  3.595 ns |  4.56x slower |   0.06x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   201.02 ns |  0.899 ns |  0.797 ns |  2.55x slower |   0.03x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   346.39 ns |  1.242 ns |  1.162 ns |  4.39x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   230.91 ns |  0.399 ns |  0.354 ns |  2.93x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   584.32 ns |  6.154 ns |  5.455 ns |  7.40x slower |   0.09x | 0.3090 |     648 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   158.99 ns |  0.535 ns |  0.501 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   245.58 ns |  1.743 ns |  1.631 ns |  1.54x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,191.28 ns |  5.045 ns |  4.472 ns |  7.49x slower |   0.03x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   653.99 ns |  4.240 ns |  3.541 ns |  4.11x slower |   0.03x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   775.60 ns |  3.732 ns |  3.309 ns |  4.88x slower |   0.02x | 0.4473 |     936 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,379.13 ns | 27.389 ns | 25.620 ns |  8.67x slower |   0.17x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,766.60 ns | 15.609 ns | 13.035 ns | 17.40x slower |   0.10x | 4.1809 |   8,752 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,121.85 ns |  7.607 ns |  6.352 ns | 13.35x slower |   0.06x | 0.3624 |     760 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   746.83 ns |  7.894 ns |  7.384 ns |  4.70x slower |   0.05x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   211.01 ns |  1.213 ns |  1.075 ns |  1.33x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   545.21 ns |  2.692 ns |  2.387 ns |  3.43x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   245.47 ns |  0.766 ns |  0.679 ns |  1.54x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   755.58 ns |  5.225 ns |  4.363 ns |  4.75x slower |   0.04x | 0.3090 |     648 B |
