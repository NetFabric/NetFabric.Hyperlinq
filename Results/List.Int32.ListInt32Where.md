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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    78.01 ns |  0.353 ns |  0.313 ns |    77.96 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   174.53 ns |  0.600 ns |  0.561 ns |   174.53 ns |  2.24x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   689.33 ns |  3.340 ns |  2.961 ns |   688.94 ns |  8.84x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   440.13 ns |  3.770 ns |  3.526 ns |   438.81 ns |  5.64x slower |   0.04x | 0.3095 |     648 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   651.17 ns |  3.304 ns |  3.090 ns |   649.74 ns |  8.35x slower |   0.04x | 0.3328 |     696 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   947.78 ns |  2.322 ns |  2.058 ns |   948.00 ns | 12.15x slower |   0.07x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,693.32 ns | 24.288 ns | 21.531 ns | 2,689.06 ns | 34.53x slower |   0.30x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,706.18 ns |  8.378 ns |  7.837 ns | 1,705.43 ns | 21.88x slower |   0.12x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   352.36 ns |  6.792 ns |  6.670 ns |   353.59 ns |  4.53x slower |   0.09x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   184.24 ns |  1.810 ns |  1.604 ns |   184.53 ns |  2.36x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   303.17 ns |  5.820 ns |  5.444 ns |   304.26 ns |  3.89x slower |   0.08x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   223.56 ns |  0.545 ns |  0.510 ns |   223.46 ns |  2.87x slower |   0.01x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   500.94 ns |  3.223 ns |  2.691 ns |   500.02 ns |  6.42x slower |   0.04x | 0.3090 |     648 B |
|                          |               |                                                                        |               |       |             |           |           |             |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    93.63 ns |  0.530 ns |  0.496 ns |    93.43 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   125.99 ns |  0.636 ns |  0.595 ns |   125.85 ns |  1.35x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   653.54 ns |  5.159 ns |  4.573 ns |   653.53 ns |  6.98x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   465.12 ns |  3.008 ns |  2.667 ns |   464.53 ns |  4.97x slower |   0.05x | 0.3095 |     648 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   418.15 ns |  2.327 ns |  2.176 ns |   417.59 ns |  4.47x slower |   0.02x | 0.3328 |     696 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   445.34 ns |  5.870 ns |  5.490 ns |   445.97 ns |  4.76x slower |   0.06x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,583.44 ns | 29.134 ns | 25.827 ns | 2,585.30 ns | 27.59x slower |   0.33x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,155.41 ns |  9.417 ns |  8.348 ns | 1,151.29 ns | 12.34x slower |   0.09x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   368.20 ns |  7.244 ns |  8.897 ns |   366.57 ns |  3.93x slower |   0.12x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   181.55 ns |  0.584 ns |  0.517 ns |   181.60 ns |  1.94x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   348.75 ns |  6.672 ns |  7.139 ns |   348.20 ns |  3.73x slower |   0.08x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   225.12 ns |  0.603 ns |  0.534 ns |   224.98 ns |  2.40x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   464.46 ns |  2.116 ns |  1.876 ns |   463.46 ns |  4.96x slower |   0.03x | 0.3095 |     648 B |
|                          |               |                                                                        |               |       |             |           |           |             |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   105.90 ns |  0.692 ns |  0.614 ns |   105.82 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   249.63 ns |  0.557 ns |  0.435 ns |   249.47 ns |  2.36x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   858.49 ns |  3.139 ns |  2.783 ns |   859.04 ns |  8.11x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   588.76 ns |  8.082 ns |  7.559 ns |   585.56 ns |  5.56x slower |   0.08x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   726.09 ns |  6.549 ns |  6.126 ns |   725.22 ns |  6.85x slower |   0.09x | 0.3328 |     696 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,060.79 ns | 20.902 ns | 33.752 ns | 1,044.93 ns | 10.18x slower |   0.31x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,804.44 ns | 22.599 ns | 20.034 ns | 2,799.91 ns | 26.48x slower |   0.25x | 4.1809 |   8,754 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1,974.93 ns |  8.403 ns |  7.449 ns | 1,972.34 ns | 18.65x slower |   0.14x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   426.31 ns |  1.733 ns |  1.536 ns |   426.31 ns |  4.03x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   193.52 ns |  2.649 ns |  2.478 ns |   193.07 ns |  1.83x slower |   0.03x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   430.92 ns |  2.889 ns |  2.561 ns |   431.40 ns |  4.07x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   232.33 ns |  0.515 ns |  0.457 ns |   232.21 ns |  2.19x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   638.19 ns |  4.648 ns |  3.881 ns |   636.85 ns |  6.03x slower |   0.03x | 0.3090 |     648 B |
