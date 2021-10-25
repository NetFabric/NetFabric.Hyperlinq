## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    77.77 ns |  0.486 ns |  0.431 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   177.01 ns |  1.145 ns |  1.071 ns |  2.28x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   982.79 ns |  3.956 ns |  3.304 ns | 12.64x slower |   0.07x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   460.67 ns |  2.406 ns |  2.009 ns |  5.92x slower |   0.04x | 0.2179 |     456 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   821.25 ns |  5.165 ns |  4.831 ns | 10.56x slower |   0.10x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   469.92 ns |  3.404 ns |  2.843 ns |  6.04x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2,867.93 ns | 27.049 ns | 25.301 ns | 36.90x slower |   0.33x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1,851.59 ns |  9.085 ns |  8.054 ns | 23.81x slower |   0.16x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   227.78 ns |  1.318 ns |  1.232 ns |  2.93x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   175.99 ns |  0.526 ns |  0.492 ns |  2.26x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   228.68 ns |  0.925 ns |  0.820 ns |  2.94x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   191.71 ns |  0.607 ns |  0.568 ns |  2.47x slower |   0.02x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |   625.32 ns |  6.148 ns |  5.134 ns |  8.04x slower |   0.09x | 0.5655 |   1,184 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    79.53 ns |  1.159 ns |  1.084 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   149.27 ns |  0.527 ns |  0.493 ns |  1.88x slower |   0.03x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   412.62 ns |  1.716 ns |  1.521 ns |  5.20x slower |   0.06x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   369.86 ns |  3.331 ns |  2.953 ns |  4.66x slower |   0.07x | 0.2179 |     456 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   438.64 ns |  4.702 ns |  4.399 ns |  5.52x slower |   0.11x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   359.35 ns |  1.147 ns |  0.958 ns |  4.53x slower |   0.06x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2,575.96 ns | 23.383 ns | 19.526 ns | 32.45x slower |   0.42x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1,488.83 ns |  9.469 ns |  8.857 ns | 18.72x slower |   0.30x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   226.14 ns |  1.341 ns |  1.189 ns |  2.85x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   177.70 ns |  0.590 ns |  0.552 ns |  2.23x slower |   0.03x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   227.43 ns |  0.857 ns |  0.802 ns |  2.86x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   201.59 ns |  0.503 ns |  0.471 ns |  2.54x slower |   0.03x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |   550.21 ns |  4.418 ns |  4.133 ns |  6.92x slower |   0.11x | 0.5655 |   1,184 B |
|                          |               |                                                                        |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   113.54 ns |  0.429 ns |  0.359 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   238.60 ns |  0.608 ns |  0.508 ns |  2.10x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   849.71 ns |  3.366 ns |  3.149 ns |  7.48x slower |   0.03x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   634.52 ns |  2.810 ns |  2.491 ns |  5.59x slower |   0.02x | 0.2174 |     456 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   820.04 ns |  5.401 ns |  4.788 ns |  7.22x slower |   0.05x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   965.92 ns |  1.891 ns |  1.476 ns |  8.51x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,947.32 ns | 28.350 ns | 26.518 ns | 25.93x slower |   0.24x | 4.2725 |   8,938 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2,016.00 ns |  6.032 ns |  4.709 ns | 17.75x slower |   0.08x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   288.29 ns |  1.768 ns |  1.654 ns |  2.54x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   190.21 ns |  0.904 ns |  0.846 ns |  1.67x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   313.06 ns |  1.741 ns |  1.454 ns |  2.76x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   207.21 ns |  0.890 ns |  0.832 ns |  1.83x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |   758.21 ns |  5.992 ns |  5.312 ns |  6.68x slower |   0.06x | 0.5655 |   1,184 B |
