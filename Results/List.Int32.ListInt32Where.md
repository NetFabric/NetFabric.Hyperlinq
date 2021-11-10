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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    92.88 ns |  0.071 ns |  0.063 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   168.50 ns |  0.233 ns |  0.182 ns |  1.81x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   685.53 ns |  2.867 ns |  2.682 ns |  7.38x slower |   0.03x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   490.25 ns |  0.426 ns |  0.378 ns |  5.28x slower |   0.00x | 0.3090 |     648 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   644.95 ns |  1.538 ns |  1.201 ns |  6.94x slower |   0.01x | 0.3328 |     696 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   941.91 ns |  2.114 ns |  1.874 ns | 10.14x slower |   0.02x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,633.40 ns | 24.940 ns | 23.329 ns | 28.36x slower |   0.26x | 4.1656 |   8,722 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,771.97 ns | 12.496 ns | 11.689 ns | 19.07x slower |   0.12x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   310.06 ns |  6.240 ns |  6.408 ns |  3.34x slower |   0.06x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   180.32 ns |  0.159 ns |  0.133 ns |  1.94x slower |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   307.00 ns |  5.354 ns |  5.008 ns |  3.30x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   222.53 ns |  0.228 ns |  0.190 ns |  2.40x slower |   0.00x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   504.60 ns |  1.056 ns |  0.824 ns |  5.43x slower |   0.01x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    79.03 ns |  0.401 ns |  0.375 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   124.92 ns |  0.176 ns |  0.156 ns |  1.58x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   643.59 ns |  8.241 ns |  7.709 ns |  8.14x slower |   0.09x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   442.18 ns |  0.948 ns |  0.887 ns |  5.60x slower |   0.03x | 0.3095 |     648 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   441.30 ns |  1.580 ns |  1.319 ns |  5.58x slower |   0.03x | 0.3328 |     696 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   467.83 ns |  7.863 ns |  7.355 ns |  5.92x slower |   0.09x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,545.73 ns |  8.025 ns |  7.114 ns | 32.20x slower |   0.20x | 4.1656 |   8,722 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,197.44 ns |  1.964 ns |  1.837 ns | 15.15x slower |   0.08x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   289.74 ns |  5.781 ns |  7.517 ns |  3.67x slower |   0.11x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   182.09 ns |  0.139 ns |  0.116 ns |  2.30x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   320.67 ns |  6.389 ns |  8.746 ns |  4.04x slower |   0.12x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   219.91 ns |  0.526 ns |  0.467 ns |  2.78x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   482.34 ns |  1.061 ns |  0.886 ns |  6.10x slower |   0.03x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   105.11 ns |  0.082 ns |  0.073 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   295.49 ns |  0.168 ns |  0.140 ns |  2.81x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   913.53 ns |  4.681 ns |  4.379 ns |  8.69x slower |   0.04x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   570.09 ns |  0.884 ns |  0.690 ns |  5.42x slower |   0.01x | 0.3090 |     648 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   624.43 ns |  1.411 ns |  1.320 ns |  5.94x slower |   0.01x | 0.3328 |     696 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   990.28 ns |  2.529 ns |  2.366 ns |  9.42x slower |   0.02x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,733.46 ns | 16.587 ns | 13.851 ns | 26.01x slower |   0.14x | 4.1809 |   8,752 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,908.04 ns | 12.468 ns | 11.663 ns | 18.15x slower |   0.11x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   497.99 ns |  5.843 ns |  5.180 ns |  4.74x slower |   0.05x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   187.40 ns |  0.094 ns |  0.078 ns |  1.78x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   389.30 ns |  5.732 ns |  5.081 ns |  3.70x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   230.68 ns |  0.292 ns |  0.273 ns |  2.19x slower |   0.00x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   599.59 ns |  1.184 ns |  1.050 ns |  5.70x slower |   0.01x | 0.3090 |     648 B |
