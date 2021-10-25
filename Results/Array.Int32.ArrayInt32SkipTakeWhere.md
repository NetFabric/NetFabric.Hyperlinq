## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    74.88 ns |  0.377 ns |  0.334 ns |       baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 1,728.67 ns | 12.668 ns | 11.230 ns |  23.09x slower |   0.20x | 0.0725 |     152 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   432.20 ns |  3.255 ns |  3.045 ns |   5.77x slower |   0.04x | 0.7191 |   1,504 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   680.90 ns |  5.974 ns |  5.296 ns |   9.09x slower |   0.09x | 0.3281 |     688 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 3,109.37 ns | 15.890 ns | 14.086 ns |  41.53x slower |   0.31x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 2,726.28 ns | 25.043 ns | 23.425 ns |  36.44x slower |   0.39x | 4.1389 |   8,674 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   312.72 ns |  1.637 ns |  1.451 ns |   4.18x slower |   0.03x |      - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 8,122.15 ns | 44.934 ns | 35.082 ns | 108.45x slower |   0.86x | 0.4272 |     912 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   358.18 ns |  6.991 ns |  6.866 ns |   4.77x slower |   0.09x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   178.01 ns |  0.644 ns |  0.571 ns |   2.38x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   355.95 ns |  6.947 ns |  8.531 ns |   4.76x slower |   0.11x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |   238.84 ns |  0.724 ns |  0.677 ns |   3.19x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    74.65 ns |  0.350 ns |  0.328 ns |       baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 1,021.74 ns |  5.139 ns |  4.556 ns |  13.69x slower |   0.10x | 0.0725 |     152 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   418.32 ns |  3.360 ns |  3.143 ns |   5.60x slower |   0.05x | 0.7191 |   1,504 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   470.51 ns |  4.350 ns |  3.857 ns |   6.31x slower |   0.06x | 0.3281 |     688 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,730.99 ns | 17.649 ns | 14.737 ns |  36.59x slower |   0.24x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 2,537.04 ns | 24.114 ns | 22.556 ns |  33.99x slower |   0.37x | 4.1389 |   8,674 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   343.47 ns |  2.469 ns |  2.309 ns |   4.60x slower |   0.03x |      - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 6,187.07 ns | 58.784 ns | 52.110 ns |  82.91x slower |   0.77x | 0.4349 |     912 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   351.20 ns |  5.277 ns |  4.936 ns |   4.70x slower |   0.07x | 0.0458 |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   203.59 ns |  0.565 ns |  0.500 ns |   2.73x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   450.71 ns |  2.828 ns |  2.645 ns |   6.04x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |   238.31 ns |  0.619 ns |  0.579 ns |   3.19x slower |   0.02x |      - |         - |
|                          |               |                                                                        |               |      |       |             |           |           |                |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    75.95 ns |  0.282 ns |  0.250 ns |       baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 1,908.60 ns |  6.195 ns |  5.492 ns |  25.13x slower |   0.13x | 0.0725 |     152 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   437.79 ns |  4.156 ns |  3.471 ns |   5.77x slower |   0.05x | 0.7191 |   1,504 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   675.33 ns |  4.148 ns |  3.880 ns |   8.88x slower |   0.06x | 0.3281 |     688 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 3,358.76 ns |  8.941 ns |  8.363 ns |  44.22x slower |   0.19x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 3,092.77 ns | 45.542 ns | 42.600 ns |  40.76x slower |   0.52x | 4.1580 |   8,704 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   510.09 ns |  3.699 ns |  3.460 ns |   6.72x slower |   0.05x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 8,251.15 ns | 20.459 ns | 17.084 ns | 108.70x slower |   0.40x | 0.4272 |     912 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   672.41 ns |  8.059 ns |  7.538 ns |   8.86x slower |   0.11x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   186.03 ns |  0.900 ns |  0.798 ns |   2.45x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   394.73 ns |  3.912 ns |  3.468 ns |   5.20x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |   256.41 ns |  0.950 ns |  0.888 ns |   3.38x slower |   0.02x |      - |         - |
