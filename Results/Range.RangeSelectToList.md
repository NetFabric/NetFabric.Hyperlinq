## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 365.05 ns |  4.254 ns |  3.979 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 331.95 ns |  2.177 ns |  1.930 ns | 1.10x faster |   0.01x | 0.2599 |     544 B |
|                   LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 393.60 ns |  5.783 ns |  5.126 ns | 1.08x slower |   0.02x | 0.6232 |   1,304 B |
|                       LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 571.97 ns |  5.089 ns |  4.250 ns | 1.57x slower |   0.02x | 0.5655 |   1,184 B |
|                   StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 274.36 ns |  1.976 ns |  1.848 ns | 1.33x faster |   0.02x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 118.95 ns |  0.307 ns |  0.239 ns | 3.06x faster |   0.03x | 0.2179 |     456 B |
|                    Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 307.52 ns |  0.825 ns |  0.644 ns | 1.18x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 151.40 ns |  1.032 ns |  0.965 ns | 2.41x faster |   0.03x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 108.16 ns |  0.625 ns |  0.585 ns | 3.38x faster |   0.04x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  74.48 ns |  0.394 ns |  0.329 ns | 4.90x faster |   0.07x | 0.2180 |     456 B |
|                              |               |                                                                        |               |       |       |           |           |           |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 325.35 ns |  2.526 ns |  2.363 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 343.95 ns |  2.124 ns |  1.986 ns | 1.06x slower |   0.01x | 0.2599 |     544 B |
|                   LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 417.39 ns |  2.005 ns |  1.675 ns | 1.28x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 545.26 ns |  4.271 ns |  3.995 ns | 1.68x slower |   0.02x | 0.5655 |   1,184 B |
|                   StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 268.54 ns |  2.727 ns |  2.551 ns | 1.21x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 119.52 ns |  1.658 ns |  1.470 ns | 2.72x faster |   0.04x | 0.2179 |     456 B |
|                    Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 269.14 ns |  2.551 ns |  2.387 ns | 1.21x faster |   0.02x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 152.45 ns |  1.397 ns |  1.307 ns | 2.13x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 107.79 ns |  0.971 ns |  0.861 ns | 3.02x faster |   0.04x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  76.31 ns |  0.681 ns |  0.637 ns | 4.26x faster |   0.05x | 0.2180 |     456 B |
|                              |               |                                                                        |               |       |       |           |           |           |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 356.29 ns |  2.724 ns |  2.548 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 316.96 ns |  1.626 ns |  1.442 ns | 1.12x faster |   0.01x | 0.2599 |     544 B |
|                   LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 401.36 ns |  8.010 ns |  9.836 ns | 1.13x slower |   0.03x | 0.6232 |   1,304 B |
|                       LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 886.48 ns | 12.278 ns | 10.884 ns | 2.49x slower |   0.04x | 0.5655 |   1,184 B |
|                   StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 353.41 ns |  1.747 ns |  1.634 ns | 1.01x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 134.50 ns |  1.156 ns |  1.082 ns | 2.65x faster |   0.03x | 0.2179 |     456 B |
|                    Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 347.57 ns |  2.697 ns |  2.523 ns | 1.03x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 268.57 ns |  2.130 ns |  1.993 ns | 1.33x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 240.75 ns |  0.989 ns |  0.826 ns | 1.48x faster |   0.01x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 222.42 ns |  1.491 ns |  1.394 ns | 1.60x faster |   0.01x | 0.2179 |     456 B |
